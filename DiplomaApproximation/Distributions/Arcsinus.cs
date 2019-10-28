using System;

namespace DiplomaApproximation.Distributions
{
    class Arcsinus : IDistribution
    {
        private double a;
        private int count;

        /// <summary>
        /// Конструктор инициализаций параметров распределения
        /// -a,              y = 0
        /// -a*cos(pi*y),    0 < y < 1
        /// a,               y = 1
        /// </summary>
        /// <param name="a">Коэффициент a</param>
        /// <param name="count">Количество элементов выборки</param>
        public Arcsinus(double a, int count)
        {
            this.a = a;
            this.count = count;
        }

        public double[] Generate()
        {
            double[] array = new double[count];
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                double y = rand.NextDouble();
                if (y >= 0.97)
                {
                    y = 1;
                }

                array[i] = (y == 0) ? -1 : (y < 1) ? -a * Math.Cos(Math.PI * y) : a;
            }
            return array;
        }
    }
}
