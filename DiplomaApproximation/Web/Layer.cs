using System;

namespace DiplomaApproximation.Web
{
    class Layer
    {
        public Neuron[] Neurons { get; private set; }

        public Layer(int countNeurons, double[] arrayOfX)
        {
            Neurons = new Neuron[countNeurons];

            for (int i = 0; i < countNeurons; i++)
            {
                Neurons[i] = new Neuron(new Random().NextDouble(), 0, arrayOfX[i]);
            }

            double radius = MaximumRadius() / System.Math.Sqrt(2 * arrayOfX.Length);

            for (int i = 0; i < countNeurons; i++)
            {
                Neurons[i].Radius = radius;
            }
        }

        private double MaximumRadius()
        {
            double max = Neurons[1].Center - Neurons[0].Center;
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
