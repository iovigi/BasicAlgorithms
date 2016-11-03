using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorics
{
    public static class PermutationsWithRepitition<T>
    {
        public static IEnumerable<T[]> Generate(T[] arr)
        {
            return Generate(arr, 0, arr.Length);
        }

        private static IEnumerable<T[]> Generate(T[] arr, int start, int n)
        {
            var result = new T[n];
            Array.Copy(arr, result, n);

            yield return result;

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (!arr[left].Equals(arr[right]))
                    {
                        Swap(ref arr[left], ref arr[right]);
                        Generate(arr, left + 1, n);
                    }
                }

                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[n - 1] = firstElement;
            }
        }

        private static void Swap(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
