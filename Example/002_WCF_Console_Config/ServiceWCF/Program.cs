using System;
using System.ServiceModel;

// Использование конфигурационного файла - App.config

namespace ServiceWCF
{
    // КОНТРАКТ.
    [ServiceContract]
    interface IContractService
    {
        [OperationContract]
        double Method(string s);
    }


    // СЕРВИС.
    class MyService : IContractService
    {
        public double Method(string s)
        {
            Console.WriteLine("Обработан запрос. " + s);

            if (s == "double")
                return 777.77;
            else
                return 0;
        }
    }

    // ХОСТ.
    class Service
    {
        static void Main(string[] args)
        {
            Console.Title = "SERVER";

            ServiceHost serviceHost = new ServiceHost(typeof(MyService));

            serviceHost.Open();

            Console.WriteLine("Для завершения нажмите <Any Key>.");
            Console.ReadKey();

            serviceHost.Close();
        }
    }
}
