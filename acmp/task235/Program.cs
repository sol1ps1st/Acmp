using System;
using System.IO;
using System.Collections.Generic;

namespace task235
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("INPUT.TXT");
            StreamWriter sw = new StreamWriter("OUTPUT.TXT");
            string s = sr.ReadLine();
            sr.Close();
            sw.Write(Do(s));
            sw.Close();
        }

        private static int Do(string s)
        {
            int angle = 90; //Угол движения
            List<Point> patch = new List<Point>(50);
            patch.Add(new Point(0, 0)); //Стартовая позиция
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == 'L')
                    angle = (angle + 90) % 360;
                else if (s[i] == 'R')
                {
                    angle = (angle - 90);
                    if (angle < 0) angle = 270;
                }
                else
                {
                    Point p = new Point();
                    Point last = patch[patch.Count - 1];
                    switch (angle)
                    {
                        case 0: p.x = last.x + 1; p.y = last.y; break;
                        case 90: p.x = last.x; p.y = last.y + 1; break;
                        case 180: p.x = last.x - 1; p.y = last.y; break;
                        case 270: p.x = last.x; p.y = last.y - 1; break;
                    }
                    patch.Add(p);
                    if (patch.IndexOf(p) != patch.Count - 1)
                        return patch.Count - 1; //Не считаем начальную точку (0;0)
                }
            }
            return -1;
        }

        struct Point
        {
            public Point(int x, int y)
            {
                this.x = x; this.y = y;
            }
            public int x, y;
        }
    }
}
