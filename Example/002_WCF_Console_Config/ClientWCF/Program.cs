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

            IContractService proxy = channelFactory.CreateChannel();

            double digit = proxy.Method("double");
            Console.WriteLine("Double: {0}", digit);

            // Задержка.
            Console.WriteLine("Для завершения нажмите <Any Key>.");
            Console.ReadKey();
        }
    }
}
