using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Neural
{
    class Matrix
    { 
        private double[,] data;
        private bool isTransposed = false;
        private int m;
        public int M { get => this.m; }

        private int n;
        public int N { get => this.n; }
        public double this[int x, int y]
        {
            get
            {
                return this.data[x, y];
            }
            set
            {
                this.data[x, y] = value;
            }
        }

        

        public void ProcessFunctionOverData(Action<int, int> func)
        {
            for (var i = 0; i < this.M; i++)
            {
                for (var j = 0; j < this.N; j++)
                {
                    func(i, j);
                }
            }
        }
        public Matrix Transposed()
        {
            var result = new Matrix(this.N, this.M);
            result.ProcessFunctionOverData((i, j) =>
                result[i, j] = this[j, i]);
            return result;

        }
        public Vector getColumn(int nn)
        {
            Vector outp = new Vector(m);
            for(int i = 0; i < m; i++)
            {
                outp[i] = this[i,nn];
            }
            return outp;
        }

        public static Matrix operator *(Matrix matrix, double value)
        {
            Matrix result = new Matrix(matrix.M, matrix.N);
            result.ProcessFunctionOverData((i, j) =>
                result[i, j] = matrix[i, j] * value);
            return result;
        }

        public static Matrix operator *(Matrix matrix, Matrix matrix2)
        {
            if (matrix.N != matrix2.M)
            {
                throw new ArgumentException("matrixes can not be multiplied");
            }
            Matrix result = new Matrix(matrix.M, matrix2.N);
            result.ProcessFunctionOverData((i, j) => {
                for (var k = 0; k < matrix.N; k++)
                {
                    result[i, j] += matrix[i, k] * matrix2[k, j];
                }
            });
            return result;
        }
        public static Vector operator *(Matrix matrix, Vector vector)
        {
            if (matrix.N != vector.M)
            {
                throw new ArgumentException("matrixes can not be multiplied");
            }
            Vector result = new Vector(matrix.M);
            result.ProcessFunctionOverData((i) =>
            {
                for(int k = 0; k < vector.M; k++)
                {
                    result[i] += matrix[i, k] * vector[k];
                }
            });
            return result;
        }
        


        public Matrix(int m, int n)
        {
            this.m = m;
            this.n = n;
            this.data = new double[m, n];
        }


        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("::::::::::::::::::" + Environment.NewLine);
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    sb.Append($"{data[i,j]:f3}   ");                    
                }
                sb.Append(Environment.NewLine);
            }
            sb.Append(":::::::::::::::::::" + Environment.NewLine);
            return sb.ToString();
        }
    }
}
