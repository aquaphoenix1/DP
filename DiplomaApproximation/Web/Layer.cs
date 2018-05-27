using System;

namespace DiplomaApproximation.Web
{
    public class Layer
    {
        public Neuron[] Neurons { get; private set; }
        private static Random rand = new Random();

        public Layer(int countNeurons, double[] arrayOfX)
        {
            Neurons = new Neuron[countNeurons];

            double k = arrayOfX[0];
            double e = (arrayOfX[arrayOfX.Length - 1] - k) / 20;

            for (int i = 0; i < countNeurons; i++)
            {
                Neurons[i] = new Neuron(rand.NextDouble(), 0, k);
                k += e;
            }

            double radius = MaximumRadius() / System.Math.Sqrt(2 * arrayOfX.Length);

            for (int i = 0; i < countNeurons; i++)
            {
                Neurons[i].Radius = radius;
            }
        }

        private double MaximumRadius()
        {
            double max;

            try
            {
                max = Neurons[1].Center - Neurons[0].Center;
            }
            catch
            {
                return Neurons[0].Center;
            }

            double val;
            for (int i = 1; i < Neurons.Length; i++)
            {
                if ((val = Neurons[i].Center - Neurons[i - 1].Center) > max)
                {
                    max = val;
                }
            }

            return max;
        }
    }
}
