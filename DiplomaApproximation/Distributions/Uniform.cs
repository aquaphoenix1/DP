using System;

namespace DiplomaApproximation.Distributions
{
    class Uniform : IDistribution
    {
        private double a;
        private double b;
        private int count;

        /// <summary>
        /// Конструктор инициализации параметров распределения
        /// 0,                  y = 0
        /// a + y * (b - a),    0 < y < 1
        /// 1                   y = 1
        /// </summary>
        /// <param name="a">Коэффициент a</param>
        /// /// <param name="b">Коэффициент b</param>
        /// <param name="count">Количество элементов выборки</param>
        public Uniform(double a, double b, int count)
        {
            this.a = a;
            this.b = b;
            this.count = count;
        }

        public double[] Generate()
        {
            double[] array = new double[count];
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                double y = rand.NextDouble();

                if(y >= 0.97)
                {
                    y = 1;
                }

                array[i] = (y == 0) ? 0 : (y == 1) ? 1 : a + y * (b - a);
            }
            return array;
        }
    }
}
