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

    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>  //zapieczętowanie klasy za pomocą sealed
    {
        public  double a { get; }
        public  double b { get;  }
        public  double c { get;  }

        public double Am { get => this.a; }
        public double Bm { get => this.b; }
        public double Cm { get => this.c; }

        public double Acm { get => this.a / 0.01; }
        public double Bcm { get => this.b / 0.01; }
        public double Ccm { get => this.c / 0.01; }

        public double Amm { get => this.a / 0.001; }
        public double Bmm { get => this.b / 0.001; }
        public double Cmm { get => this.c / 0.001; }

        public double A
        {
            get => this.Am;
            
        }
        public double B
        {
            get => this.Bm;
           
        }
        public double C
        {
            get => this.Cm;
            
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


        public Pudelko(double? a = null, double? b = null, double? c = null, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            this.Unit = unit;
            this.a = (a != null) ? SetVal ((double)a) : 0.1;
            this.b = (b != null) ? SetVal ((double)b) : 0.1;
            this.c = (c != null) ? SetVal ((double)c) : 0.1;
        }

        public override string ToString()
        {
            return this.ToString("m", CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider provider = null)
        {
            if (String.IsNullOrEmpty(format)) format = "m";
            if (provider == null) provider = CultureInfo.CurrentCulture;

            switch (format)
            {
                case "m":
                    return $"{Am.ToString("0.000", provider)} m \u00D7 " +
                        $"{Bm.ToString("0.000", provider)} m \u00D7 " +
                        $"{Cm.ToString("0.000", provider)} m";
                case "cm":
                    return $"{Acm.ToString("000.0".TrimStart(new Char[] { '0' }), provider)} cm \u00D7 " +
                       $"{Bcm.ToString("000.0".TrimStart(new Char[] { '0' }), provider)} cm \u00D7 " +
                       $"{Ccm.ToString("000.0".TrimStart(new Char[] { '0' }), provider)} cm";
                case "mm":
                    return $"{Amm.ToString("0000".TrimStart(new Char[] { '0' }), provider)} mm \u00D7 " +
                       $"{Bmm.ToString("0000".TrimStart(new Char[] { '0' }), provider)} mm \u00D7 " +
                       $"{Cmm.ToString("0000".TrimStart(new Char[] { '0' }), provider)} mm";
                default:
                    throw new FormatException("wrong code");
            }
        }
            //Property pole i objetosc
        public double Objetosc { get => Math.Round( A * B * C, 9); }
        public double Pole { get => Math.Round(2 * A * B + 2 * A * C + 2 * B * C, 6); }

        public bool Equals(Pudelko other)
        {
            if (other is null) return false;
            if (Object.ReferenceEquals(this, other)) //other i this są referencjami do tego samego obiektu
                return true;

            return (Pole == other.Pole && Objetosc == other.Objetosc);
        }

        public override bool Equals(object obj)
        {
            if (obj is Pudelko)
                return Equals((Pudelko)obj);
            else
                return false;
        }

        public override int GetHashCode()
        {
            return A.GetHashCode() + B.GetHashCode() + C.GetHashCode();
        }
        //public override int GetHashCode() => (A, B, C).GetHashCode();

        public static bool Equals(Pudelko p1, Pudelko p2)
        {
            if ((p1 is null) && (p2 is null)) return true;
            if (p1 is null) return false;

            return p1.Equals(p2);
        }

        //Przeciązenie operatora == and !=
        public static bool operator ==(Pudelko p1, Pudelko p2) => Equals(p1, p2);
        public static bool operator !=(Pudelko p1, Pudelko p2) => !(p1 == p2);
    }
}
