namespace CommonAlgorithms
{
    public static class EuclideanAlgorithm
    {
        public static int GreatestCommonDivisor(int a, int b)
        {
            return GreatestCommonDivisor(a, b, 1);
        }

        private static int GreatestCommonDivisor(int a, int b, int res)
        {
            if (a == b)
            {
                return res * a;
            }

            if (a % 2 == 0 && b % 2 == 0)
            {
                return GreatestCommonDivisor(a / 2, b / 2, 2 * res);
            }

            if (a % 2 == 0)
            {
                return GreatestCommonDivisor(a / 2, b, res);
            }

            if (b % 2 == 0)
            {
                return GreatestCommonDivisor(a, b / 2, res);
            }

            if (a > b)
            {
                return GreatestCommonDivisor(a - b, b, res);
            }

            return GreatestCommonDivisor(a, b - a, res);
        }

        public static int LeastCommonMultiple(int a,int b)
        {
            return (a * b) / GreatestCommonDivisor(a, b);
        }
    }
}
