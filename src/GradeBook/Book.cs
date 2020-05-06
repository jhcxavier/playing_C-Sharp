using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }
        public void ShowStatistics()
        {
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
            Console.WriteLine($"The avarage grade is {test:N1}");
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }
        private List<double> grades;

        

        private string name;
        
    }
}