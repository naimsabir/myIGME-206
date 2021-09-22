using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscellaneous_Homework_Code
{
    //Class: Program
    //Author: Naim Sabir
    //Purpose: To be used as a project with the sole purpose of doing homework
    //problems that involve code
    //Restrictions: Has no real purpose
    class Program
    {
        struct order
        {
          

            public string itemName;
            public int unitCount;
            public double unitCost;

            public double TotalPrice()
            {
                return unitCount * unitCost;
            }
     
            public string Receipt()
            {
                string receipt = "{0} {1} items at ${2} each, total cost ${3}", unitCount, itemName, unitCost, TotalPrice();
                return receipt;
            }

        }

        //Method: Main
        //Purpose: Same as above
        //Restrictions: Same as above
        static void Main(string[] args)
        {

        }
    }
}
