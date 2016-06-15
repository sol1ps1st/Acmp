using System;
using System.IO;
using System.Collections.Generic;

namespace task50
{
    class Program
    {
        private static string str;
        private static string subStr;
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            str = sr.ReadLine();
            subStr = sr.ReadLine();
            sr.Close();
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(GetSubCount());
            sw.Close();
        }

        static int GetSubCount()
        {
            int cnt = 0, i, subStrLen = subStr.Length, pos = 0;
            List<string> shiftsubStr = new List<string>(subStrLen);
            string buf;
            for (i = 0; i < subStrLen; ++i)
            {
                buf = subStr.Substring(i) + subStr.Substring(0, i);
                if (shiftsubStr.IndexOf(buf) != -1) continue;
                shiftsubStr.Add(buf);
                pos = 0;
                while ((pos = str.IndexOf(buf, pos)) != -1)
                {
                    cnt++;
                    pos++;
                }
            }
            return cnt;
        }
    }
}
