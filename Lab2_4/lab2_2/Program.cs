using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_2
{
    class Program
    {
        static void Main(string[] args)
        {
             StreamReader sr = new StreamReader(@"C:\PL\input.txt"); 
             //reading data from input file
             string[] l = sr.ReadLine().Split(' ');
             //reading from the console and spliting an array of strings 

             int m = int.MaxValue; 
             int M = int.MinValue;
             //giving the contr values for min and max
            foreach (string i in l)
             {
                 int k = int.Parse(i);

                 m = Math.Min(k, m);
                 M = Math.Max(M, k);
                 //here we compare two values and take the result
             }

             Console.WriteLine("Min value:{0}, Max value:{1}", m, M);
             //outputing the result into console*/

            Console.ReadKey();
           
        }
    }
    }
