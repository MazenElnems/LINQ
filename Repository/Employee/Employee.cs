using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repository.Employee
{
    public class Employee
    {
        public int SSN { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public DateTime? HDate { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public decimal? Salary { get; set; }
        public int? SupperSSN { get; set; }
        public int? DepartmentId { get; set; }

        public List<string> Skills { get; set; }

        //public int CompareTo(Employee? other)
        //{
        //    if (this.Salary > other.Salary) return 1;
        //    else if(this.Salary < other.Salary) return -1;
        //    else return 0;
        //}

        public override string ToString()
        {
            return String.Format(
                $"{SSN,-10}" +                            
                $"{String.Concat(FName, " ", LName),-30}" +  
                $"{Salary,-10}" +
                $"{DepartmentId,-10}" +
                $"[{String.Join(", ", Skills)}]"           
            ) ;

        }
        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            } 

            Employee? other = obj as Employee;
            return this.SSN.Equals(other!.SSN);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.SSN);
        }
    }
}
