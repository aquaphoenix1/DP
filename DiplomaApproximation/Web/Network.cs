using System;
using System.Collections.Generic;

namespace DiplomaApproximation.Web
{
    class Network
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

        public void InitCenters(int countHideNeurons, double[] arrayOfX)
        {
            Layer = new Layer(countHideNeurons, arrayOfX);
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
            
            double[] mas = new double[CountNeurons];
            

            for (int i = 0; i < CountNeurons; i++)
            {
                double y = OutputValue(arrayOfX[i]);
                
                mas[i] = y;

                err += CalculateError(arrayOfX[i], arrayOfY[i]);

                double difference = y - arrayOfY[i];

                Layer.Neurons[i].RecalculateWeight(LearningCoefficient, difference, arrayOfX[i], Momentum);
                Layer.Neurons[i].RecalculateCenter(LearningCoefficient, difference, arrayOfX[i]);
                Layer.Neurons[i].RecalculateRadius(LearningCoefficient, difference, arrayOfX[i]);
            }

            FormMain.Set(arrayOfX, mas);
            err = Math.Sqrt(err / (CountNeurons - 1));
            return (err <= Error);
        }

        private void Annealing()
        {
            Random rand = new Random();

            double start = Param[0],
                temperature = start,
                rate = Param[1];

            while (temperature > Param[2])
            {
                for (int j = 0; j < Layer.Neurons.Length; j++)
                {
                    double w, _w;

                    if (j == Layer.Neurons.Length - 1)
                    {
                        w = OutputValue(Layer.Neurons[j].Weight);
                        _w = OutputValue(Layer.Neurons[j - 1].Weight);
                    }
                    else
                    {
                        w = OutputValue(Layer.Neurons[j].Weight);
                        _w = OutputValue(Layer.Neurons[j + 1].Weight);
                    }

                    double f = 0.0;

                    if(_w > w)
                    {
                        f = _w;
                    }
                    else
                    {
                        double value = _w - w;

                        if(rand.NextDouble() > Math.Exp(-value / (Layer.Neurons.Length * temperature)))
                        {
                            f = _w;
                        }
                        else
                        {
                            f = w;
                        }
                    }

                    Layer.Neurons[j].Weight = f;

                    temperature *= rate;
                }

                
            }
        }

        public void Learning(FormMain form, double[] arrayOfX, double[] arrayOfY)
        {
            switch (TypeInitialization)
            {
                case "Имитация отжига":
                    {
                        Annealing();
                        break;
                    }
            }

            List<double> errorsList = new List<double>();
            List<int> XList = new List<int>();
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
