using System;

namespace DiplomaApproximation.Distributions
{
    class ExponentialOneway : IDistribution
    {
        private double lambda;
        private int count;

        /// <summary>
        /// Конструктор инициализации параметров распределения
        /// 0,                      y = 0
        /// -1/lambda * ln(1-y),    0 < y < 1
        /// </summary>
        /// <param name="lambda">Параметр лямбда</param>
        /// <param name="count">Количество элементов выборки</param>
        public ExponentialOneway(double lambda, int count)
        {
            this.lambda = lambda;
            this.count = count;
        }

        public double[] Generate()
        {
            double[] array = new double[count];
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                double y = rand.NextDouble();
                array[i] = (y == 0) ? 0 : -1 / lambda * Math.Log(1 - y);
            }
            return array;
        }
    }
}
