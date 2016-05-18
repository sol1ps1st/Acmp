using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace task698
{
    class Program
    {
        private static List<Card> peter = new List<Card>();
        private static List<Card> dude = new List<Card>();

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt",Encoding.GetEncoding(1251));
            int n, m;
            string major;
            string[] s = sr.ReadLine().Split();
            n = int.Parse(s[0]); m = int.Parse(s[1]); major = s[2];

            s = sr.ReadLine().Split(); //Peter's cards
            foreach (string c in s)
            {
                Card tmp = new Card(RangToInt(c[0].ToString()), c[1].ToString(), c[1].ToString() == major);
                peter.Add(tmp);
            }

            s = sr.ReadLine().Split(); //Dude's cards
            //s[0] = sr.ReadLine();
            foreach (string c in s)
            {
                Card tmp = new Card(RangToInt(c[0].ToString()), c[1].ToString(), c[1].ToString() == major);
                dude.Add(tmp);
            }
            sr.Close();

            StreamWriter sw = new StreamWriter("output.txt");
            if (Check())
                sw.Write("YES");
            else
                sw.Write("NO");
            sw.Close();
        }

        private static bool Check()
        {
            int i; Card bigger;
            for (i = 0; i < dude.Count; ++i)
            {
                bigger = GetBiggerCard(dude[i]);
                if (bigger == null) return false;
                peter.Remove(bigger);
            }
            return true;
        }

        private static Card GetBiggerCard(Card dudeCard)
        {
            int i; Card min = null;
            for (i = 0; i < peter.Count; ++i)
                if ((peter[i].Mast == dudeCard.Mast) && (peter[i].Rang > dudeCard.Rang))
                {
                    if (min == null) min = peter[i];
                    else if (min.Rang > peter[i].Rang) min = peter[i];
                }
            if (min != null) return min; //Минимальня карта, большая dudeCard тойже масти
            else //Не нашли карту тойже масти, ищем среди козырных
            {
                if (dudeCard.Major) return null;
                for (i = 0; i < peter.Count; ++i)
                    if (peter[i].Major)
                    {
                        if (min == null) min = peter[i];
                        else if (min.Rang > peter[i].Rang) min = peter[i];
                    }
                return min;
            }
        }

        private static int RangToInt(string r)
        {
                if ((r == "T") || (r == "Т")) return 10;
                if (r == "J") return 11;
                if (r == "Q") return 12;
                if ((r == "K") || (r == "К")) return 13;
                if ((r == "A") || (r == "А")) return 14;
                return int.Parse(r);
        }
    }

    class Card
    {
        public int Rang { get; set; }
        public string Mast { get; set; }
        public bool Major { get; set; }
        public Card(int r, string m, bool major)
        {
            Rang = r;
            Mast = m;
            Major = major;
        }

        //public int CompareTo(Card other)
        //{
        //    if ((Major) && (!other.Major))  return 1;
        //    if ((!Major) && (other.Major)) return -1;

        //    return 0;
        //}
    }


}
