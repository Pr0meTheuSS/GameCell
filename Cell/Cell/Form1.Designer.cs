
namespace Cell
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Start = new System.Windows.Forms.Button();
            this.MobsCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HardLevel = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.MobsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HardLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(22, 163);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(128, 55);
            this.Start.TabIndex = 0;
            this.Start.Text = "Старт";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // MobsCount
            // 
            this.MobsCount.Location = new System.Drawing.Point(22, 44);
            this.MobsCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MobsCount.Name = "MobsCount";
            this.MobsCount.Size = new System.Drawing.Size(128, 22);
            this.MobsCount.TabIndex = 1;
            this.MobsCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Количество ботов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Уровень сложности";
            // 
            // HardLevel
            // 
            this.HardLevel.Location = new System.Drawing.Point(22, 111);
            this.HardLevel.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.HardLevel.Name = "HardLevel";
            this.HardLevel.Size = new System.Drawing.Size(128, 22);
            this.HardLevel.TabIndex = 3;
            this.HardLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 453);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HardLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MobsCount);
            this.Controls.Add(this.Start);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Клетка-Меню";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MobsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HardLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.NumericUpDown MobsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown HardLevel;
    }
}

