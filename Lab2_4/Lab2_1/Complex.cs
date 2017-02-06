using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_4
{
    class Complex
    {
        public int x, y;//variables used to write a complex number

        public Complex(int _x, int _y)//creating konstruktor for complex class
        {
            x = _x;
            y = _y;
        }

        public Complex()
        {
        }

        public static Complex operator +(Complex a, Complex b)//creating the adding operator
        {
            Complex c = new Complex();
            c.x = a.x + b.x;
            c.y = a.y + b.y;
            return c;
        }


        public override string ToString()
        {
            return string.Format("{0} + {1}i", x, y);//outputing
        }


    }
}
