using System;
using System.IO;

namespace task0169
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("INPUT.TXT");
            StreamWriter sw = new StreamWriter("OUTPUT.TXT");
            int n, k;
            string[] s = sr.ReadLine().Split();
            n = int.Parse(s[0]);
            k = int.Parse(s[1]);
            sr.Close();
            Shop sh = new Shop(n, k);
            sw.Write(sh.FindCount());
            sw.Close();
        }
        //static void Shop(ref int cnt, int n, int k)
        //{
        //    if (n == k) { cnt++; return; }
        //    if ((n - 1 > 0) && (k - 1 > 0)) Shop(ref cnt, n - 1, k - 1); //Движемся к магазину
        //    if (n + 1 <= k - 1) Shop(ref cnt, n + 1, k - 1); //Движемся от магазина
        //}
    }

    class Shop
    {
        private int n, k;
        private int[,] a = null;
        public Shop(int n, int k)
        {
            this.n = n;
            this.k = k;
            int r = n + (k - n) / 2 + 1;
            int c = k;
            a = new int[r, c];
            for (int i = 0; i < r; ++i)
                for (int j = 0; j < c; ++j)
                    a[i, j] = -1;
        }
        ~Shop()
        {
        }
        public int FindCount()
        {
            return Count(n, k);
        }
        private int Count(int n, int k) //Используем ленивую динамику с запоминанием результата в массиве a
        {
            int res = 0;
            if (n == k) { return 1; }
            if ((n - 1 > 0) && (k - 1 > 0))
            {
                if (a[n - 1, k - 1] == -1)
                    a[n - 1, k - 1] = Count(n - 1, k - 1); //Движемся к магазину
                res += a[n - 1, k - 1];
            }
            if (n + 1 <= k - 1)
            {
                if (a[n + 1, k - 1] == -1)
                    a[n + 1, k - 1] = Count(n + 1, k - 1); //Движемся от магазина
                res += a[n + 1, k - 1];
            }
            return res;
        }
    }
}
