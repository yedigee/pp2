using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine(); //input the height of figure
            int n = int.Parse(line1); //parse string to obtain integer
            for (int i = 0; i <=n; i++) //2d array, loop till n inclusively 
            {
                for (int j = 0; j <i; j++) //increasing number of [*] in a next row
                {
                    Console.Write("[*]");
                }

                Console.WriteLine(); //go to the next line 

            }
        }
    }
}
