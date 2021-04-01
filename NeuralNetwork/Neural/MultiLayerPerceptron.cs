using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Neural
{
    class MultiLayerPerceptron
    {
        //Количество входных/выходных параметров
        public int InputCount;
        public int OutCount;
        public int HiddenNeuronCount;
        public int HiddenLayerCount;

        double error;
        //Массив слоёв сети
        public Layer[] LayerArray;
        public Vector[] localGradients;


        //Прямой проход сети
        public Vector Forward(Vector InputSygnals)
        {
            //Рассчитваем выходные сигналы для первого слоя
            LayerArray[0].SigmoidalActivate(InputSygnals);
            for(int i = 1; i< LayerArray.Length; i++)
            {
                LayerArray[i].SigmoidalActivate(LayerArray[i - 1].OutputSygnals);                
            }
            return LayerArray[LayerArray.Length - 1].OutputSygnals;
        }

        //Обратный проход
        public void Backward(Vector output, ref double error)
        {

            //Вычисление среднеквадратичной ошибки
            error = 0;
            for (int i = 0; i < output.M; i++)
            {
                double e = LayerArray[HiddenLayerCount].OutputSygnals[i] - output[i];
                localGradients[HiddenLayerCount][i] = e * LayerArray[HiddenLayerCount].dOutputSygnals[i];
                error += e * e / 2;
            }
            //Вычисление локальных градиентов
            for (int l = HiddenLayerCount; l > 0; l--)
            {                
                for(int j = 0; j < LayerArray[l].WeightMatrix.N; j++)
                {
                    localGradients[l - 1][j] = 0;
                    for (int k = 0; k < LayerArray[l].WeightMatrix.M; k++)
                    {
                        localGradients[l - 1][j] += localGradients[l][k] * LayerArray[l].WeightMatrix[k, j];
                    }
                    localGradients[l - 1][j] *= LayerArray[l - 1].dOutputSygnals[j];
                }
            }
            
        }

        public void UpdateWeights(double alpha, double teta, Vector Input)
        {

            for (int i = 0; i < LayerArray[0].WeightMatrix.N; i++)
            {
                for (int j = 0; j < LayerArray[0].WeightMatrix.M; j++)
                {
                    //LayerArray[0].WeightMatrix[j, i] =
                    //        LayerArray[0].WeightMatrix[j, i] +
                    //        teta * localGradients[0][j] * Input[i];
                    LayerArray[0].WeightMatrix[j, i] -= teta * localGradients[0][j] * Input[i];
                }
            }

            for (int k = 1; k <= HiddenLayerCount; k++)
            {
                for(int i = 0; i < LayerArray[k].WeightMatrix.N; i++)
                {
                    for (int j = 0; j < LayerArray[k].WeightMatrix.M; j++)
                    {
                        //LayerArray[k].WeightMatrix[j, i] =
                        //        LayerArray[k].WeightMatrix[j, i] +
                        //        teta * localGradients[k][j] * LayerArray[k-1].OutputSygnals[i];
                        LayerArray[k].WeightMatrix[j, i] -= teta * localGradients[k][j] * LayerArray[k-1].OutputSygnals[i];
                    }
                }
            }
        }

        
        

        public IEnumerable<double> Train(Vector[] X, Vector[] Y, double alpha, double teta, double epsilon, int epochs)
        {
            int epoch = 1;
            double error = 0;
            do
            {
                for (int i = 0; i < X.Length; i++)
                {
                    Forward(X[i]);
                    Backward(Y[i], ref error);
                    UpdateWeights(0, teta, X[i]);
                }
                epoch++;
                yield return error;
            } while (epoch <= epochs && error > epsilon);
        }

        public IEnumerable<double> Train(VectorPair[] XY, double alpha, double teta, double epsilon, int epochs)
        {
            int epoch = 1;
            double error = 0;
            do
            {
                for (int i = 0; i < XY.Length; i++)
                {
                    Forward(XY[i].X);
                    Backward(XY[i].Y, ref error);
                    UpdateWeights(0, teta, XY[i].X);
                }
                epoch++;
                yield return error;
            } while (epoch <= epochs && error > epsilon);
        }


        //Конструктор
        public MultiLayerPerceptron(int inCount, int outCount, int hiddenLayersCount, int neuronCount)
        {
            InputCount = inCount;
            OutCount = outCount;
            HiddenNeuronCount = neuronCount;
            HiddenLayerCount = hiddenLayersCount;
            LayerArray = new Layer[hiddenLayersCount+1];
            localGradients = new Vector[hiddenLayersCount + 1];
            //Первый слой отличается количеством весов, инициализируем его отдельно
            LayerArray[0] = new Layer(neuronCount, inCount);
            localGradients[0] = new Vector(neuronCount);
            //Инициализация слоёв
            for(int i = 1; i < hiddenLayersCount; i++)
            {
                LayerArray[i] = new Layer(neuronCount, neuronCount);
                localGradients[i] = new Vector(neuronCount);
            }
            //Последний слой также отличается количеством нейронов
            LayerArray[hiddenLayersCount] = new Layer(outCount, neuronCount);
            localGradients[hiddenLayersCount] = new Vector(neuronCount);
            //Рандомно заполняем все веса всех слоев
            for (int i = 0; i <= hiddenLayersCount; i++)
            {
                LayerArray[i].FillRandomly();
            }
        }


        public string PrintNet()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Нейронная сеть с параметрами:"+Environment.NewLine
                +"Количество входных параметров: " + InputCount + Environment.NewLine);
            sb.Append("Количество выходных параметров: " + OutCount + Environment.NewLine);
            sb.Append("Количество слоёв: " + HiddenLayerCount  + Environment.NewLine);
            sb.Append("Количество нейронов в скрытых слоях: " + HiddenNeuronCount + Environment.NewLine);
            foreach(var l in LayerArray)
            {
                sb.Append(l.WeightMatrix.Print());
            }

            return sb.ToString();

        }
    }
}
