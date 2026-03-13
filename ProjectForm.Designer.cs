namespace Lab03_Variant24_Lisnichuk_
{
    partial class ProjectForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectForm));
            btnGenerate = new Button();
            btnRunBruteForce = new Button();
            btnRunOptimized = new Button();
            btnCompareTime = new Button();
            lblCount = new Label();
            lblBruteForceTime = new Label();
            lblOptimizedTime = new Label();
            lblComparison = new Label();
            lstOriginal = new ListBox();
            lstBruteForce = new ListBox();
            lstOptimized = new ListBox();
            SuspendLayout();
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.LemonChiffon;
            btnGenerate.Location = new Point(98, 44);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(289, 29);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "Сгенерировать интервалы (10-1000)";
            btnGenerate.UseVisualStyleBackColor = false;
            // 
            // btnRunBruteForce
            // 
            btnRunBruteForce.BackColor = Color.PaleGoldenrod;
            btnRunBruteForce.Location = new Point(98, 189);
            btnRunBruteForce.Name = "btnRunBruteForce";
            btnRunBruteForce.Size = new Size(595, 29);
            btnRunBruteForce.TabIndex = 1;
            btnRunBruteForce.Text = "Объединить пересекающиеся интервалы методом полного перебора";
            btnRunBruteForce.UseVisualStyleBackColor = false;
            // 
            // btnRunOptimized
            // 
            btnRunOptimized.BackColor = Color.Wheat;
            btnRunOptimized.Location = new Point(98, 334);
            btnRunOptimized.Name = "btnRunOptimized";
            btnRunOptimized.Size = new Size(595, 29);
            btnRunOptimized.TabIndex = 2;
            btnRunOptimized.Text = "Объединить пересекающиеся  интервалов оптимизированным методом через сортировку";
            btnRunOptimized.UseVisualStyleBackColor = false;
            btnRunOptimized.Click += btnRunOptimized_Click_1;
            // 
            // btnCompareTime
            // 
            btnCompareTime.BackColor = Color.Silver;
            btnCompareTime.Location = new Point(98, 479);
            btnCompareTime.Name = "btnCompareTime";
            btnCompareTime.Size = new Size(289, 29);
            btnCompareTime.TabIndex = 3;
            btnCompareTime.Text = "Сравнить время выполнения двух методов";
            btnCompareTime.UseVisualStyleBackColor = false;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.BackColor = Color.Plum;
            lblCount.Location = new Point(412, 48);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(242, 20);
            lblCount.TabIndex = 4;
            lblCount.Text = "Показать количество интервалов";
            lblCount.Visible = false;
            // 
            // lblBruteForceTime
            // 
            lblBruteForceTime.AutoSize = true;
            lblBruteForceTime.BackColor = Color.Plum;
            lblBruteForceTime.Location = new Point(298, 265);
            lblBruteForceTime.Name = "lblBruteForceTime";
            lblBruteForceTime.Size = new Size(399, 20);
            lblBruteForceTime.TabIndex = 5;
            lblBruteForceTime.Text = "Вывод времени исполнения метода полного перебора";
            lblBruteForceTime.Visible = false;
            // 
            // lblOptimizedTime
            // 
            lblOptimizedTime.AutoSize = true;
            lblOptimizedTime.BackColor = Color.Plum;
            lblOptimizedTime.Location = new Point(298, 408);
            lblOptimizedTime.Name = "lblOptimizedTime";
            lblOptimizedTime.Size = new Size(540, 20);
            lblOptimizedTime.TabIndex = 6;
            lblOptimizedTime.Text = "Вывод времени исполнения оптимизированного метода через сортировку";
            lblOptimizedTime.Visible = false;
            // 
            // lblComparison
            // 
            lblComparison.AutoSize = true;
            lblComparison.BackColor = Color.Violet;
            lblComparison.Location = new Point(412, 483);
            lblComparison.Name = "lblComparison";
            lblComparison.Size = new Size(133, 20);
            lblComparison.TabIndex = 7;
            lblComparison.Text = "Вывод сравнения";
            lblComparison.Visible = false;
            lblComparison.Click += lblComparison_Click;
            // 
            // lstOriginal
            // 
            lstOriginal.BackColor = SystemColors.ActiveCaption;
            lstOriginal.FormattingEnabled = true;
            lstOriginal.Location = new Point(98, 79);
            lstOriginal.Name = "lstOriginal";
            lstOriginal.Size = new Size(150, 104);
            lstOriginal.TabIndex = 8;
            // 
            // lstBruteForce
            // 
            lstBruteForce.BackColor = SystemColors.ActiveCaption;
            lstBruteForce.FormattingEnabled = true;
            lstBruteForce.Location = new Point(98, 224);
            lstBruteForce.Name = "lstBruteForce";
            lstBruteForce.Size = new Size(150, 104);
            lstBruteForce.TabIndex = 9;
            // 
            // lstOptimized
            // 
            lstOptimized.BackColor = SystemColors.ActiveCaption;
            lstOptimized.FormattingEnabled = true;
            lstOptimized.Location = new Point(98, 369);
            lstOptimized.Name = "lstOptimized";
            lstOptimized.Size = new Size(150, 104);
            lstOptimized.TabIndex = 10;
            lstOptimized.SelectedIndexChanged += lstOptimized_SelectedIndexChanged;
            // 
            // ProjectForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1172, 570);
            Controls.Add(lstOptimized);
            Controls.Add(lstBruteForce);
            Controls.Add(lstOriginal);
            Controls.Add(lblComparison);
            Controls.Add(lblOptimizedTime);
            Controls.Add(lblBruteForceTime);
            Controls.Add(lblCount);
            Controls.Add(btnCompareTime);
            Controls.Add(btnRunOptimized);
            Controls.Add(btnRunBruteForce);
            Controls.Add(btnGenerate);
            Name = "ProjectForm";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public Button btnGenerate;
        public Button btnRunBruteForce;
        public Button btnRunOptimized;
        public Button btnCompareTime;
        public Label lblCount;
        public Label lblBruteForceTime;
        public Label lblOptimizedTime;
        public Label lblComparison;
        public ListBox lstOriginal;
        public ListBox lstBruteForce;
        public ListBox lstOptimized;
    }
}
