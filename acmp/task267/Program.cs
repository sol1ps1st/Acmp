using System;
using System.Collections.Generic;
using System.IO;


namespace task267
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string[] s = sr.ReadLine().Split();
            sr.Close();
            int n = int.Parse(s[0]);
            int s1 = int.Parse(s[1]);
            int s2 = int.Parse(s[2]);
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(CopyAmount(n, s1,s2));
            sw.Close();
        }

        static long CopyAmount(long n, int s1, int s2)
        {
            if (n == 1) return s1;
            int buf;
            if (s1 > s2) { buf = s1; s1 = s2; s2 = buf; } //s1 - minimum speed
            n--;
            //for (long i = 1; ; ++i)
            //    if (i / s1 + i / s2 >= n)
            //        return i + s1;

            long lBorder = 0, rBorder = s2 * n, med, k;
            while (rBorder - lBorder > 1)
            {
                med = (long)Math.Round(lBorder + (rBorder - lBorder) / 2.0, 0);
                k = med / s1 + med / s2;
                if (k < n)
                    lBorder = med;
                else
                    rBorder = med;
            }
            //Максимально сократили интервал поиска
            for (long i = lBorder; ; ++i)
                if (i / s1 + i / s2 >= n)
                    return i + s1;
        }
    }
}
