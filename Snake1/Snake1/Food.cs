using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    class Food
    {
        public Point location;
        public ConsoleColor color = ConsoleColor.DarkBlue;
        public char sign = '#';


        public Food()
        {
            SetRandomPosition();
        }

        public void SetRandomPosition()
        {
            int x = new Random().Next(0, 39);
            int y = new Random().Next(0, 34);

            location = new Point(x, y);

        }

        public void draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(location.x, location.y);
            Console.Write(sign);
        }


    }
}