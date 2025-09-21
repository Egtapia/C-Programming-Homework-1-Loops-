/*Exercise #4 (CHAPTER 5):

Write an application named DailyTemps that continually prompts a user for
a series of daily high temperatures until the user enters a sentinel value. 
Valid temperatures range from –20 through 130 Fahrenheit. When the user enters a 
valid temperature, add it to a total; when the user enters an invalid temperature,
display an error message. Before the program ends, display the number of 
temperatures entered and the average 
temperature. (5.1, 5.5)
*/

using System;

class DailyTemps
{
    static void Main()
    {
        // Accumulators: sum of temperatures and how many were entered
        float tempSum = 0;
        int tempCount = 0;

        string userInput;

        try
        {
            // Keep asking until the user quits
            do
            {
                Console.Write("Enter a temperature ('q' to quit): ");
                userInput = Console.ReadLine();

                // Sentinel value: quit when user types 'q'
                if (userInput == "q")
                    break;

                // Try to convert user input into a number
                if (!float.TryParse(userInput, out float temp))
                {
                    Console.WriteLine("Invalid number, please try again!");
                    continue; // Ask again
                }

                // This validate the temperature range
                if (temp >= -20 && temp <= 130)
                {
                    tempSum += temp; // Add to total
                    tempCount++;     // Increase count
                }
                else
                {
                    Console.WriteLine("Temperature must be between -20 and 130 Fahrenheit.");
                }

            } while (true);

            // Display how many temperatures were entered
            Console.WriteLine($"\nTotal temperatures entered: {tempCount}");

            // Show average if at least one temperature is valid
            if (tempCount > 0)
            {
                float avgTemp = tempSum / tempCount;
                Console.WriteLine($"Average temperature: {avgTemp:F2}");
            }
            else
            {
                Console.WriteLine("Average temperature: NAN");
            }
        }
        catch (Exception ex)
        {
            // This catch block ensures the program won't crash unexpectedly
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

}
