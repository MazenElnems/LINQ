using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository.Car
{
    public static class CarRepository
    {
        // Our Data Source
        public static IEnumerable<Car> LoadCars()
        {
            string path = "D:\\Repository\\DemoLINQ\\Repository\\Cars\\Cars.json";
            IEnumerable<Car>? cars  = JsonSerializer.Deserialize<IEnumerable<Car>>(File.ReadAllText(path),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    }
                );
            return cars!;
        }

        public static void Print(this IEnumerable<Car> cars)
        {
            string line = "+--------------------------------------+----------------+----------------+-------------+------+----------------------+";
            string header = "| Id                                   | Make           | Model          | Price       | Year | VIN                  |";

            Console.WriteLine(line);
            Console.WriteLine(header);
            Console.WriteLine(line);

            foreach (Car car in cars)
            {
                Console.WriteLine(
                    $"| {car.Id,-36} | {Truncate(car.Make, 14),-14} | {Truncate(car.Model, 14),-14} | {car.Price,11:C} | {car.Year,4} | {Truncate(car.VIN, 20),-20} |");
            }

            Console.WriteLine(line);
        }

        private static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength - 1) + "…";
        }
    }
}
