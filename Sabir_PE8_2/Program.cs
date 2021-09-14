using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_PE8_2
{
    //Class: Program
    //Author: Naim Sabir
    //Purpose: Homework Assignmment 8 Question 7
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Write a console application that accepts a string from the user and outputs
        //a string with the characters in reverse order.
        //Restrictions: None
        static void Main(string[] args)
        {
            //Pseudo Code:
            //1. Turn string into a character array 
            //2. Use decrementing for loop to display all the characters in the array in reverse
            //3. After figuring out how to make that work implement user input
            //4. Drink some apple juice for a job well done

            //Test string to make sure my idea works
            //string daString = "This is the string";
            string daString = null;

            //Prompt the user for input and store the string they create into daString
            Console.WriteLine("Enter a string of characters: ");
            daString = Console.ReadLine();

            //Declaring and Initializing my character array with ToCharArray so
            //I don't need to find a way to enter the string into the array separately.
            char[] daChars = daString.ToCharArray();

            Console.WriteLine("Your string backwards is: ");

            //Using a decrementing for loop to display all the character from last to first
            for (int i = (Convert.ToInt32(daString.Length) - 1); i >= 0; i--)
            {
                Console.Write(" {0} ", daChars[i]);
            }
            

        }
    }
}
