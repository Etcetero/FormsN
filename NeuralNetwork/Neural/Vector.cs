using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Neural
{
    class Vector
    {
        double[] data;
        int m;
        public int M { get => this.m; }
        public double this[int x]
        {
            get
            {
                return this.data[x];
            }
            set
            {
                this.data[x] = value;
            }
        }
        public void ProcessFunctionOverData(Action<int> func)
        {

            for (var i = 0; i < this.M; i++)
            {
                func(i);
            }

        }


        public static Vector operator *(Vector vector1, Vector vector2)
        {
            if (vector1.M != vector2.M)
            {
                throw new ArgumentException("vectors can not be multiplied");
            }
            Vector result = new Vector(vector1.M);
            result.ProcessFunctionOverData((i) =>
            {
                result[i] = vector1[i] * vector2[i];
            });
            return result;
        }

        public Vector(int m)
        {
            this.m = m;
           
            this.data = new double[m];
        }
        public Vector(params double[] values)
        {
            m = values.Length;
            data = new double[m];
            for(int i = 0; i < m; i++)
            {
                data[i] = values[i];
            }
        }
    }
}
