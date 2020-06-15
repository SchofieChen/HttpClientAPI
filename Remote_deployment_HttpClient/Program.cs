using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Remote_deployment_HttpClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {

                var headers = new Dictionary<string, string> { { "filename", "LED" } };

                client.BaseAddress = new Uri("http://127.0.0.1:80/test");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("ip", "10.192.242.159");
                client.DefaultRequestHeaders.Add("mac", "e0:7d:ea:75:c8:25");
                client.DefaultRequestHeaders.Add("file", "LED.bin");
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("filename:LED"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("http://127.0.0.1:80/test");
                if (response.IsSuccessStatusCode)
                {
                    int a = 0;
                }
                Console.WriteLine(response.Content.Headers);
                Console.ReadLine();

            }


        }

    }

}