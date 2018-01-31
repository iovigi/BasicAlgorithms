namespace Checksum
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Verhoeff Algorithm
    /// </summary>
    public static class VerhoeffAlgorithm
    {
        // The multiplication table
        static int[,] multiplicationTable = new int[,]
        {
            {0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
            {1, 2, 3, 4, 0, 6, 7, 8, 9, 5},
            {2, 3, 4, 0, 1, 7, 8, 9, 5, 6},
            {3, 4, 0, 1, 2, 8, 9, 5, 6, 7},
            {4, 0, 1, 2, 3, 9, 5, 6, 7, 8},
            {5, 9, 8, 7, 6, 0, 4, 3, 2, 1},
            {6, 5, 9, 8, 7, 1, 0, 4, 3, 2},
            {7, 6, 5, 9, 8, 2, 1, 0, 4, 3},
            {8, 7, 6, 5, 9, 3, 2, 1, 0, 4},
            {9, 8, 7, 6, 5, 4, 3, 2, 1, 0}
        };

        // The permutation table
        static int[,] permutationTable = new int[,]
        {
            {0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
            {1, 5, 7, 6, 2, 8, 3, 0, 9, 4},
            {5, 8, 0, 3, 7, 9, 6, 1, 4, 2},
            {8, 9, 1, 6, 0, 4, 3, 5, 2, 7},
            {9, 4, 5, 3, 1, 2, 6, 8, 7, 0},
            {4, 2, 8, 6, 5, 7, 3, 9, 0, 1},
            {2, 7, 9, 3, 8, 0, 6, 4, 1, 5},
            {7, 0, 4, 6, 9, 1, 3, 2, 5, 8}
        };

        // The inverse table
        static int[] inverseTable = { 0, 4, 3, 2, 1, 5, 6, 7, 8, 9 };


        /// <summary>
        /// Validates that an entered number is Verhoeff compliant.
        /// NB: Make sure the check digit is the last one!
        /// </summary>
        /// <param name="num">The number to validate</param>
        /// <returns>True if Verhoeff compliant, otherwise false</returns>
        public static bool ValidateVerhoeff(string num)
        {
            int c = 0;
            int[] myArray = StringToReversedIntArray(num);

            for (int i = 0; i < myArray.Length; i++)
            {
                c = multiplicationTable[c, permutationTable[(i % 8), myArray[i]]];
            }

            return c == 0;
        }

        /// <summary>
        /// For a given number generates a Verhoeff digit
        /// Append this check digit to num
        /// </summary>
        /// <param name="num">The number to generate the Verhoeff digit with</param>
        /// <returns>Verhoeff check digit as string</returns>
        public static string GenerateVerhoeff(string num)
        {
            int c = 0;
            int[] myArray = StringToReversedIntArray(num);

            for (int i = 0; i < myArray.Length; i++)
            {
                c = multiplicationTable[c, permutationTable[((i + 1) % 8), myArray[i]]];
            }

            return inverseTable[c].ToString();
        }

        /// <summary>
        /// Converts a string to a reversed integer array.
        /// </summary>
        /// <param name="num">The string to reverse</param>
        /// <returns>Reversed integer array</returns>
        private static int[] StringToReversedIntArray(string num)
        {
            num = StringNumber(num);
            int[] myArray = new int[num.Length];

            for (int i = 0; i < num.Length; i++)
            {
                myArray[i] = int.Parse(num.Substring(i, 1));
            }

            Array.Reverse(myArray);

            return myArray;
        }

        /// <summary>
        /// Makes a string from a number.
        /// </summary>
        /// <param name="num">The num.</param>
        /// <returns>The number in string format</returns>
        private static string StringNumber(string num)
        {
            char[] data = num.ToCharArray();
            StringBuilder newNum = new StringBuilder();

            for (int i = 0; i <= data.Count() - 1; i++)
            {
                newNum.Append(ToCode(num[i]));
            }

            return newNum.ToString();
        }

        /// <summary>
        /// To the code.
        /// </summary>
        /// <param name="num">The num.</param>
        /// <returns>The code</returns>
        /// <exception cref="System.NotSupportedException"></exception>
        private static int ToCode(char num)
        {
            //Character is uppercase
            if (num >= 'A' && num <= 'Z')
            {
                return (int)num + 10 - (int)'A';
            }
            else if (num >= 'a' && num <= 'z')
            {
                return (int)num + 10 - (int)'a';
            }
            //Character is numeric
            else if (num >= '0' && num <= '9')
            {
                return (int)num - (int)'0';
            }

            throw new NotSupportedException();
        }
    }
}
