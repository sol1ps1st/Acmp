using System;
using System.Collections.Generic;
using System.IO;

namespace task228
{
    class Program
    {
        static double Round(double value, int digits)
        {
            double scale = Math.Pow(10.0, digits);
            double round = Math.Floor(Math.Abs(value) * scale + 0.5);
            return (Math.Sign(value) * round / scale);
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("INPUT.TXT");
            int n = int.Parse(sr.ReadLine());
            double[,] q = new double[n,2];
            int i; 
            List<string> quotes = new List<string>(n);
            for (i = 0; i < n; ++i)
                quotes.Add(sr.ReadLine());
            sr.Close();
            string[] s = null;
            for (i =0; i < n; ++i)
            {
                s = quotes[i].Split();
                q[i,0] = float.Parse(s[0].Replace(".", ",")); //$
                q[i, 1] = float.Parse(s[1].Replace(".", ",")); //Euro
            }
            Speculations sp = new Speculations(n, q, 100);
            double res = sp.MaxResultRub(); res = Round(res, 2);
            StreamWriter sw = new StreamWriter("OUTPUT.TXT");
            sw.Write(res.ToString("F2").Replace(",", "."));
            sw.Close();
        }

        //static double MaxProfit(int n, double[,] q, double startRub)
        //{
        //    double rub = startRub, eur = 0, usd = 0, usdDif = 0, eurDif = 0;
        //    int i;
        //    for (i = 0; i < n -1; ++i)
        //    {
        //        usdDif = q[i + 1, 0] - q[i, 0];
        //        eurDif = q[i + 1, 1] - q[i, 1];
        //        if (Math.Max(usdDif, eurDif) > 0 )//Максимальное изменение курса со следующим днем больше 0, значит надо конвертировать сегодня в валюту
        //        {
        //            if (usdDif > eurDif)
        //            {
        //                if (rub > 0) { usd = rub / q[i, 0]; rub = 0; }//Из rub в usd
        //                else if (eur > 0) { usd = (eur * q[i, 1]) / q[i, 0]; eur = 0; }//Из eur в usd
        //            }
        //            else
        //                if (rub > 0) { eur = rub / q[i, 1]; rub = 0; }//Из rub в usd
        //                else if (usd > 0) { eur = (usd * q[i, 0]) / q[i, 1]; usd = 0; }//Из usd в eur
        //        }
        //        else //Переводим все в рубли чтобы не потерять при уменьшении котировок
        //        {
        //            if (usd > 0) { rub = usd * q[i, 0]; usd = 0; }//Из usd в rub
        //            else if (eur > 0) {rub = eur * q[i, 1]; eur = 0; } //Из eur в rub
        //        }
        //    }
        //    //Остался последний день. Переводим в rub
        //    if (usd > 0) rub = usd * q[i, 0]; //Из usd в rub
        //    else if (eur > 0) rub = eur * q[i, 1]; //Из eur в rub
        //    return rub;
        //}
    }
    enum Money { rub, usd, eur };
    class Speculations
    {
        private int n;
        private double[,] q;
        private double rub, eur, usd;
        public Speculations(int days, double[,] q, int strartRub)
        {
            this.n = days; this.q = q;
            rub = strartRub;
            usd = ConvertMoney(Money.rub, Money.usd, rub, 0);
            eur = ConvertMoney(Money.rub, Money.eur, rub, 0);
        }
        private double ConvertMoney(Money from, Money to, double valFrom, int d) //Сконвертировать валюту за день d
        {
            if (from == to) return valFrom;
            if (from == Money.rub)
            {
                if (to == Money.usd)
                    return valFrom / q[d,0];
                else //eur
                    return valFrom / q[d,1];
            }
            else if (from == Money.usd)
            {
                if (to == Money.rub)
                    return valFrom * q[d, 0];
                else //eur
                    return (valFrom * q[d, 0]) / q[d, 1]; //Сначала в рубли, потом в eur
            }
            else //(from = Money.eur)
            {
                if (to == Money.rub)
                    return valFrom * q[d, 1];
                else //usd
                    return (valFrom * q[d, 1]) / q[d, 0]; //Сначала в рубли, потом в usd
            }
        }
        public double MaxResultRub()
        {
            int idx;
            double[] inRub = new double[2]; //Эквивалентная сумма в рублях для валюты на следующий после текущего день. 0 - для usd, 1 - для eur
            for (int i = 1; i < n; ++i)
            {
                inRub[0] = ConvertMoney(Money.usd, Money.rub, usd, i); inRub[1] = ConvertMoney(Money.eur, Money.rub, eur, i);
                //Ищем максимум из inRub[0], inRub[1] и rub
                idx = inRub[0] > inRub[1] ? 0 : 1; // 0 - выгодно купить доллары - завтра они дадут максимальный эквивалент в рублях. 1 - eur.
                if (rub > inRub[idx])
                {
                    //Всеже наибольшая выгода если оставить деньги в рублях. Пересчитываем usd и eur
                    usd = ConvertMoney(Money.rub, Money.usd, rub, i);
                    eur = ConvertMoney(Money.rub, Money.eur, rub, i);
                }
                else if (idx == 0)
                {
                    rub = inRub[0];
                    eur = ConvertMoney(Money.rub, Money.eur, rub, i);
                }
                else if (idx == 1)
                {
                    rub = inRub[1];
                    usd = ConvertMoney(Money.rub, Money.usd, rub, i);
                }
            }
            return rub > inRub[0] ? (rub > inRub[1] ? rub : inRub[1]) : (inRub[0] > inRub[1] ? inRub[0]: inRub[1]);
        }
    }

}
