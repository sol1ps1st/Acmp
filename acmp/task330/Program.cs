using System;
using System.IO;

namespace task330
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string[] s = sr.ReadLine().Split();
            int x0 = int.Parse(s[0]); int y0 = int.Parse(s[1]);
            s = sr.ReadLine().Split();
            int x1 = int.Parse(s[0]); int y1 = int.Parse(s[1]);
            sr.Close();
            int res;
            if ((x0 + y0) % 2 != (x1 + y1) % 2)
                res = 0;
            else
            {
                if (Math.Abs(x0 - x1) == Math.Abs(y0 - y1))
                    res = 1;
                else
                    res = 2;
            }
            StreamWriter sw  = new StreamWriter("output.txt");
            sw.Write(res);
            sw.Close();
        }
    }
}
