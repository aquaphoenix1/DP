using System;

namespace DiplomaApproximation.Web
{
    class Neuron
    {
        public double Weight { get; set; }

        public double LastWeight { get; set; }

        public double Radius { get; set; }

        public double Center { get; set; }

        public Neuron(double weight, double radius, double center)
        {
            this.Weight = weight;
            this.Radius = radius;
            this.Center = center;
            this.LastWeight = 0.0;
        }

        public Neuron()
        {
            this.LastWeight = 0.0;
        }

        public double Compute(double x)
        {
            return Math.Exp(-Math.Pow(x - this.Center, 2) / (2 * Math.Pow(this.Radius, 2)));
        }

        public void RecalculateWeight(double learningCoefficient, double difference, double inputX, double momentum)
        {
            double curW = this.Weight;
            this.Weight = this.Weight - learningCoefficient * difference * Compute(inputX) + momentum * (this.Weight - this.LastWeight);
            this.LastWeight = curW;
        }

        public void RecalculateCenter(double learningCoefficient, double difference, double inputX)
        {
            this.Center -= learningCoefficient * difference * this.Weight * Math.Exp(-0.5 * Math.Pow((inputX - this.Center) / this.Radius, 2)) * (inputX - this.Center) / Math.Pow(this.Radius, 2);
        }

        public void RecalculateRadius(double learningCoefficient, double difference, double inputX)
        {
            this.Radius -= learningCoefficient * difference * this.Weight * Math.Exp(-0.5 * Math.Pow((inputX - this.Center) / this.Radius, 2)) * Math.Pow(inputX - this.Center, 2) / Math.Pow(this.Radius, 3);
        }
    }
}
