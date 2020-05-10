using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    // public delegate void GradeAddedDelegate
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    
    public interface IBook
    {
        void AddGrade(double grade);
        Statistcs GetStatistics();
                  
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
   public abstract class Book : NamedObject, IBook
   {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistcs GetStatistics();
    }
    
    public class InMemoryBook : Book
    //if you do not specify the access modifier, this class will be accessed just in this project 
    //which will be "internal class Book"
    // if we want to expose the class for the unit test we need to use "public class Book"
    // This is because the unit testing is outside src folder, in a different project (Good pratice)
    {
        public InMemoryBook(string name) : base(name)
        {
            category = "";
            grades = new List<double>();
            Name = name;
        }
        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
                //...
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
            
        }
        public override event GradeAddedDelegate GradeAdded;
        public  override Statistcs GetStatistics()
        // we use the class identifier Statistics. So this is a public method named GetStatistics, and its return type, 
        // that is the type of object is going to return, is Statitics.
        {
            var result = new Statistcs();
            
            // var arr = new List<double>(){};
            
            for(var index = 0; index < grades.Count; index++)
            {
                result.Add(grades[index]);                 
            }
            return result; 
        }

        public List<double> grades;

        private string name;
        
        readonly string category = "Science";
    }
}