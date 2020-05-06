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
            this.name = name;
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
            foreach(double e in grades)
            {
                result.Avarage += e;
                if(e > result.High){
                    result.High = e;
                }
                result.Low = Math.Min(e, result.Low);
            }
            result.Avarage /= grades.Count;

            return result;
            
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }
        private List<double> grades;

        

        private string name;
        
    }
}