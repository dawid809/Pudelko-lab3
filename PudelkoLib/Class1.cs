using System;
using System.Globalization;

namespace PudelkoLibrary
{
    public enum UnitOfMeasure
    {
        milimeter = 1000,
        centimeter = 100,
        meter = 1
    }

    public sealed class Pudelko //zapieczętowanie klasy za pomocą sealed
    {
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }

        public double Am { get => this.a; }
        public double Bm { get => this.b; }
        public double Cm { get => this.c; }

        public double Acm { get => this.a * 0.1; }
        public double Bcm { get => this.b * 0.1; }
        public double Ccm { get => this.c * 0.1; }

        public double Amm { get => this.a * 0.001; }
        public double Bmm { get => this.b * 0.001; }
        public double Cmm { get => this.c * 0.001; }

        public double A
        {
            get => this.Am;
            private set
            {
                this.a = SetVal(value);
            }
        }
        public double B
        {
            get => this.Bm;
            private set
            {
                this.b = SetVal(value);
            }
        }
        public double C
        {
            get => this.Cm;
            private set
            {
                this.c = SetVal(value);
            }
        }

        private double SetVal(double value)
        {
            switch (Unit)
            {
                case UnitOfMeasure.milimeter:
                    value *= 0.001;
                    break;
                case UnitOfMeasure.centimeter:
                    value *= 0.01;
                    break;
                case UnitOfMeasure.meter:
                    break;
            }
            var tmp = Math.Round(value, 3);
            if (tmp <= 0 || tmp > 10)
                throw new ArgumentOutOfRangeException("zle dane");

            return value;
        }

        public UnitOfMeasure Unit { get; set; } = UnitOfMeasure.meter;

        public override string ToString()
        {
            return base.ToString();
        }

        public string ToString(UnitOfMeasure unit)
        {
            return base.ToString();
        }

        private double GetDefault()
        {
            switch (Unit)
            {
                case UnitOfMeasure.milimeter:
                    return 100;
                case UnitOfMeasure.centimeter:
                    return 10;
                default:
                    return 0.1D;
            }
        }

        public Pudelko(double? a = null, double? b = null, double? c = null, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            this.Unit = unit;
            this.A = (a != null) ? (double)a : GetDefault();
            this.B = (b != null) ? (double)b : GetDefault();
            this.C = (c != null) ? (double)c : GetDefault();
        }
    }
}
