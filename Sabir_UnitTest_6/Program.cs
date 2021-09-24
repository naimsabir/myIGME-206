using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_UnitTest_6
{
    //Class: Program
    //Author: Naim Sabir
    //Purpose: Unit Test 1: Question 13
    //Restrictions: None
    class Program
    {
        //Method: Main 
        //Purpose: Rewrite #12 using the following struct:
        //struct employee
        //{
	    //public string sName;
        //public double dSalary;
        //}

        // And rewrite the GiveRaise() function to pass the struct as the only parameter


        struct employee
        {
            public string sName;
            public double dSalary;
        }
        static void Main(string[] args)
        {
            employee newEmployee;
            newEmployee.dSalary = 30000;

            //promt the user to enter their name and store it
            Console.WriteLine("What is your name?");
            newEmployee.sName = Console.ReadLine();

            if (GiveRaise(ref newEmployee) == true)
            {
                Console.WriteLine("Congratulations {0}, you have earned a raise! Your new salary is {1}!", newEmployee.sName, newEmployee.dSalary);
            }
            else if (GiveRaise(ref newEmployee) == false)
            {
                Console.WriteLine("Sorry {0}, you have not earned a raise. Your salary is still {1}!", newEmployee.sName, newEmployee.dSalary);
            }
        }
        //Method: GiveRaise
        //Purpose: Give user a raise if their name is Naim Sabir
        //Restrictions: None
        static bool GiveRaise(ref employee e)
        {
            if (e.sName == "Naim Sabir")
            {
                e.dSalary += 19999.99;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
