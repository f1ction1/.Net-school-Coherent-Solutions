namespace Task4
{
    internal sealed class RationalNumber : IComparable<RationalNumber>
    {
        public int Numerator { get; private set; }
        int _denominator;
        public int Denominator
        {
            get
            {
                return _denominator;
            }
            private set
            {
                if (value == 0)
                    throw new ArgumentException("Denominator can't be equal zero!");
                _denominator = value;   
            }
        }

        private int CalculateGCD(int a, int b)
        {
            //int min = Math.Min(a, b);
            //int max = Math.Max(a, b); 
            //while (min > 0)
            //{
            //    int tmp = min;
            //    min = max % min;
            //    max = tmp; 
            //}
            //return max;
            while (b != 0)
            {
                int tmp = b;
                b = a % b;
                a = tmp;
            }
            return Math.Abs(a);
        }
        public RationalNumber(int numerator, int denominator)
        {  
            int GCD = CalculateGCD(numerator, denominator);
            numerator = (denominator < 0 && numerator > 0) || (denominator < 0 && numerator < 0) ? 0 - numerator : numerator;
            denominator = Math.Abs(denominator);
            Numerator = GCD == 1 ? numerator : numerator / GCD;
            Denominator = GCD == 1 ? denominator : denominator / GCD;     
        }
        public override bool Equals(object? obj)
        {
            var tmp = obj as RationalNumber;
            if (tmp == null)
                return false;
            return tmp.Numerator == this.Numerator && tmp.Denominator == this.Denominator;
        }
        public override int GetHashCode()
        {
            return Numerator + Denominator;
        }
        public override string ToString()
        {
            return Numerator == 0 || Denominator == 1 ? Numerator.ToString() : $"{Numerator}/{Denominator}";
        }
        // IComparable implementation
        public int CompareTo(RationalNumber? other)
        {
            if (other == null)
                return 1;
            return (Numerator * other.Denominator).CompareTo(other.Numerator * Denominator);
        }
        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            if(a == null || b == null)
            {
                throw new ArgumentNullException("Argument can't be null");
            }
            return new RationalNumber(a.Numerator*b.Denominator + a.Denominator * b.Numerator, a.Denominator*b.Denominator);
        }
        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
        {
            if (a == null || b == null)
            {
                throw new ArgumentNullException("Argument can't be null");
            }
            return new RationalNumber(a.Numerator*b.Denominator - a.Denominator*b.Numerator,a.Denominator*b.Denominator);
        }
        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            if (a == null || b == null)
            {
                throw new ArgumentNullException("Argument can't be null");
            }
            return new RationalNumber(a.Numerator *b.Numerator,a.Denominator*b.Denominator);
        }
        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {
            if (a == null || b == null)
                throw new ArgumentNullException("Argument can't be null");
            if (b.Denominator == 0)
                throw new ArithmeticException("Can't divide by zero");  
            return new RationalNumber(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }
        public static implicit operator RationalNumber(int l)
        {    
            return new RationalNumber(l, 1);
        }
        public static explicit operator double(RationalNumber l)
        {
            if (l == null)
            {
                throw new ArgumentNullException("Argument can't be null");
            }
            return (double)l.Numerator/l.Denominator;
        }
    }
}
