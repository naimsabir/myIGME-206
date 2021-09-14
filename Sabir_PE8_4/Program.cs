using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_PE8_4
{
    //Class: Program
    //Author: Naim Sabir
    //Purpose: Homework Assignment 8 Question 9
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Write a console application that places double quotes around each word in a string.
        //Restrictions: None
        static void Main(string[] args)
        {
            //Pseudo-Code
            //1. Use <string>.PadLeft and <string>.PadRight to add double quotes around the word
            //2. Split the string using a char[] separator = {' '}
            //3. Create a string [] to hold the separated version of your string
            //4. Use the string [] in a foreach loop and then use <string>.Pad to add the " around each letter
            //5. Take note that the .Pad work by entering the number of characters in the string + the amount of spaces you want
            //   so theoretically I should be able to use (word.Length + 1) to output what I want correctly
            Console.WriteLine("Enter a string: ");

            //the directions did not say to use a user inputed string but I'm going to do so 
            //just in case
            //string myString = "This is a test string";
            string myString = Console.ReadLine();

            char[] separator = { ' ' };
            string[] myWords = myString.Split(separator);
            foreach(string word in myWords)
            {
                string newWord;
                string newWord2;
                newWord = word.PadLeft((word.Length + 1), '"');
                newWord2 = newWord.PadRight((newWord.Length + 1), '"');
                Console.WriteLine(newWord2);
                
            }

        }
    }
}
