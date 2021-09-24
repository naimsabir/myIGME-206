using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_UnitTest_5
{
    //Class: Program
    //Author: Naim Sabir
    //Purpose: Unit Test 1: Question 12
    //Restrictions: None
    class Program
    {
        //Method: Main 
        //Purpose: Write a console application that has the following variable declarations:
        //string sName;
        //double dSalary = 30000;

        //It should prompt for the user's name, then call the following function:

        //static bool GiveRaise(string name, ref double salary)

        //The function should increase the salary by $19,999.99 if name = your name and return true
        //Otherwise it should return false.
        
        //The main program should congratulate the user if they got a raise, and display their new salary.

        static void Main(string[] args)
        {
            string sName;
            double dSalary = 30000;

            //promt the user to enter their name and store it
            Console.WriteLine("What is your name?");
            sName = Console.ReadLine();

            if(GiveRaise(sName,ref dSalary) == true)
            {
                Console.WriteLine("Congratulations {0}, you have earned a raise! Your new salary is {1}!", sName, dSalary);
            }
            else if(GiveRaise(sName, ref dSalary) == false)
            {
                Console.WriteLine("Sorry {0}, you have not earned a raise. Your salary is still {1}!", sName, dSalary);
            }
        }
        //Method: GiveRaise
        //Purpose: Give user a raise if their name is Naim Sabir
        //Restrictions: None
        static bool GiveRaise(string name, ref double salary)
        {
            if(name == "Naim Sabir")
            {
                salary += 19999.99;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
