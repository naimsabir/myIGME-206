using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_PE8_3
{
    //Class: Program
    //Author: Naim Sabir
    //Purpose: Homework Assignment 8 Question 8
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Write a console application that accepts a string and does a case-insensitive
        //replacement of all occurrences of the word "no" with "yes". 
        //Restrictions: Does not work if the yes or no are followed by anything other than a space
        static void Main(string[] args)
        {
            //Pseudo-Code
            //1. Use string.Split() to turn a string into an array of words
            //2. Use a foreach loop along with a switch statement to replace all no's with yes's and
            //vice versa
            //3. Use a string.Trim in conjunction with a chars to Trim array

            //test string to see if program works
            //string myString = "no this is not a test string";

            //declare initial string
            string myString;

            //solicit input from the user
            Console.WriteLine("Write a string that contains the word yes or no");

            myString = Console.ReadLine();

            //tried to make an array of characters to trim but isn't working
            //char[] charsToTrim = { '.', '!', '?' };

            //string array to put separated user input into
            string[] myWords;

            //the separator that separates each part of the string by the spaces
            char[] separator = { ' ' };

            //using string.ToLower to make entries case insensitive
            myString = myString.ToLower();

            //separating string into an array of strings
            myWords = myString.Split(separator);

            Console.WriteLine("Your new statement is: ");
            foreach(string word in myWords)
            {
                //word.TrimEnd(charsToTrim);
                //switch statement to output the new correct word or keep word the same
                switch(word)
                {
                    case "no":
                        Console.Write("yes ");
                        break;
                    case "yes":
                        Console.Write("no ");
                        break;
                    default:
                        Console.Write(word + " ");
                        break;
                }
            }

        }
    }
}
