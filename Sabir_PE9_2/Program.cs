using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_PE9_2
{
    //Class: Program
    //Author: Naim Sabir
    //Purpose: Homework Assignment 9
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Create a delegate function and use it to impersonate the Console.ReadLine() function when asking for user input.
        //Refer to the "Lecture Code Examples" for the 3 steps in defining a delegate function.
        //The signature of Console.ReadLine() is "string ReadLine()" (ie. it returns a string and accepts no parameters).
        //Restrictions: None

        //declare the delegate function
        delegate string LineRead(string input);

        //create a function for delegate function variable to call so it can obtain input
        static string ReadLine(string input)
        {
            input = Console.ReadLine();
            return input;
        }
        static void Main(string[] args)
        {
            //string to hold result 
            string result, input = null;
            //declare the delegate variable
            LineRead line;
            //Prompt the user to enter a string
            Console.WriteLine("Enter a string: ");
            //setting the delegate function variable to the ReadLine() Function
            line = new LineRead(ReadLine);
            //call the delegate function to get the string
            result = line(input);
            //output the answer
            Console.WriteLine("The Output is: ");
            Console.WriteLine(result);
            
            
        }
    }
}
