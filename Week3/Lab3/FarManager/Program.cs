using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FarManager
{
    class Layer
    {
        public FileSystemInfo[] Content
        {
            get;
            set;
        }
        
        
        int selectedItem;

        /*
        public int GetSelectedItem()
        {
            return selectedItem;
        }
        public void SetSelectedItem(int value)
        {
            selectedItem = value;
        }*/



        public int SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (value < 0)
                {
                    selectedItem = Content.Length - 1; //IF WE HAVE GONE BEYOND UPPER BORDER
                }
                else if (value >= Content.Length) //IF WE HAVE GONE BEYOND LOWER BORDER
                {
                    selectedItem = 0;
                }
                else //ANY OTHER CASE IS OK 
                {
                    selectedItem = value;
                }
            }
        }

        public void Draw() //LIGHTEN SELECTED ITEM WITH OTHER COLORS
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for (int i = 0; i < Content.Length; ++i)
            {
                if (i == SelectedItem)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(i+1+" "+Content[i].Name);
            }
        }
    }

    enum FarMode //ENUMERATION 0 1
    {
        FileView,
        DirectoryView
    }

    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo root = new DirectoryInfo(@"C:\Users\Yedige\Desktop\New folder (2)");
            Stack<Layer> history = new Stack<Layer>();
            FarMode farMode = FarMode.DirectoryView;

            history.Push( //PUSHING NEW LAYER TO OUR STACK OF LAYERS LIFO
                new Layer
                {
                    Content = root.GetFileSystemInfos(),
                    SelectedItem = 0
                });

            while (true)  
            {
                if (farMode == FarMode.DirectoryView)
                {
                    history.Peek().Draw(); //RETURNING THE VALUE AT THE TOP OF THE STACK AND CALLING DRAW-METHOD
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(); //READING KEY FROM KEYBOARD
                switch (consoleKeyInfo.Key) 
                {
                    case ConsoleKey.UpArrow: //DECREASE THE VALUE OF SELECTED ITEM TO MOVE UP
                        history.Peek().SelectedItem--;
                        break;
                    case ConsoleKey.DownArrow: //VISE VERSA
                        history.Peek().SelectedItem++;
                        break;
                    case ConsoleKey.Enter:
                        int x = history.Peek().SelectedItem; //DEFINING INT VALUE TO SAVE SELECTED ITEM VALUE
                        FileSystemInfo fileSystemInfo = history.Peek().Content[x];
                        if (fileSystemInfo.GetType() == typeof(DirectoryInfo)) //CHECKING IF FILE IS DIRECTORY
                        {
                            DirectoryInfo d = fileSystemInfo as DirectoryInfo;
                            history.Push(new Layer { Content = d.GetFileSystemInfos(), SelectedItem = 0 });
                        }
                        else
                        {
                            farMode = FarMode.FileView;
                            using (FileStream fs = new FileStream(fileSystemInfo.FullName, FileMode.Open, FileAccess.Read))
                            {
                                using (StreamReader sr = new StreamReader(fs))
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine(sr.ReadToEnd()); //READS FILE TO THE END
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (farMode == FarMode.DirectoryView)
                        {
                            history.Pop();
                        }
                        else if (farMode == FarMode.FileView)
                        {
                            farMode = FarMode.DirectoryView;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    /*case ConsoleKey.R:
                        int y = history.Peek().SelectedItem;
                        FileSystemInfo fsiR = history.Peek().Content[y];
                        if (fsiR.GetType() == typeof(DirectoryInfo))
                        {
                            Console.Clear();
                            string s = Console.ReadLine();
                            string Name = fsiR.Name;
                            string fName = fsiR.FullName;
                            string newpath = " ";
                            for (int i = 0; i < fName.Length - Name.Length; i++)
                            {
                                newpath += fName[i];
                            }
                            newpath = newpath + s;
                            Directory.Move(fName, newpath);
                        }
                        else
                        {
                            Console.Clear();
                            string s = Console.ReadLine();
                            string Name = fsiR.Name;
                            string fName = fsiR.FullName;
                            string newpath = " ";
                            for (int i = 0; i < fName.Length - Name.Length; i++)
                            {
                                newpath += fName[i];
                            }
                            newpath = newpath + s;
                            File.Move(fName, newpath);
                        }
                        break;*/
                



                    case ConsoleKey.Delete:
                        int x2 = history.Peek().SelectedItem;
                        FileSystemInfo fileSystemInfo2 = history.Peek().Content[x2];
                        if (fileSystemInfo2.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo d = fileSystemInfo2 as DirectoryInfo;
                            Directory.Delete(fileSystemInfo2.FullName, true);
                            history.Peek().Content = d.Parent.GetFileSystemInfos();
                        }
                        else
                        {
                            FileInfo f = fileSystemInfo2 as FileInfo;
                            File.Delete(fileSystemInfo2.FullName);
                            history.Peek().Content = f.Directory.GetFileSystemInfos();
                        }
                        history.Peek().SelectedItem--;
                        break;
                    
                }
            }
        }
    }
}
