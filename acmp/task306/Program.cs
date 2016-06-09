using System;
using System.IO;
using System.Text;

namespace task306
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            int n = int.Parse(sr.ReadLine());
            sr.Close();
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(Girls(n));
            sw.Close();
        }

        private static string Girls(int n)
        {
            if (n == 1) return "B";
            if (n == 2) return "BR";
            if (n == 3) return "BBR";
            bool[] g = new bool[n]; //Пусть синяя юбка - true, а красная - false
            //Заполняем нечетные позиции
            int i;
            bool skirt = true; //Начинаем с синей
            for (i = 0; i < n; i+=2)
            {
                g[i] = skirt;
                skirt = !skirt;
            }

            bool cross = true; //Признак того, была ли "вычеркнута" предыдущая девушка. Если n - нечетное, то последняя девушка в исходной строке будет вычеркнута, а затем
            //нам надо заполнять пропуски на местах 1, 3, ...
            if (n % 2 == 0) //Если n - четное, то последнее число не заполнится. Продолжаем заполнять с него
            {
                g[n - 1] = g[n - 2];
                cross = false; //Заполнили последнюю девушку, но она вычеркнута сразу не будет! Надо вычеркивать следующую (на пустом пока месте 1)
            }
            skirt = g[n-1]; //Последняя заполненная
            for (i = 1; i < n-1; i += 2)
            {
                if (cross)
                {
                    g[i] = skirt;//Если последняя была вычеркнута, то надо добавить такую же юбку поскольку она перенесется в конец строки
                    cross = false;//Теперь последняя не вычеркнута
                }
                else
                {
                    g[i] = !skirt;//Если последняя не вычеркнута, то надо добавить другую юбку поскольку она вычеркнется следующей
                    skirt = g[i];
                    cross = true;
                }
            }
            StringBuilder sb = new StringBuilder(n);
            for (i = 0; i < n; ++i)
                sb.Append(g[i] ? 'B' : 'R');
            return sb.ToString();
        }
    }
}
