using System;

namespace WeatherClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
    }
}
