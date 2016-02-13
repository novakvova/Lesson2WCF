using System;
using System.ServiceModel;

namespace ServiceLibrary
{
    [ServiceContract]
    interface IContract
    {
        [OperationContract]
        string Method(string s);
    }

    public class MyService : IContract
    {
        public string Method(string s)
        {
            return s + " WAS/IIS7";
        }
    }
}
