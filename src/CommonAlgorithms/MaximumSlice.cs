namespace CommonAlgorithms
{
    public static class MaximumSlice
    {
        public static int Calculate(int[] array, bool canBeEmptySlice)
        {
            if(array.Length ==0)
            {
                return 0;
            }

            if(array.Length == 1)
            {
                return array[0] > 0 ? array[0] : 0;
            }

            var maxSlice = 0;
            var currentSlice = 0;

            if(canBeEmptySlice)
            {
                for(int i=0;i<array.Length;i++)
                {
                    var currSum = currentSlice + array[i];

                    if(currSum > 0)
                    {
                        currentSlice = currSum;
                    }
                    else
                    {
                        currentSlice = 0;
                    }

                    if(currentSlice  > maxSlice)
                    {
                        maxSlice = currentSlice;
                    }
                }

                return maxSlice;
            }

            maxSlice = array[0];
            currentSlice = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                var currSum = currentSlice + array[i];

                if (currSum > array[i])
                {
                    currentSlice = currSum;
                }
                else
                {
                    currentSlice = array[i];
                }

                if (currentSlice > maxSlice)
                {
                    maxSlice = currentSlice;
                }
            }

            return maxSlice;
        }

        public static long Calculate(long[] array, bool canBeEmptySlice)
        {
            if (array.Length == 0)
            {
                return 0;
            }

            if (array.Length == 1)
            {
                return array[0] > 0 ? array[0] : 0;
            }

            long maxSlice = 0;
            long currentSlice = 0;

            if (canBeEmptySlice)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var currSum = currentSlice + array[i];

                    if (currSum > 0)
                    {
                        currentSlice = currSum;
                    }
                    else
                    {
                        currentSlice = 0;
                    }

                    if (currentSlice > maxSlice)
                    {
                        maxSlice = currentSlice;
                    }
                }

                return maxSlice;
            }

            maxSlice = array[0];
            currentSlice = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                var currSum = currentSlice + array[i];

                if (currSum > array[i])
                {
                    currentSlice = currSum;
                }
                else
                {
                    currentSlice = array[i];
                }

                if (currentSlice > maxSlice)
                {
                    maxSlice = currentSlice;
                }
            }

            return maxSlice;
        }

        public static double Calculate(double[] array, bool canBeEmptySlice)
        {
            if (array.Length == 0)
            {
                return 0;
            }

            if (array.Length == 1)
            {
                return array[0] > 0 ? array[0] : 0;
            }

            double maxSlice = 0;
            double currentSlice = 0;

            if (canBeEmptySlice)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var currSum = currentSlice + array[i];

                    if (currSum > 0)
                    {
                        currentSlice = currSum;
                    }
                    else
                    {
                        currentSlice = 0;
                    }

                    if (currentSlice > maxSlice)
                    {
                        maxSlice = currentSlice;
                    }
                }

                return maxSlice;
            }

            maxSlice = array[0];
            currentSlice = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                var currSum = currentSlice + array[i];

                if (currSum > array[i])
                {
                    currentSlice = currSum;
                }
                else
                {
                    currentSlice = array[i];
                }

                if (currentSlice > maxSlice)
                {
                    maxSlice = currentSlice;
                }
            }

            return maxSlice;
        }
    }
}
