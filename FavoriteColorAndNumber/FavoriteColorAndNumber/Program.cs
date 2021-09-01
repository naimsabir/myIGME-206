using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavoriteColorAndNumber
{
    //Class: Program
    //Author: Naim Sabir
    //Purpose: Console Read/Write and Exception-handling exercise
    //Restriction: None
    static class Program
    {
        //Method: Main
        //Purpose: Prompt the user for their favorite color and number
        //         Output their favorite color (in limited text colors) their favorite number of times
        //Restrictions: None
        static void Main(string[] args)
        {
            //string to hold their favorite color
            //compile-time error: missing semi colon
            //string color = null
            string sColor = null;
            string sNumber = null;
            string sFirstName = null;

            //int to hold their favorite number
            int favNum = 0;

            //flag to indicate if they entered a valid number string
            bool bValid = false;

            //loop counter
            int i = 0;

            //prompt for favorite color
            //demonstrate including the tab special character.
            //         "\n is the newline character, which is added to the end of the string for the Console
            Console.Write("Enter your favorite color:\t");

            //read their favorite color from the keyboard
            //and store it in color
            //logic error
            //sNumber = Console.ReadLine();
            sColor = Console.ReadLine();

            //prompt for favorite number 
            Console.Write("Enter your favorite number:\t");
            sNumber = Console.ReadLine();

            //This causes a runtime error with non numeric string
            //favNum = Convert.ToInt32(sNumber);
            while (bValid == false)
            {
                try
                {
                    favNum = Convert.ToInt32(sNumber);
                    bValid = true;
                }
                catch
                {
                    //and "catch" any run-time exception that might occur from the "try" code block
                    //guide the user with what kind of data we are expecting
                    Console.WriteLine("Please enter an integer.");

                    //flag that they have not entered valid data yet, so that we stay in the loop.
                    bValid = false;
                }
            }

            //use a switch() statement to set the output text color for several favorite colors 
            //the string class has a ToLower() method that allows us to more efficiently compare what 
            //otherwise we would need to check for "red", "RED", "rEd", "reD", "REd", "rED", and
            //note that color .ToLower() does not change the contents of color, but only returns a copy
            switch(sColor.ToLower())
            {
                //set the text color to Red
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                //set the text color to Blue
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                //set the text color to Green
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                //if none of the above cases are met, then invert the text color (black on white)
                default:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
            }

            for(i = 0; i < favNum; ++i)
            {
                //using $"" causes string interpolations such that the {} within the string are compiled
                //in this case we add ! to the color
                Console.WriteLine($"Your favorite color is {sColor + "!"}");

                //Two other ways to generate the same output:

                //1. simple string concatenation (note that you do not usw $ or {}):
                //             Console.WriteLine("Your favorite color is " + color + "!");

                //2. string replacement using {} (but not $):
                //             Console.WriteLine("Your favorite color is {0}!", color);
            }
            /* The above for loop can be rewritten as a while() loop as follows:
               Initiate the counter outside of the loop
               i = 0;

               while i < the number of times to write the output
               while (i < favNum)
               {
                write the output
                Console.WriteLine($"Your favorite color is {color + "!"}");\
                increment the counter
                ++i;
             */
        }
    }
}
