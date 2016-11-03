namespace Combinatorics
{
    using System.Collections.Generic;

    public static class CombinationsWithoutRepetition<T>
    {
        public static IEnumerable<T[]> Generate(int numberOfElementForCombination, T[] elements)
        {
            return Generate(numberOfElementForCombination, elements, 0, 0, new int[numberOfElementForCombination]);
        }

        private static IEnumerable<T[]> Generate(int numberOfElementForCombination, T[] elements, int index, int start, int[] carryArray)
        {
            if (index >= numberOfElementForCombination)
            {
                var combination = new T[numberOfElementForCombination];

                for (int i = 0; i < numberOfElementForCombination; i++)
                {
                    combination[i] = elements[carryArray[i]];
                }

                yield return combination;
            }
            else
            {
                for (int i = start; i < elements.Length; i++)
                {
                    carryArray[index] = i;

                    foreach (var combination in Generate(numberOfElementForCombination, elements, index + 1, i + 1, carryArray))
                    {
                        yield return combination;
                    }
                }
            }
        }
    }
}
