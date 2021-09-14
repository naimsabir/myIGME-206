using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_PE8
{
    
    //Class: Program
    //Author: Naim Sabir
    //Purpose: Homework Assignment 8
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Homework Assignment 8: Question 5
        //Restrictions: When using the for loop to check the results the program for some reason outputs a list of 0's 
        //before each iteration
        static void Main(string[] args)
        {
            //Section of code to try problems
            /*Given the formula z = 3y2 + 2x - 1 write a console application to calculate z for the following ranges of x and y:
              -1 <= x <= 1 in 0.1 increments : there are 21 x values
               1 <= y <= 4 in 0.1 increments : there are 51 y values

               Use a 3-dimensional array double[,,] to store the values of x, y and z for each computation.*/

            //use these doubles to hold the values of x y and z
            double x = 0, y = 0, z = 0;

            //ints for accessing the array dimensions
            int nX = 0;
            int nY = 0;

            //declaring the 3 dimensional array to hold:
            //          21 values of x
            //          51 values of y for each value of x
            //          3 values for each data point: x, y, and z
            double[,,] dArray = new double[21, 51, 3];

            //loop through each value of x incrementing nX on every turn
            for (x = -1; x <= 1; x += 0.1, ++nX)
            {
                //make sure nY is 0 for each loop through
                nY = 0;
                //loop through each value of y incrementing nY on every turn
                for(y = 1; y <= 4; y += 0.1, ++nY)
                {
                    //calculate z
                    z = (3 * Math.Pow(y, 2)) + (2 * x) - 1;

                    //store x, y, and z for this data point
                    dArray[nX, nY, 0] = x;
                    dArray[nX, nY, 1] = y;
                    dArray[nX, nY, 2] = z;
                }
            }
            for(int daX = 0; daX < 21; daX++)
            {
                for(int daY = 0; daY < 51; daY++)
                {
                   for(int daZ = 0; daZ < 3; daZ++)
                    {
                        Console.WriteLine("The values are: " + dArray[daX, daY, daZ]);
                    }
                }
            }

        }
    }
}
