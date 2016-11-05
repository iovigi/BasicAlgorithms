namespace CommonAlgorithms
{
    using System;

    public static class BinarySearch

    {
        /// <summary>
        /// Search for item. If it present in array, return item index, if doesn't return -1. 
        /// </summary>
        /// <param name="array">array of items</param>
        /// <param name="searchNumber">searched item</param>
        /// <param name="upperBound">if it is true, take upper index if there is more then one items same with seached item</param>
        /// <returns>return item index, if item present in array, if it doesn't return -1</returns>
        public static int Search<T>(this T[] array, T searchItem, bool upperBound)
            where T : IComparable<T>
        {
            int n = array.Length;
            int beginIndex = 0;
            int endIndex = n - 1;
            int result = -1;

            while (beginIndex <= endIndex)
            {
                var middleIndex = (beginIndex + endIndex) / 2;

                if (array[middleIndex].CompareTo(searchItem) == 0)
                {
                    return middleIndex;
                }

                if (array[middleIndex].CompareTo(searchItem) < 0)
                {
                    beginIndex = middleIndex + 1;
                }
                else
                {
                    endIndex = middleIndex - 1;
                }
            }

            return result;
        }
    }
}
