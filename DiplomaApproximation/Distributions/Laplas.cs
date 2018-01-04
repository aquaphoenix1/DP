using System;

namespace DiplomaApproximation.Distributions
{
    class Laplas : IDistribution
    {
        private double lambda, mu;
        private int count;

        /// <summary>
        /// Конструктор инициализации параметров распределения
        /// 1/lambda * ln(2*y) + mu,         0 < y < 1/2
        /// -1/lambda * ln(2*(1-y)) + mu,    1/2 <= y < 1
        /// </summary>
        /// <param name="lambda">Коэффициент лямбда</param>
        /// <param name="mu">Коэффициент мю</param>
        /// <param name="count">Количество элементов выборки</param>
        public Laplas(double lambda, double mu, int count)
        {
            this.lambda = lambda;
            this.mu = mu;
            this.count = count;
        }

        public double[] Generate()
        {
            double[] array = new double[count];
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                double y = rand.NextDouble();
                while (y == 0)
                {
                    y = rand.NextDouble();
                }

                array[i] = (y < 1 / 2) ? (1 / lambda * Math.Log(2 * y) + mu) : (-1 / lambda * Math.Log(2 * (1 - y)) + mu);
            }
            return array;
        }
    }
}
