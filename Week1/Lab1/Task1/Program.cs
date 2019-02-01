using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public static bool isPrime(int x) //our function to check if element is prime or not
        {
            if (x == 1) return false; //1 is not a prime number 
            for(int i = 2; i < x; i++)
            {
                if (x % i == 0) return false; //if x is divisible by any other element with a remainder of 0, it isn't a prime 
            }
            return true;

        }


         

        static void Main(string[] args)
        {
            List<int> primenumbers = new List<int>(); //new list for our prime numbers
            string line1 = Console.ReadLine(); //number of elements
            string line2 = Console.ReadLine(); //elements 
            int n = int.Parse(line1); // string to int 
            string[] elements = line2.Split(); //split elements with " "
            for(int i = 0; i < elements.Length; i++)
            {
                int x = int.Parse(elements[i]); //create integers and let it be equal to out elements
                if (isPrime(x) == true) //checking whether element is prime or not 
                {
                    primenumbers.Add(x); //if prime, add to out new list
                }

            }
            Console.WriteLine(primenumbers.Count); //counting number of prime elements and outputting it 
            for(int i = 0; i < primenumbers.Count; i++)
            {
                Console.Write(primenumbers[i]+" "); //outputting prime elements
            }

        }
    }
}
