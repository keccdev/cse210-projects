using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your percentage grade: ");
            double percentage = double.Parse(Console.ReadLine());

            // Qualification statements
            char letterGrade;
            if (percentage >= 90)
                letterGrade = 'A';
            else if (percentage >= 80)
                letterGrade = 'B';
            else if (percentage >= 70)
                letterGrade = 'C';
            else if (percentage >= 60)
                letterGrade = 'D';
            else
                letterGrade = 'F';

             // Determine the sign (+ or -)
        char sign = ' ';
        int lastDigit = (int)(percentage % 10);
        if (lastDigit >= 7)
            sign = '+';
        else if (lastDigit < 3)
            sign = '-';

            // Print the letter grade
            Console.WriteLine($"Your letter grade is: {letterGrade}{sign}");

            // Check if the student passed the course
            if (percentage >= 70)
                Console.WriteLine("Congratulations! You passed the course.");
            else
                Console.WriteLine("Keep working hard for next time.");
    }
}