namespace CommonAlgorithms
{
    using System.Collections.Generic;

    public static class PrimeNumber
    {
        public static bool SimpleCheck(long n)
        {
            int i = 2;

            while (i * i <= n)
            {
                if (n % i == 0)
                {
                    return false;
                }

                i += 1;
            }

            return true;
        }

        public static bool SimpleCheck(int n)
        {
            int i = 2;

            while (i * i <= n)
            {
                if (n % i == 0)
                {
                    return false;
                }

                i += 1;
            }

            return true;
        }
        /// <summary>
        /// count zeros of multiply numbers from 0 to n.
        /// </summary>
        /// <param name="n">End of range n</param>
        /// <returns>return count of zero</returns>
        public static int CountOfZero(int n)
        {
            int zeros = 0;
            int p = 5;

            while(n>= p)
            {
                zeros += n / p;
                p *= 5;
            }

            return zeros;
        }

        /// <summary>
        /// Calculate all primes in range from 0 to n
        /// </summary>
        /// <param name="n">end of range</param>
        /// <returns>return range(every true index in array is prime number)</returns>
        public static bool[] CalculateSieveOfEratosthenes(int n)
        {
            bool[] sieve = new bool[n + 1];

            for (int i = 0; i < sieve.Length; i++)
            {
                sieve[i] = true;
            }

            sieve[0] = false;
            sieve[1] = false;

            int indexOfCandidatePrime = 2;

            while (indexOfCandidatePrime * indexOfCandidatePrime <= n)
            {
                if (sieve[indexOfCandidatePrime])
                {
                    int indexOfNotPrime = indexOfCandidatePrime * indexOfCandidatePrime;

                    while (indexOfNotPrime <= n)
                    {
                        sieve[indexOfNotPrime] = false;
                        indexOfNotPrime += indexOfCandidatePrime;
                    }
                }

                indexOfCandidatePrime += 1;
            }

            return sieve;
        }

        /// <summary>
        /// "Prime Factorization" is finding which prime numbers multiply together to make the original number.
        /// </summary>
        public static List<int> PrimeFactorization(int n)
        {
            int[] factor = new int[n + 1];
            int index = 2;

            while (index * index <= n)
            {
                if (factor[index] == 0)
                {
                    int k = index * index;

                    while (k <= n)
                    {
                        if (factor[k] == 0)
                        {
                            factor[k] = index;
                        }

                        k += 1;
                    }
                }

                index += 1;
            }

            var primeFactors = new List<int>();

            index = n;

            while(factor[index] > 0)
            {
                primeFactors.Add(factor[index]);

                index /= factor[index];
            }

            return primeFactors;
        }
    }
}
