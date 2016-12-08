using System;
using System.IO;

namespace task39
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("INPUT.TXT");
            StreamWriter sw = new StreamWriter("OUTPUT.TXT");
            int n = Int32.Parse(sr.ReadLine());
            int[] c = new int[n];
            string[] s = sr.ReadLine().Split();
            sr.Close();
            for (int i = 0; i < n; ++i)
                c[i] = Int32.Parse(s[i]);

            int max, pos = 0, maxPos, sum = 0, hairLen = 1;
            while (pos < n)
            {
                max = c[pos]; maxPos = pos;
                for (int i = pos + 1; i < n; ++i)
                    if (c[i] > max) { max = c[i]; maxPos = i; }
                hairLen += maxPos - pos;
                sum += max * hairLen;
                pos = maxPos + 1; hairLen = 1;
            }
            sw.Write(sum);
            sw.Close();
        }
    }
}
