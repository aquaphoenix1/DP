using System;

namespace DiplomaApproximation.Swarm
{
    class Particle
    {
        public double Speed { get; set; }
        public double[] Weights { get; set; }
        public double[] CurrentValue { get; set; }
        public double[] BestValue { get; set; }

        public static double[] BestValueFromSwarm;

        private static Random random = new Random();

        public Particle(double speed, int size)
        {
            Speed = speed;
            Weights = new double[size];

            for (int i = 0; i < size; i++)
            {
                Weights[i] = random.NextDouble();
            }

            CurrentValue = new double[Weights.Length];
            BestValue = new double[Weights.Length];

            Weights.CopyTo(CurrentValue, 0);
            Weights.CopyTo(BestValue, 0);
        }
    }
}
