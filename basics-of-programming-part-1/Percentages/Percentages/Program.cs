using System;
using System.Linq;

namespace Percentages
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Calculate(Console.ReadLine()));
        }

        private static double Calculate(string userInput)
        {
            var read = userInput.Split(' ').Select(double.Parse).ToArray();
            var principal = read[0];
            var percentageRate = read[1];
            var termMonths = read[2];
            return principal * Math.Pow(1 + percentageRate / (100 * 12), termMonths);
        }
    }
}