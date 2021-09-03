using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApplication.Models;

namespace WeatherApplication.DbServices
{
    public interface IWeatherDbService {

        Task InsertDataAsync(WeatherData weatherData);

        Task<IEnumerable<WeatherData>> GetWeatherDatasAsync(DateTime dateTime);

        Task<IEnumerable<WeatherData>> GetAllDataAsync();

    }
    public class WeatherDbService :IWeatherDbService
    {
        private readonly WeatherDbContext db;
        public WeatherDbService(WeatherDbContext context)
        {
            db = context;
        }

        public async Task InsertDataAsync(WeatherData weatherData)
        {
            try
            {
                await db.weatherDatas.AddAsync(weatherData);
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task<IEnumerable<WeatherData>> GetWeatherDatasAsync(DateTime dateTime)
        {
            try
            {
                var data = db.weatherDatas.Where(x => x.time_stamp==dateTime);
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return new List<WeatherData>();
        }

        public async Task<IEnumerable<WeatherData>> GetAllDataAsync()
        {
            try
            {
                var data = await db.weatherDatas.ToListAsync();
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return new List<WeatherData>();
        }

    }
}
