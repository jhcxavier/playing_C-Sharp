using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {


            var book = new Book("Joao's Book");
            book.AddGrade(98.9);
            book.AddGrade(90.5);
            book.AddGrade(100.0);

            // var numbers = new [] {12.7, 52.1, 11.5};
            var grades = new List<double>() {12.7, 52.1, 11.5};
            grades.Add(100.01);
            var str = "test";
            var test = 0.0;
            var highest = double.MinValue;
            var lowest = double.MaxValue;
            // var arr = new List<double>(){};
            foreach(double e in grades)
            {
                test += e;
                if(e > highest){
                    highest = e;
                }
                lowest = Math.Min(e, lowest);
            }
            System.Console.WriteLine($"The lowest grade  is {lowest}");
            System.Console.WriteLine($"The higher score is {highest}");
            test /= grades.Count;
            // Console.WriteLine(grades);
            // System.Console.WriteLine(arr);
            Console.WriteLine($"The avarage grade is {test:N1}");
        }
    };

    
}
