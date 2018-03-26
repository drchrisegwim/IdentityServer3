using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace IdentityServerClient
{
   
    class Program
    {
        static TokenResponse GetClientToken()
        {
            var client = new TokenClient(
                "http://localhost:59377/connect/token",
                "silicon",
                "F621F470-9731-4A25-80EF-67A6F7C5F4B8");

            return client.RequestClientCredentialsAsync("api1").Result;
        }

        static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            Console.WriteLine(client.GetStringAsync("http://localhost:14869/test").Result);
        }
        static void Main(string[] args)
        {
            CallApi(GetClientToken());

            Console.ReadLine();
        }
    }
}
