namespace TaylorSeries
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtX = new TextBox();
            txtA = new TextBox();
            cmbFunction = new ComboBox();
            btnCalculate = new Button();
            numOrder = new NumericUpDown();
            txtSteps = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            plotView = new OxyPlot.WindowsForms.PlotView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)numOrder).BeginInit();
            SuspendLayout();
            // 
            // txtX
            // 
            txtX.BackColor = Color.Honeydew;
            txtX.Location = new Point(123, 280);
            txtX.Name = "txtX";
            txtX.Size = new Size(125, 27);
            txtX.TabIndex = 1;
            // 
            // txtA
            // 
            txtA.BackColor = Color.Honeydew;
            txtA.Location = new Point(178, 198);
            txtA.Name = "txtA";
            txtA.Size = new Size(125, 27);
            txtA.TabIndex = 0;
            // 
            // cmbFunction
            // 
            cmbFunction.BackColor = Color.Honeydew;
            cmbFunction.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFunction.FormattingEnabled = true;
            cmbFunction.Items.AddRange(new object[] { "e^x", "sin(x)", "cos(x)" });
            cmbFunction.Location = new Point(121, 152);
            cmbFunction.Name = "cmbFunction";
            cmbFunction.Size = new Size(151, 28);
            cmbFunction.TabIndex = 1;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(21, 328);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(100, 39);
            btnCalculate.TabIndex = 2;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // numOrder
            // 
            numOrder.BackColor = Color.Honeydew;
            numOrder.Location = new Point(89, 240);
            numOrder.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numOrder.Name = "numOrder";
            numOrder.ReadOnly = true;
            numOrder.Size = new Size(150, 27);
            numOrder.TabIndex = 4;
            // 
            // txtSteps
            // 
            txtSteps.BackColor = Color.Honeydew;
            txtSteps.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSteps.Location = new Point(21, 417);
            txtSteps.Multiline = true;
            txtSteps.Name = "txtSteps";
            txtSteps.ReadOnly = true;
            txtSteps.ScrollBars = ScrollBars.Both;
            txtSteps.Size = new Size(411, 249);
            txtSteps.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 283);
            label1.Name = "label1";
            label1.Size = new Size(96, 20);
            label1.TabIndex = 3;
            label1.Text = "Evaluate at x:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 201);
            label2.Name = "label2";
            label2.Size = new Size(151, 20);
            label2.TabIndex = 3;
            label2.Text = "Expansion at point a: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 242);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 3;
            label3.Text = "Order n:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 155);
            label4.Name = "label4";
            label4.Size = new Size(94, 20);
            label4.TabIndex = 3;
            label4.Text = "Function f(x):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 394);
            label5.Name = "label5";
            label5.Size = new Size(48, 20);
            label5.TabIndex = 3;
            label5.Text = "Steps:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Consolas", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(21, 31);
            label6.Name = "label6";
            label6.Size = new Size(375, 33);
            label6.TabIndex = 6;
            label6.Text = "Taylor Series Calculator";
            // 
            // plotView
            // 
            plotView.BackColor = Color.Honeydew;
            plotView.Location = new Point(473, 152);
            plotView.Name = "plotView";
            plotView.PanCursor = Cursors.Hand;
            plotView.Size = new Size(852, 514);
            plotView.TabIndex = 7;
            plotView.Text = "plotView1";
            plotView.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(1383, 12);
            button1.Name = "button1";
            button1.Size = new Size(50, 50);
            button1.TabIndex = 8;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGreen;
            ClientSize = new Size(1446, 813);
            Controls.Add(button1);
            Controls.Add(plotView);
            Controls.Add(label6);
            Controls.Add(txtSteps);
            Controls.Add(numOrder);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCalculate);
            Controls.Add(cmbFunction);
            Controls.Add(txtA);
            Controls.Add(txtX);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numOrder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtX;
        private TextBox txtA;
        private ComboBox cmbFunction;
        private Button btnCalculate;
        private NumericUpDown numOrder;
        private TextBox txtSteps;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private OxyPlot.WindowsForms.PlotView plotView;
        private Button button1;
    }
}
