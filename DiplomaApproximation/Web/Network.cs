﻿using DiplomaApproximation.Swarm;
using System;
using System.Collections.Generic;

namespace DiplomaApproximation.Web
{
    public class Network
    {
        public Layer Layer { get; private set; }

        public int CountLearningItterations { get; private set; }
        public double LearningCoefficient { get; private set; }
        public double Momentum { get; private set; }
        public double Error { get; private set; }
        public int CountNeurons { get; private set; }
        public string TypeInitialization { get; private set; }
        private double[] Param { get; set; }

        public Network()
        {

        }

        public void InitCenters(double[] arrayOfX, double[] arrayOfY)
        {
            Layer = new Layer(CountNeurons, arrayOfX);

            switch (TypeInitialization)
            {
                case "Имитация отжига":
                    {
                        Annealing(arrayOfX);
                        break;
                    }
                case "Дифференциальная эволюция":
                    {
                        DifferentialEvolution(arrayOfX, arrayOfY);
                        break;
                    }
                case "Рой частиц":
                    {
                        SwarmMethod(arrayOfX, arrayOfY);
                        break;
                    }
            }
        }

        private double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        private double MultiplyArrays(double[] first, double[] second)
        {
            double result = 0.0;

            for (int i = 0; i < first.Length; i++)
            {
                result += first[i] * second[i];
            }

            return result;
        }

        private double[] MultiplyArrayByConst(double[] array, double c)
        {
            double[] result = new double[array.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = array[i] * c;
            }

            return result;
        }

        private double[] MinusArrays(double[] first, double[] second)
        {
            double[] result = new double[first.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = first[i] - second[i];
            }

            return result;
        }

        public void SwarmMethod(double[] arrayOfX, double[] arrayOfY)
        {
            List<Particle> particles = new List<Particle>();

            var fp = 0.2;
            var fg = 0.2;
            var omega = 0.2;

            var random = new Random();

            for (int i = 0; i < CountNeurons; i++)
            {
                particles.Add(new Particle(GetRandomNumber(-1.0, 1.0), Layer.Neurons.Length));
            }

            Particle.BestValueFromSwarm = new double[Layer.Neurons.Length];
            for (int i = 0; i < Particle.BestValueFromSwarm.Length; i++)
            {
                Particle.BestValueFromSwarm[i] = 1;
            }

            for (int k = 0; k < particles.Count; k++)
            {
                var err = CountErrorForVector(particles[k].CurrentValue, arrayOfX, arrayOfY);
                var errBest = CountErrorForVector(Particle.BestValueFromSwarm, arrayOfX, arrayOfY);

                if (err < errBest)
                {
                    particles[k].CurrentValue.CopyTo(Particle.BestValueFromSwarm, 0);
                }
            }

            var countIterations = 1000;

            for (int j = 0; j < countIterations; j++)
            {
                for (int i = 0; i < CountNeurons; i++)
                {
                    var randVectorOne = new double[CountNeurons];
                    var randVectorTwo = new double[CountNeurons];

                    for (int k = 0; k < CountNeurons; k++)
                    {
                        randVectorOne[k] = random.NextDouble();
                        randVectorTwo[k] = random.NextDouble();
                    }

                    particles[i].Speed = omega * particles[i].Speed +
                        MultiplyArrays(MultiplyArrayByConst(randVectorOne, fp), MinusArrays(particles[i].BestValue, particles[i].CurrentValue)) +
                        MultiplyArrays(MultiplyArrayByConst(randVectorTwo, fg), MinusArrays(Particle.BestValueFromSwarm, particles[i].CurrentValue));

                    for (int k = 0; k < particles[i].CurrentValue.Length; k++)
                    {
                        particles[i].CurrentValue[k] += particles[i].Speed;
                    }

                    var bestError = CountErrorForVector(particles[i].BestValue, arrayOfX, arrayOfY);
                    var currentError = CountErrorForVector(particles[i].CurrentValue, arrayOfX, arrayOfY);

                    if (currentError < bestError)
                    {
                        Array.Copy(particles[i].CurrentValue, particles[i].BestValue, particles[i].BestValue.Length);

                        var bestSwarmError = CountErrorForVector(Particle.BestValueFromSwarm, arrayOfX, arrayOfY);

                        if (currentError < bestSwarmError)
                        {
                            Array.Copy(particles[i].CurrentValue, Particle.BestValueFromSwarm, Particle.BestValueFromSwarm.Length);
                        }
                    }
                }
            }

            for (int k = 0; k < CountNeurons; k++)
            {
                Layer.Neurons[k].Weight = Particle.BestValueFromSwarm[k];
            }
        }

