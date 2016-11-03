using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorics
{
    public static class VariationsWithRepetition<T>
    {
        public IEnumerable<T[]> Generate(T[] elements,int numberOfVariations)
        {
            return Generate(elements, numberOfVariations, 0, new int[numberOfVariations]);
        }

        public IEnumerable<T[]> Generate(T[] elements, int numberOfVariations,int index,int[] indexes)
        {
            if (index >= numberOfVariations)
            {
                var result = new T[numberOfVariations];

                for (int i = 0; i < numberOfVariations; i++)
                {
                    result[i] = elements[indexes[i]];
                }

                yield return result;
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    indexes[index] = i;
                    Generate(elements, numberOfVariations, index + 1, indexes);
                }
            }
        }
    }
}
