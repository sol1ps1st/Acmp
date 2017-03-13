using System;
using System.Collections.Generic;
using System.IO;

namespace task487
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string[] str = sr.ReadLine().Split();
            int n = int.Parse(str[0]);
            int k = int.Parse(str[1]);
            int p = int.Parse(str[2]);
            int[] steps = new int[p];
            int buf;
            StreamWriter sw = new StreamWriter("output.txt");
            for (int i = 0; i < p; ++i)
            {
                steps[i] = int.Parse(sr.ReadLine());
                buf = n % (k + 1);
                sw.WriteLine((buf == steps[i] || buf == 0)? "T": "F");
                n -= steps[i];
            }
            sr.Close();
            sw.Close();
        }
    }
}
