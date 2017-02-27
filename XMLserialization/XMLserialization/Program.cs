using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TypesofSerialization;

namespace XMLserialization
{
    [Serializable]
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            FileStream f = new FileStream("c.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            
            Complex c = new Complex();

            xs.Serialize(f, c);
            f.Close();
            Complex c2 = new Complex();
            FileStream fs2 = new FileStream("c.xml", FileMode.Open, FileAccess.Read);
            c2 = xs.Deserialize(fs2) as Complex;
            Console.WriteLine(c2);
            fs2.Close();
        }
    }
}