using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WeatherApplication.DbServices;
using WeatherApplication.Models;

namespace WeatherApplication.WeatherService
{

    public class WeatherBgService :  IHostedService
    {
        //private readonly IWeatherDbService dbService;
        private HttpClient client = new HttpClient();
        private Timer timer;

        //public WeatherBgService(IWeatherDbService dbService)
        //{
        //    this.dbService = dbService;
        //}

        public Task StartAsync(CancellationToken cancellationToken )
        {

            timer = new Timer(async o =>
            {
                HttpResponseMessage response = client.GetAsync("http://demo4567044.mockable.io/weather").Result;
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<WeatherData>(apiResponse);

                    try
                    {
                        Console.WriteLine($"{data.humidity}");
                        //await dbService.InsertDataAsync(data);
                       

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            },
           null,
           TimeSpan.Zero,
           TimeSpan.FromSeconds(2));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("service stopped");
            return Task.CompletedTask;
        }

    
    }
}
