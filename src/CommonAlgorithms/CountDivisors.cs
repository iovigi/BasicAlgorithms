namespace CommonAlgorithms
{
    using System;

    public static class CountDivisors
    {
        public static int Calculate(int n)
        {
            int count = 0;
            int i = 1;

            var finish = Math.Sqrt(n);

            while (i < finish)
            {
                if (n % i == 0)
                {
                    count += 2;
                }

                i++;
            }

            if (i * i == n)
            {
                count += 1;
            }

            return count;
        }

        public static long Calculate(long n)
        {
            long count = 0;
            long i = 1;

            var finish = Math.Sqrt(n);

            while (i < finish)
            {
                if (n % i == 0)
                {
                    count += 2;
                }

                i++;
            }

            if (i * i == n)
            {
                count += 1;
            }

            return count;
        }
    }
}
