using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2;

namespace Task2.Tests
{
    [TestFixture]
    public class SortingsTests
    {
        [TestCase]
        public void BubbleSort_PositiveMaxA()
        {
            int[][] array = new int[][] { new int[] { 1, 3, 2 }, new int[] { 3, 2 }, new int[] { 1, 3, 2, 5 } };
            int[][] result = new int[][] { new int[] { 1, 2, 3 }, new int[] { 2, 3 }, new int[] { 1, 2, 3, 5 } };
            array.BubbleSort(Sortings.RowOrder.Maximal, Sortings.ElementsOrder.Ascending);
            Assert.AreEqual(result, array);
        }

        [TestCase]
        public void BubbleSort_PositiveMinA()
        {
            int[][] array = new int[][] { new int[] { 1, 3, 2 }, new int[] { 3, 2 }, new int[] { 1, 3, 2, 5 } };
            int[][] result = new int[][] { new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 5 }, new int[] { 2, 3 } };
            array.BubbleSort(Sortings.RowOrder.Minimal, Sortings.ElementsOrder.Ascending);
            Assert.AreEqual(result, array);
        }

        [TestCase]
        public void BubbleSort_PositiveSumA()
        {
            int[][] array = new int[][] { new int[] { 1, 3, 2 }, new int[] { 3, 2 }, new int[] { 1, 3, 2, 5 } };
            int[][] result = new int[][] { new int[] { 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 5 } };
            array.BubbleSort(Sortings.RowOrder.Sum, Sortings.ElementsOrder.Ascending);
            Assert.AreEqual(result, array);
        }

        [TestCase]
        public void BubbleSort_ArgumentNullException()
        {
            int[][] array = null;
            Assert.Throws<ArgumentNullException>(() => { array.BubbleSort(Sortings.RowOrder.Maximal, Sortings.ElementsOrder.Ascending); });
        }
    }
}
