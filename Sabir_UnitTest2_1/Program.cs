using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_UnitTest2_1
{
    //struct Friend
    //{
    //    public string name;
    //    public string greeting;
    //    public DateTime birthdate;
    //    public string address;
    //}

    //Class: Friend
    //Author: Naim Sabir
    //Purpose: Unit Test 2 Question 14
    //Restrictions: None
    public class Friend : ICloneable
    {
        //keeping the same fields as the struct
        public string name;
        public string greeting;
        public DateTime birthdate;
        public string address;

        //Creating a clone method to perform a deep copy
        public Object Clone()
        {
            //create a friend object to copy stuff into
            //don't need any other things added to copy because everything is inside of the friend class
            Friend copy = (Friend)this.MemberwiseClone();

            return copy;
        }
    
    }
    

    //Class: Program
    //Author: Naim Sabir
    //Purpose: Unit Test 2
    //Restrictions: None
    class Program
    {
     
        //Method: Main
        //Purpose: Unit Test 2 #14
        //Restrictions: None
        static void Main(string[] args)
        {
            //Write a console application which converts the following code from using
            //struct Friend to public class Friend and generates the same output:

            //could potentially just make methods for adding values to the Friend class fields
            //methods would be Name, Greeting, Birthdate, and Address

            //change from struct objects to class objects

            Friend friend = new Friend();
            Friend enemy = new Friend();

            //Friend friend;
            //Friend enemy;

            // create my friend Charlie Sheen
            friend.name = "Charlie Sheen";
            friend.greeting = "Dear Charlie";
            friend.birthdate = DateTime.Parse("1967-12-25");
            friend.address = "123 Any Street, NY NY 12202";

            //calling the clone method in the Friend class to deep copy
            // now he has become my enemy
            enemy = (Friend)friend.Clone();

            // set the enemy greeting and address without changing the friend variable
            enemy.greeting = "Sorry Charlie";
            enemy.address = "Return to sender.  Address unknown.";

            Console.WriteLine($"friend.greeting => enemy.greeting: {friend.greeting} => {enemy.greeting}");
            Console.WriteLine($"friend.address => enemy.address: {friend.address} => {enemy.address}");

            //The original output: friend.greeting => enemy.greeting: Dear Charlie => Sorry Charlie
            //friend.address => enemy.address: 123 Any Street, NY NY 12202 => Return to sender.Address unknown.

            //The previous output: friend.greeting => enemy.greeting: Sorry Charlie => Sorry Charlie
            //friend.address => enemy.address: Return to sender.Address unknown. => Return to sender.Address unknown.

            //need to deep copy

            //The current output:friend.greeting => enemy.greeting: Dear Charlie => Sorry Charlie
            //friend.address => enemy.address: 123 Any Street, NY NY 12202 => Return to sender.Address unknown.

        }

    }
}
