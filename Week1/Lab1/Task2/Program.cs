using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        class Student //created class student
        {
            public string Name;
            public string ID;
            public int YearOfStudy;
            public Student(string n,string d,int y) 
            {
                Name = n;
                ID = d;
                YearOfStudy = y;

            }
            public void PrintInfo() //method which will print information about student 
            {
                Console.WriteLine(Name + " " + ID + " " + YearOfStudy);
            }

        }
        static void Main(string[] args)
        {
            int x = 0;
            x++; //increment year of study 

            Student Ramir = new Student("Ramir", "18BD1337", x); //set parameters to the student 
            Student Amir = new Student("Amir", "18BD2281", x);
            Ramir.PrintInfo(); //call a method 
            Amir.PrintInfo();
            

        }
    }
}
