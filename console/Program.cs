using System;
/*
BY MATTHEW WILLIAMS
FOR EMERSON Automation Solutions - Senior Software Engineer (Agile) – Job ID 20003893

Assignment 1 - Coding a Simple File Parser
 
Write a program that takes a file as a command-line argument.  The file will be a standard CSV with an arbitrary number of lines.  
 
Your program should:
 - Print the fourth value on each line to the terminal/console
 - Assert the file exists
 - Exit immediately if a line has fewer than 5 comma-separated values
 - Print a warning for each line with more than 5 comma-separated values
 
Given a file with the following content:
 
This,is,the,first,line
This,is,another,awesome,line
 
Your program should produce the output:
first
awesome
 
Ideas for how to make your submission standout:
- Use tests to drive the implementation
- Use a language you have not used professionally before

MY WORK ITEMS
-------------

1.  Create an app with command line arguements.  Use first arguement as a path to a file.  Check if file exists and return an error
    if it doesnt.  Display help text with 0 or more than 1 arguements.

2.  Attempt to parse file.  If file throws error or has fewer than 5 comma separated values, exit and display error message.

3.  Print the fourth element of each line.  If the line has more than 5 values, display a warning for that line.
    Still show the fourth value.

*/
namespace console
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("\nWhat is your name? ");
            // var name = Console.ReadLine();
            // var date = DateTime.Now;
            // Console.WriteLine($"\nHello, {name}, on {date:d} at {date:t}!");
            // Console.Write("\nPress any key to exit...");
            // Console.ReadKey(true);
            var errorCode = ParseCsv(args);

            switch(errorCode)
            {
                case ErrorCode.NO_ARGS:
                    Console.WriteLine("No arguements passed.  Please include the filename.");
                    break;
                case ErrorCode.MORE_THAN_ONE_ARGS:
                    Console.WriteLine("Too many arguements passed.  Please only include the filename.");
                    break;
            }
        }

        // Validate the arguements passed in to Main
        public static ErrorCode ValidateArgs(string[] args)
        {
            var returnCode = ErrorCode.NONE;
            if (args.Length == 0) {
                returnCode = ErrorCode.NO_ARGS;
            } else if (args.Length > 1) {
                returnCode = ErrorCode.MORE_THAN_ONE_ARGS;
            }
            if (returnCode > ErrorCode.NONE)
                return returnCode; // no need to proceed.
            
            // Parse arguement and detect if file is found.

            
            return returnCode;
        }
        
        // Parse Csv file
        public static ErrorCode ParseCsv(string[] args)
        {
            var returnCode = ErrorCode.NONE;
            returnCode = ValidateArgs(args);

            return returnCode;
        }
    }

    public enum ErrorCode
    {
        NONE = 0,
        NO_ARGS = 1,
        MORE_THAN_ONE_ARGS = 2,
        FILE_NOT_FOUND = 3,
        FEWER_THAN_FIVE = 4,
        MORE_THAN_FIVE = 5
    }
}
