using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    public class Worm : GameObject
    {
        
        public ConsoleColor color = ConsoleColor.Magenta;
        public new char sign = '*';
        public static List<Point> body = new List<Point>();
        public static new List<Point> points = new List<Point>();


        public Worm()
        {
            body.Add(new Point(10, 10));
            //body.Add(new Point(9, 10));
        }




        public void move(int dx, int dy)
        {
            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x += dx;
            body[0].y += dy;
            if (body[0].x > 30)
            {
                body[0].x = 0;            
            }
            if (body[0].x < 0)
            {
                body[0].x = 30;            
            }
            if (body[0].y > 30)
            {
                body[0].y = 0;
            }
            if (body[0].y < 0)
            {
                body[0].y = 30;
            }

        }



        public bool CanEat(Food f)
        {
            if (body[0].x == f.location.x && body[0].y == f.location.y)
            {
                body.Add(new Point(f.location.x, f.location.y));
                return true;
            }
            return false;
        }

        public bool CollisionWithWall()
        {
            for (int i = 0; i < Program.wall.points.Count; i++)
                if (base.points[0].Equals(Program.wall.points[i]))
                    return true;
            return false;
        }

        public bool CollisionWithSelf()
        {
            for (int i = 0; i < base.points.Count; ++i)
            {
                for (int j = 0; j < base.points.Count; ++j)
                {
                    if (i == j)
                        continue;
                    if (base.points[i].Equals(Point[j])) return true;
                }
            }
            return false;
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
