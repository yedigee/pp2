using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            string line2 = Console.ReadLine();
            int n = int.Parse(line1); //parse string to obtain integer
            //string[] numb = line2.Split(new char[] { ',', ' ', ';', '#', '$' });
            string[] numb = line2.Split(); //split ex. 123 to 1 2 3 with " "
            for (int i = 0; i < numb.Length; i++) //define a loop through whole length of array
            {
                int x = int.Parse(numb[i]); //parse strings to obtain integers 
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(x + " "); //output integers 
                }
            }


        }
    }
}
