using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace task270
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string s = sr.ReadLine();
            sr.Close();
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(Synonim(s));
            sw.Close();
        }

        private static string Synonim(string s)
        {
            if (IsCName(s))
            {
                string[] parts = s.Split('_');
                StringBuilder sb = new StringBuilder();
                sb.Append(parts[0]);
                for (int i = 1; i < parts.Length; ++i)
                    sb.Append(parts[i][0].ToString().ToUpper() + parts[i].Substring(1));
                return sb.ToString();
            }
            else if (IsJavaName(s))
            {
                int i, pos = 0;
                string str = s;
                for (i = 0; i < str.Length; ++i)
                {
                    if (str[i].ToString() == str[i].ToString().ToUpper())
                    {
                        str = str.Remove(i, 1).Insert(i, "_" + str[i].ToString().ToLower());
                        pos = i;
                    }
                }
                return str;
            }
            else
                return "Error!";
        }

        private static bool IsCName(string s)
        {
            if (s != s.ToLower() || s.IndexOf(" ") != -1)
                return false;
            for (int i = 0; i < s.Length; ++i)
            {
                //int pos = s.IndexOf("_");
                if (s[i] == '_')
                {
                    if (i == s.Length - 1) return false;
                    if (s[i + 1] == s[i]) return false;
                }
            }
            
            return true;
        }
        private static bool IsJavaName(string s)
        {
            if ((s.IndexOf(" ") != -1) || (s.IndexOf("_") != -1) || (s[0].ToString().ToLower() != s[0].ToString()))
                return false;

            //int pos = s.IndexOf("_");
            //string c;
            //while (pos + 1 < s.Length && pos != -1)
            //{
            //    pos = s.IndexOf("_", pos + 1);
            //    c = s[pos + 1].ToString(); //Символ после подчеркивания должен быть большим
            //    if (c != c.ToUpper())
            //        return false;
            //}
            return true;
        }

    }
}
