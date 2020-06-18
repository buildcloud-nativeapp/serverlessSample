using System;

namespace ServerlessSample.FunctionBackEnd.Services
{
    public class SettingService : ISettingService
    {
        // Cosmos DB
        private const string CosmosDbEndpoint = "CosmosDbEndpoint";
        private const string CosmosDbApiKey = "CosmosDbApiKey";
        private const string CosmosDbDatabaseName = "CosmosDbDatabaseName";
        private const string CosmosDbMainContainerName = "CosmosDbMainContainerName";

        // Cosmos DB
        public string GetCosmosDbEndpoint()
        {
            return GetEnvironmentVariable(CosmosDbEndpoint);
        }

        public string GetCosmosDbApiKey()
        {
            return GetEnvironmentVariable(CosmosDbApiKey);
        }

        public string GetCosmosDbDatabaseName()
        {
            return GetEnvironmentVariable(CosmosDbDatabaseName);
        }
        
        public string GetCosmosDbMainContainerName()
        {
            return GetEnvironmentVariable(CosmosDbMainContainerName);
        }

        //*** PRIVATE ***//
        private static string GetEnvironmentVariable(string name)
        {
            return System.Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
    }
}
