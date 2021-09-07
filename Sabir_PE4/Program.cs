using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_PE4
{
    //Class: Program
    //Author: Naim Sabir
    //Purpose: Homework Assignment 4
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Write a console application that obtains two numbers
        //         from the user and displays them, but rejects any input
        //         where both numbers are greater than 10 and asks for two
        //         new numbers.
        //Restrictions: None
        static void Main(string[] args)
        {
            //Declaring two integer values that will hold the numbers obtained from the user
            int val1, val2;
            
            //startLabel will be a label to come back to if both numbers are greater than 10
            startLabel:

            //asking the user to input the two numbers that will be evaluated
            Console.WriteLine("Please enter Number 1");
            val1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter Number 2");
            val2 = Convert.ToInt32(Console.ReadLine());

            //This would be the most logical statement to use but the instructions asked to use the answer
            //from the previous question so I did not use it

            //if ((val1  <10) || (val2 < 10))
            //{
            //    Console.WriteLine("Number one is: {0}\n Number two is: {1}", val1, val2);
            //}

            //Using the logic from exercise 1 to test whether or not the values are less than 10
            //by using if statements with different operands to test the values and force the user
            //to enter two new numbers if both values are greater than or equal to.
            if ((val1 < 10) ^ (val2 < 10))
            {
                Console.WriteLine("Number one is: {0}\n Number two is: {1}", val1, val2);
            }
            else if ((val1 >= 10) && (val2 >= 10))
            {
                Console.WriteLine("Please enter two new numbers.");
                goto startLabel;
            }
        }
    }
}
