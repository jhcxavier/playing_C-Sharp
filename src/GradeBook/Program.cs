using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // double x = 31.3;
            // int y = 100;
            // var result = x + y;
            // Console.WriteLine(result);
            // System.Console.WriteLine();

            var numbers = new [] {12.7, 52.1, 11.5};
            // numbers[0] = 12.7;
            // numbers[1] = 52.1;
            // numbers[2] = 11.5;
            var result = new double[0];
            // var result = numbers[0];
            // result += numbers[1];
            // result += numbers[2];
            double test = 0;
            foreach(double e in numbers)
            {
                test += e;
            }
            System.Console.WriteLine(test);

            // System.Console.WriteLine(result);

            



            if(args.Length > 0)
            {
                Console.WriteLine($"Hello, {args[0]}!");
            }
            else 
            {
                Console.WriteLine("Hello");
            }
        }
    };
}
