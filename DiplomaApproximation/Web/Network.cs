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

        /*public Network(int countHideNeurons, double[] arrayOfX)
        {
            Layer = new Layer(countHideNeurons, arrayOfX);
        }*/

        public Network()
        {
            //Layer = new Layer();
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
            
            double[] mas = new double[arrayOfX.Length];
            

            for (int i = 0; i < arrayOfX.Length; i++)
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
            err = Math.Sqrt(err / (Layer.Neurons.Length - 1));
            return (err <= Error);
        }

        public void Learning(FormMain form, double[] arrayOfX, double[] arrayOfY)
        {
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
            //form.ChangeTextBoxCurrentIterationAndError(false);
            form.DrawError(errorsList.ToArray(), XList.ToArray());
        }

        public void Init(int countLearningItterations, double learningCoefficient, double momentum, double error)
        {
            CountLearningItterations = countLearningItterations;
            LearningCoefficient = learningCoefficient;
            Momentum = momentum;
            Error = error;
        }
    }
}
