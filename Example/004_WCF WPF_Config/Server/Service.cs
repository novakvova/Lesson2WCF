using System;

// СЕРВИС.

namespace Server
{
    class Service : IContract
    {
        public string Say(string input)
        {
            return "From Server: Вы сказали - " + input; 
        }
    }
}
