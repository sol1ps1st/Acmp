using System;
using System.IO;
using System.Collections.Generic;

namespace task397
{
    class Program
    {

        private static string str;
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            str = sr.ReadLine();
            sr.Close();
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(FindQualityStr());
            sw.Close();
        }

        private static string FindQualityStr()
        {
            int i, min = 256, max = -1;
            for (i = 0; i < str.Length; ++i)
            {
                if (str[i] < min) min = str[i];
                if (str[i] > max) max = str[i];
            }
            if (min != max)
                return Convert.ToChar(min).ToString() + Convert.ToChar(max).ToString();
            else
                return Convert.ToChar(max).ToString();
        }
    }
}
