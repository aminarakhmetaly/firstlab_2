using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    [Serializable]
   public class Food : GameObject
    {
        public Point location;
        public ConsoleColor color = ConsoleColor.White;
        public new char sign = 'o';


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
        public bool foodInWall()
        {
            for (int i = 0; i < wall.points.Count; i++)
            {
                if (points[0].Equals(Wall.points[i]))
                    return true;
            }
            return false;
        }

        public bool foodInWorm()
        {
            for (int i = 0; i < Worm.points.Count; i++)
            {
                if (points[0].Equals(Worm.points[i]))
                    return true;
            }
            return false;
        }

        public void newFood()
        {
            do
            {
                points.Clear();
                SetRandomPosition();
            } while (foodInWall() || foodInWorm());
        }

       
    }


}
