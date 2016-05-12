using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace task415
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string f = sr.ReadLine(); string s = sr.ReadLine();
            sr.Close();
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(MinStr(f, s));
            sw.Close();
        }

        static string MinStr(string f, string s)
        {
            int fL = f.Length; int sL = s.Length;
            if (f == s) return f;
            int minL;

            if (fL < sL)
            {
                minL = fL;
                int pos = s.IndexOf(f, StringComparison.OrdinalIgnoreCase);
                if (pos != -1)
                {
                    pos += fL - 1;
                    char c = s[pos + fL -1];
                    return s.Remove(pos, 1).Insert(pos, c.ToString().ToUpper());
                }
            }
            else
            {
                minL = sL;
                int pos = f.IndexOf(s, StringComparison.OrdinalIgnoreCase);
                if (pos != -1)
                {
                    pos += sL - 1;
                    char c = f[pos];
                    return f.Remove(pos, 1).Insert(pos, c.ToString().ToUpper());
                }
            }

            int fsCount = 0, sfCount = 0;
            for (int i = 1; i <= minL; ++i)
            {
                if (f.Substring(fL - i, i).ToUpper() == s.Substring(0, i).ToUpper())
                    fsCount = i;
                if (s.Substring(sL - i, i).ToUpper() == f.Substring(0, i).ToUpper())
                    sfCount = i;
            }

            if (fsCount > sfCount)
                return f.Substring(0, fL - fsCount) + s[0].ToString().ToUpper() + s.Substring(1);
            else if (fsCount < sfCount)
                return s.Substring(0, sL - sfCount) + f[0].ToString().ToUpper() + f.Substring(1);
            else
            {
                string resF = f.Substring(0, fL - fsCount) + s[0].ToString().ToUpper() + s.Substring(1);
                string resS = s.Substring(0, sL - sfCount) + f[0].ToString().ToUpper() + f.Substring(1);
                return String.CompareOrdinal(resF, resS) < 0 ? resF : resS;

            }
        }
    }
}
