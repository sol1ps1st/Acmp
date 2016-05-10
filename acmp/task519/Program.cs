using System;
using System.IO;
using System.Collections.Generic;

namespace task519
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            int n = int.Parse(sr.ReadLine());
            sr.Close();
            int min, max;
            MinMax(n, out min, out max);
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(min.ToString() + " " + max.ToString());
            sw.Close();
        }

        static void MinMax(int n, out int min, out int max)
        {
            List<int> digits = new List<int>();
            while (n > 0)
            {
                digits.Add(n - (n / 10) * 10);
                n /= 10;
            }

            min = max = 0;
            digits.Sort();
            int i;
            for (i = digits.Count-1; i >= 0; --i)
                max += (digits[i] * (int)Math.Pow(10, i));

            int firstNotNullEl = 0;// Не можем начать число с 0. Соответственно, ищем первый ненулевой элемент и ставим его на 1 место
            while ((digits[firstNotNullEl] == 0) && (firstNotNullEl < digits.Count))
                firstNotNullEl++;

            if (firstNotNullEl != 0)
            {
                int tmp = digits[firstNotNullEl];
                digits[firstNotNullEl] = 0;
                digits[0] = tmp;
            }
            for (i = 0; i < digits.Count; ++i)
                min += (digits[i] * (int)Math.Pow(10, digits.Count - 1 - i));
        }
    }
}
