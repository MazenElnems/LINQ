using Repository.Employee;

namespace LINQ.Join
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = EmployeeRepository.LoadEmployees();
            var departments = EmployeeRepository.LoadDepartments();

            #region Join - Method Syntax

            // LINQ2SQL => it execute INNER JOIN

            var employeeDepartments = employees
                .Join(departments, e => e.DepartmentId, d => d.DepartmentId, (e, d) => new
                {
                    EmployeeName = e.FName + " " + e.LName,
                    Department = d.DepartmentName
                });

            foreach (var item in employeeDepartments)
            {
                Console.WriteLine(item);
            }

            Sep();
            #endregion

            #region Join - Query Syntax
            var employeeDepartments2 = from e in employees
                                         join d in departments
                                         on e.DepartmentId equals d.DepartmentId
                                         select new
                                         {
                                             EmployeeName = e.FName + " " + e.LName,
                                             Department = d.DepartmentName
                                         };

            foreach (var item in employeeDepartments2)
            {
                Console.WriteLine(item);
            }
            Sep();

            #endregion

            #region GroupJoin - Method Syntax
            var employeeByDepartments = departments
                .GroupJoin(employees, d => d.DepartmentId, e => e.DepartmentId,
                (d, emps) => new
                {
                    Key = d.DepartmentName,
                    Value = emps
                });

            foreach (var item in employeeByDepartments)
            {
                Console.WriteLine(item.Key);
                foreach (var e in item.Value)   
                {
                    Console.WriteLine("++++++++++ "+e.FName + " " + e.LName);
                }
            }
            Sep();
            #endregion

            #region GroupJoin - Query Syntax

            var employeeByDepartments2 = from d in departments
                                         join e in employees
                                         on d.DepartmentId equals e.DepartmentId
                                         group e by d.DepartmentName;

            foreach (var item in employeeByDepartments2)
            {
                Console.WriteLine(item.Key);
                foreach (var e in item)
                {
                    Console.WriteLine("+++++++++++ " + e.FName + " " + e.LName);
                }
            }

            Sep();  
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
