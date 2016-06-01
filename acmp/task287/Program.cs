using System;
using System.IO;
using System.Collections.Generic;

namespace task287
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string[] s = sr.ReadLine().Split();
            int n = int.Parse(s[0]);
            int l = int.Parse(s[1]);
            string text = sr.ReadLine();
            sr.Close();
            int r = WordCount(n, l, text);
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(r);
            sw.Close();
        }

        private static int WordCount(int n, int l, string text)
        {
            List<string> words = new List<string>();
            string w;
            for (int i = 0; i <= n - l; ++i)
            {
                w = text.Substring(i, l);
                if (words.IndexOf(w) == -1)
                    words.Add(w);
            }
            return words.Count;
        }
    }
}
