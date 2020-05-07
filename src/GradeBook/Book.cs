using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    //if you do not specify the access modifier, this class will be accessed just in this project 
    //which will be "internal class Book"
    // if we want to expose the class for the unit test we need to use "public class Book"
    // This is because the unit testing is outside src folder, in a different project (Good pratice)
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }
        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                System.Console.WriteLine("Invalid Value");
            }
            
        }
        public Statistcs GetStatistics()
        // we use the class identifier Statistics. So this is a public method named GetStatistics, and its return type, 
        // that is the type of object is going to return, is Statitics.
        {
            var result = new Statistcs();
            result.Avarage= 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            // var arr = new List<double>(){};
            
            for(var index = 0; index < grades.Count; index++)
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.Low = Math.Max(grades[index], result.High);
                result.Avarage += grades[index];                
            }
            result.Avarage /= grades.Count;

            return result;
            
        }
        
        public List<double> grades;
        public string Name;
        
    }
}