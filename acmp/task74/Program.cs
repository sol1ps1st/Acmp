using System;
using System.Collections.Generic;
using System.IO;

namespace task74
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            int n, m;
            string[] s = sr.ReadLine().Split();
            n = int.Parse(s[0]); m = int.Parse(s[1]);
            sr.Close();
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(FindMPos(n, m));
            sw.Close();
        }

        static int FindMPos(int n, int m)
        {
            int N = n;
            int d = 0, buf;
            if (n == 1) return 1;
            int start = 2, startNext = 2; // Начинаем удалять элементы начиная со второго
            while (n > 1)
            {
                if (start == 2) //Если начинаем со второго
                {
                    if (m % 2 == 0) //Четный элемент удалится на текущем проходе
                        break;
                    if (n % 2 != 0) //количество элементов нечетное
                        startNext = 1; // На следующей итерации начнем с 1
                }
                else if (start == 1)
                {
                    if (m % 2 != 0) //Нечетный элемент удалится на текущем проходе
                        break;
                    if (n % 2 != 0)
                        startNext = 2; // На следующей итерации начнем с 2
                }

                if (start == 2)
                    m = (m + 1) / 2;
                else
                    m = m / 2;

                if (start == 1 && n % 2 != 0)
                    buf = n / 2 + 1;
                else
                    buf = n / 2;
                n -= buf;
                d += buf;

                start = startNext;
            }
            if (n == 1) return N;

            if (start == 2)
                d += m / 2;
            else
                d += (m + 1) / 2;
            return d;
        }
    }
}
