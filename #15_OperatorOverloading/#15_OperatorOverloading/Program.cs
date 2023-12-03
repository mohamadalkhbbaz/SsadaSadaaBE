using System.Numerics;

namespace _15_OperatorOverloading
{
    //  user defined type that can overload predefined operators
    internal class Program
    {
        static void Main(string[] args)
        {
            Complex complex1 = new Complex(2, 3);
            Complex complex2 = new Complex(11, 4);

            Complex resultAddition = complex1 + complex2;
            Complex resultSubtraction = complex1 - complex2;

            Console.WriteLine($"Sum: {resultAddition}");
            Console.WriteLine($"Difference: {resultSubtraction}");
            Console.WriteLine(complex1.ToString());
            Console.WriteLine(complex1 > complex2);

            Console.ReadKey();
        }
    }
    class Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        // Overloading the '+' operator
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        // Overloading the '-' operator
        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
        }

        // Overriding the ToString method for better display
        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }

        public static bool operator <(Complex c1, Complex c2)
        {
            return c1.Real < c2.Real;
        }

        public static bool operator >(Complex c1, Complex c2)
        {
            return c1.Real > c2.Real;
        }

    }
}