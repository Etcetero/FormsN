using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using NeuralNetwork.Neural;



namespace NeuralNetwork.Forms
{

    public partial class FormLearningPerceptron : Form
    {
        public FormLearningPerceptron(int inC, int outC, int hiddenLC, int neuronC)
        {
            //Vector[] X = {
            //    new Vector(0, 0),
            //    new Vector(0, 1),
            //    new Vector(1, 0),
            //    new Vector(1, 1)
            //};

            //// массив выходных обучающих векторов
            //Vector[] Y = {
            //    new Vector(0.0), // 0 ^ 0 = 0
            //    new Vector(1.0), // 0 ^ 1 = 1
            //    new Vector(1.0), // 1 ^ 0 = 1
            //    new Vector(0.0) // 1 ^ 1 = 0
            //};

            Vector[] X = {
                 new Vector(0.136363636, 0.136363636),
                 new Vector(0.154545455, 0.154545455),
                 new Vector(0.172727273, 0.172727273),
                 new Vector(0.190909091, 0.190909091),
                 new Vector(0.209090909, 0.209090909),
                 new Vector(0.227272727, 0.227272727),
                 new Vector(0.245454545, 0.245454545),
                 new Vector(0.263636364, 0.263636364),
                 new Vector(0.281818182, 0.281818182),
                 new Vector(0.3 ,        0.3),
                 new Vector(0.318181818, 0.318181818)
            };

            Vector[] Y = {
                new Vector(0.0), // 0 ^ 0 = 0
                new Vector(0.1), // 0 ^ 1 = 1
                new Vector(0.2), // 1 ^ 0 = 1
                new Vector(0.3), // 1 ^ 1 = 0
                new Vector(0.4), // 0 ^ 0 = 0
                new Vector(0.5), // 0 ^ 1 = 1
                new Vector(0.6), // 1 ^ 0 = 1
                new Vector(0.7),
                new Vector(0.8), // 0 ^ 0 = 0
                new Vector(0.9), // 0 ^ 1 = 1
                new Vector(1.0)
            };
            //perceptron = new MultiLayerPerceptron(2, 1, 4, 3);
            perceptron = new MultiLayerPerceptron(inC, outC, hiddenLC, neuronC);
            perceptron.Train(X, Y, 0.1f, 0.1f, 0.0005f, 10000000);
            InitializeComponent();
        }

        public FormLearningPerceptron()
        {
            InitializeComponent();
        }

        private void buttonCustomValues_Click(object sender, EventArgs e)
        {
            //текст преобразуем в массив чисел
            double[] values = textBox1.Text.Split(' ').Select(x => double.Parse(x)).ToArray();
            //массив чисел преобразуем во входной вектор
            Vector Input = new Vector(values.Length);
            for (int i = 0; i < values.Length; i++)
            {
                Input[i] = values[i];
            }

            //Делаем прямой проход сети
            Vector output = perceptron.Forward(Input);

            //Это для вывода ответа
            StringBuilder sbuilder = new StringBuilder();
            for (int i = 0; i < output.M; i++)
            {
                sbuilder.Append(output[i] + " ");
            }

            MessageBox.Show(sbuilder.ToString());

        }





        MultiLayerPerceptron perceptron;

        private void FormLearningPerceptron_Load(object sender, EventArgs e)
        {
            textBox2.Text = perceptron.PrintNet();
        }
    }


}
