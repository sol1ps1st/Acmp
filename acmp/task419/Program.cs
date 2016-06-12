using System;
using System.IO;
using System.Collections.Generic;

namespace task419
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string s = sr.ReadLine().Replace(" ", "").Replace(",", "").Replace(".", "").Replace("!", "").Replace("?", "").ToLower();
            sr.Close();
            StreamWriter sw = new StreamWriter("output.txt");
            bool res = false;
            string palindrom = GetPalindrom(s, ref res);
            if (res)
                sw.WriteLine("YES");
            sw.Write(palindrom);
            sw.Close();
        }

        static string GetPalindrom(string s, ref bool result)
        {
            result = true;
            int pos = 0, tmp = 0;
            bool res = IsPalindrom(s, ref pos);
            if (res) return s;

            try
            {
                //Пробуем удалить букву справа
                if (s[pos] == s[s.Length - 2 - pos]) //После удаления буква в позиции pos совпадет с симметричной буквой с другого конца. Имеет смысл попробовать удалить
                    if (IsPalindrom(s.Remove(s.Length - 1 - pos, 1), ref tmp))
                        return s.Remove(s.Length - 1 - pos);

                //Пробуем удалить букву слева
                if (s[pos + 1] == s[s.Length - 1 - pos])
                    if (IsPalindrom(s.Remove(pos, 1), ref tmp))
                        return s.Remove(pos,1 );

                //Пробуем заменить букву на соседа
                string buf = s.Insert(pos, s[s.Length - 1 - pos].ToString()).Remove(pos + 1, 1);
                if (IsPalindrom(buf, ref tmp))
                    return buf;

                //Пробуем вставить в pos соседнюю букву
                buf = s.Insert(pos, s[s.Length - 1 - pos].ToString());
                if (IsPalindrom(buf, ref tmp))
                    return buf;

                //Пробуем вставить соседнюю букву справа
                buf = s.Insert(s.Length - 1 - pos, s[pos].ToString());
                if (IsPalindrom(buf, ref tmp))
                    return buf;
            }
            catch
            {
            }
            result = false;
            return "NO";
        }
        static bool IsPalindrom(string s, ref int errorPos)
        {
            int l = s.Length;
            for (int i = 0; i < l; ++i)
            {
                if (s[i] != s[l - 1 - i])
                {
                    errorPos = i;
                    return false;
                }
            }
            return true;
        }
    }
}
