using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1FromFile
{
    class Program
    {
        static bool IsPalindrome(string s)
        {
            char[] copyS = s.ToCharArray();
            Array.Reverse(copyS);
            string Reversed = new string(copyS);
            if (Reversed == s)
                return true;
            else return false;
        }

        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Yedige\Desktop\ProgrammingII\pp2\Week2\Lab2\Task1FromFile\TestFiles\Task1Test.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadLine();
            if (IsPalindrome(s))
            {
                Console.WriteLine("Yes");
            }
            else Console.WriteLine("No");
            
        }
    }
}
