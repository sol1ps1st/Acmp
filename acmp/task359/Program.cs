using System;
using System.Collections.Generic;
using System.IO;

namespace task359
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("INPUT.TXT");
            StreamWriter sw = new StreamWriter("OUTPUT.TXT");
            int n = int.Parse(sr.ReadLine());
            sr.Close();
            sw.Write(GetNumber(n));
            //sw.Write(NumberWithout0(n));
            sw.Close();
        }

        static long GetNumber(int n)
        {
            if (n <= 2) return n;
            long res = 2;
            for (int i = 3; i <= n; ++i)
            {
                if (i % 2 == 0)
                    res += i - 1;
                else
                    res += i;
            }
            return NumberWithout0(res);
        }

        private static long NumberWithout0(long num) //Исключить числа, оканчивающиеся на 0
        {
            List<string> resParts = new List<string>();
            resParts.Add(num.ToString());
            long rest = num / 10;
            while (rest > 0)
            {
                resParts.Add(rest.ToString());
                rest /= 10;
            }
            string res = resParts[resParts.Count - 1];
            for (int i = resParts.Count - 2; i >= 0; i--)
                res = Add2Numbers(res, resParts[i]);
            return Convert.ToInt64(res);
        }

        private static string Add2Numbers(string f, string s) //Складываем 2 числа в столбик, учитывая, что 10 преобразуется в 1 и перенос разряда для самого младшего (правого) разряда
        {
            string res = "";
            int digits = f.Length;
            if (s.Length > digits) digits = s.Length;
            int buf = 0;
            bool over = false; //признак переноса разряда
            for (int d = 0; d < digits; ++d) //Цикл от младших (правее) разрядов числа к старшим
            {
                if (f.Length > d)
                    buf = int.Parse(f.Substring(f.Length - 1 - d, 1));
                else
                    buf = 0;
                if (s.Length > d)
                     buf += int.Parse(s.Substring(s.Length - 1 - d, 1));
                if ((d == 0) && (buf > 9))
                    buf++; // Переход через 10
                if (over) buf++;
                if (buf > 9) 
                {
                    over = true;
                    buf = buf % 10; //Последняя цифра
                }
                else
                    over = false;
                res = buf.ToString() + res;
            }
            if (over) res = "1" + res; //Добавляем слева еще один разряд если после вычислений остался перенос разряда
            return res;
        }
    }
}
