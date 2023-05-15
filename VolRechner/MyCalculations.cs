using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolRechner
{
    public class MyCalculations
    {
        public double RechteckU(double seite_a)
        {
            return 4 * seite_a;
        }
        public double RechteckF(double seite_a)
        {
            return QuadratF(seite_a, seite_a);
        }
        public double QuadratU(double seite_a, double seite_b)
        {
            return 2 * (seite_a + seite_b);
        }
        public double QuadratF(double seite_a, double seite_b)
        {
            return seite_a * seite_b;
        }
        public double ParallelogrammU(double seite_a, double seite_b)
        {
            return (seite_a + seite_b) * 2;
        }
        public double ParallelogrammF(double seite_a, double hoehe)
        {
            return seite_a * hoehe;
        }
        public double TrapezU(double seite_a, double seite_b, double seite_c, double seite_d)
        {
            return seite_a + seite_b + seite_c + seite_d;
        }
        public double TrapezF(double seite_a, double seite_c, double hoehe)
        {
            return ((seite_a + seite_c) * hoehe) / 2;
        }
        public double DeltoidU(double seite_a, double seite_b)
        {
            return (seite_a + seite_b) * 2;
        }
        public double DeltoidF(double diag_e, double diag_f)
        {
            return (diag_e * diag_f) / 2;
        }
        public double DreieckU(double seite_a, double seite_b, double seite_c)
        {
            return seite_a + seite_b + seite_c;
        }
        public double DreieckF(double grundseite, double hoehe)
        {
            return (grundseite * hoehe) / 2;
        }
        public double RechtwinkligesdreieckU(double seite_a, double seite_b, double seite_c)
        {
            return seite_a + seite_b + seite_c;
        }
        public double RechtwinkligesdreieckF(double seite_a, double seite_b)
        {
            return (seite_a * seite_b) / 2;
        }
        public double GleichseitigesdreieckU(double seite_a)
        {
            return 3 * seite_a;
        }
        public double GleichseitigesdreieckF(double seite_a)
        {
            return ((seite_a * seite_a) * Math.Sqrt(3)) / 4;
        }
        public double KreisU(double radius)
        {
            double pi = Math.PI;
            return 2 * radius * pi;
        }
        public double KreisF(double radius)
        {
            double pi = Math.PI;
            return radius * radius * pi;
        }
        public double KreissektorU(double radius, double seite_b)
        {
            return 2 * radius + seite_b;
        }
        public double KreissektorF(double radius, double seite_b)
        {
            return (seite_b * radius) / 2;
        }
        public double DodekaederV(double seite_a)
        {
            return ((seite_a * seite_a * seite_a) / 4) * (15 + 7 * Math.Sqrt(5));
        }
    }
}