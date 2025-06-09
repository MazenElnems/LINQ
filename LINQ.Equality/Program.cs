using LINQ.Equality.Models;

namespace LINQ.Equality
{
    public class Program
    {
        static void Main(string[] args)
        {
            // SequenceEqual 

            // it first check if the two sequence have the same length
            // and if yes then it check equality of each element in the two sequences by
            // item1.Equals(item2)


            var quiz1 = new List<Question>
            {
                new Question
                {
                    Title = "Question One" ,
                    Choices = new List<Choice>
                    {
                        new Choice{ Order = 1 , Discription = "A"},
                        new Choice{ Order = 2 , Discription = "B"},
                        new Choice{ Order = 3 , Discription = "C"},
                        new Choice{ Order = 4 , Discription = "D"},
                    }
                },
                new Question
                {
                     Title = "Question Two" ,
                    Choices = new List<Choice>
                    {
                        new Choice{ Order = 1 , Discription = "A"},
                        new Choice{ Order = 2 , Discription = "B"},
                        new Choice{ Order = 3 , Discription = "C"},
                        new Choice{ Order = 4 , Discription = "D"},
                    }
                },
                new Question
                {
                    Title = "Question Three" ,
                    Choices = new List<Choice>
                    {
                        new Choice{ Order = 1 , Discription = "A"},
                        new Choice{ Order = 2 , Discription = "B"},
                        new Choice{ Order = 3 , Discription = "C"},
                        new Choice{ Order = 4 , Discription = "D"},
                    }
                },
            };

            var quiz2 = new List<Question>
            {
                new Question
                {
                    Title = "Question One" ,
                    Choices = new List<Choice>
                    {
                        new Choice{ Order = 1 , Discription = "A"},
                        new Choice{ Order = 2 , Discription = "B"},
                        new Choice{ Order = 3 , Discription = "C"},
                        new Choice{ Order = 4 , Discription = "D"},
                    }
                },
                new Question
                {
                     Title = "Question Two" ,
                    Choices = new List<Choice>
                    {
                        new Choice{ Order = 1 , Discription = "A"},
                        new Choice{ Order = 2 , Discription = "B"},
                        new Choice{ Order = 3 , Discription = "C"},
                        new Choice{ Order = 4 , Discription = "D"},
                    }
                },
                new Question
                {
                    Title = "Question Three" ,
                    Choices = new List<Choice>
                    {
                        new Choice{ Order = 1 , Discription = "A"},
                        new Choice{ Order = 2 , Discription = "B"},
                        new Choice{ Order = 3 , Discription = "C"},
                        new Choice{ Order = 4 , Discription = "D"},
                    }
                },
            };


            bool isEqual = quiz1.SequenceEqual(quiz2);

            if(isEqual)
                Console.WriteLine("Quiz#1 and Quiz#2 are equal");

            else
                Console.WriteLine("Quiz#1 and Quiz#2 are not equal");


            // first condition : quiz1.Length == quiz2.Length
            // second condition : quiz1[i].Equals(quiz2[i]) .. [i >= 0 && i < Length]



        }
    }
}
