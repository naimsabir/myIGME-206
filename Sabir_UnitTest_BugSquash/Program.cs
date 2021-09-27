using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_UnitTest_BugSquash
{
    class Program
    {
        // Calculate x^y for y > 0 using a recursive function
        static void Main(string[] args)
        {
            //sNumber is not initialized which causes issues later in the code
            //string sNumber;
            string sNumber = null;
            int nX;
            //compile-time error no semicolon
            //int nY
            int nY;
            int nAnswer;
            //compile-time error no quotation marks
            //Console.WriteLine(This program calculates x ^ y.);
            Console.WriteLine("This program calculates x ^ y");

            do
            {
                Console.Write("Enter a whole number for x: ");
                //run-time error: not having ReadLine go into a variable has it repeat endlessly
                //Console.ReadLine();
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nX));

            do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nY));
            //run-time error: while (int.TryParse(sNumber, out nY)) keeps makes the code loop endlessly
            //while (int.TryParse(sNumber, out nY));

            //compile-time error. Had the wrong variable which would result in Power being unable to be called
            //while (int.TryParse(sNumber, out nX));

            // compute the factorial of the number using a recursive function
            nAnswer = Power(nX, nY);

            //logic error: the code will not display the actual variables because it is missing the $
            //Console.WriteLine("{nX}^{nY} = {nAnswer}");
            Console.WriteLine($"{nX}^{nY} = {nAnswer}");
        }

        //Power cannot be called inside of main unless it is static which is both a logic error and can result in a compile-time error
        //int Power(int nBase, int nExponent)
        static int Power(int nBase, int nExponent)
        {
            int returnVal = 0;
            //logic error: the purpose of the program is to calculate the exponent value there is no need for factorial calculation
            //int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                returnVal = 0;
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                //run-time error: Causes a stackoverflowexceptions
                //nextVal = Power(nBase, nExponent + 1);


                // multiply the base with all subsequent values
                //logic error: there is no use for next value
                //returnVal = nBase * nextVal;
                returnVal = (int)Math.Pow(nBase, nExponent);
            }
            //error there is no actual return statement
            //returnVal;
            return returnVal;
        }
    }
}
