using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Far_manager
{
    class State
    {
        private int index;

        public int Index
        //making the variable of index public
        {
            get { return index; }

            set //comparing with max value
            {
                int maxVal = Folder.GetFileSystemInfos().Length;
                if (value >= 0 && value < maxVal)
                {
                    index = value;
                }
            }
        }

        public DirectoryInfo Folder;
    }

    class Program
    {
        static void ShowFolderContent(State state)//function that shows the content
        {
            Console.Clear();
            //cleaning the console from extra ones

            FileSystemInfo[] list = state.Folder.GetFileSystemInfos();
            //adding an array of folders to the called "list"
            for (int i = 0; i < list.Length; i++)
            {

                if (state.Index == i)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    //if index equals to the ith element it changes its bg color
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }



                if (list[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }



                Console.WriteLine(list[i].Name);
                //using foreach outputing the names of files
            }

        }

        static void Main(string[] args)
        {
            bool alive = true;

            State state = new State { Folder = new DirectoryInfo(@"C:\"), Index = 0 };
            //adding new variable for class of state with two items


            Stack<State> layers = new Stack<State>();
            // adding the stack of states

            bool modeFileOpen = false;

            layers.Push(state);
            //pushing the layers into the stack
            while (alive)
            {
                if (!modeFileOpen) ShowFolderContent(layers.Peek());
                //shows the content of initial element

                ConsoleKeyInfo pressedKey = Console.ReadKey();
                //inputing data using console keys
                switch (pressedKey.Key)
                // using switch in order to describe various keys
                {
                    case ConsoleKey.UpArrow:
                        layers.Peek().Index--;
                        break;
                    case ConsoleKey.DownArrow:
                        layers.Peek().Index++;
                        break;
                    case ConsoleKey.Escape:
                        State top2 = layers.Peek();
                        FileSystemInfo x2 = top2.Folder.GetFileSystemInfos()[top2.Index];
                        //pushing the enter opens new layer
                        if (x2.GetType() == typeof(DirectoryInfo))
                        {

                            if (layers.Count != 1)
                            {

                                layers.Pop();
                            }


                        }
                        else
                        {
                            modeFileOpen = false;

                        }
                        break;
                    case ConsoleKey.Enter:
                        State top = layers.Peek();
                        FileSystemInfo x = top.Folder.GetFileSystemInfos()[top.Index];
                        if (x.GetType() == typeof(DirectoryInfo))
                        {
                            State newState = new State //new class
                            {

                                Folder = x as DirectoryInfo,   //naming new folder in the list
                                Index = 0
                                //index at first elemement
                            };
                            layers.Push(newState);
                        }
                        else if (x.GetType() == typeof(FileInfo))
                        {
                            FileStream sr = new FileStream(x.FullName, FileMode.Open, FileAccess.Read);//opening and reading data
                            StreamReader g = new StreamReader(sr);
                            string s = g.ReadToEnd();
                            Console.Clear();
                            Console.Write(s);
                            modeFileOpen = true;//opens file
                        }
                        break;


                }
            }
        }
    }
}
