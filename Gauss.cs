using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp3
{
    public struct kPoint
    {
        public double X;
        public double Y;
        public double Z;
        public double a;
    }
    public struct dPoint
    {
        public double B;
        public double L;
        public double H;
        public double a;
    }
    class Gauss
    {
        public static kPoint Forsol(dPoint dp, int what)
        {
            int a;
            double B, L, N, l, t, n, e, X, x, y, a0, a1, a2, a3, a4, a5, a6, a7, L0;
            Elliptse ell = new Elliptse();
            ell = Ellipses.SetEllipse(what);
            B = dp.B;
            L = dp.L;
            a = (int)(L / 6) + 1;
            L0 = 6 * (double)a - 3;
            Ang A1,A2, b;
            A1.val = L;
            A2.val = L0;
            b.val = B;
            L = AngelTransformation.AngtoRad(A1);
            L0 = AngelTransformation.AngtoRad(A2);
            l = L - L0;
            B = AngelTransformation.AngtoRad(b);
            N = ell.a / Math.Sqrt(1 - ell.e1 * Math.Pow(Math.Sin(B), 2.0));
            t = Math.Tan(B);
            n = Math.Sqrt(ell.e2) * Math.Cos(B);
            e = ell.e1;
            a0 = 1 + 3 * e / 4 + 45 * e * e / 64 + 175 * e * e * e / 256 + 11025 * e * e * e * e / 16384
                + 43659 * e * e * e * e * e / 65336 + 693693 * Math.Pow(e, 6) / 1048576
                + 2760615 * Math.Pow(e, 7) / 41944304 + 703956835 * Math.Pow(e, 8) / 1073741824;
            a1 = 3 * e / 4 + 15 * e * e / 16 + 525 * e * e * e / 512 + 2205 * e * e * e * e / 2048
                + 72765 * e * e * e * e * e / 65536 + 297297 * Math.Pow(e, 6) / 262144
                + 19324305 * Math.Pow(e, 7) / 16777216;
            a2 = 15 * e * e / 64 + 105 * e * e * e / 256 + 2205 * e * e * e * e / 4096
                + 10395 * e * e * e * e * e / 16384 + 1486485 * Math.Pow(e, 6) / 2097152
                + 6441435 * Math.Pow(e, 7) / 8388608;
            a3 = 35 * e * e * e / 512 + 315 * e * e * e * e / 2048 + 31185 * e * e * e * e * e / 131072
                + 165165 * Math.Pow(e, 6) / 524288 + 6441435 * Math.Pow(e, 7) / 16777216;
            a4 = 315 * e * e * e * e / 16348 + 3465 * e * e * e * e * e / 65536 
                + 90999 * Math.Pow(e, 6) / 1048576 + 585585 * Math.Pow(e, 7) / 4194304;
            a5 = 693 * Math.Pow(e, 5) / 131072 + 9009 * Math.Pow(e, 6) / 524288 
                + 585585 * Math.Pow(e, 7) / 16777216;
            a6 = 3003 * Math.Pow(e, 6) / 2097152 + 45045 * Math.Pow(e, 7) / 8388608;
            a7 = 6435 * Math.Pow(e, 7) / 16777216;
            X = ell.a * (1 - e) * (a0 * B - 0.5 * a1 * Math.Sin(2 * B) + 0.25 * a2 * Math.Sin(4 * B)
                - a3 * Math.Sin(6 * B) / 6 + a4 * Math.Sin(8 * B) / 8 - a5 * Math.Sin(10 * B) / 10
                + a6 * Math.Sin(12 * B) / 12 - a7 * Math.Sin(14 * B) / 14);
            x = X + N * Math.Sin(B) * Math.Cos(B) * l * l / 2
                + N * Math.Sin(B) * Math.Pow(Math.Cos(B), 3) * (5 - t + 9 * n * n + 4 * Math.Pow(n, 4)) 
                * Math.Pow(l, 4) / 24
                + N * Math.Sin(B) * Math.Pow(Math.Cos(B), 5) * (61 - 58 * t * t + Math.Pow(t, 4)) 
                * Math.Pow(l, 6) / 720;
            y = N * Math.Cos(B) * l + N * Math.Pow(Math.Cos(B), 3) * (1 - t * t + n * n) * Math.Pow(l, 3) / 6
                + N * Math.Pow(Math.Cos(B), 5) 
                * (5 - 18 * t * t + Math.Pow(t, 4) + 14 * n * n - 58 * t * t * n * n) * Math.Pow(l, 5);
            kPoint kp = new kPoint();
            kp.X = x;
            kp.Y = y;
            return kp;
        }
        public static dPoint BackCal(kPoint kp, int what)
        {
            double B, l, nf, Bf, B0, tf, Nf, Mf, X, C1, C2, C3, C4, a0, a1, a2, a3, a4, a5, a6, a7, e, y;
            Elliptse ell = new Elliptse();
            e = ell.e1;
            a0 = 1 + 3 * e / 4 + 45 * e * e / 64 + 175 * e * e * e / 256 + 11025 * e * e * e * e / 16384
                + 43659 * e * e * e * e * e / 65336 + 693693 * Math.Pow(e, 6) / 1048576
                + 2760615 * Math.Pow(e, 7) / 41944304 + 703956835 * Math.Pow(e, 8) / 1073741824;
            B0 = kp.X / a0;
            a1 = 3 * e / 4 + 15 * e * e / 16 + 525 * e * e * e / 512 + 2205 * e * e * e * e / 2048
                + 72765 * e * e * e * e * e / 65536 + 297297 * Math.Pow(e, 6) / 262144
                + 19324305 * Math.Pow(e, 7) / 16777216;
            a2 = 15 * e * e / 64 + 105 * e * e * e / 256 + 2205 * e * e * e * e / 4096
                + 10395 * e * e * e * e * e / 16384 + 1486485 * Math.Pow(e, 6) / 2097152
                + 6441435 * Math.Pow(e, 7) / 8388608;
            a3 = 35 * e * e * e / 512 + 315 * e * e * e * e / 2048 + 31185 * e * e * e * e * e / 131072
                + 165165 * Math.Pow(e, 6) / 524288 + 6441435 * Math.Pow(e, 7) / 16777216;
            a4 = 315 * e * e * e * e / 16348 + 3465 * e * e * e * e * e / 65536
                + 90999 * Math.Pow(e, 6) / 1048576 + 585585 * Math.Pow(e, 7) / 4194304;
            a5 = 693 * Math.Pow(e, 5) / 131072 + 9009 * Math.Pow(e, 6) / 524288
                + 585585 * Math.Pow(e, 7) / 16777216;
            a6 = 3003 * Math.Pow(e, 6) / 2097152 + 45045 * Math.Pow(e, 7) / 8388608;
            a7 = 6435 * Math.Pow(e, 7) / 16777216;
            X = ell.a * (1 - e) * (a0 * B0 - 0.5 * a1 * Math.Sin(2 * B0) + 0.25 * a2 * Math.Sin(4 * B0)
                - a3 * Math.Sin(6 * B0) / 6 + a4 * Math.Sin(8 * B0) / 8 - a5 * Math.Sin(10 * B0) / 10
                + a6 * Math.Sin(12 * B0) / 12 - a7 * Math.Sin(14 * B0) / 14);
            C1 = 3 * e / 8 + 3 * e * e / 16 + 213 * e * e * e / 2048 + 255 * Math.Pow(e, 4) / 4096;
            C2 = 21 * e * e / 256 + 21 * e * e * e / 256 + 533 * Math.Pow(e, 4) / 8192;
            C3 = 151 * e * e * e / 6144 + 151 * Math.Pow(e, 4) / 4096;
            C4 = 1097 * Math.Pow(e, 4) / 131072;
            Bf = B0 + C1 * Math.Sin(2 * B0) + C2 * Math.Sin(4 * B0) + C3 * Math.Sin(6 * B0) 
                + C4 * Math.Sin(8 * B0);
            Nf = ell.a / Math.Sqrt(1 - e * Math.Pow(Math.Sin(Bf), 2));
            tf = Math.Tan(Bf);
            nf = Math.Sqrt(ell.e2) * Math.Cos(Bf);
            Mf = ell.a * (1 - e) / Math.Pow(Math.Sqrt(1 - e * Math.Pow(Math.Sin(Bf), 2)), 3);
            y = kp.Y;
            l = y / (Nf * Math.Cos(Bf)) - ((1 + 2 * tf * tf + nf * nf) * Math.Pow(y, 3)) 
                / (6 * Nf * Nf * Nf * Math.Cos(Bf)) 
                + ((5 + 28 * tf * tf + 6 * nf * nf + 24 * Math.Pow(tf, 4) + 8 * tf * tf * nf * nf) 
                * Math.Pow(y, 5)) / (120 * Math.Pow(Nf, 5) * Math.Cos(Bf));
            B = Bf - (tf * y * y) / (2 * Mf * Nf) + (5 + 3 * tf * tf + nf * nf - 9 * nf * nf * tf * tf)
                / (24 * Mf * Math.Pow(Nf, 3)) + ((61 + 90 * tf * tf + 65 * Math.Pow(tf, 4)) * 
                Math.Pow(y, 6)) / (720 * Mf * Math.Pow(Nf, 5));
            dPoint dp = new dPoint();
            Rad r1, r2;
            r1.val = B;
            r2.val = l;
            dp.B = AngelTransformation.RadtoAng(r1);
            dp.L = AngelTransformation.RadtoAng(r2);
            return dp;
        }
    }
}
