namespace CommonAlgorithms
{
    public static class PreffixSum
    {
        public static byte[] CalculatePreffSums(this byte[] array)
        {
            byte[] preff = new byte[array.Length + 1];

            for (int i = 1; i < array.Length + 1; i++)
            {
                preff[i] = (byte)(preff[i - 1] + array[i - 1]);
            }

            return preff;
        }

        public static sbyte[] CalculatePreffSums(this sbyte[] array)
        {
            var preff = new sbyte[array.Length + 1];

            for (int i = 1; i < array.Length + 1; i++)
            {
                preff[i] = (sbyte)(preff[i - 1] + array[i - 1]);
            }

            return preff;
        }

        public static short[] CalculatePreffSums(this short[] array)
        {
            var preff = new short[array.Length + 1];

            for (int i = 1; i < array.Length + 1; i++)
            {
                preff[i] = (short)(preff[i - 1] + array[i - 1]);
            }

            return preff;
        }

        public static ushort[] CalculatePreffSums(this ushort[] array)
        {
            var preff = new ushort[array.Length + 1];

            for (int i = 1; i < array.Length + 1; i++)
            {
                preff[i] = (ushort)(preff[i - 1] + array[i - 1]);
            }

            return preff;
        }

        public static int[] CalculatePreffSums(this int[] array)
        {
            var preff = new int[array.Length + 1];

            for (int i = 1; i < array.Length + 1; i++)
            {
                preff[i] = preff[i - 1] + array[i - 1];
            }

            return preff;
        }

        public static uint[] CalculatePreffSums(this uint[] array)
        {
            var preff = new uint[array.Length + 1];

            for (int i = 1; i < array.Length + 1; i++)
            {
                preff[i] = preff[i - 1] + array[i - 1];
            }

            return preff;
        }

        public static long[] CalculatePreffSums(this long[] array)
        {
            var preff = new long[array.Length + 1];

            for (int i = 1; i < array.Length + 1; i++)
            {
                preff[i] = preff[i - 1] + array[i - 1];
            }

            return preff;
        }

        public static ulong[] CalculatePreffSums(this ulong[] array)
        {
            var preff = new ulong[array.Length + 1];

            for (int i = 1; i < array.Length + 1; i++)
            {
                preff[i] = preff[i - 1] + array[i - 1];
            }

            return preff;
        }

        public static float[] CalculatePreffSums(this float[] array)
        {
            var preff = new float[array.Length + 1];

            for (int i = 1; i < array.Length + 1; i++)
            {
                preff[i] = preff[i - 1] + array[i - 1];
            }

            return preff;
        }

        public static double[] CalculatePreffSums(this double[] array)
        {
            var preff = new double[array.Length + 1];

            for (int i = 1; i < array.Length + 1; i++)
            {
                preff[i] = preff[i - 1] + array[i - 1];
            }

            return preff;
        }

        public static decimal[] CalculatePreffSums(this decimal[] array)
        {
            var preff = new decimal[array.Length + 1];

            for (int i = 1; i < array.Length + 1; i++)
            {
                preff[i] = preff[i - 1] + array[i - 1];
            }

            return preff;
        }

        public static byte CalculateSlice(byte[] preffixSums, int startIndex, int endIndex)
        {
            return (byte)(preffixSums[endIndex + 1] - preffixSums[startIndex]);
        }

        public static sbyte CalculateSlice(sbyte[] preffixSums, int startIndex, int endIndex)
        {
            return (sbyte)(preffixSums[endIndex + 1] - preffixSums[startIndex]);
        }

        public static short CalculateSlice(short[] preffixSums, int startIndex, int endIndex)
        {
            return (short)(preffixSums[endIndex + 1] - preffixSums[startIndex]);
        }

        public static ushort CalculateSlice(ushort[] preffixSums, int startIndex, int endIndex)
        {
            return (ushort)(preffixSums[endIndex + 1] - preffixSums[startIndex]);
        }

        public static int CalculateSlice(int[] preffixSums, int startIndex,int endIndex)
        {
            return preffixSums[endIndex + 1] - preffixSums[startIndex];
        }

        public static uint CalculateSlice(uint[] preffixSums, int startIndex, int endIndex)
        {
            return preffixSums[endIndex + 1] - preffixSums[startIndex];
        }

        public static long CalculateSlice(long[] preffixSums, int startIndex, int endIndex)
        {
            return preffixSums[endIndex + 1] - preffixSums[startIndex];
        }

        public static ulong CalculateSlice(ulong[] preffixSums, int startIndex, int endIndex)
        {
            return preffixSums[endIndex + 1] - preffixSums[startIndex];
        }

        public static float CalculateSlice(float[] preffixSums, int startIndex, int endIndex)
        {
            return preffixSums[endIndex + 1] - preffixSums[startIndex];
        }

        public static double CalculateSlice(double[] preffixSums, int startIndex, int endIndex)
        {
            return preffixSums[endIndex + 1] - preffixSums[startIndex];
        }

        public static decimal CalculateSlice(decimal[] preffixSums, int startIndex, int endIndex)
        {
            return preffixSums[endIndex + 1] - preffixSums[startIndex];
        }
    }
}
