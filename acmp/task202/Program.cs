using System;
using System.IO;
using System.Collections.Generic;
using System.Text;


namespace task202
{
    class Program
    {

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string str = sr.ReadLine();
            string s = sr.ReadLine();
            sr.Close();
            StreamWriter sw = new StreamWriter("output.txt");
            StrPos sp = new StrPos(str, s);
            sw.Write(sp.FindAllSubStrPos());
            sw.Close();
        }

    }

    class StrPos
    {
        public StrPos(string sourseStr, string subStr)
        {
            txt = sourseStr;
            s = subStr;
        }

        private string txt;
        private string s;
        private string kmp;
        private int kmpL;
        int n, m;
        private int[] pref; // Массив значений префиксов
        public string FindAllSubStrPos()
        {
            List<int> pos = new List<int>();
            int i, j;
            n = s.Length; m = txt.Length;
            kmp = s + "#" + txt; //Образуем строку по алгоритму Кнута-Морриса-Пратта
            kmpL = kmp.Length; pref = new int[kmpL]; pref[0] = 0; for (i = 1; i < kmpL; ++i) pref[i] = -1;
                for (i = 0; i < kmpL; ++i)
                {
                    Prefix(i);
                    if ((i > n) && (pref[i] == n))
                        pos.Add(i - n - n);
                }


            StringBuilder sb = new StringBuilder();
            for (i = 0; i < pos.Count; ++i)
            {
                sb.Append(pos[i] + " ");
            }
            return sb.ToString();
        }
        private int Prefix(int p)// Префикс функция от строки длиной p + 1
        {
            if (p == 0) return 0;
            int j = pref[p - 1];
            while ((j > 0) && (kmp[j] != kmp[p]))
            {
                j = pref[j-1];
            }
            if (kmp[j] == kmp[p])
                j++;

            pref[p] = j;
            return j;
        }

    }
}
