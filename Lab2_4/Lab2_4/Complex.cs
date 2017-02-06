using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_4
{
    class Complex//creating a complex class
    {
        int x;
        int y;
        public Complex(int _x, int _y)//using konstruktor for a class
        {
            _x = x;
            _y = y;
        }
        public static Complex operator +(Complex z1, Complex z2)//the function of + operator 
        {
            Complex res = new Complex(0, 0);

            res.x = z1.x + z2.y;
            res.y = z1.x + z2.y;

            return res;// here we take the result
        } 
        public override string ToString()
        {
            return string.Format("{0} + {1}i", x, y);//outputing and formating the result
        }
    }
}
}
