using System;
using System.Collections.Generic;
using System.IO;

namespace task269
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            Break f = new Break(sr.ReadLine());
            Break s = new Break(sr.ReadLine());
            sr.Close();
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(GetMinBreakLen(f,s));
            sw.Close();
        }

        private static int GetMinBreakLen(Break f, Break s)
        {
            //пробуем смещать первую пластину относительно второй
            int shift, res = f.Count() + s.Count(), tmp = 0;
            for (shift = 0; shift < s.Count() - 1; ++shift)
            {
                if (IsMerge(f, shift, s, ref tmp))
                    res = res < tmp ? res : tmp;
            }
            //пробуем смещать вторую пластину относительно первой
            for (shift = 0; shift < f.Count() - 1; ++shift)
            {
                if (IsMerge(s, shift, f, ref tmp))
                    res = res < tmp ? res : tmp;
            }

            return res;
        }

        private static bool IsMerge(Break f, int fShift, Break s, ref int len)
        {
            int maxIdx = Math.Min(s.Count() - fShift, f.Count());
            for(int i = 0; i < maxIdx; ++i)
            {
                if (f[i] + s[i+ fShift] > 3) return false;
            }
            len = Math.Max(s.Count(), f.Count() + fShift);
            return true;
        }

    }
}
