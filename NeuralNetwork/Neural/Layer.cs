using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Neural
{
    class Layer
    {
        public double b;
        //Матрица входных весов
        public Matrix WeightMatrix;
        //Выходные сигналы этого слоя
        public Vector OutputSygnals;
        public Vector dOutputSygnals;
        //Функция для получения значений на выходах слоя
        public Vector SigmoidalActivate(Vector inputSygnals)
        {
            //return SigmoidalActivate(inputSygnals, 1);
            
            //Добавление во входной вектор веса смещения
            double[] values = new double[inputSygnals.M+1];
            for(int i = 0; i < inputSygnals.M; i++)
            {
                values[i] = inputSygnals[i];
            }
            values[inputSygnals.M] = b;
            Vector tempSygnals = new Vector(values);

            OutputSygnals = WeightMatrix * tempSygnals;
            for (int i = 0; i < OutputSygnals.M; i++)
            {

                OutputSygnals[i] = 1.0 / (1.0 + Math.Exp(-OutputSygnals[i]));
                //OutputSygnals[i] /= 0.5;
                ////doutputs - производные от выходов слоя
                //dOutputSygnals[i] = 2;
                dOutputSygnals[i] = OutputSygnals[i] * (1.0 - OutputSygnals[i]) ;
            }
            
            return OutputSygnals;
        }
        public Vector SigmoidalActivate(Vector inputSygnals, double a)
        {
            //Добавление во входной вектор веса смещения
            double[] values = new double[inputSygnals.M + 1];
            for (int i = 0; i < inputSygnals.M; i++)
            {
                values[i] = inputSygnals[i];
            }
            values[inputSygnals.M] = b;
            Vector tempSygnals = new Vector(values);

            OutputSygnals = WeightMatrix * tempSygnals;
            for (int i = 0; i < OutputSygnals.M; i++)
            {

                //OutputSygnals[i] = 1.0f / (1.0f + Math.Exp(-OutputSygnals[i] * a));
                //dOutputSygnals[i] =a* OutputSygnals[i] * (1.0f - OutputSygnals[i]);
                OutputSygnals[i] = OutputSygnals[i] < 0.0 ? 0.0 : OutputSygnals[i];
                dOutputSygnals[i] = OutputSygnals[i] < 0.0 ? 0.0 : 1.0; 
               // OutputSygnals[i] *= 0.5f;
                ////doutputs - производные от выходов слоя
               // dOutputSygnals[i] = 0.5f;


            }


            return OutputSygnals;
        }

        //Конструктор; prevCount - количество нейронов в предыдущем слое 
        //             NeuronCount-количество нейронов для создаваемого слоя
        public Layer(int NeuronCount, int prevCount)
        {
            b = 1;
            OutputSygnals = new Vector(NeuronCount);
            dOutputSygnals = new Vector(NeuronCount);
            WeightMatrix = new Matrix(NeuronCount, prevCount + 1);
        }
        public Layer(int NeuronCount, int prevCount, double b)
        {
            this.b = b;
            OutputSygnals = new Vector(NeuronCount);
            dOutputSygnals = new Vector(NeuronCount);
            WeightMatrix = new Matrix(NeuronCount, prevCount + 1);
        }

        //Рандомное заполнение весов 
        public void FillRandomly()
        {
            Random random = new Random();
            for (int i = 0; i < WeightMatrix.M; i++)
            {
                for (int k = 0; k < WeightMatrix.N; k++)
                {
                    WeightMatrix[i, k] = random.NextDouble()*2-1;
                    //WeightMatrix[i, k] = 0;
                }
            }
        }
        public void Nullate()
        {
            for (int i = 0; i < WeightMatrix.M; i++)
            {
                for (int k = 0; k < WeightMatrix.N; k++)
                {
                    WeightMatrix[i, k] = 0;
                }
            }
        }

    }
}
