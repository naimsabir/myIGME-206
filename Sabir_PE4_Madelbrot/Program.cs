using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Mandelbrot
{
    /// <summary>
    /// This class generates Mandelbrot sets in the console window!
    /// </summary>


    class Class1
    {
        /// <summary>
        /// This is the Main() method for Class1 -
        /// this is where we call the Mandelbrot generator!
        /// </summary>
        /// <param name="args">
        /// The args parameter is used to read in
        /// arguments passed from the console window
        /// </param>

        [STAThread]
        static void Main(string[] args)
        {
            //doubles that will hold the user generated start and end values for realCoord and imagCoord
            //called userrealCoord and userimageCoord respectively
            double userrealCoord, userimageCoord;
            double realCoord, imagCoord;
            double realTemp, imagTemp, realTemp2, arg;
            int iterations;
            //prompt user for new start and end values
            Console.WriteLine("Enter a value for realCoord:");
            userrealCoord = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter a value for imageCoord:");
            userimageCoord = Convert.ToDouble(Console.ReadLine());

            //need to make sure that there are 48 values
            //in order to maintain 48 values I use the user's input as the logic statement inside the for loop
            //in order to be able to use the number they entered in a mathematic expression to ensure the same
            //values regardless of the number the user input.
            for (imagCoord = userimageCoord; imagCoord >= -(userimageCoord); imagCoord -= (userimageCoord/24))
            {
                //need to make sure there are 80 values
                //in order to maintain 48 values I use the user's input as the logic statement inside the for loop
                //in order to be able to use the number they entered in a mathematic expression to ensure the same
                //values regardless of the number the user input.
                for (realCoord = -(userrealCoord); realCoord <= (userrealCoord); realCoord += (userrealCoord/40))
                {
                    iterations = 0;
                    realTemp = realCoord;
                    imagTemp = imagCoord;
                    arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    while ((arg < 4) && (iterations < 40))
                    {
                        realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp)
                           - realCoord;
                        imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                        iterations += 1;
                    }
                    switch (iterations % 4)
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                    }
                }
                Console.Write("\n");
            }

        }
    }
}
