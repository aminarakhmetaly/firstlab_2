using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_3
{
    class Program
    {
        static bool IsPrime(int a)
        {
            int cnt = 0;
            //находим количество делителей
            for (int i = 1; i <= a; ++i)
            {
                if (a % i == 0)
                {
                    cnt++;
                }
            }

            if (cnt == 2) return true;

            return false;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C:\PL\in.txt");
            //reading data from input file
            string[] l = sr.ReadLine().Split(' ');
            //reading from the console and spliting an array of strings 

            int m = int.MaxValue;
             //giving the contr values for min and max

            foreach (string i in l)
            {
                int x = int.Parse(i);

                m = Math.Min(x, m);
                //here we compare two values and take the result

                StreamWriter sw = new StreamWriter(@"C:\PL\out.txt");

                if (m != int.MaxValue)//checking whether the number is min
                    sw.WriteLine(m);
                else
                    sw.WriteLine("There is no prime number in the given array");
                sw.Flush();//method which records data in the file in order to output the result 
            }

        }
    }
}
