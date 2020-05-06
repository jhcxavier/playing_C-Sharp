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
            book.ShowStatistics();
        }
    };
   
}
