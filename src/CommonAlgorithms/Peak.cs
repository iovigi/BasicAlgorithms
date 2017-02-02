namespace CommonAlgorithms
{
    using System;

    public static class Peak<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Find one peak from array and return index of it.
        /// </summary>
        /// <returns>return index of the peak if exist or return -1.</returns>
        public static int FindPeakIndex(T[] array)
        {
            var len = array.Length;

            if (len == 0)
            {
                return -1;
            }

            if (len == 1)
            {
                return 0;
            }

            if (len == 2)
            {
                var cmp = array[0].CompareTo(array[1]);

                if (cmp > 0)
                {
                    return 0;
                }

                if (cmp < 0)
                {
                    return 1;
                }

                return -1;
            }

            var middleIndex = len / 2;
            var currEl = array[middleIndex];
            bool noAnswer = false;


            if (currEl.CompareTo(array[middleIndex - 1]) < 0)
            {
                if (middleIndex - 1 == 0)
                {
                    return middleIndex - 1;
                }

                currEl = array[middleIndex - 1];

                for (int i = middleIndex - 1; i > 0; i--)
                {
                    if (array[i].CompareTo(array[i - 1]) > 0)
                    {
                        return i;
                    }
                }

                if (array[1].CompareTo(array[0]) < 0)
                {
                    return 0;
                }

                noAnswer = true;
            }

            if (currEl.CompareTo(array[middleIndex + 1]) < 0)
            {
                if (middleIndex + 1 == len - 1)
                {
                    return middleIndex + 1;
                }

                currEl = array[middleIndex + 1];

                for (int i = middleIndex + 1; i < len - 1; i++)
                {
                    if (array[i].CompareTo(array[i + 1]) > 0)
                    {
                        return i;
                    }
                }

                if (array[len - 2].CompareTo(array[len - 1]) < 0)
                {
                    return len - 1;
                }

                noAnswer = true;
            }

            if (noAnswer)
            {
                return -1;
            }

            if (currEl.CompareTo(array[middleIndex - 1]) > 0 && currEl.CompareTo(array[middleIndex + 1]) > 0)
            {
                return middleIndex;
            }

            if (middleIndex - 1 > 0)
            {
                for (int i = middleIndex - 1; i > 0; i--)
                {
                    if (array[i].CompareTo(array[i - 1]) >= 0)
                    {
                        continue;
                    }

                    if (i - 1 == 0 || array[i - 1].CompareTo(array[i - 2]) > 0)
                    {
                        return i - 1;
                    }
                }
            }

            if (middleIndex + 1 < len - 1)
            {
                currEl = array[middleIndex + 1];

                for (int i = middleIndex + 1; i < len - 1; i++)
                {
                    if (array[i].CompareTo(array[i + 1]) >= 0)
                    {
                        continue;
                    }

                    if (i + 1 == len - 1 || array[i + 1].CompareTo(array[i + 2]) > 0)
                    {
                        return i + 1;
                    }
                }
            }

            return -1;
        }

        public static int FindPeakIndex(T[,] array)
        {
            throw new NotImplementedException();
        }
    }
}
