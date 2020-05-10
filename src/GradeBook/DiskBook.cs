using System.IO;
using System;
namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {

        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            string path = $"{Name}.txt";
            using(var writer = File.AppendText(path))
            {
                writer.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            } 
        }

        public override Statistcs GetStatistics()
        {
            var result = new Statistcs();
            string path = $"{Name}.txt";
            using(var reader = File.OpenText(path))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }

            }

            return result;
        }
    }
}