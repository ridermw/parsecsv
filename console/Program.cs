using System;
using System.IO;
/*
BY MATTHEW WILLIAMS

*/
namespace console
{
    /// <summary>
    /// This Program will take in a file name, parse the file, and return the fourth value.
    /// </summary>
    public class Program
    {
        const char CSV_DELIMETER = ',';
        const int COLUMN_LENGTH_MAX = 5;
        static void Main(string[] args)
        {
            
            var errorCode = ProcessFile(args);

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
                    Console.WriteLine("Error: A line contained fewer than " + COLUMN_LENGTH_MAX + " values in this file.");
                    break; 
            }
        }

        /// <summary>
        /// Validate and parse a csv file
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static ErrorCode ProcessFile(string[] args)
        {
            var returnCode = ValidateArgs(args);
            if (returnCode != ErrorCode.NONE) {
                return returnCode; // error parsing args
            }

            return ParseCsv(args[0]);
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
        public static ErrorCode ParseCsv(string fileName)
        {
            try
            {
                // parse file
                using (var sr = new StreamReader(fileName)) 
                {
                    string rowData;
                    while ((rowData = sr.ReadLine()) != null) 
                    {
                        var values = rowData.Split(CSV_DELIMETER);
                        if (values.Length < COLUMN_LENGTH_MAX) {
                            return ErrorCode.FEWER_THAN_FIVE;
                        } 
                        var output = values[3];  // output the fourth value
                        if (values.Length > COLUMN_LENGTH_MAX ) {
                            output += " WARNING: This line contains more than five values.";
                        }
                        Console.WriteLine(output);
                    }                 
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: There was a problem reading from the file:");
                Console.WriteLine(e.Message);                
            }

            return ErrorCode.NONE;
        }
    }

    public enum ErrorCode
    {
        NONE = 0,
        NO_ARGS = 1,
        MORE_THAN_ONE_ARGS = 2,
        FILE_NOT_FOUND = 3,
        FEWER_THAN_FIVE = 4
    }
}
