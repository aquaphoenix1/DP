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

        public void InitCenters(double[] arrayOfX)
        {
            Layer = new Layer(CountNeurons, arrayOfX);

            switch (TypeInitialization)
            {
                case "Имитация отжига":
                    {
                        Annealing(arrayOfX);
                        break;
                    }
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
