using System.ServiceModel;

// КОНТРАКТ.

namespace Server
{
    [ServiceContract]
    interface IContract //Предоставляемый контракт
    {
        [OperationContract]
        string Say(string input);
    }
}
