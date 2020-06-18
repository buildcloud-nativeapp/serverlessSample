using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using ServerlessSample.FunctionBackEnd.Models;

namespace ServerlessSample.FunctionBackEnd.Services
{
    public class CosmosPersistenceService : IPersistenceService
    {
        private static CosmosClient _cosmosSingletonClient;

        private ISettingService _settingService;

        public CosmosPersistenceService(ISettingService setting)
        {
            _settingService = setting;
        }

        public async Task<IEnumerable<WeekPlan>> GetWeekPlansAsync(string queryString = "")
        {
            if (queryString == "")
            {
                // Query all data if queryString is empty
                queryString = "SELECT * FROM c"; 
            }

            var container = await GetContainer();
            var query = container.GetItemQueryIterator<WeekPlan>(new QueryDefinition(queryString));
            List<WeekPlan> results = new List<WeekPlan>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task<WeekPlan> GetWeekPlanAsync(string id)
        {
            var container = await GetContainer();
            ItemResponse<WeekPlan> response = await container.ReadItemAsync<WeekPlan>(id, new PartitionKey(id));
            return response.Resource;
        }

        public async Task<WeekPlan> AddWeekPlanAsync(WeekPlan weekPlan)
        {
            var container = await GetContainer();
            return await container.CreateItemAsync<WeekPlan>(weekPlan, new PartitionKey(weekPlan.Id));
        }

        public async Task<WeekPlan> UpdateWeekPlanAsync(string id, WeekPlan weekPlan)
        {
            var container = await GetContainer();
            return await container.UpsertItemAsync<WeekPlan>(weekPlan, new PartitionKey(id));
        }

        public async Task DeleteWeekPlanAsync(string id)
        {
            var container = await GetContainer();
            await container.DeleteItemAsync<WeekPlan>(id, new PartitionKey(id));
        }

        //**** PRIVATE METHODS ****//
        private static async Task<CosmosClient> GetCosmosClient(ISettingService settingService)
        {
            if (_cosmosSingletonClient == null)
            {
                var cosmosDbName = settingService.GetCosmosDbDatabaseName();
                var cosmosDbEndpoint = settingService.GetCosmosDbEndpoint();
                var cosmosDbApiKey = settingService.GetCosmosDbApiKey();
                var cosmosDbContainerName = settingService.GetCosmosDbMainContainerName();

                CosmosClientBuilder clientBuilder = new CosmosClientBuilder(cosmosDbEndpoint, cosmosDbApiKey);
                _cosmosSingletonClient = clientBuilder
                        .WithConnectionModeDirect()
                        .Build();

                //Create Database or Container if they don't exist
                DatabaseResponse database = await _cosmosSingletonClient.CreateDatabaseIfNotExistsAsync(cosmosDbName);
                await database.Database.CreateContainerIfNotExistsAsync(cosmosDbContainerName, "/id");
            }
            return _cosmosSingletonClient;
        }

        private async Task<Container> GetContainer(ISettingService settingService = null)
        {
            if (settingService == null)
                settingService = _settingService;

            var cosmosDbClient = await GetCosmosClient(settingService);
            var container = cosmosDbClient.GetContainer(settingService.GetCosmosDbDatabaseName(), settingService.GetCosmosDbMainContainerName());
            return container;
        }
    }
}
