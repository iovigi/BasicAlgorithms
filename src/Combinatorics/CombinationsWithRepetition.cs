namespace Combinatorics
{
    using System;
    using System.Collections.Generic;

    public class CombinationsWithRepetition<T>
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

                    foreach (var combination in Generate(numberOfElementForCombination, elements, index + 1, i, carryArray))
                    {
                        yield return combination;
                    }
                }
            }
        }
    }
}
