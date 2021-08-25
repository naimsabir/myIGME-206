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
            string color = null;
            string sNumber = null;

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
            color = Console.ReadLine();

            //prompt for favorite number 
            Console.Write("Enter your favorite number:\t");
            sNumber = Console.ReadLine();

            //This causes a runtime error with non numeric string
            favNum = Convert.ToInt32(sNumber);
        }
    }
}
