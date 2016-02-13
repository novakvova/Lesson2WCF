using System;
using System.ServiceModel;

namespace ClientWCF
{
    // КОНТРАКТ.
    [ServiceContract]
    interface IContract
    {
        [OperationContract]
        string Method(string s);
    }
        
    class Service
    {
        static void Main(string[] args)
        {
            ChannelFactory<IContract> factory = 
                new ChannelFactory<IContract>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost/My/MyService.svc"));

            IContract channel = factory.CreateChannel();

            string str = channel.Method("apple");
            Console.WriteLine(str);

            Console.WriteLine("Для завершения нажмите <Any Key>.");
            Console.ReadKey();           
        }
    }
}
