using System;

namespace DiplomaApproximation.Distributions
{
    class Veibull : IDistribution
    {
        private double a, b;
        private int count;

        /// <summary>
        /// Консутрктор инициализации параметров распределения
        /// 0,                                  y = 0
        /// - (ln(1 - y) / b) ^ (1 / a)         0 < y < 1
        /// </summary>
        /// <param name="a">Коэффициент a</param>
        /// <param name="b">Коэффициент b</param>
        /// <param name="count">Количество элементов выборки</param>
        public Veibull(double a, double b, int count)
        {
            this.a = a;
            this.b = b;
            this.count = count;
        }

        public double[] Generate()
        {
            Random rand = new Random();
            double[] array = new double[count];
            for (int i = 0; i < count; i++)
            {
                double y = rand.NextDouble();

                array[i] = (y == 0) ? 0 : - (Math.Pow(Math.Log(1 - y) / b, 1 / a));
            }
            return array;
        }
    }
}
