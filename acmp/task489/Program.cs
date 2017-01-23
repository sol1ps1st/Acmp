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
            int i, c = Math.Abs(begCoins[n-1]);
            for (i = 0; i < n-1; ++i) //В endCoins на одну монету меньше. Ее значение и надо найти
            {
                if (Math.Abs(begCoins[i]) != Math.Abs(endCoins[i]))
                { c = Math.Abs(begCoins[i]); break; }
            }
            begCoins = begCoins.FindAll(delegate(int x) { return (x == c) || (x == -c); });
            endCoins = endCoins.FindAll(delegate(int x) { return (x == c) || (x == -c); });
            rotations = rotations.FindAll(delegate(int x) { return (x == c) || (x == -c); });

            int bSum = 0, eSum = 0, rSum = 0;
            foreach (int e in begCoins)
                bSum += e > 0 ? 1 : -1;
            foreach (int e in endCoins)
                eSum += e > 0 ? 1 : -1;
            foreach (int e in rotations)
                rSum ++;

            if (rSum % 2 == 0)
            {
                //Четное количеcтво вращений целевых монет (cтоимоcтью c) Они не изменят иcходный набор монет - изменитcя может только порядок cледования монет.
                return (bSum - eSum) * c;
            }
            else
            {
                //Считаем, что сняли плюсовую монету, тогда должно выполниться условие (Поскольку за один шаг кол-во плюсовых монет может измениться только на 2)
                if (Math.Abs(eSum + 1 - bSum) == 2)
                    return c; 
                else
                    return -c;
            }
        }
    }
}
