using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Equality.Models
{
    internal class Choice
    {
        public int Order { get; set; }
        public string Description { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj == null || obj.GetType() != typeof(Choice))
                return false;
            if(object.ReferenceEquals(this, obj))
                return true; 
            
            Choice? other = obj as Choice;
            return other!.Order == this.Order && other.Description == this.Description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Order, Discription);
        }
    }
}
