using Microsoft.Extensions.Hosting;
using System.Net.Http.Headers;

namespace Sceduler
{
    public class Worker : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(1000, stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {

                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44354/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response = await client.GetAsync("api/ApiLoop/start");
                    }
                }
                catch (Exception ex)
                {
                    Log($"{ex.Message}");
                }

                await Task.Delay(600000, stoppingToken);
            }

            Console.ReadLine();
        }

        private void Log(string msg)
        {
            Console.WriteLine($"[{DateTime.UtcNow.ToShortTimeString()}] {msg}");
        }

    }
}


