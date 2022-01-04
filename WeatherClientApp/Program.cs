using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace WeatherClientApp
{
    class Program
    {
        private static int[] zips = new int[] { 08816, 08536, 08810, 08812, 08817, 08832 };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static async IAsyncEnumerable<MainModel> GetHumidity()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44332/")
            };

            foreach (var zip in zips)
            {
                var response = await client.GetAsync($"weatherforecast?zip={zip}");
                var data = await response.Content.ReadAsStringAsync();
                var weather = JsonConvert.DeserializeObject<WeatherModel>(data);
                weather.Main.Zip = zip;
                yield return weather.Main;
            }
        }
    }

    public class WeatherModel
    {
        public MainModel Main { get; set; }
    }

    public class MainModel
    {
        public decimal Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int Zip { get; set; }
    }
}
