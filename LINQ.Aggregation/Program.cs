using Repository.Car;
using System.Linq;

namespace LINQ.Aggregation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Aggregation : the process of compute a single value from a collection of values.

            // Aggregate() - AggregateBy() - Count() - Sum() - Avg() - Max() - Min() - MaxBy() - MinBy()


            // Aggregate()

            // it takes Func<TSource,TSource,TSource> func : accumulator function
            
            // func(a,b){
            //  a = a + b[0]
            //  return fun(a,next);
            //}

            // AggregateBy()

            // it perform first Grouping by a key selector and then perform a custom aggregation for each group

            RunAggregate01();

            Console.WriteLine();
            Console.WriteLine(" ---------------------------------------- ");
            Console.WriteLine(" ++++++++++++++++++++++++++++++++++++++++ ");
            Console.WriteLine(" ---------------------------------------- ");
            Console.WriteLine();

            RunAggregate02();

            Console.WriteLine();
            Console.WriteLine(" ---------------------------------------- ");
            Console.WriteLine(" ++++++++++++++++++++++++++++++++++++++++ ");
            Console.WriteLine(" ---------------------------------------- ");
            Console.WriteLine();

            RunAggregateBy01();

            Console.WriteLine();
            Console.WriteLine(" ---------------------------------------- ");
            Console.WriteLine(" ++++++++++++++++++++++++++++++++++++++++ ");
            Console.WriteLine(" ---------------------------------------- ");
            Console.WriteLine();

            RunMaxBy();
        }

        public static void RunAggregate01()
        {
            // Get a String of the first character of these list of names.

            Console.WriteLine("\tGet a String of the first character of these list of names\n");

            var names = new string[] { "Mazen" , "Ali" , "Fares" , "Sami" , "Khaled"};

            var teamName = names.Aggregate(string.Empty,(a, b) =>
            {
                a = a + $"{b[0]}";
                return a;
            });

            Console.WriteLine(teamName);
        }

        public static void RunAggregate02() 
        {
            // get longest string

            Console.WriteLine("\tget longest string\n");
            var names = new string[] { "Mazen", "Ali", "Fares", "Mohamed", "Sami", "Khaled" };

            var longestString = names.Aggregate((a, b) => b.Length > a.Length ? b : a);
            Console.WriteLine(longestString);
        }

        public static void RunAggregateBy01() 
        {
            // foreach car make get the total prices

            Console.WriteLine("\tforeach car make get the total prices\n");
            var cars = CarRepository.LoadCars();

            var carsByMake = cars.AggregateBy(
                c => c.Make,
                0M,
                (acc, c) => acc + c.Price
            );

            foreach (var item in carsByMake)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }

        }

        public static void RunMaxBy() 
        {
            // get the car with max price

            // Max 
            // return numeric value or it return TSource if it implement IComparable

            // MaxBy
            // return TSource with max selector

            var cars = CarRepository.LoadCars();

            var maxPrice = cars.Max(c => c.Price);

            var carWithMaxPrice = cars.MaxBy(c => c.Price);

            Console.WriteLine($"Max Price : {maxPrice}");
            Console.WriteLine();
            Console.WriteLine($"Id: {carWithMaxPrice.Id}\n{carWithMaxPrice.Make}\n{carWithMaxPrice.Year}\n{carWithMaxPrice.Price}");
        }

    }
}
