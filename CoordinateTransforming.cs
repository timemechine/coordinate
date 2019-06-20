using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp3
{
    class CoordinateTransforming
    {
        public static kPoint DToK(dPoint dp,int what)
        {
            Elliptse ell = new Elliptse();
            ell=Ellipses.SetEllipse(what);
            double W, N, B, L, H;
            Ang b, l;
            b.val = dp.B;
            l.val = dp.L;
            B = AngelTransformation.AngtoRad(b);
            L = AngelTransformation.AngtoRad(l);
            H = dp.H;
            W = Math.Sqrt(1 - ell.e1 * Math.Pow(Math.Sin(B), 2.0));
            N = ell.a / W;
            kPoint kp = new kPoint();
            kp.X = (N + H) * Math.Cos(B) * Math.Cos(L);
            kp.Y = (N + H) * Math.Cos(B) * Math.Sin(L);
            kp.Z = (N * (1 - ell.e1) + H) * Math.Sin(B);
            return kp;
        }
        public static dPoint KToD(kPoint kp, int what)
        {
            Elliptse ell = new Elliptse();
            ell = Ellipses.SetEllipse(what);
            double X, Y, Z, N;
            X = kp.X;
            Y = kp.Y;
            Z = kp.Z;
            dPoint dp = new dPoint();
            Rad b, l;
            l.val = Math.Acos(X / Math.Sqrt(Math.Pow(X, 2.0) + Math.Pow(Y, 2.0)));
            dp.L = AngelTransformation.RadtoAng(l);
            double[] B1 = new double[99999];
            B1[0] = Math.Atan(Z / Math.Sqrt(X * X + Y * Y));
            int i = 0;
            for (i = 0; i < 99999; i++)
            {
                B1[i + 1] = Math.Atan((1 / Math.Sqrt(Math.Pow(X, 2.0) + Math.Pow(Y, 2.0))) * (Z + (ell.c * ell.e1 * Math.Tan(B1[i])) / Math.Sqrt(1 + ell.e2 + Math.Pow(Math.Tan(B1[i]), 2.0))));
                if (Math.Abs(B1[i + 1] - B1[i]) <= 0.001/(648000/Math.PI))
                {
                    break;
                }
            }
            b.val = B1[i];
            dp.B = AngelTransformation.RadtoAng(b);
            N = ell.c / Math.Sqrt(1.0 + ell.e2 * Math.Pow(Math.Cos(b.val), 2.0));
            dp.H = Z / Math.Sin(b.val) - N * (1 - ell.e1);
            return dp;
        }
        public static kPoint ParaSwi(kPoint kp, double X, double Y, double xita, double k)
        {
            kPoint kp1 = new kPoint();
            Ang a;
            a.val = xita;
            xita = AngelTransformation.AngtoRad(a);
            kp1.X = X + k * kp.X * Math.Cos(xita) - k * kp.Y * Math.Sin(xita);
            kp1.Y = Y + k * kp.Y * Math.Cos(xita) + k * kp.X * Math.Sin(xita);
            return kp1;
        }
        public static double ConvergenceAngle(dPoint dp, int what)
        {
            int a;
            double B, l, L, L0, t, n, r;
            Elliptse ell = new Elliptse();
            Ellipses.SetEllipse(what);
            B = dp.B;
            L = dp.L;
            a = (int)(L / 6) + 1;
            L0 = 6 * (double)a - 3;
            Ang A1, A2, b;
            A1.val = L;
            A2.val = L0;
            b.val = B;
            L = AngelTransformation.AngtoRad(A1);
            L0 = AngelTransformation.AngtoRad(A2);
            l = L - L0;
            B = AngelTransformation.AngtoRad(b);
            t=Math.Tan(B);
            n = Math.Sqrt(ell.e2) * Math.Cos(B);
            r = Math.Sin(B) * l + Math.Sin(B) * Math.Pow(Math.Cos(B), 2) * l * l * l * 
                (1 + 3 * n * n + 2 * Math.Pow(n, 4)) / 3 + Math.Sin(B) * Math.Pow(Math.Cos(B), 4) 
                * Math.Pow(l, 5) * (2 - t * t) / 15;
            Rad r1;
            r1.val = r;
            r = AngelTransformation.RadtoAng(r1);
            return r;
        }
    }
}
