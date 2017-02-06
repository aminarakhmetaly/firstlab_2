using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    class State
    {
        private int index;

        public int Index 
        //making the variable of index public
        {
            get { return index; }

            set

            {
                int maxVal = Folder.GetDirectories().Length;
                //comparing with max value
                if (value >= 0 && value < maxVal)
                {
                    index = value;
                }
            }
        }

        public DirectoryInfo Folder { get; set; }
    }

    class Program
    {
        static void ShowFolderContent(State state)
        //function that shows the content
        {
            Console.Clear();
            //cleaning the console from extra ones

            DirectoryInfo[] list = state.Folder.GetDirectories(); 
            //adding an array of folders to the called "list"

            for (int i = 0; i < list.Length; ++i)
            {
                if (state.Index == i) 
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    //if index equals to the ith element it changes its bg color
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.Write(list[i]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }

            foreach (FileInfo f in state.Folder.GetFiles())
            {
                Console.WriteLine(f.Name);
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

            layers.Push(state); 
            //pushing the layers into the stack
            while (alive)
            {
                ShowFolderContent(layers.Peek());
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
                        layers.Pop();
                        break;
                    case ConsoleKey.Enter:
                       
                        DirectoryInfo[] list = layers.Peek().Folder.GetDirectories();
                        //pushing the enter opens new layer
                       
                        State newState = new State
                        {
                            
                            Folder = new DirectoryInfo(list[state.Index].FullName),
                            //naming new folder in the list
                          
                            Index = 0
                        };
                        layers.Push(newState);
                        //adds a new state for initial ones
                        break;
                }

            }
        }
    }
}