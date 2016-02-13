using System.ServiceModel;

// КОНТРАКТ.

namespace Client
{
    [ServiceContract]
    interface IContract  //Требуемый контракт
    {
        [OperationContract]
        string Say(string input);
    }
}
