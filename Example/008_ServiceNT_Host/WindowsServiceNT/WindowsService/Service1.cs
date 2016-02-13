using System.ServiceProcess;
using System.ServiceModel;
using System.ComponentModel;
using System.Configuration.Install;

namespace WindowsServiceNT
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public ProjectInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;

            service = new ServiceInstaller();
            service.ServiceName = "lllll ServiceNT lllll";
            service.Description = "My Service !!!!!!!!!!";
            service.StartType = ServiceStartMode.Automatic;
            
            Installers.Add(process);
            Installers.Add(service);
        }
    }

    public partial class Service1 : ServiceBase
    {
        // Ссылка на экземпляр ServiceHost.
        ServiceHost service = null;

        public Service1() 
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (service == null)
            {
                // Создание экземпляра ServiceHost.
                service = new ServiceHost(typeof(Service));
                // Начало ожидания прихода сообщений.
                service.Open();
            }
        }

        protected override void OnStop()
        {
            if (service != null)
            {
                // Завершение ожидания прихода сообщений.
                service.Close();               
            }
        }
    }

    //********************************************************************************************    
    [ServiceContract]
    interface IContract                                                  // КОНТРАКТ.
    {
        [OperationContract]
        string Say(string input);
    }

    class Service : IContract                                            // СЕРВИС.
    {
        public string Say(string input)
        {
            return "From Server: Вы сказали - " + input;
        }
    }
    //********************************************************************************************
}
