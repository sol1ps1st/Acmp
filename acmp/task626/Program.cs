using System;
using System.IO;
using System.Collections.Generic;

namespace task626
{
    class Program
    {
        private static int n;
        private static List<string> rules;
        private static string str;

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            n = int.Parse(sr.ReadLine());
            rules = new List<string>(n);
            for(int i = 0; i < n; ++i)
                rules.Add(sr.ReadLine());
            str = sr.ReadLine();
            sr.Close();
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(TransformStr());
            sw.Close();
        }

        private static string TransformStr()
        {
            int i, pos;
            int cnt;
            do
            {
                cnt = 0;
                for (i = 0; i < rules.Count; ++i)
                {
                    pos = str.IndexOf(rules[i]);
                    if (pos != -1)
                    {
                        str = str.Remove(pos, rules[i].Length);
                        ++cnt;
                    }
                }
            } while (cnt > 0);
            return str;
        }
    }
}
