using System.ServiceModel;

// КОНТРАКТ.

namespace Client
{
    [ServiceContract]
    interface IContract
    {
        [OperationContract]
        string Say(string input);
    }
}
