namespace DiplomaApproximation
{
    abstract class Tools
    {
        public static double FindMinAndMax(double[] array, out double max)
        {
            double min = array[0];
            max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
                else if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }

        public static void MiniMax(double[] array)
        {
            double max;
            double min = FindMinAndMax(array, out max);
            double difference = max - min;
            for (int i = 0; i < array.Length; i++)
            {
                if (difference > 0)
                {
                    array[i] = (array[i] - min) / difference;
                }
                else
                {
                    array[i] = 1;
                }
            }
        }

        public static double SquareSimpson(double step, double[] arrY, int countNeurons)
        {
            double square = 0.0;
            int i = 1;
            while (i < countNeurons - 1)
            {
                square += 4 * arrY[i++];
                square += 2 * arrY[i++];
            }

            square = step / 3 * (square + arrY[0] - arrY[arrY.Length - 1]);

            return square;
        }

        public static double Square(double[] arrayDistribution)
        {
            int countIntervals = 500;

            double[] arrayOfX = new double[countIntervals],
                arrayOfY = new double[countIntervals];

            double minX = arrayDistribution[0];
            double maxX = arrayDistribution[arrayDistribution.Length - 1];
            double step = (maxX - minX) / countIntervals;

            arrayOfX[0] = minX;
            int sum = 0;
            for (int i = 1; i < countIntervals; i++)
            {
                arrayOfX[i] = arrayOfX[i - 1] + step;
            }

            for (int i = 0; i < arrayDistribution.Length; i++)
            {
                for (int j = 0; j < countIntervals - 1; j++)
                {
                    if (arrayDistribution[i] >= arrayOfX[j] && arrayDistribution[i] < arrayOfX[j + 1])
                    {
                        arrayOfY[j]++;
                        sum++;
                        break;
                    }
                }
            }

            arrayOfY[arrayOfY.Length - 1] = arrayDistribution.Length - sum;

            for (int i = 0; i < countIntervals; i++)
            {
                arrayOfY[i] /= arrayDistribution.Length;
            }

            for (int i = 0; i < countIntervals; i++)
            {
                arrayOfY[i] /= step;
            }

            double square = 0.0;

            for (int i = 1; i < arrayOfY.Length - 1; i++)
            {
                square += arrayOfY[i];
            }

            square += ((arrayOfY[0] + arrayOfY[arrayOfY.Length - 1]) / 2);

            square *= step;

            return square;
        }
    }
}
