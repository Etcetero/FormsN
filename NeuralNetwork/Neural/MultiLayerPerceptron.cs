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
        //Массив слоёв сети
        public Layer[] LayerArray;


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



        //Конструктор
        public MultiLayerPerceptron(int inCount, int outCount, int hiddenLayersCount, int neuronCount)
        {
            InputCount = inCount;
            OutCount = outCount;
            LayerArray = new Layer[hiddenLayersCount+1];
            //Первый слой отличается количеством весов, инициализируем его отдельно
            LayerArray[0] = new Layer(neuronCount, inCount);
            //Инициализация слоёв
            for(int i = 1; i < hiddenLayersCount; i++)
            {
                LayerArray[i] = new Layer(neuronCount, neuronCount);
            }
            //Последний слой также отличается количеством нейронов
            LayerArray[hiddenLayersCount] = new Layer(outCount, neuronCount);

            //Рандомно заполняем все веса всех слоев
            for(int i = 0; i <= hiddenLayersCount; i++)
            {
                LayerArray[i].FillRandomly();
            }
        }
    }
}
