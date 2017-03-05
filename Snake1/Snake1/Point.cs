﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    public class Point
    {
        public int x;
        public int y;
    

        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public override bool Equals(object obj)
        {
            Point o = obj as Point;
            if (this.x == o.x && this.y == o.y)
                return true;
            return false;
        }

       
    }
}

