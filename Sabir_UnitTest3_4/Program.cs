using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_UnitTest3_4
{
    //Question #7: Define a Wizard class that contains the following fields:
    //string name
    //int age
    //Declare a List<Wizard>.Fill the list with 10 Wizard objects with different names and ages.
    //Write the code to use List.Sort() to sort the list based on their age.  (Refer to Week #12 in class code).
	//+5 points if you also implement it as a delegate or lambda expression!
    public class Wizard : IComparable<Wizard>
    {
        public string name;
        public int age;
        public Wizard(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Wizard w)
        {
            return this.age.CompareTo(w.age);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Wizard wizard1 = new Wizard("tom", 20);
            Wizard wizard2 = new Wizard("ben", 60);
            Wizard wizard3 = new Wizard("andrew", 45);
            Wizard wizard4 = new Wizard("frankonius", 95);
            Wizard wizard5 = new Wizard("fred", 18);
            Wizard wizard6 = new Wizard("charlie", 30);
            Wizard wizard7 = new Wizard("sarah", 25);
            Wizard wizard8 = new Wizard("claire", 22);
            Wizard wizard9 = new Wizard("gren", 20);
            Wizard wizard10 = new Wizard("geraldine", 50);

            
            List<Wizard> wizards = new List<Wizard>();
            wizards.Add(wizard1);
            wizards.Add(wizard2);
            wizards.Add(wizard3);
            wizards.Add(wizard4);
            wizards.Add(wizard5);
            wizards.Add(wizard6);
            wizards.Add(wizard7);
            wizards.Add(wizard8);
            wizards.Add(wizard9);
            wizards.Add(wizard10);

            //regular sort
            wizards.Sort();

            //lambda sort
            wizards = wizards.OrderBy(delegate (Wizard n) { return n.age; }).ToList();

        }
    }
}
