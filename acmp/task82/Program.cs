using System;
using System.IO;

namespace task82
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
            int[] arN = new int[n];
            for (int i = 0; i < n; ++i)
                arN[i] = int.Parse(s[i]);
            GC.Collect();
            string[] s1 = sr.ReadLine().Split();
            sr.Close();
            int[] arM = new int[m];
            for (int i = 0; i < m; ++i)
                arM[i] = int.Parse(s1[i]);
            GC.Collect();
            //string res = SetCross(n, m, arN, arM);
            //sw.Write(res);
            SetCross(n, m, arN, arM, sw);
            sw.Close(); 
        }
        //private static string SetCross(int n, int m, int[] arN, int[] arM) //Slow
        //{
        //    Array.Sort(arN);
        //    Array.Sort(arM);

        //    int lastIndex = -1;
        //    int startPos = 0;
        //    StringBuilder res = new StringBuilder();
        //    for (int i = 0; i < n; ++i)
        //    {
        //        lastIndex = Array.IndexOf(arM, arN[i], startPos);
        //        if (lastIndex != -1)
        //        {
        //            res.Append(arN[i] + " ");
        //            startPos = lastIndex + 1;
        //            for (int j = startPos; (j < m) && (arM[j] == arN[i]); ++j)
        //                startPos++;
        //        }
        //    }
        //    return res.ToString().TrimEnd();
        //}
        private static void SetCross(int n, int m, int[] arN, int[] arM, StreamWriter sw) //Fast but use a lot of memory
        {
            const int maxCount = 300000;
            int[] a = new int[maxCount];
            int i;
            for (i = 0; i < n; ++i) a[arN[i]] = 1;
            for (i = 0; i < m; ++i)
                if (a[arM[i]] == 1) a[arM[i]] = 2;
            //StringBuilder res = new StringBuilder();
            for (i = 0; i < maxCount; ++i)
                if(a[i] == 2)
                {
                    //res.Append(i); res.Append(" ");
                    sw.Write(i); sw.Write(" ");
                }
            //return res.ToString().TrimEnd();
        }
    }
}
