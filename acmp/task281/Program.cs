using System;
using System.IO;
using System.Text;

namespace task281
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("INPUT.TXT");
            StreamWriter sw = new StreamWriter("OUTPUT.TXT");
            string[] s = sr.ReadLine().Split();
            sr.Close();
            int n = int.Parse(s[0]), m = int.Parse(s[1]);
            int cnt = 1;
            for (int i = m; i < n; ++i)
                cnt += fact(n) / (fact(i) * fact(n- i));
            sw.Write(cnt);
            sw.Close();
        }
        static int fact(int n)
        {
            int res = 1;
            for (int i = 2; i <= n; ++i)
                res *= i;
            return res;
        }
    }
}
