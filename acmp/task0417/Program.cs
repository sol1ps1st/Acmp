using System;
using System.IO;
using System.Text;

namespace task0417
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("INPUT.TXT");
            StreamWriter sw = new StreamWriter("OUTPUT.TXT");
            int k = Convert.ToInt32(sr.ReadLine());
            string res = DateShift(k);
            sw.WriteLine(res);
            sr.Close();
            sw.Close(); 
        }

        static int GetDaysCount(int year)
        {
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
                return 366;
            else
                return 365;
        }

        static string DateShift(int k)
        {
            var sourseK = k;

            int y = 2008, m = 1, d = 1, count, i;
            while (k > (count = GetDaysCount(y))) //find year
            {
                k -= count; y++;
            }
            for (i = m; i <=12; ++i) //find month
            {
                switch(i)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        count = 31;
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        count = 30;
                        break;
                    case 2:
                        count = GetDaysCount(y) == 365 ? 28 : 29;
                        break;
                }
                if (k >= count)
                {
                    k -= count; m++;
                }
                else
                {
                    break;
                }
            }
            d += k; //find day

            StringBuilder res = new StringBuilder(); //Make a result string
            string[] months = {"Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", "Monday"};
            res.Append(months[sourseK % 7]);
            res.Append(", ");
            res.Append(d > 9 ? d.ToString() : "0" + d.ToString());
            res.Append(".");
            res.Append(m > 9 ? m.ToString() : "0" + m.ToString());
            //res.Append(".");
            //res.Append(y.ToString());
            return res.ToString();
        }
    }
}
