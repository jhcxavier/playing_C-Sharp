using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Joao's Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();
            
            Console.WriteLine($"For the book named {book.Name}");
            System.Console.WriteLine($"The lowest grade  is {stats.Low}");
            System.Console.WriteLine($"The higher score is {stats.High}");
            Console.WriteLine($"The avarage grade is {stats.Avarage:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter:N1}");
        }

        private static void EnterGrades(IBook book)
        {
            var rounds = 1;
            for (var i = 0; i < rounds; i++)
            {
                System.Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                    rounds++;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    rounds++;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    rounds++;
                }
                finally
                {
                    System.Console.WriteLine("**");
                }
            }
            // while(!done)
            // {
            //     System.Console.WriteLine("Enter a grade or 'q' to quit");
            //     var input = Console.ReadLine();
            //     var grade = double.Parse(input);
            //     book.AddGrade(grade);
            // }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added!");
        }
    };
   
}
