using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static bool IsPrime(string s)
        {
            int x = int.Parse(s);
            if (x <= 1) return false;
            for (int i = 2; i < x; i++)
            {
                if (x % i == 0) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            List<string> PrimeNums = new List<string>();
            FileStream fs = new FileStream(@"C:\Users\Yedige\Desktop\ProgrammingII\pp2\Week2\Lab2\Task2\Task2Tests\Task2Input.txt", FileMode.Open,FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadLine();
            string[] nums = line.Split(' ');
            foreach(var q in nums)
            {
                if (IsPrime(q))
                {
                    PrimeNums.Add(q);
                }
            }
            sr.Close();
            fs.Close();

            FileStream fs2 = new FileStream(@"C:\Users\Yedige\Desktop\ProgrammingII\pp2\Week2\Lab2\Task2\Task2Tests\Task2Output.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);
            foreach(var q in PrimeNums)
            {
                sw.Write(q + " ");
            }
            sw.Close();
            fs2.Close();

        }
    }
}
