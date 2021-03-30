
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
            // 
            // buttonStartLearning
            // 
            this.buttonStartLearning.Location = new System.Drawing.Point(350, 12);
            this.buttonStartLearning.Name = "buttonStartLearning";
            this.buttonStartLearning.Size = new System.Drawing.Size(159, 29);
            this.buttonStartLearning.TabIndex = 1;
            this.buttonStartLearning.Text = "Обучить нейронную сеть";
            this.buttonStartLearning.UseVisualStyleBackColor = true;
            // 
            // buttonCustomValues
            // 
            this.buttonCustomValues.Location = new System.Drawing.Point(12, 307);
            this.buttonCustomValues.Name = "buttonCustomValues";
            this.buttonCustomValues.Size = new System.Drawing.Size(157, 29);
            this.buttonCustomValues.TabIndex = 2;
            this.buttonCustomValues.Text = "Подать свои значения";
            this.buttonCustomValues.UseVisualStyleBackColor = true;
            this.buttonCustomValues.Click += new System.EventHandler(this.buttonCustomValues_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(175, 311);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(334, 23);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 47);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(497, 254);
            this.textBox2.TabIndex = 4;
            // 
            // FormLearningPerceptron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 348);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonCustomValues);
            this.Controls.Add(this.buttonStartLearning);
            this.Controls.Add(this.buttonLoadTeachTable);
            this.Name = "FormLearningPerceptron";
            this.Text = "FormLearningPerceptron";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadTeachTable;
        private System.Windows.Forms.Button buttonStartLearning;
        private System.Windows.Forms.Button buttonCustomValues;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}