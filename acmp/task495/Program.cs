using System;
using System.IO;
using System.Collections.Generic;
//using System.Text;

namespace task495
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            int n = int.Parse(sr.ReadLine());
            List<Tuple<double, double>> v = new List<Tuple<double,double>>();
            string[] s;
            for (int i = 0; i < n; ++i)
            {
                s = sr.ReadLine().Split();
                Tuple<double, double> tmp = new Tuple<double,double>(double.Parse(s[0]), double.Parse(s[1]));
                v.Add(tmp);
            }
            int k = int.Parse(sr.ReadLine());
            sr.Close();

            StreamWriter sw = new StreamWriter("output.txt");
            double len = DualLen(n, k, v);
            sw.Write(len.ToString("F6").Replace(",", "."));
            sw.Close();
        }

        private static double DualLen(int n, int k, List<Tuple<double, double>> v)
        {
            List<Tuple<double, double>> newV = new List<Tuple<double, double>>(v);
            int i, j;
            for (i = 0; i < k; ++i)
            {
                for (j = 0; j < n; ++j)
                    newV[j] = Util.GetMiddlePoint(v[j], v[(j + 1) % n]);
            }
            //Ищем длину полученной ломаной
            double len = 0;
            for (j = 0; j < n; ++j)
            {
                len += Util.GetLen(newV[j], newV[(j + 1) % n]);
            }
            return len;
        }
    }

    static class Util
    {
        public static Tuple<double, double> GetMiddlePoint(Tuple<double, double> a, Tuple<double, double> b)
        {
            return new Tuple<double, double>(a.Item1 + (b.Item1 - a.Item1) / 2, a.Item2 + (b.Item2 - a.Item2) / 2);
        }

        public static double GetLen(Tuple<double, double> a, Tuple<double, double> b)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(a.Item1 - b.Item1), 2) + Math.Pow(Math.Abs(a.Item2 - b.Item2), 2));
        }
    }
}
