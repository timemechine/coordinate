using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp3
{
    public struct Rad
    {
        public double val;
    }
    public struct Ang
    {
        public double val;
    }
    public struct Dec
    {
        public double val;
    }
    class AngelTransformation
    {
        
        public const double c = 648000 / Math.PI;
        public static double RadtoAng(Rad R1)
        {
            double r1, a1, deg, min, sec;
            r1 = R1.val;
            deg = (int)((r1 * c) / 3600);
            min = (int)(((r1 * c) / 3600 - deg) * 60);
            sec = (r1 * c) - deg * 3600 - min * 60;
            a1 = (double)deg + (double)(min / 100) + (double)(sec / 10000);
            return a1;
        }
        public static double AngtoRad(Ang A1)
        {
            double a1, r1, deg, min, sec;
            a1 = A1.val;
            deg = (int)a1;
            min = (int)((a1 - deg) * 100);
            sec = ((a1 - deg - min / 100) * 10000);
            r1 = ((double)(deg * 3600) + (double)(min * 60) + (double)sec) / c;
            return r1;
        }
        public static double RadtoDec(Rad R1)
        {
            double r1, d1;
            r1 = R1.val;
            d1 = (r1 * c) / 3600;
            return d1;
        }
        public static double DectoRad(Dec D1)
        {
            double r1, d1;
            d1 = D1.val;
            r1 = (d1 * 3600) / c;
            return r1;
        }
        public static double DectoAng(Dec D1)
        {
            double d1, a1, deg, min, sec;
            d1 = D1.val;
            deg = (int)d1;
            min = (int)((d1 - deg) * 60);
            sec = ((d1 - deg) * 3600 - min * 60);
            a1 = (double)deg + (double)(min / 100) + sec / 10000;
            return a1;
        }
        public static double AngtoDec(Ang A1)
        {
            double d1, a1, deg, min, sec;
            a1 = A1.val;
            deg = (int)a1;
            min = (int)((a1 - deg) * 100);
            sec = ((a1 - deg - min / 100) * 10000);
            d1 = (double)deg + (double)(min / 60) + (double)(sec / 3600);
            return d1;
        }
    }
}
