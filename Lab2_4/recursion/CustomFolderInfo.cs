using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class CustomFolderInfo//creating class of customfolder
    {
        CustomFolderInfo prev; //initial class
        int index;//variable for index
        DirectoryInfo[] dirs; // content of folders

        public CustomFolderInfo(CustomFolderInfo prev, int index, DirectoryInfo[] directoryInfo)
            //creating konstruktor for three items of a class
        {
            this.prev = prev;
            this.index = index;
            this.dirs = directoryInfo;
        }
        public void PrintFolderInfo()
        // function used for coloured folders while moving between them
        {
            Console.Clear();

            for (int i = 0; i < dirs.Length; ++i)
            {
                if (i == index)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(dirs[i]);
            }
        }

        public void DecreaseIndex()
        //function for decreasing index when we go up
        {
            if (index - 1 >= 0) index--;
        }

        public void IncreaseIndex()
        //function for increasing index when we go down
        {
            if (index + 1 < dirs.Length) index++;
        }

        public CustomFolderInfo GetNextItem()
        {
            return new CustomFolderInfo(this, 0, this.dirs[index].GetDirectories());
            //giving new info for the next opened item
        }

        public CustomFolderInfo GetPrevItem()
        {
            return prev;
            //getting the info that we took before
        }
    }
}