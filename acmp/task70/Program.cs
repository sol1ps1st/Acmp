using System;
using System.IO;

namespace task70
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string str = sr.ReadLine();
            int k = int.Parse(sr.ReadLine());
            sr.Close();
            StreamWriter sw = new StreamWriter("output.txt");
            //sw.Write(StringPow(str, k));
            StringPow(str, k, sw);
            sw.Close();
        }

        private const string No = "NO SOLUTION";
        private const int MaxLen = 1023;
        static void StringPow(string str, int k, StreamWriter sw)
        {
            //string res = null;
            int strLen = str.Length;
            if (k > 0)
            {
                //StringBuilder sb = new StringBuilder();
                //for (int i = 0; i < k; ++i)
                //    sb.Append(str);
                //res = sb.ToString();
                int count = 0;
                for (int i = 0; i < k; ++i)
                {
                    if ((count + 1) * strLen > MaxLen)
                    {
                        sw.Write(str.Substring(0, MaxLen - count * strLen));
                        return;
                    }
                    sw.Write(str);
                    count++;
                }
            }
            else
            {
                k = -k;
                if (strLen % k != 0) { NoSolution(sw); return; }
                int resLen = strLen / k;
                int i, j;
                for (i = 1; i < k; ++i)
                {
                    for (j = 0; j < resLen; ++j)
                        if (str[i * resLen + j] != str[j]) { NoSolution(sw); return; }
                }
                //res = str.Substring(0, resLen);
                sw.Write(str.Substring(0, Math.Min(resLen, MaxLen)));
            }
            //if (res.Length <= MaxLen)
            //    return res;
            //else
            //    return res.Substring(0, MaxLen);
        }

        private static void NoSolution(StreamWriter sw)
        {
            sw.Write(No);
        }
    }
}
