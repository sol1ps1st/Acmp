using System;
using System.Collections.Generic;
using System.IO;

namespace task502
{
    class Program
    {
        static int  n;
        static int[,] a;
        static List<int> sumAr = new List<int>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("INPUT.TXT");
            n = int.Parse(sr.ReadLine());
            a = new int[n,n];
            string[] s;
            for (int i = 0; i < n; ++i)
            { 
                s = sr.ReadLine().Split();
                for (int j = 0; j < n; ++j)
                    a[i,j] = int.Parse(s[j]);
            }
            sr.Close();
            List<Pair> path = new List<Pair>();
            GetMosCount(n, path);
            int max = -1;
            for (int i = 0; i < sumAr.Count; ++i)
                if (sumAr[i] > max) max = sumAr[i];
            StreamWriter sw = new StreamWriter("OUTPUT.TXT");
            sw.Write(max);
            sw.Close();
        }

        struct Pair
        {
            public int r, c;
        }

        static int GetMosCount(int rows, List<Pair> path)
        {
            int i, j, tmp;
            if (rows == 1) //Попали в ветку где надо взять еще один элемент из 1 строки. Берем максимальный из оставшихся
            {
                tmp = -1;
                for (j = 0; j < n; ++j)
                    if ((!InPath(j, path)) && (a[0,j] > tmp)) tmp = a[0,j];
                if (rows == n)
                    sumAr.Add(tmp);
                return tmp;
            }
            for (j = 0; j < n; ++j)
            {
                if (!InPath(j, path))
                {
                    for (i = 0; i < rows; ++i)
                        if (rows - (i + 1) > 0)
                        {
                            List<Pair> pathn = new List<Pair>(path); pathn.Add(new Pair() { r = i, c = j });
                            tmp = (GetMosCount(rows - (i + 1), pathn) + a[i, j]);
                            if (rows == n)
                                sumAr.Add(tmp);
                        }
                        else if (rows - (i + 1) == 0)
                            return a[i,j];
                }
            }
            return 0;
        }

        static bool InPath(int j, List<Pair> path)
        {
            for (int k = 0; k < path.Count; ++k)
            {
                if (path[k].c == j)
                    return true;
            }
            return false;
        }
    }
}
