using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Enter multiple lines (Type 'end' to finish input):");

        // Read multiple lines of input
        string input = "";
        string line;
        while ((line = Console.ReadLine()) != "end")
        {
            input += line + Environment.NewLine;
        }

        // Process the input
        string modifiedInput = ProcessInput(input);

        // Display the modified input
        Console.WriteLine("\nModified Input:");
        Console.WriteLine(modifiedInput);

        // Calculate and display the sum of two-digit numbers
        int sum = SumTwoDigitNumbers(modifiedInput);
        Console.WriteLine($"\nSum of Two-Digit Numbers: {sum}");
    }

    public static string ProcessInput(string input)
    {
        // Match one-digit numbers in words
        string pattern = @"\b(one|two|three|four|five|six|seven|eight|nine)\b";

        // Replace one-digit numbers in words with the formatted result
        string result = Regex.Replace(input, pattern, match =>
        {
            string digitInWord = match.Groups[1].Value;
            int digitInInt = digitInWord.Length; // Get the integer representation

            // Find the first and last one-digit numbers on the line
            string firstDigit = digitInWord;
            string lastDigit = Regex.Matches(match.Value, pattern).Cast<Match>().Last().Groups[1].Value;

            // Create a two-digit number and replace the original text
            string twoDigitNumber = $"{digitInInt}{firstDigit}{lastDigit}";
            return twoDigitNumber;
        });

        return result;
    }   

    public static int SumTwoDigitNumbers(string input)
    {
        // Match all two-digit numbers
        string pattern = @"\b(\d{2})\b";

        // Sum up all two-digit numbers
        int sum = Regex.Matches(input, pattern)
                      .Cast<Match>()
                      .Sum(match => int.Parse(match.Groups[1].Value));

        return sum;
    }
}