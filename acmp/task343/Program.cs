using System;
using System.IO;
using System.Collections.Generic;

namespace task343
{
    class Program
    {

        private static int n, m, k;
        private static List<Command> commands = null;
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string[] s = sr.ReadLine().Split();
            n = int.Parse(s[0]); m = int.Parse(s[1]);
            k = int.Parse(sr.ReadLine());
            commands = new List<Command>(k);
            for (int i = 0; i < k; ++i)
            {
                s = sr.ReadLine().Split();
                commands.Add(new Command(int.Parse(s[0]), int.Parse(s[2]), int.Parse(s[1])));
            }
            sr.Dispose();
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(Square());
            sw.Dispose();
        }

        private static int Square()
        {
            bool[,] f = new bool[m, n]; //Пол под плитку
            int res = 0; //Площадь, покрытая плиткой
            int i, j, l;
            for (l = 0; l < k; ++l)
            {
                TryTile(f, commands[l]);
            }
            for (i = 0; i < m; ++i)
                for (j = 0; j < n; ++j)
                    if (f[i, j]) res++;
            return res;
        }

        private static void TryTile(bool[,] f, Command c)
        {
            c.x--; c.y--;
            if (c.type == 1)
            {
                if ((f[c.x + 1, c.y]) || (f[c.x, c.y + 1]) || (f[c.x + 1, c.y + 1]))
                    return;
                else
                    f[c.x + 1, c.y] = f[c.x, c.y + 1] = f[c.x + 1, c.y + 1] = true;
            }
            else if (c.type == 2)
            {
                if ((f[c.x, c.y]) || (f[c.x, c.y + 1]) || (f[c.x + 1, c.y + 1]))
                    return;
                else
                    f[c.x, c.y] = f[c.x, c.y + 1] = f[c.x + 1, c.y + 1] = true;
            }
            else if (c.type == 3)
            {
                if ((f[c.x, c.y]) || (f[c.x + 1, c.y]) || (f[c.x + 1, c.y + 1]))
                    return;
                else
                    f[c.x, c.y] = f[c.x + 1, c.y] = f[c.x + 1, c.y + 1] = true;
            }
            else
            {
                if ((f[c.x, c.y]) || (f[c.x + 1, c.y]) || (f[c.x, c.y + 1]))
                    return;
                else
                    f[c.x, c.y] = f[c.x + 1, c.y] = f[c.x, c.y + 1] = true;
            }
        }
    }

    class Command
    {
        public int type, x, y;
        public Command(int type, int x, int y)
        {
            this.type = type;
            this.x = x;
            this.y = y;
        }
    }

}
