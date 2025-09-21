/*
 EXERCISE #6 MULTIPLICATION TABLE
Write an application named DisplayMultiplicationTable that displays a table 
of the products of every combination of two integers from 1 through 10. (5.1, 5.2, 5.4)

NOTE: You can make the table larger by asking the user for a maximum number! 
I did this for fun :)
 */

using System;

class DisplayMultiplicationTable
{
    static void Main()
    {
        Console.WriteLine("Multiplication Table (1–10) :)");

        /*Violates SRP (Single Responsibility Principle):
        Main is handling input, output, logic, and extra features all at once.
        If we refactored, we could create:
        A method PrintTable()
        A method PracticeQuestion()
        That would apply SRP properly*/

        // Ask the user if they want a custom size table
        Console.Write("Would you like to set a custom table size? (y/n): ");
        string choice = Console.ReadLine();

        int size = 10; // default table size
        if (choice?.ToLower() == "y")
        {
            Console.Write("Enter the maximum number for the table (e.g., 12, 15, etc.): ");
            if (!int.TryParse(Console.ReadLine(), out size) || size < 1)
            {
                Console.WriteLine("Invalid input, using default size 10.");
                size = 10;
            }
        }

        Console.WriteLine($"\nGenerating a {size} x {size} multiplication table...\n");

        // ---- HEADER ROW ----
        Console.Write("    |");
        for (int i = 1; i <= size; i++)
        {
            Console.Write($"{i,4}");
        }
        Console.WriteLine();
        Console.WriteLine("----" + new string('-', 4 * size));

        // ---- TABLE BODY ----
        for (int i = 1; i <= size; i++)
        {
            Console.Write($"{i,3} |");
            for (int j = 1; j <= size; j++)
            {
                Console.Write($"{i * j,4}");
            }
            Console.WriteLine();
        }

        // Fun extra: Ask if the user wants to test themselves :)
        Console.Write("\nWould you like to practice? (y/n): ");
        string practiceChoice = Console.ReadLine();

        if (practiceChoice?.ToLower() == "y")
        {
            Random rand = new Random();
            int a = rand.Next(1, size + 1);
            int b = rand.Next(1, size + 1);

            Console.Write($" Look at the table and tell me.. What is {a} x {b}? ");
            string answerInput = Console.ReadLine();

            if (int.TryParse(answerInput, out int answer))
            {
                if (answer == a * b)
                    Console.WriteLine("Correct! Nice work! You will recieve this happy face ☻");
                else
                    Console.WriteLine($"Oops! Nice try, but The correct answer is {a * b} :D");
            }
            else
            {
                Console.WriteLine("Oops! Not a valid number...");
            }
        }

        Console.WriteLine("\nThanks for using the Multiplication Table app! See you ;)");
    }
}