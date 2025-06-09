using Repository.Car;
using Repository.Employee;

namespace Grouping
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cars = CarRepository.LoadCars();
            var employees = EmployeeRepository.LoadEmployees();

            #region GroupBy
            // it groups data based on attribute/feature 
            var carGroups = cars.GroupBy(c => c.Make);

            var carGroups2 = from c in cars
                             group c by c.Make;

            foreach(var group in carGroups2)
            {
                Sep($" < {group.Key} > ");
                group.Print();
                Console.WriteLine();
            }

            #endregion

            #region ToLookUp

            var employeeLookup = employees.ToLookup(e => e.DepartmentId);

            foreach (var items in employeeLookup)
            {
                Sep($" < {items.Key} > ");
                items.Print();
                Console.WriteLine();
            }

            // Fast Access O(1)
            Sep($" < {101} > ");
            var empIn101 = employeeLookup[101];
            foreach (var items in empIn101)
                Console.WriteLine(items);

            #endregion

        }

        private static void Sep(string title = "")
        {
            string line = new string('-', 118);
            if (!string.IsNullOrWhiteSpace(title))
            {
                int padding = (118 - title.Length - 2) / 2;
                string paddedTitle = $"{new string('-', padding)} {title} {new string('-', 118 - padding - title.Length - 2)}";
                Console.WriteLine(paddedTitle);
            }
            else
            {
                Console.WriteLine(line);
            }
        }

    }
}
