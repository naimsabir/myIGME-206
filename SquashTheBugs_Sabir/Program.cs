using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquashTheBugs_Sabir
{
    // Class Program
    // Author: Naim Sabir
    // Purpose: Bug squashing exercise
    // Restrictions: None

    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10 
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None

        static void Main(string[] args)
        {
            // declare int counter
            // Syntax Error: Missing an ;
            //int i = 0
            int i = 0;
            // declare string to hold all numbers
            string allNumbers = null;

            // loop through the numbers 1 through 10
            // logic error: loop will end at the number 9 because it uses a < instead of a <=
            // for(i = 1; i < 10; ++i)
            for (i = 1; i <= 10; ++i)
            {
                // declare string to hold all numbers
                //string allNumbers = null;

                // output explanation of calculation
                //Missing the parentheses for the arithmetic operation i - 1
                //Console.Write(i + "/" + i - 1 + " = ");
                Console.Write(i + "/" + (i - 1) + " = ");

                // output the calculation based on the numbers
                // compile-time error: caused by dividing by 0 when i = 1
                // fixed by using an if else statement to produce a new string when dividing by 0
                //Console.WriteLine(i / (i - 1));
                if(i == 1)
                {
                    Console.WriteLine("0");
                }
                else
                {
                    //logic error: unable to output decimals because the variable is an int
                    //Console.WriteLine(i/ (i - 1));
                    Console.WriteLine((float)i / (i - 1));
                }
                // concatenate each number to allNumbers
                allNumbers += i + " ";

                // increment the counter
                // logic error: There is no need for an incrementer in a for loop because it already has one
                //i = i + 1;
            }
            // output all numbers which have been processed
            //allNumbers does not exist outside of the for loop
            //fixed by declaring allNumbers inside of main instead of the for loop
            Console.WriteLine("These numbers have been processed: " + allNumbers);
        }

    }
}
