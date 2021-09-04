using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_PE3
{
    // Class Program
    // Author: Naim Sabir
    // Purpose: Homework Assignment 3
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: obtain four int values from the user
        // and display the product
        // Restrictions: None
        static void Main(string[] args)
        {
            int val1, val2, val3, val4;
            //string sVal1, sVal2, sVal3, sVal4;
            Console.WriteLine("Enter your first integer.");
            val1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your second integer.");
            val2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your third integer.");
            val3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your fourth integer.");
            val4 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Integer 1 is {0}: \n Integer 2 is {1} \n Integer 3 is {2} \n Integer 4 is {3}", val1, val2, val3, val4);
        }
    }
}
