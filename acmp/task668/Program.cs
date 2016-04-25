using System;
using System.IO;
using System.Text;

namespace task668
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("INPUT.TXT");
            StreamWriter sw = new StreamWriter("OUTPUT.TXT");
            int h, t;
            string[] s = sr.ReadLine().Split();
            h = Convert.ToInt32(s[0]);
            t = Convert.ToInt32(s[1]);
            int res = Gorinich(h, t);
            sw.WriteLine(res);
            sr.Close();
            sw.Close(); 
        }
        static int Gorinich(int h, int t)
        {
            if (t == 0)
            {
                if (h % 2 != 0) return -1;
                else
                    return h / 2;
            }

            int cnt = 0, buf;
            while (t > 2)
            {
                t -= 2;
                h++;
                cnt++;
            };

            if (h % 2 == 0)
                { cnt += (4 - t); t = 4; }//При четном кол-ве голов нужно "вырастить" 4 хвоста
            else
                { cnt += (2 - t); t = 2;} //При нечетном кол-ве голов нужно "вырастить" 2 хвоста
            buf = t / 2;
            cnt += (buf + (h + buf)/2);
            return cnt;
        }
    }
}
