using System;
using System.IO;
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
    /// <summary>
    /// This Program will take in a file name, parse the file, and return the fourth value.
    /// </summary>
    public class Program
    {
        public const char CSV_DELIMETER = ',';
        static void Main(string[] args)
        {
            //TODO: change to a try/catch 
            var errorCode = ParseCsv(args);

            switch(errorCode)
            {
                case ErrorCode.NO_ARGS:
                    Console.WriteLine("No arguements passed.  Please include the filename.");
                    break;
                case ErrorCode.MORE_THAN_ONE_ARGS:
                    Console.WriteLine("Too many arguements passed.  Please only include the filename.");
                    break;
                case ErrorCode.FILE_NOT_FOUND:
                    Console.WriteLine("File not found!  Please check the path and try again.");
                    break;
                case ErrorCode.FEWER_THAN_FIVE:
                    Console.WriteLine("Error: A line contained few than five values in this file.");
                    break; 
            }
        }

        /// <summary>
        /// Validate the arguements passed in from Main. Check if file exists.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static ErrorCode ValidateArgs(string[] args)
        {
            if (args.Length == 0) {
                return ErrorCode.NO_ARGS;
            } else if (args.Length > 1) {
                return ErrorCode.MORE_THAN_ONE_ARGS;
            }
            
            // Parse arguement and detect if file is found.
            var fileName = args[0];
            if (!File.Exists(fileName)) {
                return ErrorCode.FILE_NOT_FOUND;
            }
            
            return ErrorCode.NONE;
        }
        
        /// <summary>
        /// Parse a CSV file
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static ErrorCode ParseCsv(string[] args)
        {
            var returnCode = ErrorCode.NONE;
            returnCode = ValidateArgs(args);
            if (returnCode != ErrorCode.NONE) {
                return returnCode; // error parsing args
            }

            using (var sr = new StreamReader(args[0])) 
            {
                string rowData;
                while ((rowData = sr.ReadLine()) != null) 
                {
                    var values = rowData.Split(CSV_DELIMETER);
                    if (values.Length < 5) {
                        return ErrorCode.FEWER_THAN_FIVE;
                    } 
                    var output = values[3];  // output the fourth value

                    Console.WriteLine(output);
                }                 
            }

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
