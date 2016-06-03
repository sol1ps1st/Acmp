using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace task458
{
    class Program
    {
        private static int lineCnt;
        private static int[] linesOrder;
        private static string source;

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt", Encoding.GetEncoding(1251));
            lineCnt = int.Parse(sr.ReadLine());
            linesOrder = new int[lineCnt];
            string[] s = sr.ReadLine().Split();
            for (int i = 0; i < lineCnt; ++i)
                linesOrder[i] = int.Parse(s[i]);
            source = sr.ReadLine();
            sr.Close();
            FileStream fs = new FileStream("output.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251));
            sw.Write(EnCript());
            sw.Close();
        }

        private static string EnCript()
        {
            StringBuilder  sb = new StringBuilder(lineCnt);
            int strL = source.Length;
            int smallLinesLen = strL / lineCnt; //Длина строк, в которых последний символ не заполнен
            int fullLinesCnt = strL - smallLinesLen * lineCnt; //Количество строк, в которых есть символы на всех позициях. Эти строки находятся вверху прямоугольника
            int i; int pos = 0;
            string[] lines = new string[lineCnt];
            for (i = 0; i < lineCnt; ++i)
            {
                if (linesOrder[i] <= fullLinesCnt)
                {
                    lines[linesOrder[i] - 1] = source.Substring(pos, smallLinesLen + 1); // Строка - полная
                    pos += smallLinesLen + 1;
                }
                else
                {
                    lines[linesOrder[i] - 1] = source.Substring(pos, smallLinesLen); // Строка - не полная
                    pos += smallLinesLen;
                }
            }

            for (i = 0; i < strL; ++i)
            {
                sb.Append(lines[i % lineCnt][i / lineCnt]);
            }
            return sb.ToString();
        }
    }
}
