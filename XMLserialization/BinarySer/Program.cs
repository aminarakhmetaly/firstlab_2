using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySer
{
    [Serializable]
    class Program
    {
        
       static void Main(string[] args)
        {
            Complex c = new Complex(9, 7);
            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream("c.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                bf.Serialize(fs, c);
            }
            
            using (FileStream fs = new FileStream("c.bin", FileMode.OpenOrCreate))
            {
                Complex v = (Complex)bf.Deserialize(fs);

              
                Console.WriteLine(v);
            }

            Console.ReadLine();

        }
    }
}