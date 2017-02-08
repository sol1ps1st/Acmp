using System;
using System.Collections.Generic;
using System.IO;

namespace task476
{
    class Program
    {
        private static int r, c;
        private static int[,] f;
        static void Main(string[] args)
        {
            
            StreamReader sr = new StreamReader("input.txt");
            string[] str = sr.ReadLine().Split();
            r = int.Parse(str[0]);
            c = int.Parse(str[1]);
            sr.Close();
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(WinnerNum());
            sw.Close();
        }

        private static int WinnerNum()
        {
            f = new int[r, c];
            f[0, 0] = -1;
            int i;
            for (i = 0; i < r; ++i) f[i, 0] = 1;
            for (i = 0; i < c; ++i) f[0, i] = 1;
            for (i = 0; (i < c) && (i < r); ++i) f[i, i] = 1;
            if (Calc(r - 1, c - 1) == -1)
                return 2;
            else
                return 1;
        }

        private static int Calc(int row, int col)
        {
            if (f[row, col] != 0) return f[row, col];
            int i, j;
            //Проверяем столбец снизу от позиции (row, col)
            for (i = row - 1; i >= 0; --i)
                if (Calc(i, col) == -1) return 1;

            //Проверяем строку слева от позиции (row, col)
            for (j = col - 1; j >= 0; --j)
                if (Calc(row, j) == -1) return 1;

            //Проверяем диагональ от позиции (row, col)
            i = row - 1; j = col - 1;
            while ((i >= 0) && (j >= 0))
            {
                if (Calc(i, j) == -1) return 1;
                --i; --j;
            };

            return -1;
        }
    }
}
