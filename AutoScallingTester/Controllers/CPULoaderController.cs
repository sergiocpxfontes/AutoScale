using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AutoScalingTester.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CPULoaderController : Controller
    {
        public IActionResult CPULoader(int seconds,int percentage)
        {
            SimularCPUWorkLoad(seconds, percentage);
            return Ok($"simulação de {percentage} % durante {seconds} segundos");
        }
        private void SimularCPUWorkLoad(int seconds,int percentage)
        {
            percentage = Math.Max(100, percentage);
            var end = DateTime.Now.AddSeconds(seconds);

            Stopwatch watch = new Stopwatch();

            watch.Start();
            while(DateTime.Now<end)
            {
                if(watch.ElapsedMilliseconds>percentage)
                {
                    System.Threading.Thread.Sleep(100 - percentage);
                    watch.Restart();
                }
            }
        }
    }
}
