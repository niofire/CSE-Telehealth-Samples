using Microsoft.Azure;
using Microsoft.Practices.Unity;
using Microsoft.SfB.PlatformService.SDK.Samples.ApplicationCore;
using Microsoft.SfB.PlatformService.SDK.Common;

namespace CSETHSamples_TrustedApp
{
    /// <summary>
    /// The Unity Configuration.
    /// </summary>
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            //Register global used interface implementation here
            var container = IOCHelper.DefaultContainer;
            container.RegisterType<IPlatformServiceLogger, AzureDiagnosticLogger>(new ContainerControlledLifetimeManager(),
               new InjectionFactory(c => new AzureDiagnosticLogger()));

            var storageConnectionString = CloudConfigurationManager.GetSetting("Microsoft.Storage.ConnectionString");
            var serviceBusConnectionString = CloudConfigurationManager.GetSetting(Constants.SERVICEBUS_CONNECTION);

            // 1. Uncomment me to enable logging to Azure Storage
            // 2. Add Microsoft.Storage.Connection string to web.config
            // 3. Change the Execute*Async() methods to Execute*AndRecordAsync() in the job handlers

            //container.RegisterType<IStorage, AzureStorage>(
            //           new ContainerControlledLifetimeManager(),
            //      new InjectionFactory(c => AzureStorage.Connect(storageConnectionString)));

            container.RegisterType<ICallbackMessageQueueManager, AzureServiceBusCallbackMessageQueueManager>(
                          new ContainerControlledLifetimeManager(),
               new InjectionFactory(c => new AzureServiceBusCallbackMessageQueueManager(serviceBusConnectionString)));
        }
    }
}