        private void GeneratePopulations(List<double[]> populations, int count)
        {
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var population = new double[Layer.Neurons.Length];
                for (int j = 0; j < population.Length; j++)
                {
                    population[j] = random.NextDouble();
                }

                populations.Add(population);
            }
        }

        private double GenerateVector(double a, double b, double c, double F)
        {
            return c + F * (a - b);
        }

        private double CountErrorForVector(double[] weights, double[] arrayX, double[] arrayY)
        {
            for (int i = 0; i < Layer.Neurons.Length; i++)
            {
                Layer.Neurons[i].Weight = weights[i];
            }

            var error = 0.0;

            for (int i = 0; i < arrayX.Length; i++)
            {
                error += Math.Pow(OutputValue(arrayX[i]) - arrayY[i], 2);
            }

            return Math.Sqrt(error / (Layer.Neurons.Length - 1));
        }

        private void DifferentialEvolution(double[] arrayX, double[] arrayY)
        {
            var minimumIndex = 0;
            var minimumValue = Double.MaxValue;

            var populations = new List<double[]>();
            var maxPopulation = 20;
            var F = 0.8;
            var CR = 0.5;

            var outputPopulations = new List<double[]>();

            var random = new Random();

            GeneratePopulations(populations, 10);

            for (int k = 0; k < maxPopulation;)
            {

                for (int j = 0; j < populations.Count; j++)
                {
                    int randomIndex;

                    double a, b, c;
                    double j1, j2, j3;

                    do
                    {
                        randomIndex = random.Next(0, populations[j].Length);
                        a = Layer.Neurons[randomIndex].Weight;
                        j1 = randomIndex;
                    } while (randomIndex == j);

                    do
                    {
                        randomIndex = random.Next(0, populations[j].Length);
                        b = Layer.Neurons[randomIndex].Weight;
                        j2 = randomIndex;
                    } while (randomIndex == j || j2 == j1);

                    do
                    {
                        randomIndex = random.Next(0, populations[j].Length);
                        c = Layer.Neurons[randomIndex].Weight;
                        j3 = randomIndex;
                    } while (randomIndex == j || j3 == j1 || j3 == j2);

                    var n = populations[j].Length;

                    var newPopulation = new double[Layer.Neurons.Length];

                    for (int i = 0; i < n; i++)
                    {
                        var U = random.NextDouble();

                        if (i == n)
                        {
                            newPopulation[i] = GenerateVector(a, b, c, F);
                        }
                        else
                        {
                            if (U <= CR)
                            {
                                newPopulation[i] = GenerateVector(a, b, c, F);
                            }
                            else
                            {
                                newPopulation[i] = populations[j][i];
                            }
                        }
                    }

                    var errorCurrentVector = CountErrorForVector(populations[j], arrayX, arrayY);
                    var errorNewVector = CountErrorForVector(newPopulation, arrayX, arrayY);

                    if (errorCurrentVector < errorNewVector)
                    {
                        outputPopulations.Add(populations[j]);

                        if (errorCurrentVector < minimumValue)
                        {
                            minimumValue = errorCurrentVector;
                            minimumIndex = outputPopulations.Count - 1;
                        }
                    }
                    else
                    {
                        outputPopulations.Add(newPopulation);

                        if (errorNewVector < minimumValue)
                        {
                            minimumValue = errorNewVector;
                            minimumIndex = outputPopulations.Count - 1;
                        }
                    }

                    k++;
                }
            }

            for (int j = 0; j < Layer.Neurons.Length; j++)
            {
                Layer.Neurons[j].Weight = outputPopulations[minimumIndex][j];
            }
        }

