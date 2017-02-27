using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesofSerialization
{
    public class Complex
    {
        int y;
        int x;

        public Complex(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public Complex()
        {
            this.x = 5;
            this.y = 6;
        }


        public static Complex operator +(Complex a, Complex b)
        {
            Complex c = new Complex(0, 0);
            c.x = a.x + b.x;
            c.y = a.y + b.y;
            return c;

        }
        public override string ToString()
        {
            return string.Format("{0} + {1}i", x, y);
        }
    }
}