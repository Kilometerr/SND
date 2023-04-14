using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SndAPI.Services
{
    public class RepeatingService : BackgroundService
    {
        private readonly PeriodicTimer _timer = new(TimeSpan.FromMilliseconds(1000));

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (await _timer.WaitForNextTickAsync(stoppingToken)&& !stoppingToken.IsCancellationRequested){
                await DoWorkAsync();
            }
        }

        private static async Task DoWorkAsync(){
            Console.WriteLine(DateTime.Now.ToString("O"));
        }
    }
}