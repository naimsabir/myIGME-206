using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_PE12
{
    //Class: MyClass
    //Author: Naim Sabir
    //Purpose:Create a console application and derive the public class MyDerivedClass from MyClass.
    //Override the GetString() method to return the string from the base class by using the base implementation of the method,
    //but append the text " (output from the derived class)" to the returned string.
    //Have the Main() instantiate a MyDerivedClass object and output the string returned by the GetString() method.
    //Restrictions: None
    public class MyClass
    {
        public string myString;

        public MyClass()
        {
           
        }
        public string MyString
        {
            set
            {
                myString = value;

            }
        }


        //virtual means default implementation of a method
        public virtual string GetString()
        {
            return myString;
        }
      
    }

    //Class: MyDerivedClass
    //Author: Naim Sabir
    //Purpose: To override the GetString method of the base class and output myString plus extra output
    //Restrictions: None
    public class MyDerivedClass : MyClass
    {
        public MyDerivedClass() : base()
        {

        }

        public override string GetString()
        {
            return base.myString += " Output from derived class";
        }

    }
    //Class: Program
    //Purpose: To create a MyDerivedClass object in main and call the GetString method to see the result
    //Restrictions: None
    class Program
    {
        static void Main(string[] args)
        {
            string outputString;
            MyDerivedClass derivedClass = new MyDerivedClass();

            outputString = derivedClass.GetString();

            Console.WriteLine("The result: " + outputString);
        }
    }
}
