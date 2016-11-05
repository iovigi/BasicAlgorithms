namespace Test
{
    using System;
    using CommonAlgorithms;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            for(int i=0;i<int.MaxValue;i++)
            {
                var resMat = Fibonacci.CalculateWithMatrix(i);
                var resDyn = Fibonacci.CalculateWithDynamicOptimization(i);

                if (resMat != resDyn)
                {
                    throw new Exception(i.ToString());
                }
            }
        }
    }
}
