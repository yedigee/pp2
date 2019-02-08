using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public static int exitCode = 0;

        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] != s[s.Length - i - 1])
                {
                    Console.WriteLine("No");
                    Environment.Exit(exitCode);
                }
            }
            Console.WriteLine("Yes");
        }
    }
}
