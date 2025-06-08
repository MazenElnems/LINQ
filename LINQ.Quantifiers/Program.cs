using Repository.Car;
using Repository.Employee;

namespace LINQ.Quantifiers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Quantifiers 

            // all Quantifiers returns boolean
            // all Quantifier operators are immediate execution.


            // Data Sources
            var cars = CarRepository.LoadCars();
            var employees = EmployeeRepository.LoadEmployees();


            #region Any

            // it checks the condition and once condition it true it terminates and return
            // true otherwise it returns false.

            // Complexity : O(n)


            // check if there is any car produced before 1990
            bool r1 = cars.Any(c => c.Year < 1990);
            Console.WriteLine($"check if there is any car produced before 1990 : {r1}");

            Sep();
            // it can be used as a part of condition of another query

            // get all employees that have C# as skill in their skills set.
            IEnumerable<Employee> r2 = employees.Where(e => e.Skills.Any(s => s.ToLower() == "c#"));
            r2.Print();


            Sep();
            IEnumerable<Employee> r3 = from e in employees
                                       where e.Skills.Any(s => s.ToLower() == "c#")
                                       select e;
            #endregion

            #region All
            // it check if all elements satisfy the condition 
            // Complexity : O(n)

            // check if all cars produced after 1950
            bool r4 = cars.All(c => c.Year >= 1980);
            Console.WriteLine($"check if all cars produced after 1980 : {r4}");

            Sep();

            // also it can be used as a part of condition

            // get employees that has all skills of greater than 3 character only
            var r5 = employees.Where(e => e.Skills.All(s => s.Length > 3));
            r5.Print();

            Sep();

            var r6 = from e in employees
                     where e.Skills.All(s => s.Length > 3)
                     select e;
            r6.Print();

            Sep();
            #endregion

            #region Contains
            // it return true if the given element in the sequence otherwise false.

            // Complexity : O(n) in case of List or array
            // Complexity : O(1) in case of HashTable storing 

            // Overloads
            // T value
            // T value , IEqualityComparer comparer

            Employee employee1 = new Employee
            {
                SSN = 1002,
                FName = "Cochran",
                LName = "Cole",
                HDate = new DateTime(2017, 11, 2),
                Gender = "male",
                Salary = 315800m,
                DepartmentId = 101,
            };

            bool r7 = employees.Contains(employee1);
            Console.WriteLine($"is this employee1 exists: {r7}");

            Sep();


            // if you don't want to make equality based on employee.Equals()
            // you can make custom equality using the second overload

            Employee employee2 = new Employee
            {
                SSN = 1002,
                FName = "Sami",
                LName = "Khaled",
                HDate = new DateTime(2017, 11, 2),
                Gender = "male",
                Salary = 315800m,
                DepartmentId = 101,
            };

            bool r8 = employees.Contains(employee2, new CustomEmployeeEqualityComparer());
            Console.WriteLine($"is this employee2 exists: {r8}");

            #endregion

        }



        private static void Sep(string title = "")
        {
            string line = new string('-', 50);
            if (!string.IsNullOrWhiteSpace(title))
            {
                int padding = (50 - title.Length - 2) / 2;
                string paddedTitle = $"{new string('-', padding)} {title} {new string('-', 50 - padding - title.Length - 2)}";
                Console.WriteLine(paddedTitle);
            }
            else
            {
                Console.WriteLine(line);
            }
        }
    }
}

