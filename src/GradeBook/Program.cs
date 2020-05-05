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

            var numbers = new double[3];
            numbers[0] = 12.7;
            numbers[1] = 52.1;
            numbers[2] = 11.5;

            var result = numbers[0];
            result = result + numbers[1];
            result = result + numbers[2];
            System.Console.WriteLine(result);





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
