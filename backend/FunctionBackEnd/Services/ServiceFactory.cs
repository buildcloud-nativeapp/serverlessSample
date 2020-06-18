namespace ServerlessSample.FunctionBackEnd.Services
{
    public static class ServiceFactory
    {
        private static ISettingService _settingService = null;
        private static IPersistenceService _persistenceService = null;

        public static ISettingService GetSettingService()
        {
            if (_settingService == null)
            _settingService = new SettingService();

            return _settingService;
        }

        public static IPersistenceService GetPersistenceService()
        {
            if (_persistenceService == null)
            {
                _persistenceService = new CosmosPersistenceService(GetSettingService());
            }

            return _persistenceService;
        }
    }
}
