using System;
using System.IO;
using System.Collections.Generic;


namespace task292
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            uint n = uint.Parse(sr.ReadLine());
            sr.Close();
            uint r = SimpleRoot(n);
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(r);
            sw.Close();
        }

        private static uint SimpleRoot(uint n)
        {
            if (IsSimple(n)) return n;
            if (n < 10) return 0;
            uint sum = 0; uint buf;
            while (n > 0)
            {
                buf = n / 10;
                sum += n - buf * 10;
                n = buf;
            }
            return SimpleRoot(sum);
        }

        private static bool IsSimple(uint n)
        {
            if (n == 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            uint max = (uint)Math.Ceiling(Math.Sqrt(n));
            for (uint i = 3; i <= max; i+=2)
                if (n % i == 0) return false;
            return true;
        }
    }
}
