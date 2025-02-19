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
                    Console.WriteLine(DateTime.Now.ToString("mm:ss") +  " - /api/CPULoader?percentage=70&seconds=80");
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.BaseAddress = "https://autoscaletest.azurewebsites.net";
                        var json = webClient.DownloadString("/api/CPULoader?percentage=85&seconds=80");
                    }
                }
                catch (WebException ex)
                {
                    throw ex;
                }
            }
            Console.WriteLine("Concluído");
            Console.ReadLine();
        }

    }
}
