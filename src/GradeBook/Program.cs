using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            var book = new Book("Joao's Book");
=======


            var book = new Book("Joao's Book ");
>>>>>>> b8aea5b40dc503f52277b739229fe9c0eee49550
            book.AddGrade(98.9);
            book.AddGrade(90.5);
            book.AddGrade(100.0);
            book.ShowStatistics();
        }
    };

    
}
