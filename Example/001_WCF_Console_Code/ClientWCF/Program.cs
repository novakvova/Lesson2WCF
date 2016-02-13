using System;
using System.ServiceModel;

namespace ClientWCF
{
    // КОНТРАКТ.
    [ServiceContract]
    interface IContractService
    {
        [OperationContract]
        double Method(string s);
    }

    // КЛИЕНТ.
    class Client
    {
        static void Main()
        {
            Console.Title = "CLIENT";

            ChannelFactory<IContractService> channelFactory =
                new ChannelFactory<IContractService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:8000/ServiceWCF"));

            IContractService service = channelFactory.CreateChannel(); //Обьектно ориентированное представленние канала

            double digit = service.Method("double"); //Обращение к сервису
            Console.WriteLine("Double: {0}", digit);

            // Задержка.
            Console.WriteLine("Для завершения нажмите <Any Key>.");
            Console.ReadKey();
        }
    }
}
