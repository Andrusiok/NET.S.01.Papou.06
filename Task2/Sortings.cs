using System;
using System.Linq;

namespace Task2
{
    public static class Sortings
    {
        #region private fields
        private delegate bool Compare(int[] left, int[] right, ElementsOrder orderElementsByMode);
        #endregion

        #region public enums
        public enum RowOrder { Sum, Minimal, Maximal}
        public enum ElementsOrder { Ascending, Descending}
        #endregion

        #region public methods
        /// <summary>
        /// Implements bubble sort method
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="orderRowByMode">Explains how rows of array should be sorted</param>
        /// <param name="orderElementsByMode">Explains how elements in rows of array should be sorted</param>
        public static void BubbleSort(this int[][] array, RowOrder orderRowByMode, ElementsOrder orderElementsByMode)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException();

            foreach(int[] row in array)
                SortElements(row, orderElementsByMode);
            SortRows(array, orderRowByMode, orderElementsByMode);
        }
        #endregion

        #region private methods
        private static void SortRows(int[][] array, RowOrder orderRowByMode, ElementsOrder orderElementsByMode)
        {
            Compare compare = null;
            switch (orderRowByMode)
            {
                case RowOrder.Maximal:
                    compare = (int[] left, int[] right, ElementsOrder orderMode) => { return FindOrder(left.Max(), right.Max(), orderMode); };
                    break;
                case RowOrder.Minimal:
                    compare = (int[] left, int[] right, ElementsOrder orderMode) => { return FindOrder(left.Min(), right.Min(), orderMode); };
                    break;
                case RowOrder.Sum:
                    compare = (int[] left, int[] right, ElementsOrder orderMode) => { return FindOrder(left.Sum(), right.Sum(), orderMode); };
                    break;
            }

            for (int i = 0; i < array.Length; i++)
                for (int j = array.Length-1; j > i; j--)
                    if (compare(array[j - 1], array[j], orderElementsByMode))
                        Swap(ref array[j - 1], ref array[j]);
        }

        private static void SortElements(int[] array, ElementsOrder orderElementsByMode)
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = array.Length-1; j > i; j--)
                    if (FindOrder(array[j - 1], array[j], orderElementsByMode))
                        Swap(ref array[j - 1], ref array[j]);
        }

        private static bool FindOrder(int left, int right, ElementsOrder orderElementsByMode)
        {
            if (orderElementsByMode == ElementsOrder.Ascending) return (left > right);
            else return (left < right);
        }

        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        #endregion
    }
}
