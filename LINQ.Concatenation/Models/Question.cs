using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Concatenation.Models
{
    internal class Question
    {
        public string Title { get; set; }
        public List<Choice> Choices { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"# Question: {Title}");
            sb.AppendLine(" Choices:");
            foreach (var choice in Choices.OrderBy(c => c.Order))
            {
                sb.AppendLine($"   {choice.Order}. {choice.Description}");
            }
            return sb.ToString();
        }
    }
}
