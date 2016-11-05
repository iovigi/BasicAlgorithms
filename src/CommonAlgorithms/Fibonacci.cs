namespace CommonAlgorithms
{
    using System;

    public static class Fibonacci
    {
        public static long CalculateWithMatrix(long n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            long matrixCell;

            long fibonacci = CalculateMatrix(1, 1, 1, 0, Math.Abs(n) - 1, out matrixCell, out matrixCell, out matrixCell);

            return n < 0 && n % 2 == 0 ? -fibonacci : fibonacci;
        }

        private static long CalculateMatrix(
        long a11, long a12, long a21, long a22, long n,
        out long b12, out long b21, out long b22)
        {
            if (n == 0)
            {
                b12 = b21 = 0;

                return b22 = 1;
            }

            long c12, c21, c22, c11 = CalculateMatrix(
                a11, a12, a21, a22,
                n % 2 == 0 ? n / 2 : n - 1,
                out c12, out c21, out c22);

            if (n % 2 == 0)
            {
                a11 = c11; a12 = c12; a21 = c21; a22 = c22;
            }

            b12 = c11 * a12 + c12 * a22;
            b21 = c21 * a11 + c22 * a21;
            b22 = c21 * a12 + c22 * a22;

            return c11 * a11 + c12 * a21;
        }

        public static long CalculateWithDynamicOptimization(long n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            var fibArray = new long[n + 1];
            fibArray[0] = 0;
            fibArray[1] = 1;
            fibArray[2] = 1;

            for (int i = 3; i <= n; i++)
            {
                fibArray[i] = fibArray[i - 1] + fibArray[i - 2];
            }

            return fibArray[n];
        }

        public static int CalculateWithDynamicOptimization(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            var fibArray = new int[n + 1];
            fibArray[0] = 0;
            fibArray[1] = 1;
            fibArray[2] = 1;

            for (int i = 3; i <= n; i++)
            {
                fibArray[i] = fibArray[i - 1] + fibArray[i - 2];
            }

            return fibArray[n];
        }
    }
}
