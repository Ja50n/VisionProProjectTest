using GCCA.Utilities.V2.HttpClientManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MVCWebApiClientSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please key-in the words you want display at WebAPI browser page:");
            string userInputString = Console.ReadLine();
            string url = "";
            HttpClientManager httpClientConnector = new HttpClientManager();
            string responseFromWebAPI = httpClientConnector.Post(url, userInputString);
        }
    }
}
