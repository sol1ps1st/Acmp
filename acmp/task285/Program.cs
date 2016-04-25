using System;
using System.IO;

namespace task285
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("INPUT.TXT");
            StreamWriter sw = new StreamWriter("OUTPUT.TXT");
            int n, m;
            string[] s = sr.ReadLine().Split();
            n = int.Parse(s[0]);
            m = int.Parse(s[1]);
            s = sr.ReadLine().Split();
            sr.Close();
            n = s.Length;
            int[] ar = new int[n];
            for (int i = 0; i < s.Length; ++i)
                ar[i] = int.Parse(s[i]);
            string res = Fireplace(n, m, ar);
            sw.WriteLine(res);
            sw.Close(); 
        }
        static string Fireplace(int n, int m, int[] ar)
        {
            int i, maxTime = 0;
            int maxEl = ar[0];
            for (i = 0; i < n; ++i)
            {
                maxTime += ar[i];
                if (ar[i] > maxEl) maxEl = ar[i];
            }
            maxTime -= (n - 1); //Максимально долгое горение костра
            if ((maxTime < m) || (maxEl > m))
                return "no";
            return "yes";
        }

    }
}
