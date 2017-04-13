using System;
using System.Linq;

namespace Task2
{
    public interface IComparer
    {
        int CompareTo(int[] lhs, int[] rhs);
    }

    internal class Comparer:IComparer
    {
        private Comparison _comparison;

        public Comparer(Comparison comparison)
        {
            _comparison = comparison;
        }

        public int CompareTo(int[] lhs, int[] rhs) => _comparison(lhs, rhs);
    }

    public delegate int Comparison(int[] lhs, int[] rhs);

    public static class Sortings
    {
        #region public methods first variation       
        /// <summary>
        /// Sorts array by special parameter.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void BubbleSort(this int[][] array, IComparer comparer)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException();
            if (ReferenceEquals(comparer, null)) throw new ArgumentNullException();

            array.BubbleSort(comparer.CompareTo);
        }

        public static void BubbleSort(this int[][] array, Comparison comparison)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException();
            if (ReferenceEquals(comparison, null)) throw new ArgumentNullException();

            for (int i = 0; i < array.Length; i++)
                for (int j = array.Length - 1; j > i; j--)
                    if (comparison(array[j - 1], array[j]) > 0)
                        Swap(ref array[j - 1], ref array[j]);
        }
        #endregion

        #region public methods second variation        
        /// <summary>
        /// Bubbles the sort.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void BubbleSortSecond(this int[][] array, IComparer comparer)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException();
            if (ReferenceEquals(comparer, null)) throw new ArgumentNullException();

            for (int i = 0; i < array.Length; i++)
                for (int j = array.Length - 1; j > i; j--)
                    if (comparer.CompareTo(array[j - 1], array[j]) > 0)
                        Swap(ref array[j - 1], ref array[j]);
        }

        public static void BubbleSortSecond(this int[][] array, Comparison comparison)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException();
            if (ReferenceEquals(comparison, null)) throw new ArgumentNullException();

            array.BubbleSortSecond(new Comparer(comparison));
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
