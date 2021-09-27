using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sabir_Vehicles;
namespace Sabir_Traffic
{
    //Class: Program
    //Author: Naim Sabir
    //Purpose: Homework Assignment 11: Question 6
    //Restrictions: None
    class Program
    {
        //Function: AddPassenger
        //Author: Naim Sabir
        //Purpose: Create a console application project, Traffic, which references Vehicles.dll (created in Q5 above).
        //Include a function called AddPassenger() that accepts any object with the IPassengerCarrier interface.
        //Within the AddPassenger() function, call the LoadPassenger() method using a reference to the interface.
        //Also add a line to call the ToString() method inherited from System.Object
        //(ie. if vehicleObject is passed to the function, call  Console.WriteLine(vehicleObject.ToString()).
        //Also try passing an object that did not inherit the IPassengerCarrier interface and see what happens.
        //Restrictions: None

        public void AddPassenger(IPassengerCarrier i)
        {
            //use reference to the interface to call LoadPassenger()
            i.LoadPassenger();

            //if the object passed through the interface is a type of vehicle output it
            if(i.GetType() == typeof(Vehicle))
            {
                Console.WriteLine($"{i.ToString()}");
            }
        }
        //Method: Main
        //Purpose: Homework Assignment 11: Question 6
        //Restrictions: None
        static void Main(string[] args)
        {
        }
    }
}
