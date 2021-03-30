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
            FormLearningPerceptron form = new FormLearningPerceptron();
            form.Show();
        }
    }
}
