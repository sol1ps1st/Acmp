using System;
using System.IO;
using System.Collections.Generic;

namespace task489
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string[] str = sr.ReadLine().Split();
            int n = int.Parse(str[0]); int k = int.Parse(str[1]);
            List<int> begCoins = new List<int>(n);
            List<int> endCoins = new List<int>(n-1);
            List<int> rotations = new List<int>(k);
            str = sr.ReadLine().Split();
            int i;
            for (i = 0; i < n; ++i)
                begCoins.Add(int.Parse(str[i]));
            str = sr.ReadLine().Split();
            for (i = 0; i < n - 1; ++i)
                endCoins.Add(int.Parse(str[i]));
            str = sr.ReadLine().Split();
            for (i = 0; i < k; ++i)
                rotations.Add(int.Parse(str[i]));
            sr.Close();
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(FindNumber(n, k, begCoins, endCoins, rotations));
            sw.Close();
        }

        private static Comparison<int> AbsSort;

        static int FindNumber(int n, int k, List<int> begCoins, List<int> endCoins, List<int> rotations)
        {
            AbsSort = delegate(int x, int y)
            {
                return Math.Abs(x).CompareTo(Math.Abs(y));
            };
            begCoins.Sort(AbsSort); endCoins.Sort(AbsSort);
            int i, с = Math.Abs(begCoins[n-1]);
            for (i = 0; i < n-2; ++i) //В endCoins на одну монету меньше. Ее значение и надо найти
            {
                if (Math.Abs(begCoins[i]) != Math.Abs(endCoins[i]))
                { с = Math.Abs(begCoins[i]); break; }
            }
            return с;
        }
    }
}
