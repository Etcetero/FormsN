using System;
using System.Collections.Generic;
using System.Linq;
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
        double b;

        double error;
        //Массив слоёв сети
        public Layer[] LayerArray;
        public Vector[] localGradients;


        //Прямой проход сети
        public Vector Forward(Vector InputSygnals)
        {
            //Рассчитваем выходные сигналы для первого слоя
            LayerArray[0].SigmoidalActivate(InputSygnals);
            for(int i = 1; i< LayerArray.Length-1; i++)
            {
                LayerArray[i].SigmoidalActivate(LayerArray[i - 1].OutputSygnals);                
            }
            LayerArray[LayerArray.Length - 1].SigmoidalActivate(LayerArray[LayerArray.Length - 2].OutputSygnals, 1f);
            return LayerArray[LayerArray.Length - 1].OutputSygnals;
        }

        //Обратный проход
        public void Backward(Vector output, ref double error)
        {

            //Вычисление среднеквадратичной ошибки
            //error = 0;
            for (int i = 0; i < output.M; i++)
            {
                double e = LayerArray[HiddenLayerCount].OutputSygnals[i] - output[i];
                localGradients[HiddenLayerCount][i] = e * LayerArray[HiddenLayerCount].dOutputSygnals[i];
                error += (e * e) / 2;
                //error += e;
            }
            
            //Вычисление локальных градиентов
            for (int l = HiddenLayerCount; l > 0; l--)
            {                
                for(int j = 0; j < LayerArray[l].WeightMatrix.N-1; j++)
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
            for (int i = 0; i < LayerArray[0].WeightMatrix.M; i++)
            {
                for (int j = 0; j < LayerArray[0].WeightMatrix.N-1; j++)
                {
                    LayerArray[0].WeightMatrix[i, j] -= teta * localGradients[0][i] * Input[j];
                }
                //Корректировка веса смещения
                LayerArray[0].WeightMatrix[i, LayerArray[0].WeightMatrix.N - 1] -= teta * localGradients[0][i] * LayerArray[0].b;
            }
            

            for (int k = 1; k <= HiddenLayerCount; k++)
            {
                for(int i = 0; i < LayerArray[k].WeightMatrix.M; i++)
                {
                    for (int j = 0; j < LayerArray[k].WeightMatrix.N-1; j++)
                    {
                        LayerArray[k].WeightMatrix[i, j] -= teta * localGradients[k][i] * LayerArray[k-1].OutputSygnals[j];
                    }
                    //Корректировка веса смещения
                    LayerArray[k].WeightMatrix[i, LayerArray[k].WeightMatrix.N - 1] -= teta * localGradients[k][i] * LayerArray[k].b;
                }
            }
            ;
        }


        Random rand;
        int[] indexes;
        public IEnumerable<double> Train(VectorPair[] XY, double alpha, double teta, double epsilon, int epochs)
        {
            indexes = Enumerable.Range(0, XY.Length).ToArray();
            int epoch = 1;
            double error = 0;
            do
            {
                error = 0;
                //Shuffle
                for(int i = XY.Length-1; i>0; i--)
                {
                    int j = rand.Next(i + 1);
                    int temp = indexes[j];
                    indexes[j] = indexes[i];
                    indexes[i] = temp;
                }
                
                //tempR =(MultiLayerPerceptron) this.MemberwiseClone();
                for (int cx = 0; cx < indexes.Length; cx++)
                {
                    Forward(XY[indexes[cx]].X);
                    Backward(XY[indexes[cx]].Y, ref error);
                    //UpdateWeights(0, teta, XY[indexes[cx]].X);
                    UpdateWeights(alpha, teta, XY[indexes[cx]].X);
                }
                //previous = (MultiLayerPerceptron)tempR.MemberwiseClone();
                
                epoch++;
                yield return error;
            } while (epoch <= epochs && (error > epsilon ));
        }


        //Конструктор
        public MultiLayerPerceptron(int inCount, int outCount, int hiddenLayersCount, int neuronCount , double b)
        {            
            rand = new Random();
            this.b = b;
            InputCount = inCount;
            OutCount = outCount;
            HiddenNeuronCount = neuronCount;
            HiddenLayerCount = hiddenLayersCount;
            LayerArray = new Layer[hiddenLayersCount+1];
            localGradients = new Vector[hiddenLayersCount + 1];
            //Первый слой отличается количеством весов, инициализируем его отдельно
            LayerArray[0] = new Layer(neuronCount, inCount, b);
            localGradients[0] = new Vector(neuronCount);
            //Инициализация слоёв
            for(int i = 1; i < hiddenLayersCount; i++)
            {
                LayerArray[i] = new Layer(neuronCount, neuronCount,b);
                localGradients[i] = new Vector(neuronCount);
            }
            //Последний слой также отличается количеством нейронов
            LayerArray[hiddenLayersCount] = new Layer(outCount, neuronCount,b);
            localGradients[hiddenLayersCount] = new Vector(neuronCount);
            //Рандомно заполняем все веса всех слоев
            for (int i = 0; i <= hiddenLayersCount; i++)
            {
                LayerArray[i].FillRandomly();
            }
            
        }
        public MultiLayerPerceptron(int inCount, int outCount, int hiddenLayersCount, int neuronCount) 
            : this(inCount, outCount, hiddenLayersCount, neuronCount, 1.0f)
        {
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
