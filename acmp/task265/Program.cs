using System;
using System.IO;
using System.Collections.Generic;

namespace task265
{
    class Program
    {

        private static int n;
        //private static List<Pair> desk;
        private static int[,] desk;
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            n = int.Parse(sr.ReadLine());
            //desk = new List<Pair>(n);
            desk = new int[8, 8];
            string[] s;
            for (int i = 0; i < n; ++i)
            {
                s = sr.ReadLine().Split();
                //desk.Add(new Pair(){x=int.Parse(s[0]), y=int.Parse(s[1])});
                desk[int.Parse(s[0]) - 1, int.Parse(s[1]) - 1] = 1;
            }
            sr.Close();
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(GetPerim());
            sw.Close();
        }

        private static int GetPerim()
        {
            int res = n * 4, idx;
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    if (desk[i, j] == 1)
                    {
                        idx = i + 1; if ((idx >= 0 && idx < 8) && (desk[idx, j] == 1)) res--;
                        idx = i - 1; if ((idx >= 0 && idx < 8) && (desk[idx, j] == 1)) res--;
                        idx = j + 1; if ((idx >= 0 && idx < 8) && (desk[i, idx] == 1)) res--;
                        idx = j - 1; if ((idx >= 0 && idx < 8) && (desk[i, idx] == 1)) res--;
                    }
                }
            }
            return res;
        }
    }

    struct Pair
    {
        public int x, y;
    }
}
