using System;
using System.Collections.Generic;
using System.IO;

namespace task389
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            int n = int.Parse(sr.ReadLine());
            int cnt = (int)Math.Pow(2, n);
            int[] a = new int[cnt];
            int i;
            string[] str = sr.ReadLine().Split();
            for (i = 0; i < cnt; ++i)
                a[i] = int.Parse(str[i]);
            int m = int.Parse(sr.ReadLine());
            Pair[] p = new Pair[m];
            for (i = 0; i < m; ++i)
            {
                str = sr.ReadLine().Split();
                p[i] = new Pair() { f = int.Parse(str[0]), s = int.Parse(str[1]) };
            }
            sr.Close();
            GreyCode gc = new GreyCode(cnt, a, m, p);
            StreamWriter sw = new StreamWriter("output.txt");
            string[] res = gc.GetAllSubstitutionResults();
            for (i = 0; i < m; ++i)
                sw.WriteLine(res[i]);
            sw.Close();
        }
    }

    struct Pair
    {
        public int f, s;
    }

    class GreyCode
    {
        private int cnt { get; set; }
        private int[] a;
        private int m { get; set; }
        private Pair[] p;
        public GreyCode(int cnt, int[] a, int m, Pair[] p)
        {
            this.cnt = cnt; this.a = a; this.m = m; this.p = p;
        }
        public string[] GetAllSubstitutionResults()
        {
            string[] res = new string[m];
            int buf;
            for (int i = 0; i < m; ++i)
            {
                //Производим перестановку и проверяем последовательность
                buf = a[p[i].f]; a[p[i].f] = a[p[i].s]; a[p[i].s] = buf;
                res[i] = (Check() ? "Yes" : "No");
            }
            return res;
        }

        private int l; //Левый сосед
        private int xor;
        private double logXor;
        private const double e = 0.000001;

        private bool Check() //Проверка текущей последовательности на код Грея
        {
            for (int i = 0; i < cnt; ++i)
            {
                //Достаточно проверять только левых соседей. Остальные проверки избыточны
                l = i > 0 ? i - 1 : cnt - 1;
                xor = a[l] ^ a[i]; logXor = Math.Log(xor, 2);
                if (Math.Abs(Math.Round(logXor) - logXor) > e) return false;
                //r = i == cnt - 1 ? 0 : i + 1;
                //xor = a[r] ^ a[i]; logXor = Math.Log(xor, 2);
                //if (Math.Abs(Math.Round(logXor) - logXor) > e) return false;
            }
            return true;
        }
    }
}
