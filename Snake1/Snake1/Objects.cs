using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    [Serializable]
    class Objects
    {
        Snakes snake = new Snakes();
        Food food = new Food();
        static bool Gameover = false;
        Wall wall = new Wall(1);
        public Objects()
        {

        }
        public Objects(Snakes _snake,Food _food, bool _Gameover, Wall _wall)
        {
            snake = _snake;
            food = _food;
            Gameover = _Gameover;
            wall = _wall;
        }
    }
}
