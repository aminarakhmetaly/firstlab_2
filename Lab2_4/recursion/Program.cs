using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class Program
    {
        static void ShowFolderInfo(CustomFolderInfo item)
            //usage of a class
        {
            item.PrintFolderInfo();
            //usage of a function that shows the content

            ConsoleKeyInfo pressedKey = Console.ReadKey();

            //various cases of putting data into the console using the kursor and buttons
            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                item.DecreaseIndex();
                //usage of function that decreases the index
                ShowFolderInfo(item);
                //showing the content
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                item.IncreaseIndex();
                //usage of function that increases the index
                ShowFolderInfo(item);
            }
            else if (pressedKey.Key == ConsoleKey.Enter)
            {
                CustomFolderInfo newItem = item.GetNextItem();
                //usage of function that shows following folder
                ShowFolderInfo(newItem);
            }
            else if (pressedKey.Key == ConsoleKey.Escape)

            {
                CustomFolderInfo newItem = item.GetPrevItem();
                ////usage of function that shows the initial one
                ShowFolderInfo(newItem);
            }
        }

        static void Main(string[] args)
        {
            CustomFolderInfo test = new CustomFolderInfo(null, 0, new DirectoryInfo(@"C:\inetpub\temp\appPools").GetDirectories());
            //here we create new variable of a class and give the data for its items
            ShowFolderInfo(test);
        }
    }

    internal class CustomFolderInfo
    {
    }
}
