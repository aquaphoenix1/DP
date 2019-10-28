using System;

namespace DiplomaApproximation.Distributions
{
    class Simpson : IDistribution
    {
        private double a, b;
        private int count;

        /// <summary>
        /// Консутрктор инициализации параметров распределения
        /// a,                                  y = 0
        /// a - sqrt(y / 2) * |b - a|,          0 < y <= 1/2
        /// b + sqrt((1 - y) / 2) * | b - a|,   1/2 < y <= 1
        /// b                                   y = 1
        /// </summary>
        /// <param name="a">Коэффициент a</param>
        /// <param name="b">Коэффициент b</param>
        /// <param name="count">Количество элементов выборки</param>
        public Simpson(double a, double b, int count)
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
                if (y > 0.97)
                {
                    y = 1;
                }

                array[i] = (y == 0) ? a : (y <= 0.5) ? a - Math.Sqrt(y / 2) * Math.Abs(b - a) : (y < 1) ? (b + Math.Sqrt((1 - y) / 2) * Math.Abs(b - a)) : b;
            }
            return array;
        }
    }
}
