﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab301
{
    class Fraction
    {
        private double _numer, _denom;
        public double Numer
        {
            get { return _numer; }
            set { _numer = value; }
        }
        public double Denom
        {
            get { return _denom; }
            set { _denom = value; }
        }

        private static int _count = 0;
        public static int Count
        {
            get { return _count; }
        }
        public Fraction()
        {
            this.Numer = 0;
            this.Denom = 1;
            _count++;
        }
        public Fraction(double numer)
        {
            this.Numer = numer;
            this.Denom = 1;
            _count++;
        }
        public Fraction(double numer, double denom)
        {

            this.Numer = numer / Fraction.GCD(numer, denom);
            this.Denom = denom / Fraction.GCD(numer, denom);
            _count++;
        }
        public Fraction(Fraction f)
        {
            this.Numer = f.Numer;
            this.Denom = f.Denom;
        }
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numer * f2.Denom + f2.Numer * f1.Denom, f1.Denom * f2.Denom);
        }
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            return new Fraction((f1.Numer * f2.Denom - f2.Numer * f1.Denom), (f1.Denom * f2.Denom));
        }
        public static Fraction operator ++(Fraction f)
        {
            return new Fraction((f.Numer + f.Denom), f.Denom);
        }
        public static Fraction operator --(Fraction f)
        {
            return new Fraction((f.Numer - f.Denom), f.Denom);
        }

        public static Fraction operator +(Fraction f, int x)
        {
            return new Fraction((f.Numer + (f.Denom * x)), (f.Denom));
        }
        public static Fraction operator +(int x, Fraction f)
        {
            return new Fraction((f.Numer + (f.Denom * x)), (f.Denom));
        }
        public static Fraction operator -(int x, Fraction f)
        {
            return new Fraction(((f.Denom * x) - f.Numer), (f.Denom));
        }
        public static Fraction operator -(Fraction f, int x)
        {
            return new Fraction((f.Numer - (f.Denom * x)), (f.Denom));
        }
        public static bool operator ==(Fraction f1, Fraction f2)
        {
            return (f1.Numer / f1.Denom == f2.Numer / f2.Denom);
        }
        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return (f1.Numer / f1.Denom != f2.Numer / f2.Denom);
        }
        public bool Equals(Fraction f)
        {
            return (this._numer / this._denom == f.Numer / f.Denom);
        }
        public void setValue(int a, int b)
        {
            this._numer = a;
            if (b == 0)
                this._denom = 1;
            else
                this._denom = b;
        }
        public static int GCD(double a, double b)
        {
            int gcd = 1;
            for (int cd = 1; (cd <= a) && (cd <= b); cd++)
            {
                if ((a % cd == 0) && (b % cd == 0))
                {
                    gcd = cd;
                }
            }
            return gcd;
        }
        public override string ToString()
        {
            string s = "[Rational: " + this._numer + "/" + this._denom + "], value=" + (this._numer / this._denom) + "]";
            return s;
        }
    }
}
