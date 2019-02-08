using System;
using System.IO;
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
            string Foldername1 = @"C:\Users\Yedige\Desktop\ProgrammingII\pp2\Week2\Lab2\Task4";
            string pathstring = Path.Combine(Foldername1, "Folder1");
            Directory.CreateDirectory(pathstring);
            string Filename = "NewFile.txt";
            pathstring = Path.Combine(pathstring, Filename);

            string Foldername2 = @"C:\Users\Yedige\Desktop\ProgrammingII\pp2\Week2\Lab2\Task4";
            string pathstring2 = Path.Combine(Foldername2, "Folder2");
            Directory.CreateDirectory(pathstring2);

            if (!File.Exists(pathstring))
            {
                using (FileStream fs = File.Create(pathstring))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", Filename);
                return;
            }

            string path1 = @"C:\Users\Yedige\Desktop\ProgrammingII\pp2\Week2\Lab2\Task4\Folder1";
            string path2 = @"C:\Users\Yedige\Desktop\ProgrammingII\pp2\Week2\Lab2\Task4\Folder2";

            string sourcefile = Path.Combine(path1, Filename);
            string destfile = Path.Combine(path2, Filename);
            Directory.CreateDirectory(path2);
            File.Copy(sourcefile, destfile, true);

            if (File.Exists(@"C:\Users\Yedige\Desktop\ProgrammingII\pp2\Week2\Lab2\Task4\Folder1\NewFile.txt"))
            {
                try
                {
                    File.Delete(@"C:\Users\Yedige\Desktop\ProgrammingII\pp2\Week2\Lab2\Task4\Folder1\NewFile.txt");
                }
                catch(IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }
    }
}
