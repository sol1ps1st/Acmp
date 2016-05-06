using System;
using System.Collections.Generic;
using System.IO;

namespace task300
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string[] s; 
            int[] roketT = new int[4];
            int[] roketV = new int[4];
            int Tpov, d;
            for (int i = 0; i < 4; ++i)
            {
                s = sr.ReadLine().Split();
                roketT[i] = int.Parse(s[0]);
                roketV[i] = int.Parse(s[1]);
            }
            s = sr.ReadLine().Split();
            sr.Close();
            Tpov = int.Parse(s[0]);
            d = int.Parse(s[1]);
            Radar r = new Radar(roketT, roketV, Tpov, d);
            StreamWriter sw = new StreamWriter("output.txt");
            sw.Write(r.AtackResult());
            sw.Close();
        }
    }

    class Radar
    {
        private int[] roketT;
        private int[] roketV;
        private float[] boomT;
        private int Tpov;
        private int d;
        private float curTime; //Текущее время в сек
        private int roketPos; //Текущая сторона ближайшей ракеты 1, 2, 3 или 4
        private int guardPos; //текущая сторона щита 1, 2, 3 или 4
        //private List<int> order; //Порядок долетания ракет до щита. Вначале - индексы ракет с минимальным временем

        public Radar (int[] roketT, int[] roketV, int Tpov, int d)
        {
            this.roketT = roketT;
            this.roketV = roketV;
            this.Tpov = Tpov;
            this.d = d;
            boomT = new float[4];
        }

        private int GuardMoveTime() //Сколько потребуется времени чтобы повернуть щит в сторону ракеты
        {
            int dif = Math.Abs(roketPos - guardPos);
            dif =  Math.Min(dif, 4 - dif);
            return Tpov * dif; //поворачиваем щит dif раз
        }

        private void GetBoomTime()
        {
            for (int i = 0; i < 4; ++i)
                boomT[i] = roketT[i] + (float)d / roketV[i];
        }

        private int GetNextRoketIdx()
        {
            int i; float minTime = -1;
            int idx = -1;
            for (i = 0; i < 4; ++i)
                if (roketT[i] != -1) //Неиспользованная ракета?
                {
                    minTime = boomT[i];
                    idx = i + 1;
                }
            if (minTime == -1) return -1;
            for (i = 1; i <= 4; ++i)
                if ((boomT[i-1] != -1) && (minTime > boomT[i-1]))
                {
                    minTime = boomT[i-1];
                    idx = i;
                }
            return idx;
        }

        public string AtackResult()
        {
            int i, cnt = 0, guardTime;
            curTime = 0; //Начинаем в момент времени 0
            guardPos = 1; //Сначала защита в 1 позиции
            GetBoomTime(); //Определяем времена долетов всех ракет до радара
            while ((i = GetNextRoketIdx()) != -1)
            {
                roketPos = i; // Первой долетит ракета i
                guardTime = GuardMoveTime(); //Время установки защиты в позицию i из позиции guardPos
                if ((guardTime + curTime) <= boomT[i - 1])
                {
                    curTime = boomT[i-1]; //момент отражения ракеты
                    cnt++;
                    guardPos = roketPos;
                    roketT[i - 1] = -1; boomT[i - 1] = -1; //Эту ракету больше не использовать
                }
                else
                    break;
            }
            return cnt == 4 ? "ALIVE" : cnt.ToString();
        }
    }
}
