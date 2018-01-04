using System;

namespace DiplomaApproximation.Distributions
{
    class Koshi : IDistribution
    {
        private int count;
        private double mu, a;

        /// <summary>
        /// Конструктор инициализации параметров распределения
        /// mu + a * tg(PI * (y - 1 / 2))
        /// </summary>
        /// <param name="mu">Коэффициент mu</param>
        /// <param name="a">Коэффициент a</param>
        /// <param name="count">Количество элементов выборки</param>
        public Koshi(double mu, double a, int count)
        {
            this.count = count;
            this.mu = mu;
            this.a = a;
        }

        public double[] Generate()
        {
            double[] array = new double[count];
            Random rand = new Random();

            for (int i = 0; i < count; i++)
            {
                double y = rand.NextDouble();

                array[i] = mu + a * Math.Tan(Math.PI * (y - 1 / 2));
            }
            return array;
        }
    }
}
