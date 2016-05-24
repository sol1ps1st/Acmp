using System;
using System.IO;
using System.Collections.Generic;

namespace task464
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            int N = int.Parse(sr.ReadLine());
            sr.Close();
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(GetNumberByPos(N));
            sw.Close();
        }

        private static int GetNumberByPos(int pos)
        {
            if (pos == 1) return 0;
            else if (pos == 2) return 1;
            int n, k, p, midR, res;
            p = (int)Math.Log(pos, 2);
            n = (int)(Math.Pow(2, p) + 1);
            k = (int)(Math.Pow(2, p+1));
            res = 1;
            while (k - n > 1)
            {
                p--;
                midR = n + (int)Math.Pow(2, p);
                if (pos >= midR)
                {
                    res++;
                    n = midR;
                }
                else
                    k = midR - 1;
            }
            if (pos == k) res++;
            res %= 3;
            return res;
        }
    }
}
