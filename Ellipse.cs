using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public struct Elliptse
    {
        public string name;
        public double a;
        public double b;
        public double f;
        public double e1;
        public double e2;
        public double c;
    }
    class Ellipses
    {
        public static Elliptse SetEllipse(int what)
        {
            Elliptse el = new Elliptse();
            switch (what)
            {
                case 0:
                    {
                        el.name = "克拉索夫斯基椭球";
                        el.a = 6378245.0000;
                        el.b = 6356863.0187730473;
                        el.f = (el.a - el.b) / el.b;
                        el.e1 = (el.a* el.a - el.b* el.b) / (el.a* el.a);
                        el.e2 = (el.a* el.a - el.b* el.b) / (el.b* el.b);
                        el.c = (el.a* el.a) / el.b;
                        break;
                    }
                case 1:
                    {
                        el.name = "Bessel椭球";
                        el.a = 6377397.1550;
                        el.b = 6356078.9630;
                        el.f = (el.a - el.b) / el.b;
                        el.e1 = (el.a* el.a - el.b* el.b) / (el.a* el.a);
                        el.e2 = (el.a* el.a - el.b* el.b) / (el.b* el.b);
                        el.c = (el.a* el.a) / el.b;
                        break;
                    }
                case 2:
                    {
                        el.name = "WGS-84椭球";
                        el.a = 6378137.0000;
                        el.b = 6356752.3142;
                        el.f = (el.a - el.b) / el.b;
                        el.e1 = (el.a* el.a - el.b* el.b) / (el.a* el.a);
                        el.e2 = (el.a* el.a - el.b* el.b) / (el.b* el.b);
                        el.c = (el.a* el.a) / el.b;
                        break;
                    }
                case 3:
                    {
                        el.name = "西安80/国际1975年椭球";
                        el.a = 6378140.0000;
                        el.b = 6356755.2881575287;
                        el.f = (el.a - el.b) / el.b;
                        el.e1 = (el.a* el.a - el.b* el.b) / (el.a* el.a);
                        el.e2 = (el.a* el.a - el.b* el.b) / (el.b* el.b);
                        el.c = (el.a* el.a) / el.b;
                        break;
                    }
                case 4:
                    {
                        el.name = "2000年中国大地椭球";
                        el.a = 6378137.0000;
                        el.b = 6356752.3141;
                        el.f = (el.a - el.b) / el.b;
                        el.e1 = (el.a* el.a - el.b* el.b) / (el.a* el.a);
                        el.e2 = (el.a* el.a - el.b* el.b) / (el.b* el.b);
                        el.c = (el.a* el.a) / el.b;
                        break;
                    }
            }
            return el;
        }
    }
}
