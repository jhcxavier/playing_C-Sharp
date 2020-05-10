using System;
namespace GradeBook
{
    public class Statistcs
    {
        public double Avarage
        {
            get
            {
                return Sum / Count;
            }
        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch (Avarage)
                {
                    case var d when d >= 90:
                        return 'A';
                    case var d when d >= 80:
                        return 'B';                        
                    case var d when d >= 70:
                        return 'C';
                    case var d when d >= 60:
                        return 'D';        
                    default:
                        return 'F';                  
                }
            }
        }
        public double Sum;
        public int Count;
        public void Add(double number)
        {
            Sum += number;
            Count++;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }
        public Statistcs()
        {
            Count = 0;
            Sum = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;

        }


    }
}