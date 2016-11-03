namespace CommonAlgorithms
{
    using System.Collections.Generic;

    public static class Leader
    {
        /// <summary>
        /// Find leader of array
        /// </summary>
        /// <param name="array">array</param>
        /// <returns>return leader if exist or -1.</returns>

        public static int FindLeader(this int[] array)
        {
            if(array == null || array.Length == 0)
            {
                return -1;
            }

            Stack<int> elements = new Stack<int>();
            foreach (var item in array)
            {
                if (elements.Count == 0 || elements.Peek() == item)
                {
                    elements.Push(item);
                }

                if (elements.Peek() != item)
                {
                    elements.Pop();
                }
            }

            if (elements.Count == 0)
            {
                return -1;
            }

            var candidate = elements.Pop();
            var count = 0;
            var n = array.Length;
            var minCount = n / 2 + 1;

            for (var i = 0; i < n; i++)
            {
                var el = array[i];

                if (el == candidate)
                {
                    count++;
                }

                if (count >= minCount)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
