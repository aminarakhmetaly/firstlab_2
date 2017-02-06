using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_4
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Complex x = new Complex(2, 3);//creating new variables
            Complex y = new Complex(3, 4);
            Complex z = x + y;//adding them with the help of operator +

            Console.WriteLine(z);//outputing the complex c
            Console.ReadKey();
        }
    }
}
