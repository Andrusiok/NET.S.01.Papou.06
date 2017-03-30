using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task1;

namespace Task1.Tests
{
    [TestFixture]
    public class PolynomTests
    {
        [TestCase(null)]
        public void Constructor_ArgumentNullException(double[] array)
        {
            Assert.Throws<ArgumentNullException>(() => { new Polynom(array); });
        }

        [TestCase(new double[] { 1, 2, 3}, new double[] { 1, 2, 3}, ExpectedResult =true)]
        [TestCase(new double[] { }, new double[] { 1, 2, 3 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 4 }, ExpectedResult = false)]
        public bool Equals_Polynom_Positive(double[] a, double[] b)
        {
            Polynom aPolynom = new Polynom(a);
            Polynom bPolynom = new Polynom(b);
            return aPolynom.Equals(bPolynom);
        }

        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, ExpectedResult = false)]
        public bool Equals_Object_Positive(double[] a, object b)
        {
            Polynom aPolynom = new Polynom(a);
            return aPolynom.Equals(b);
        }

        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 4 }, ExpectedResult = false)]
        public bool Equals_Object_Positive2(double[] a, double[] b)
        {
            Polynom aPolynom = new Polynom(a);
            object bPolynom = new Polynom(b);
            return aPolynom.Equals(bPolynom);
        }

        [TestCase(new double[] {1,2.3 }, new double[] { 1, 1, -1}, new double[] { 2, 3.3, -1 })]
        [TestCase(new double[] { 1, 2.3 }, new double[] { 1, 1 }, new double[] { 2, 3.3 })]
        [TestCase(new double[] { 1, 2.3 }, new double[] {  }, new double[] { 1, 2.3 })]
        public void Add_Positive(double[] a, double[] b, double[] expected)
        {
            Polynom result = new Polynom(a) + new Polynom(b);
            Assert.AreEqual(result, new Polynom(expected));
        }

        [TestCase(new double[] { 1, 2 }, new double[] { 1, 1, -1 }, new double[] { 0, 1, 1 })]
        [TestCase(new double[] { 1, 2 }, new double[] { 1, 1 }, new double[] { 0, 1 })]
        [TestCase(new double[] { }, new double[] { }, new double[] { })]
        [TestCase(new double[] {1,2 }, new double[] { }, new double[] {1,2 })]
        public void Substract_Positive(double[] a, double[] b, double[] expected)
        {
            Polynom result = new Polynom(a) - new Polynom(b);
            Assert.AreEqual(result, new Polynom(expected));
        }

        [TestCase(new double[] { 1, 2.3 }, new double[] { 1, 1, -1 }, new double[] { 1, 2.3, -1 })]
        [TestCase(new double[] { 1, 2.3 }, new double[] { 1, 1 }, new double[] { 1, 2.3 })]
        [TestCase(new double[] { 1, 2.3 }, new double[] { }, new double[] { 1, 2.3 })]
        public void Mul_Positive(double[] a, double[] b, double[] expected)
        {
            Polynom result = new Polynom(a) * new Polynom(b);
            Assert.AreEqual(result, new Polynom(expected));
        }

        [TestCase(new double[] { 1, 2.3 }, ExpectedResult ="1,00*x+2,30")]
        [TestCase(new double[] { -1, 2.3 }, ExpectedResult = "-1,00*x+2,30")]
        [TestCase(new double[] { 1, -2.3 }, ExpectedResult = "1,00*x-2,30")]
        [TestCase(new double[] { 1, -2.3,5 }, ExpectedResult = "1,00*x^2-2,30*x+5,00")]
        [TestCase(new double[] { 1 }, ExpectedResult = "1,00")]
        public string ToString_Positive(double[] a)
        {
            return new Polynom(a).ToString();
        }
    }
}
