# parsecsv

BY MATTHEW WILLIAMS

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

2.  Attempt to parse file.  Print the fourth element of each line.  If a line has fewer than 5 comma separated values, exit and display error message.

3.  If the line has more than 5 values, display a warning for that line.
