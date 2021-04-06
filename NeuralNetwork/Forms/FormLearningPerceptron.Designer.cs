
namespace NeuralNetwork.Forms
{
    partial class FormLearningPerceptron
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLoadTeachTable = new System.Windows.Forms.Button();
            this.buttonStartLearning = new System.Windows.Forms.Button();
            this.buttonCustomValues = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoadTeachTable
            // 
            this.buttonLoadTeachTable.Location = new System.Drawing.Point(12, 12);
            this.buttonLoadTeachTable.Name = "buttonLoadTeachTable";
            this.buttonLoadTeachTable.Size = new System.Drawing.Size(132, 29);
            this.buttonLoadTeachTable.TabIndex = 0;
            this.buttonLoadTeachTable.Text = "Загрузить выборку";
            this.buttonLoadTeachTable.UseVisualStyleBackColor = true;
            this.buttonLoadTeachTable.Click += new System.EventHandler(this.buttonLoadTeachTable_Click);
            // 
            // buttonStartLearning
            // 
            this.buttonStartLearning.Location = new System.Drawing.Point(350, 46);
            this.buttonStartLearning.Name = "buttonStartLearning";
            this.buttonStartLearning.Size = new System.Drawing.Size(159, 29);
            this.buttonStartLearning.TabIndex = 1;
            this.buttonStartLearning.Text = "Обучить нейронную сеть";
            this.buttonStartLearning.UseVisualStyleBackColor = true;
            this.buttonStartLearning.Click += new System.EventHandler(this.buttonStartLearning_Click);
            // 
            // buttonCustomValues
            // 
            this.buttonCustomValues.Location = new System.Drawing.Point(12, 456);
            this.buttonCustomValues.Name = "buttonCustomValues";
            this.buttonCustomValues.Size = new System.Drawing.Size(157, 29);
            this.buttonCustomValues.TabIndex = 2;
            this.buttonCustomValues.Text = "Подать свои значения";
            this.buttonCustomValues.UseVisualStyleBackColor = true;
            this.buttonCustomValues.Click += new System.EventHandler(this.buttonCustomValues_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(175, 460);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(334, 23);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 85);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(497, 365);
            this.textBox2.TabIndex = 4;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 3;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDown1.Location = new System.Drawing.Point(275, 17);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(69, 23);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Скорость обучения";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Допустимая ошибка";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 6;
            this.numericUpDown2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numericUpDown2.Location = new System.Drawing.Point(275, 51);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(69, 23);
            this.numericUpDown2.TabIndex = 8;
            this.numericUpDown2.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // FormLearningPerceptron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 495);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonCustomValues);
            this.Controls.Add(this.buttonStartLearning);
            this.Controls.Add(this.buttonLoadTeachTable);
            this.Name = "FormLearningPerceptron";
            this.Text = "FormLearningPerceptron";
            this.Load += new System.EventHandler(this.FormLearningPerceptron_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadTeachTable;
        private System.Windows.Forms.Button buttonStartLearning;
        private System.Windows.Forms.Button buttonCustomValues;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
    }
}