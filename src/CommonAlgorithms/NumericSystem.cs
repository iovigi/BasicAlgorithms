namespace CommonAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NumericSystem
    {
        public static string DecimalToNBasedSystem(long decimalNumber, List<string> digits)
        {
            const int BitsInLong = 64;

            if (digits.Count < 2)
            {
                return "";
            }

            if (decimalNumber == 0)
            {
                return digits[0];
            }

            int index = BitsInLong - 1;

            long currentNumber = Math.Abs(decimalNumber);

            string[] digitArray = new string[BitsInLong];
            var radix = digits.Count;

            while (currentNumber != 0)
            {
                int remainder = (int)(currentNumber % radix);
                digitArray[index--] = digits[remainder];
                currentNumber = currentNumber / radix;
            }

            var sb = new StringBuilder();

            if (decimalNumber < 0)
            {
                sb.Append("-");
            }

            for (int i = index + 1; i < BitsInLong - index - 1; i++)
            {
                sb.Append(digitArray[i]);
            }

            var result = sb.ToString();

            return result;
        }

        public static long NBasedToDecimalSystem(string number, List<string> digits)
        {
            if (digits.Count < 2)
            {
                return 0;
            }

            if (String.IsNullOrEmpty(number))
            {
                return 0;
            }

            long result = 0;
            long multiplier = 1;
            var radix = digits.Count;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                char c = number[i];
                if (i == 0 && c == '-')
                {
                    // This is the negative sign symbol
                    result = -result;
                    break;
                }

                int digit = digits.IndexOf(c.ToString());

                if (digit == -1)
                {
                    throw new ArgumentException(
                        "Invalid character in the arbitrary numeral system number",
                        "number");
                }

                result += digit * multiplier;
                multiplier *= radix;
            }

            return result;
        }
    }
}
