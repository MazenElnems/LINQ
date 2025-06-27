using LINQ.Concatenation.Models;

namespace LINQ.Concatenation
{
    internal class Program
    {
        public static List<Question> quiz1 = new List<Question>
            {
                new Question
                {
                    Title = "What is Dependency Injection in ASP.NET Core?",
                    Choices = new List<Choice>
                    {
                        new Choice{ Order = 1, Description = "A technique for directly instantiating services" },
                        new Choice{ Order = 2, Description = "A way to hide implementation details" },
                        new Choice{ Order = 3, Description = "A design pattern to manage service lifetimes and decouple components" },
                        new Choice{ Order = 4, Description = "A tool for logging errors" },
                    }
                },
                new Question
                {
                    Title = "Which middleware is used to handle errors globally in ASP.NET Core?",
                    Choices = new List<Choice>
                    {
                        new Choice{ Order = 1, Description = "Routing Middleware" },
                        new Choice{ Order = 2, Description = "Exception Handling Middleware" },
                        new Choice{ Order = 3, Description = "Authorization Middleware" },
                        new Choice{ Order = 4, Description = "Static File Middleware" },
                    }
                },
                new Question
                {
                    Title = "What is the purpose of the `IHostedService` interface in ASP.NET Core?",
                    Choices = new List<Choice>
                    {
                        new Choice{ Order = 1, Description = "To configure HTTP clients" },
                        new Choice{ Order = 2, Description = "To host a web server" },
                        new Choice{ Order = 3, Description = "To run background tasks or services" },
                        new Choice{ Order = 4, Description = "To provide authentication services" },
                    }
                },
            };
        public static List<Question> quiz2 = new List<Question>
            {
                new Question
                {
                    Title = "What does the SQL `JOIN` clause do?",
                    Choices = new List<Choice>
                    {
                        new Choice{ Order = 1, Description = "Deletes rows from a table" },
                        new Choice{ Order = 2, Description = "Combines rows from two or more tables based on a related column" },
                        new Choice{ Order = 3, Description = "Updates data in one table from another" },
                        new Choice{ Order = 4, Description = "Creates a new index on a column" },
                    }
                },
                new Question
                {
                    Title = "What is a PRIMARY KEY in a relational database?",
                    Choices = new List<Choice>
                    {
                        new Choice{ Order = 1, Description = "A column that allows NULL values" },
                        new Choice{ Order = 2, Description = "A column used to store images or files" },
                        new Choice{ Order = 3, Description = "A column that uniquely identifies each row in a table" },
                        new Choice{ Order = 4, Description = "A default sorting column" },
                    }
                },
                new Question
                {
                    Title = "Which SQL statement is used to prevent SQL Injection?",
                    Choices = new List<Choice>
                    {
                        new Choice{ Order = 1, Description = "Using inline queries with user input" },
                        new Choice{ Order = 2, Description = "Using stored procedures and parameterized queries" },
                        new Choice{ Order = 3, Description = "Enabling full table scans" },
                        new Choice{ Order = 4, Description = "Using dynamic SQL generation" },
                    }
                },
            };

        static void Main(string[] args)
        {

            // Concatenation : concat sequences in one sequence and the sequences
            // needs to be of the same type.

            // in LINQ2EF it translated to UNION ALL Not UNION So it removes the duplicates.


            RunConCat01();

            Console.WriteLine();
            Console.WriteLine(" ---------------------------------------- ");
            Console.WriteLine(" ++++++++++++++++++++++++++++++++++++++++ ");
            Console.WriteLine(" ---------------------------------------- ");
            Console.WriteLine();

            RunConCat02();

            Console.WriteLine();
            Console.WriteLine(" ---------------------------------------- ");
            Console.WriteLine(" ++++++++++++++++++++++++++++++++++++++++ ");
            Console.WriteLine(" ---------------------------------------- ");
            Console.WriteLine();

            RunConCat03();
        }


        static void RunConCat01()
        {
            // Concat two quiz in one quiz

            var quiz3 = quiz1.Concat(quiz2);

            foreach (var q in quiz3)
                Console.WriteLine(q);

        }
        static void RunConCat02()
        {
            // Concat part of two sequences.
            var quizTitles = quiz1.Select(q => q.Title).Concat(quiz2.Select(q => q.Title));

            foreach (var title in quizTitles)
            {
                Console.WriteLine(title);
            }
        }
        static void RunConCat03()
        {
            // concat 3 or more sequences
            var firstNames = new List<string> { "John", "Emily", "Michael", "Sarah", "David" };
            var lastNames = new List<string> { "Smith", "Johnson", "Williams", "Brown", "Davis" };
            var middleNames = new List<string> { "James", "Marie", "Lee", "Grace", "Allen" };

            var names = firstNames.Concat(middleNames)
                .Concat(lastNames);

            foreach(var n in names) Console.WriteLine(n);

        }

    }
}
