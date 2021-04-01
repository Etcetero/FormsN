using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using NeuralNetwork.Neural;
using System.Threading.Tasks;
using System.IO;
using OfficeOpenXml;
using System.Threading;

namespace NeuralNetwork.Forms
{

    public partial class FormLearningPerceptron : Form
    {
        int inCount;
        int outCount;
        int hiddenLayerCount;
        int neuronCount;
        Vector[] X;
        Vector[] Y;
        VectorPair[] Inputs;
        public FormLearningPerceptron(int inC, int outC, int hiddenLC, int neuronC)
        {
            inCount = inC;
            outCount = outC;
            hiddenLayerCount = hiddenLC;
            neuronCount = neuronC;

            //perceptron = new MultiLayerPerceptron(2, 1, 4, 3);
            //perceptron = new MultiLayerPerceptron(inC, outC, hiddenLC, neuronC);
            //perceptron.Train(X, Y, 0.5f, 0.5f, 0.005f, 10000000);
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
            //textBox2.Text = perceptron.PrintNet();
        }

        private void buttonStartLearning_Click(object sender, EventArgs e)
        {
            perceptron = new MultiLayerPerceptron(inCount, outCount, hiddenLayerCount, neuronCount);
            
            double teta = Convert.ToDouble(numericUpDown1.Value);
            double epsilon = Convert.ToDouble(numericUpDown2.Value);
            var tempo = perceptron.Train(Inputs, teta, teta, epsilon, 100000);
            int i = 0;
            foreach (var x in tempo)
            {
                
                textBox2.Text += "Эпоха: " + (++i) + "; Среднекв. ошибка: " + x.ToString() + "\r\n";
            }
            textBox2.Text += perceptron.PrintNet();

        }
        private void func()
        {
            
            
        }

        private void buttonLoadTeachTable_Click(object sender, EventArgs e)
        {
            //Открытие файла
            OpenFileDialog OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                FileInfo file = new FileInfo(OPF.FileName);
                using(ExcelPackage excelPackage = new ExcelPackage(file))
                {
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[0];

                    int rowCount =    workSheet.Dimension.Rows;
                    int columnCount = workSheet.Dimension.Columns;

                    Inputs = new VectorPair[rowCount+1];

                    for(int i = 0; i < rowCount-1; i++)
                    {
                        double[] values = new double[columnCount];
                        for(int j = 0; j < columnCount; j++)
                        {
                            values[j] = Convert.ToDouble(workSheet.Cells[i+2, j+1].Value.ToString());
                        }
                        Inputs[i].X = new Vector(inCount);
                        Inputs[i].Y = new Vector(outCount);
                        for (int k = 0; k < inCount; k++)
                        {
                            Inputs[i].X[k] = values[k];
                        }
                        for(int k = inCount; k < outCount+inCount; k++)
                        {
                            Inputs[i].Y[k - inCount] = values[k];
                        }
                    }

                    GetMaxMin();
                    NormalizeInputTable();
                }
            }
        }

        private void GetMaxMin()
        {
            //Следующий блок вычисляет минимальные и максимальные элементы столбцов
            // и добавляет в конец массива
            Inputs[Inputs.Length - 2] = new VectorPair();
            Inputs[Inputs.Length - 1] = new VectorPair();
            Inputs[Inputs.Length - 2].X = new Vector(inCount);
            Inputs[Inputs.Length - 1].X = new Vector(inCount);
            Inputs[Inputs.Length - 2].Y = new Vector(outCount);
            Inputs[Inputs.Length - 1].Y = new Vector(outCount);
            for (int i = 0; i < Inputs[0].X.M; i++)
            {
                double min = Inputs[0].X[i];
                double max = Inputs[0].X[i];
                for (int k = 0; k < Inputs.Length - 2; k++)
                {
                    min = (min < Inputs[k].X[i]) ? min : Inputs[k].X[i];
                    max = (max > Inputs[k].X[i]) ? max : Inputs[k].X[i];
                }
                Inputs[Inputs.Length - 1].X[i] = max;
                Inputs[Inputs.Length - 2].X[i] = min;
            }
            for (int i = 0; i < Inputs[0].Y.M; i++)
            {
                double min = Inputs[0].Y[i];
                double max = Inputs[0].Y[i];
                for (int k = 0; k < Inputs.Length - 2; k++)
                {
                    min = (min < Inputs[k].Y[i]) ? min : Inputs[k].Y[i];
                    max = (max > Inputs[k].Y[i]) ? max : Inputs[k].Y[i];
                }
                Inputs[Inputs.Length - 1].Y[i] = max;
                Inputs[Inputs.Length - 2].Y[i] = min;
            }
        }

        private void NormalizeInputTable()
        {
            for(int k = 0; k < Inputs.Length-2; k++)
            {
                for(int i = 0; i < Inputs[k].X.M; i++)
                {
                    Inputs[k].X[i] = (Inputs[k].X[i] - Inputs[Inputs.Length - 2].X[i]) /
                                        (Inputs[Inputs.Length - 1].X[i] - Inputs[Inputs.Length - 2].X[i]);
                }
            }
            for (int k = 0; k < Inputs.Length-2 ; k++)
            {
                for (int i = 0; i < Inputs[k].Y.M; i++)
                {
                    Inputs[k].Y[i] = (Inputs[k].Y[i] - Inputs[Inputs.Length - 2].Y[i]) /
                                        (Inputs[Inputs.Length - 1].Y[i] - Inputs[Inputs.Length - 2].Y[i]);
                }
            }
            
        }
        

       
    }


}
