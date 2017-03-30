using System;
using System.Linq;

namespace Task2
{
    public interface IComparer
    {
        int CompareTo(int[] lhs, int[] rhs);
    }

    public static class Sortings
    {
        #region public methods        
        /// <summary>
        /// Bubbles the sort.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void BubbleSort(this int[][] array, IComparer comparer)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException();
            if (ReferenceEquals(comparer, null)) throw new ArgumentNullException();

            for (int i = 0; i < array.Length; i++)
                for (int j = array.Length - 1; j > i; j--)
                    if (comparer.CompareTo(array[j - 1], array[j]) > 0)
                        Swap(ref array[j - 1], ref array[j]);
        }
        #endregion

        #region private methods

        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }
        #endregion
    }
}
