﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake1
{
    [Serializable]
    public class Program
    {
        static Worm snake = new Worm();
        static Food food = new Food();
        static bool Gameover = false;
        static Wall wall = new Wall(1);
        static Objects g = new Objects(snake, food, Gameover, wall);
        public static Thread toMove = new Thread(new ThreadStart(callingMove));
        public static Thread pressedKeys = new Thread(new ThreadStart(play));


        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(50, 50);
            Game.Init();
            pressedKeys.Start();
            public static void play()
        {
            Game.Generate();
            toMove.Start();
            Game.Draw();
            while (Game.inGame)
            {
                Game.Draw();
                ConsoleKeyInfo button = Console.ReadKey(true);

                switch (button.Key)
                {
                    case ConsoleKey.UpArrow:
                        Game.worm.changeDirection(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        Game.worm.changeDirection(0, 1);
                        break;
                    case ConsoleKey.RightArrow:
                        Game.worm.changeDirection(1, 0);
                        break;
                    case ConsoleKey.LeftArrow:
                        Game.worm.changeDirection(-1, 0);
                        break;
                    case ConsoleKey.Q:
                        Game.saveGame();
                        break;
                    case ConsoleKey.W:
                        Game.loadGame();
                        break;
                }
                Game.worm.Clear();
            }
        }

        public static void callingMove()
        {
            while (!Gameover)
            {
                Thread.Sleep(Game.SPEED);
                Game.Clear();
                Console.Clear();
                snake.draw();
                food.draw();
                wall.draw();
                BinaryFormatter bf = new BinaryFormatter();

                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        snake.move(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        snake.move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        snake.move(1, 0);
                        break;
                    case ConsoleKey.Escape:
                        Gameover = true;
                        break;
                    case ConsoleKey.F2:
                        Objects f = new Objects();
                        using (FileStream fs = new FileStream("objects.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                        {
                            bf.Serialize(fs, f);
                        }
                        break;
                    case ConsoleKey.F10:
                        using (FileStream fs = new FileStream("objects.bin", FileMode.OpenOrCreate))
                        {
                            Objects d = (Objects)bf.Deserialize(fs);
                            Console.WriteLine(d);
                        }
                        Gameover = true;
                        break;

                
                }
                
                if (snake.CanEat(food))
                {
                    food.SetRandomPosition();
                    
                }

                if (snake.body.Count == 5)
                {
                    wall = new Wall(2);
                }
                if (snake.body.Count == 10)
                {
                    wall = new Wall(3);
                }
                if (snake.body.Count == 15)
                {
                    wall = new Wall(4);
                }
                if (snake.body.Count == 20)
                {
                    wall = new Wall(5);
                }

                for(int i=0; i < wall.body.Count; i++)
                {
                    if(snake.body[0].x == wall.body[i].x && snake.body[0].y == wall.body[i].y)
                    {
                        
                        Console.Clear();
                        Console.WriteLine("Game Over");
                        Console.ReadKey();
                        Gameover = true;
                    }
                }

            }


        }
    }
}
