using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<double> numberList = new List<double>();
            double inputNumber;

            Console.WriteLine("Enter a list of numbers, type 0 when finished.");

            do
            {
                Console.Write("Enter number: ");
                if (double.TryParse(Console.ReadLine(), out inputNumber))
                {
                    if (inputNumber != 0)
                    {
                        numberList.Add(inputNumber);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            } while (inputNumber != 0);

            // Calculate sum
            double sum = numberList.Sum();

            // Calculate average
            double average = sum / numberList.Count;

            // Find the largest number
            double largestNumber = numberList.Max();

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {largestNumber}");

            // Stretch challenge: Find the smallest positive number
            var positiveNumbers = numberList.Where(n => n > 0);
            double smallestPositiveNumber = positiveNumbers.DefaultIfEmpty(double.MaxValue).Min();
            Console.WriteLine($"The smallest positive number is: {smallestPositiveNumber}");

            // Stretch challenge: Sort and display the list
            numberList.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (var number in numberList)
            {
                Console.WriteLine(number);
            }
    }
}
