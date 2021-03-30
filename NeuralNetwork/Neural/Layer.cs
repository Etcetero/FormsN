using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Neural
{
    class Layer
    {
        //Матрица входных весов
        public Matrix WeightMatrix;
        //Выходные сигналы этого слоя
        public Vector OutputSygnals;
        //Функция для получения значений на выходах слоя
        public Vector SigmoidalActivate(Vector inputSygnals)
        {
            OutputSygnals = WeightMatrix * inputSygnals;
            for (int i = 0; i < OutputSygnals.M; i++)
            {
                OutputSygnals[i] = 1 / (1 + Math.Exp(-OutputSygnals[i]));
            }
            return OutputSygnals;
        }

        //Конструктор; prevCount - количество нейронов в предыдущем слое 
        //             NeuronCount-количество нейронов для создаваемого слоя
        public Layer(int NeuronCount, int prevCount)
        {
            OutputSygnals = new Vector(NeuronCount);
            WeightMatrix = new Matrix(NeuronCount, prevCount);
        }

        //Рандомное заполнение весов 
        public void FillRandomly()
        {
            Random random = new Random();
            for (int i = 0; i < WeightMatrix.M; i++)
            {
                for (int k = 0; k < WeightMatrix.N; k++)
                {
                    WeightMatrix[i, k] = random.NextDouble() * 2 - 1;
                }
            }
        }

    }
}
