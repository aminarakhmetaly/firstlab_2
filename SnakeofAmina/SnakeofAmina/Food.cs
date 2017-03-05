using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeofAmina
{
    class Food
    {
        public Point location;
        public ConsoleColor color = ConsoleColor.White;
        public char sign = 'o';


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