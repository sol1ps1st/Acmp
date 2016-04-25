using System;
using System.IO;
using System.Collections.Generic;

namespace task29
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            StreamWriter sw = new StreamWriter("output.txt");
            int i = 0, n = int.Parse(sr.ReadLine());
            int[] h = new int[n];
            string[] s = sr.ReadLine().Split();
            sr.Close();
            for (i = 0; i < n; ++i)
                h[i] = int.Parse(s[i]);
            sw.Write(FindMinEnergy(n, h));
            sw.Close();
        }

        static int FindMinEnergy(int n, int[] h)
        {
            int i, prev = 0, cur, next;
            if (n == 1) return prev;
            cur = Math.Abs(h[1] - h[0]);
            if (n == 2) return cur = Math.Abs(h[1] - h[0]);
            for (i = 2; i < n; ++i)
            {
                next = Math.Min(cur + Math.Abs(h[i] - h[i - 1]), prev + 3 * Math.Abs(h[i] - h[i - 2]));
                prev = cur;
                cur = next;
            }
            return cur;
        }
    }
}
