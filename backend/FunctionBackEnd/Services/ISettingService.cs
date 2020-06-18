namespace ServerlessSample.FunctionBackEnd.Services
{
    public interface ISettingService
    {
        // Cosmos DB
        string GetCosmosDbEndpoint();
        string GetCosmosDbApiKey();
        string GetCosmosDbDatabaseName();
        string GetCosmosDbMainContainerName();
    }
}
