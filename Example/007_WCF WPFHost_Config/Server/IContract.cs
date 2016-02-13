using System.ServiceModel;

// КОНТРАКТ.

namespace Server
{
    [ServiceContract]
    interface IContract
    {
        [OperationContract]
        string Say(string input);
    }
}
