using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NeuralNetwork.Forms;

namespace NeuralNetwork.Forms
{
    public partial class FormPerceptronCreate : Form
    {
        public FormPerceptronCreate()
        {
            InitializeComponent();
        }

        private void buttonCreatePerceptro_Click(object sender, EventArgs e)
        {
            //передача параметров формы для создания сети
            FormLearningPerceptron form = new FormLearningPerceptron(
                Convert.ToInt32(numericUpDown4.Value),
                Convert.ToInt32(numericUpDown5.Value),
                Convert.ToInt32(numericUpDown2.Value),
                Convert.ToInt32(numericUpDown3.Value)
                );
            form.Show();
        }
    }
}
