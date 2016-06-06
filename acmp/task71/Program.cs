using System;
using System.Collections.Generic;
using System.IO;

namespace task71
{
    class Program
    {
        private static int n;
        private static int[] w;

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            n = int.Parse(sr.ReadLine());
            w = new int[n];
            string[] s = sr.ReadLine().Split();
            for (int i = 0; i < n; ++i)
                w[i] = int.Parse(s[i]);
            sr.Close();
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(MinDif());
            sw.Close();
        }

        private static int MinDif()
        {
            int a = 0, b = 0;
            return Dif(n, a, b);
        }

        private static int Dif(int c, int a, int b)
        {
            if (c == 0)
            {
                return Math.Abs(a - b);
            }
            //int f = Dif(c - 1, a + w[c-1], b);
            //int s = Dif(c - 1, a, b + w[c-1]);
            //return Math.Min(f, s);
            return Math.Min(Dif(c - 1, a + w[c-1], b), Dif(c - 1, a, b + w[c-1]));
        }
    }
}
