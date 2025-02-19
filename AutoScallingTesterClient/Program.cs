using Newtonsoft.Json;
using System;
using System.Net;

namespace AutoScallingTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A iniciar");
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    Console.WriteLine(DateTime.Now.ToString("mm:ss") +  " - " + args[0] + "/api/CPULoader?percentage=70&seconds=80");
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.BaseAddress = args[0];
                        //webClient.BaseAddress = "http://localhost:80";
                        var json = webClient.DownloadString("/api/CPULoader?percentage=85&seconds=80");
                    }
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("Concluído");
            Console.ReadLine();
        }

    }
}
