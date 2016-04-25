using System;
using System.Collections.Generic;
using System.IO;

namespace task502
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("INPUT.TXT");
            int n = int.Parse(sr.ReadLine());
            int[,] a = new int[n,n];
            string[] s;
            for (int i = 0; i < n; ++i)
            { 
                s = sr.ReadLine().Split();
                for (int j = 0; j < n; ++j)
                    a[i,j] = int.Parse(s[j]);
            }
            sr.Close();
            int[] cols = { };
            int res = GetMosCount(n, a, n, cols);
            StreamWriter sw = new StreamWriter("OUTPUT.TXT");
            sw.Write(res);
            sw.Close();
        }

        static int GetMosCount(int n, int[,] a, int rows, int[] cols)
        {
            return 0;
        }
    }
}