        public double OutputValue(double inputX)
        {
            double sum = 0;
            for (int j = 0; j < Layer.Neurons.Length; j++)
            {
                sum += Layer.Neurons[j].Weight * Layer.Neurons[j].Compute(inputX);
            }

            return sum;
        }
        private double CalculateError(double inputX, double inputY)
        {
            return Math.Pow(OutputValue(inputX) - inputY, 2);
        }

        private bool Epoch(double[] arrayOfX, double[] arrayOfY, out double err)
        {
            err = 0;

            double[] mas = new double[arrayOfX.Length];

            for (int j = 0; j < arrayOfX.Length; j++)
            {
                double y = OutputValue(arrayOfX[j]);
                mas[j] = y;
                double difference = y - arrayOfY[j];

                for (int i = 0; i < CountNeurons; i++)
                {
                    Layer.Neurons[i].RecalculateWeight(LearningCoefficient, difference, arrayOfX[j], Momentum);
                    Layer.Neurons[i].RecalculateCenter(LearningCoefficient, difference, arrayOfX[j]);
                    Layer.Neurons[i].RecalculateRadius(LearningCoefficient, difference, arrayOfX[j]);
                }
                err += CalculateError(arrayOfX[j], arrayOfY[j]);
            }

            FormMain.Set(arrayOfX, mas);
            if (CountNeurons > 1)
            {
                err = Math.Sqrt(err / (CountNeurons - 1));
                //err /= 2;
            }
            return (err <= Error);
        }

        private void Annealing(double[] arrayX)
        {
            Random rand = new Random();

            double start = Param[0],
                temperature = start,
                rate = Param[2];

            int j = 0;

            while (temperature > Param[1])
            {
                if (j >= arrayX.Length - 1)
                {
                    j = arrayX.Length - 2;
                }

                double w, _w;
                bool isChanged = false;

                if (j == Layer.Neurons.Length - 1)
                {
                    w = OutputValue(arrayX[j]);
                    _w = OutputValue(arrayX[j - 1]);
                }
                else
                {
                    w = OutputValue(arrayX[j]);
                    _w = OutputValue(arrayX[j + 1]);
                }

                double f = 0.0;
                double res = _w - w;

                if (res <= 0)
                {
                    f = _w;
                    isChanged = true;
                }
                else
                {
                    if (rand.NextDouble() < Math.Exp(-res / temperature))
                    {
                        f = _w;
                        isChanged = true;
                    }
                    else
                    {
                        f = w;
                        isChanged = false;
                    }
                }

                Layer.Neurons[j].Weight = f;

                if (!isChanged)
                {
                    j--;
                }

                temperature *= rate;

                j++;
            }

        }

        public static List<double> errorsList;
        public static List<int> XList;

        public void Learning(FormMain form, double[] arrayOfX, double[] arrayOfY)
        {
            errorsList = new List<double>();
            XList = new List<int>();
            int j = 0;
            while (j++ < CountLearningItterations)
            {
                if (Epoch(arrayOfX, arrayOfY, out double err))
                {
                    break;
                }

                form.SetCurrentIteration(j);
                form.SetCurrentError(err);
                errorsList.Add(err);
                XList.Add(j);
            }
            form.SwitchButton(true);
            form.DrawError(errorsList.ToArray(), XList.ToArray());
        }

        public void Init(int countLearningItterations, double learningCoefficient, double momentum, double error, int countNeurons, string typeInit, double[] param)
        {
            CountLearningItterations = countLearningItterations;
            LearningCoefficient = learningCoefficient;
            Momentum = momentum;
            Error = error;
            CountNeurons = countNeurons;

            TypeInitialization = typeInit;
            Param = param;
        }
    }
}
