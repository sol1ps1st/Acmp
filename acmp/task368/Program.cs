using System;
using System.IO;
using System.Text;

namespace task368
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("INPUT.TXT");
            StreamWriter sw = new StreamWriter("OUTPUT.TXT");
            int i, j, n = int.Parse(sr.ReadLine());
            string s; int[,] a = new int[n, n]; int sLen;
            for (i = 0; i < n; ++i)
            {
                s = sr.ReadLine(); sLen = s.Length;
                for (j = 0; j < sLen; ++j)
                    a[i, j] = int.Parse(s.Substring(j, 1)); 
            }
            sr.Close();
            Path p = new Path(n, a);
            bool[,] res = p.FindPath();
            StringBuilder sb = new StringBuilder();
            for (i = 0; i < n; ++i)
            {
                for (j = 0; j < n; ++j)
                    sb.Append(res[i, j] ? "#" : ".");
                sb.Append(Environment.NewLine);
            }
            sw.Write(sb.ToString());
            sw.Close(); 
        }
    }

    class Path
    {
        public Path(int n, int[,] a)
        {
            this.n = n;
            this.a = a;
            c = new int[n, n];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    c[i, j] = -1;
            res = new bool[n, n];
        }
        ~Path()
        {
        }

        private int n;
        private int[,] a, c;
        private bool [,] res;

        public bool[,] FindPath()
        {
            c[0, 0] = a[0, 0];
            int row = n - 1, col = n - 1;
            res[row, col] = res[0, 0] = true;
            c[row, col] = PerfomPath(n - 1, n -1);
            //Теперь найдена вся матрица с. cij- стоимость движения из (i,j) в (0,0)
            bool top, left;
            while ((row != 0) || (col != 0))
            {
                top = row - 1 >= 0; left = col - 1 >= 0;
                if (top && left)
                {
                    if (c[row - 1, col] <= c[row, col - 1])
                        row--;
                    else
                        col--;
                    res[row, col] = true;
                }
                else if (top)
                {
                    row--; res[row, col] = true;
                }
                else if (left)
                {
                    col--;
                    res[row, col] = true;
                }
            }
            return res;
        }
        private int PerfomPath(int row, int col)
        {
            if (c[row, col] != -1) return c[row, col];
            bool top = row - 1 >= 0; bool left = col - 1 >= 0;
            if (left && top)
            {
                c[row - 1, col] = PerfomPath(row - 1, col);
                c[row, col - 1] = PerfomPath(row, col - 1);
                c[row, col] = Math.Min(c[row - 1, col], c[row, col - 1]) + a[row, col];
            }
            else if (top)
            {
                c[row - 1, col] = PerfomPath(row - 1, col);
                c[row, col] = c[row - 1, col] + a[row, col];
            }
            else if(left)
            {
                c[row, col - 1] = PerfomPath(row, col - 1);
                c[row, col] = c[row, col - 1] + a[row, col];
            }
            return c[row, col];
        }
    }
}
