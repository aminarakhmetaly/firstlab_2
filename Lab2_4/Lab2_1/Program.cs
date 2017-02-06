using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Complex a = new Complex(1, 6);//creating values for new variables of complex numbers
            Complex b = new Complex(8, 3);
            Complex c = a + b;//using operator +
            Console.Write(c);//outputing the result for console
        
            Console.ReadKey();
        }
    }
}
