using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_PE14
{
    public interface IFace
    {
        void Method();
    }
    public class Class1 : IFace
    {
        public void Method()
        {
            Console.WriteLine("Class 1");
        }
    }
    public class Class2 : IFace
    {
        public void Method()
        {
            Console.WriteLine("Class 2");
        }
    }
    //Class: Program
    //Author: Naim Sabir
    //Purpose: Homework Assignment 14
    //Restrictions: None
    class Program
    {
        public static void MyMethod(object myObject)
        {
            IFace interFace;
            interFace = (IFace)myObject;
            interFace.Method();
            
        }

        //Method: Main
        //Purpose: Write a console application which has a Main() and a method called MyMethod() with the following signature:
        //public static void MyMethod(object myObject)
        //Using the class and interface definitions you created in #2, create objects of both classes and call MyMethod with each object.  
        //The code in MyMethod must use the interface to call the common method name.
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            Class2 class2 = new Class2();

            MyMethod(class1);
            MyMethod(class2);
        }
    }
}
