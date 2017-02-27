﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    class Wall
    {
        public ConsoleColor color = ConsoleColor.White;
        public List<Point> body = new List<Point>();
        public char sign = '$';


        public Wall(int level)
        {
            string filename = string.Format(@"level{0}.txt", level);
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);


            string line = "";

            int row = 0;

            while ((line = sr.ReadLine()) != null)
            {

                for (int col = 0; col < line.Length; col++)
                {
                    if (line[col] == '#')
                    {
                        body.Add(new Point(col, row));
                    }
                }

                row++;
            }
        }



        public void draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
           
        }


    }
}