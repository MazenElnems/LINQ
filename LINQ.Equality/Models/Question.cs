using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Equality.Models
{
    internal class Question
    {
        public string Title { get; set; }
        public List<Choice> Choices { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != typeof(Question))
                return false;

            if(object.ReferenceEquals(this, obj)) 
                return true;

            Question? other = obj as Question;
            return other!.Title == this.Title && other.Choices.SequenceEqual(this.Choices);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Choices);
        }
    }
}
