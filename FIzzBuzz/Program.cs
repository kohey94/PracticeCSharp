using System;
using System.Linq;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = 15;

            for (int i = 1; i <= num; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine("-----");

            Enumerable.Range(1, num)
                .Select(x =>
                    x % 15 == 0 ? "FizzBuzz"
                    : x % 3 == 0 ? "Fizz"
                    : x % 5 == 0 ? "Buzz"
                    : x.ToString())
                .ToList().ForEach(Console.WriteLine);
        }
    }
}