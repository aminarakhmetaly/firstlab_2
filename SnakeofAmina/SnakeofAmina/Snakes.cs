using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeofAmina
{
    class Snakes
    {
        public ConsoleColor color = ConsoleColor.Magenta;
        public char sign = '*';
        public List<Point> body = new List<Point>();
        Game game = null;

        public void LinkToGame(Game game)
        {
            this.game = game;
        }



        public Snakes()
        {
            body.Add(new Point(10, 10));
            //body.Add(new Point(9, 10));
            //body.Add(new Point(8, 10));

        }




        public void move(int dx, int dy)
        {
            while (true)
            {
                Thread.Sleep(Game.SPEED);
                for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x += dx;
            body[0].y += dy;
                this.Clear();

            if (body[0].x > 60)
            {
                body[0].x = 0;
            }
            if (body[0].x < 0)
            {
                body[0].x = 60;
            }
            if (body[0].y > 30)
            {
                body[0].y = 0;
            }
            if (body[0].y < 0)
            {
                body[0].y = 30;
            }
                this.Draw();

                game.CanEat();

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