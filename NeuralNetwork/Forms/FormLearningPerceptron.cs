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
        public FormLearningPerceptron()
        {
            perceptron = new MultiLayerPerceptron(2, 2, 3, 3);
            InitializeComponent();
        }

        private void buttonCustomValues_Click(object sender, EventArgs e)
        {
            //текст преобразуем в массив чисел
            double[] values = textBox1.Text.Split(' ').Select(x => double.Parse(x)).ToArray();
            //массив чисел преобразуем во входной вектор
            Vector Input = new Vector(values.Length);
            for(int i = 0; i < values.Length; i++)
            {
                Input[i] = values[i];
            }

            //Делаем прямой проход сети
            Vector output = perceptron.Forward(Input);

            //Это для вывода ответа
            StringBuilder sbuilder = new StringBuilder();
            for(int i = 0; i < output.M; i++)
            {
                sbuilder.Append(output[i] + " ");
            }

            MessageBox.Show(sbuilder.ToString());

        }





        MultiLayerPerceptron perceptron;
    }


}
