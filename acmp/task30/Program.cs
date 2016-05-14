using System;
using System.IO;

namespace task30
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string s = sr.ReadLine();
            Clock start = new Clock(int.Parse(s.Substring(0, 2)), int.Parse(s.Substring(3, 2)), int.Parse(s.Substring(6, 2)));
            s = sr.ReadLine();
            Clock end = new Clock(int.Parse(s.Substring(0, 2)), int.Parse(s.Substring(3, 2)), int.Parse(s.Substring(6, 2)));
            sr.Close();
            GetDigCount(start, end);
            StreamWriter sw = new StreamWriter("output.txt");
            foreach(int i in cnt)
                sw.WriteLine(i);
            sw.Close();
        }

        private static int[] cnt = new int[10];

        public static void GetDigCount(Clock s, Clock e)
        {
            string str; int i; int[] parts = new int[3];
            while (true)
            {
                parts[0] = s.S; parts[1] = s.M; parts[2] = s.H;
                foreach (int p in parts)
                {
                    str = p.ToString("D2");
                    i = int.Parse(str.Substring(0, 1)); cnt[i]++;
                    i = int.Parse(str.Substring(1, 1)); cnt[i]++;
                }
                if (s.Equals(e)) break;
                s.Tick();
            };
        }
    }



    class Clock
    {
        public int H { get; set; }
        public int M { get; set; }
        public int S { get; set; }

        public Clock(int h, int m, int s)
        {
            H = h;
            M = m;
            S = s;
        }

        public void Tick()
        {
            if (S == 59)
            {
                S = 0;
                if (M == 59)
                {
                    M = 0;
                    if (H == 23)
                        H = 0;
                    else
                        H++;
                }
                else
                    M++;
            }
            else
                S++;
        }

        public override bool Equals(Object rhs)
        {
            if (rhs is Clock)
                return ((H == (rhs as Clock).H) && (M == (rhs as Clock).M) && (S == (rhs as Clock).S));
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
