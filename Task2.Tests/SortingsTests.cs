using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2;

namespace Task2.Tests
{
    class MaxA : IComparer
    {
        int IComparer.CompareTo(int[] lhs, int[] rhs) => lhs.Max() - rhs.Max();
    }

    class MaxD : IComparer
    {
        int IComparer.CompareTo(int[] lhs, int[] rhs) => rhs.Max() - lhs.Max();
    }

    class MinA : IComparer
    {
        int IComparer.CompareTo(int[] lhs, int[] rhs) => lhs.Min() - rhs.Min();
    }

    class MinD : IComparer
    {
        int IComparer.CompareTo(int[] lhs, int[] rhs) => rhs.Min() - lhs.Min();
    }

    class SumA : IComparer
    {
        int IComparer.CompareTo(int[] lhs, int[] rhs) => lhs.Sum() - rhs.Sum();
    }

    class SumD : IComparer
    {
        int IComparer.CompareTo(int[] lhs, int[] rhs) => lhs.Sum() - rhs.Sum();
    }

    [TestFixture]
    public class SortingsTests
    {
        [TestCase]
        public void BubbleSort_PositiveMaxA()
        {
            int[][] array = new int[][] { new int[] { 1, 3, 2 }, new int[] { 3, 2 }, new int[] { 1, 3, 2, 5 } };
            int[][] result = new int[][] { new int[] { 1, 3, 2 }, new int[] { 3, 2 }, new int[] { 1, 3, 2, 5 } };
            array.BubbleSort(new MaxA());
            Assert.AreEqual(result, array);
        }

        [TestCase]
        public void BubbleSort_PositiveMinA()
        {
            int[][] array = new int[][] { new int[] { 1, 3, 2 }, new int[] { 3, 2 }, new int[] { 1, 3, 2, 5 } };
            int[][] result = new int[][] { new int[] { 1, 3, 2 }, new int[] { 1, 3, 2, 5 }, new int[] { 3, 2 } };
            array.BubbleSort(new MinA());
            Assert.AreEqual(result, array);
        }

        [TestCase]
        public void BubbleSort_PositiveSumA()
        {
            int[][] array = new int[][] { new int[] { 1, 3, 2 }, new int[] { 3, 2 }, new int[] { 1, 3, 2, 5 } };
            int[][] result = new int[][] { new int[] { 3, 2 }, new int[] { 1, 3, 2 }, new int[] { 1, 3, 2, 5 } };
            array.BubbleSort(new SumA());
            Assert.AreEqual(result, array);
        }

        [TestCase]
        public void BubbleSort_ArgumentNullException()
        {
            int[][] array = null;
            Assert.Throws<ArgumentNullException>(() => { array.BubbleSort(null); });
        }
    }
}
