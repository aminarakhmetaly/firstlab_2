using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace JsonSerialization
{
    [Serializable]
    public class Complex
    {
        public int y;
        public int x;

        public Complex(int _x, int _y)
        {
            x = _x;
            y = _y;
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

    class Program
    {
       

        static void Main(string[] args)
        {
            Complex c = new Complex(4, 6);
            string ans = JsonConvert.SerializeObject(c);
            using (FileStream ds = new FileStream("c.json", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(ds))
                {
                    sw.WriteLine(ans);
                }
            }
          
            FileStream fs2 = new FileStream("c.json", FileMode.Open, FileAccess.Read);

            StreamReader g = new StreamReader(fs2);
            string s = g.ReadToEnd();
            Complex res = new Complex(s[5] - '0', s[11] - '0');

            Console.Write(res);
            Console.ReadKey();
         
            fs2.Close();

        }
    }
}