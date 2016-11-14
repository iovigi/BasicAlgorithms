namespace Combinatorics
{
    using System.Collections.Generic;

    public static class VariationsWithoutRepitition<T>
    {
        public static IEnumerable<T[]> Generate(T[] elements,int numberOfVariations)
        {
            return Generate(elements, elements.Length, 0, new int[numberOfVariations], new bool[elements.Length]);
        }

        public static IEnumerable<T[]> Generate(T[] elements, int numberOfVariations, int index,int[] indexes, bool[] used)
        {
            if (index >= numberOfVariations)
            {
                var result = new T[numberOfVariations];

                for(int i=0;i< numberOfVariations; i++)
                {
                    result[i] = elements[indexes[i]];
                }

                yield return result;
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        indexes[index] = i;
                        Generate(elements, numberOfVariations, index + 1, indexes, used);
                        used[i] = false;
                    }
                }
            }
        }
    }
}
