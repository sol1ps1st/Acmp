using System;
using System.IO;
using System.Collections.Generic;

namespace task236
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string exp = sr.ReadLine();
            int x = int.Parse(sr.ReadLine());
            sr.Close();
            EvalExpression e = new EvalExpression(exp);
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(e.GetResult(x));
            sw.Close();
        }
    }

    internal class ExpPart
    {
        private bool minus;
        private string exp;
        public string Exp
        {
            get { return exp; }
            set
            {
                minus = ((value.Length > 0) && (value[0] == '-'));
                if ((value[0] == '+') || (value[0] == '-'))
                    exp = value.Substring(1).Replace("*", "");
                else
                    exp = value.Replace("*", "");
            }
        }
        public ExpPart()
        {
        }

        public ExpPart(string exp)
        {
            this.exp = exp;
        }
        public long Eval(long x)
        {
            long mul = 0, pow = 0;
            string[] s = exp.Split('x');
            if (s.Length < 2) pow = 1; //Нет части с x. Присваиваем 1 чтобы не обнулить итоговый результат.
            for (int i = 0; i < s.Length; ++i)
            {
                if (i == 0) //Множитель
                {
                    if (s[i] == "") 
                        mul = 1;
                    else
                        mul = int.Parse(s[0]);
                }
                else if (i == 1) //Все, что относится к x
                {
                    if (s[i] == "") pow = x;
                    else
                    {
                        int pos = exp.IndexOf("^");
                        pow = (int)Math.Pow((double)x, double.Parse(exp.Substring(pos + 1)));
                    }
                }
            }
            return (minus ? -1 : 1) * mul * pow;
        }
    }

    public class EvalExpression
    {
        private string exp;
        public EvalExpression(string exp)
        {
            this.exp = exp;
        }

        public long GetResult(int x)
        {
            long sum = 0;
            //Разбиваем на части выражение
            List<string> s = new List<string>();
            int i, start = 0, posM, posP, pos = 0;
            while (true)
            {
                posM = exp.IndexOf('-', start + 1);
                posP = exp.IndexOf('+', start + 1);
                if (posM == -1 && posP == -1)
                {
                    s.Add(exp.Substring(start));
                    break;
                }
                if (posM != -1)
                {
                    pos = posM;
                    if (posP != -1 && posP < pos)
                        pos = posP;
                }
                if (posP != -1)
                {
                    pos = posP;
                    if (posM != -1 && posM < pos)
                        pos = posM;
                }

                s.Add(exp.Substring(start, pos - start));
                start = pos;
            }
            ExpPart p = new ExpPart();
            for (i = 0; i < s.Count; ++i)
            {
                p.Exp = s[i];
                sum += p.Eval(x);
            }
            return sum;
        }
    }

}

