using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherObserver
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("GLOBAL WEATHER OBSERVER");
            Console.WriteLine();

            while (true)
            {
                Console.Write("Enter City Name (or 'exit'): ");
                string city = Console.ReadLine();

                if (city.ToLower() == "exit")
                {
                    break;
                }

                Console.Write("Enter Latitude and Longitude (e.g., 40.71 -74.01): ");
                string input = Console.ReadLine();

                string[] parts = input.Split(' ');

                double lat = double.Parse(parts[0]);
                double lon = double.Parse(parts[1]);

                string url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current=temperature_2m,apparent_temperature,relative_humidity_2m,wind_speed_10m,weather_code";

                using HttpClient client = new HttpClient();

                string json = await client.GetStringAsync(url);

                WeatherResponse weather = JsonSerializer.Deserialize<WeatherResponse>(json);

                double tempC = weather.current.temperature_2m;
                double tempF = (tempC * 1.8) + 32;

                double feelsLikeC = weather.current.apparent_temperature;
                double feelsLikeF = (feelsLikeC * 1.8) + 32;

                int humidity = weather.current.relative_humidity_2m;

                double windKmh = weather.current.wind_speed_10m;
                double windMph = windKmh * 0.621371;

                int code = weather.current.weather_code;
                string condition;

                if (code == 0)
                {
                    condition = "Clear Sky";
                }
                else if (code >= 1 && code <= 3)
                {
                    condition = "Partly Cloudy";
                }
                else if (code >= 61 && code <= 65)
                {
                    condition = "Rainy";
                }
                else if (code >= 71 && code <= 75)
                {
                    condition = "Snowy";
                }
                else
                {
                    condition = "Cloudy";
                }

                Console.WriteLine($"---- Report for {city.ToUpper()} ----");
                Console.WriteLine($"Condition:    {condition}");
                Console.WriteLine($"Actual Temp:  {tempC:F1}°C / {tempF:F1}°F");
                Console.WriteLine($"Feels Like:   {feelsLikeC:F1}°C / {feelsLikeF:F1}°F");
                Console.WriteLine($"Humidity:     {humidity}%");
                Console.WriteLine($"Wind Speed:   {windKmh:F1} km/h / {windMph:F1} mph");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine();
            }
        }
    }

    public class WeatherResponse
    {
        public Current current { get; set; }
    }

    public class Current
    {
        public double temperature_2m { get; set; }
        public double apparent_temperature { get; set; }
        public int relative_humidity_2m { get; set; }
        public double wind_speed_10m { get; set; }
        public int weather_code { get; set; }
    }
}