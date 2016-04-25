using System;
using System.IO;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("INPUT.TXT");
            StreamWriter sw = new StreamWriter("OUTPUT.TXT");
            string[] s = sr.ReadLine().Split();
            sw.WriteLine(int.Parse(s[0]) + int.Parse(s[1]));
            sr.Close();
            sw.Close(); 
        }
    }
}
