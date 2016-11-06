namespace Combinatorics
{
    using System.Collections.Generic;

    public static class PermutationsWithoutRepetition<T>
    {
        public static IEnumerable<T[]> Generate(T[] arr)
        {
            return Generate(arr, 0);
        }

        private static IEnumerable<T[]> Generate(T[] arr, int k)
        {
            if (k >= arr.Length)
            {
                yield return arr;
            }
            else
            {
                Generate(arr, k + 1);

                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    Generate(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
