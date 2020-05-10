using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    // public delegate void GradeAddedDelegate
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }
    public interface IBook
    {
        void AddGrade(double grade);
        object GetStatistcs();

        Statistcs Statistcs { get; }
        string Name {get;}
        event GradeAddedDelegate GradeAdded;
    }
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistcs GetStatistcs();
    }
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {

        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            File.AppendText($"{Name}.txt");
        }

        public override Statistcs Statistcs
        {
            get;
        }
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
                result.High = Math.Max(grades[index], result.High);
                result.Avarage += grades[index];                
            }
            result.Avarage /= grades.Count;

            switch(result.Avarage)
            {
                case var d when d >= 90:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;

            }

            return result;
            
        }

        public override Statistcs Statistcs => throw new NotImplementedException();

        public List<double> grades;

        private string name;
        
        readonly string category = "Science";
    }
}