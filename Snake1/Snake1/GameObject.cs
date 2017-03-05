using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Snake1
{
    [Serializable]
    public abstract class GameObject : IDrawable
    {
        public char sign;
        public List<Point> points = new List<Point>();

        public void Draw()
        {
            for (int i = 0; i < points.Count; ++i)
            {
                if (points[i].x > 0 && points[i].y > 0)
                    Console.SetCursorPosition(points[i].x, points[i].y);
                else continue;
                if (GetType() == typeof(Worm) && i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write(sign);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Clear()
        {
            for (int i = 0; i < points.Count; ++i)
            {
                if (points[i].x > 0 && points[i].y > 0)
                    Console.SetCursorPosition(points[i].x, points[i].y);
                else continue;
                Console.Write(' ');
            }
        }

        public void Save()
        {
            string fname = GetType().Name;
            XmlSerializer xs = new XmlSerializer(this.GetType());
            using (FileStream fs = new FileStream(string.Format("{0}.xml", fname), FileMode.Create, FileAccess.Write))
            {
                xs.Serialize(fs, this);
            }
        }

        public object Load()
        {
            string fname = GetType().Name;
            XmlSerializer xs = new XmlSerializer(GetType());
            object res;
            using (FileStream fs = new FileStream(string.Format("{0}.xml", fname), FileMode.Open, FileAccess.Read))
            {
                res = xs.Deserialize(fs);
            }
            return res;
        }
    }
}