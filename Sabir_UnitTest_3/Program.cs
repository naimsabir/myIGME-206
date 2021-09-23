using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_UnitTest_3
{
    //Class: Program
    //Author: Naim Sabir
    //Purpose: Unit Test 1: Question 3
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Create a console application that uses a delegate to impersonate the Console.ReadLine() function when asking for user input.
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
