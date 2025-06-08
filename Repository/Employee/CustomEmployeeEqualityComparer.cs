using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Employee
{
    public class CustomEmployeeEqualityComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee? x, Employee? y)
        {
            if(x == null || y == null)
            {
                return false;
            }
            if(object.ReferenceEquals(x, y))
            {
                return true;
            }    
            return x.FName == y.FName && x.LName == y.LName;
        }

        public int GetHashCode([DisallowNull] Employee obj)
        {
            return HashCode.Combine(obj.FName, obj.LName);
        }
    }
}
