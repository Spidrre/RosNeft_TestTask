
namespace RosNeft_TestTask
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAlgo = new System.Windows.Forms.Button();
            this.btnClearLines = new System.Windows.Forms.Button();
            this.btnDeleteArea = new System.Windows.Forms.Button();
            this.rbSelectionArea = new System.Windows.Forms.RadioButton();
            this.rbLine = new System.Windows.Forms.RadioButton();
            this.pb = new System.Windows.Forms.PictureBox();
            this.btnClearResults = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnClearResults);
            this.groupBox1.Controls.Add(this.btnAlgo);
            this.groupBox1.Controls.Add(this.btnClearLines);
            this.groupBox1.Controls.Add(this.btnDeleteArea);
            this.groupBox1.Controls.Add(this.rbSelectionArea);
            this.groupBox1.Controls.Add(this.rbLine);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 571);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu";
            // 
            // btnAlgo
            // 
            this.btnAlgo.Location = new System.Drawing.Point(0, 219);
            this.btnAlgo.Name = "btnAlgo";
            this.btnAlgo.Size = new System.Drawing.Size(136, 23);
            this.btnAlgo.TabIndex = 5;
            this.btnAlgo.Text = "Solve task";
            this.btnAlgo.UseVisualStyleBackColor = true;
            this.btnAlgo.Click += new System.EventHandler(this.btnAlgo_Click);
            // 
            // btnClearLines
            // 
            this.btnClearLines.Location = new System.Drawing.Point(0, 354);
            this.btnClearLines.Name = "btnClearLines";
            this.btnClearLines.Size = new System.Drawing.Size(136, 23);
            this.btnClearLines.TabIndex = 3;
            this.btnClearLines.Text = "Clear Lines";
            this.btnClearLines.UseVisualStyleBackColor = true;
            this.btnClearLines.Click += new System.EventHandler(this.btnClearLines_Click);
            // 
            // btnDeleteArea
            // 
            this.btnDeleteArea.Location = new System.Drawing.Point(-1, 383);
            this.btnDeleteArea.Name = "btnDeleteArea";
            this.btnDeleteArea.Size = new System.Drawing.Size(137, 23);
            this.btnDeleteArea.TabIndex = 2;
            this.btnDeleteArea.Text = "Delete Selected Area";
            this.btnDeleteArea.UseVisualStyleBackColor = true;
            this.btnDeleteArea.Click += new System.EventHandler(this.btnDeleteArea_Click);
            // 
            // rbSelectionArea
            // 
            this.rbSelectionArea.AutoSize = true;
            this.rbSelectionArea.Location = new System.Drawing.Point(7, 53);
            this.rbSelectionArea.Name = "rbSelectionArea";
            this.rbSelectionArea.Size = new System.Drawing.Size(80, 17);
            this.rbSelectionArea.TabIndex = 1;
            this.rbSelectionArea.TabStop = true;
            this.rbSelectionArea.Text = "Select Area";
            this.rbSelectionArea.UseVisualStyleBackColor = true;
            // 
            // rbLine
            // 
            this.rbLine.AutoSize = true;
            this.rbLine.Location = new System.Drawing.Point(7, 29);
            this.rbLine.Name = "rbLine";
            this.rbLine.Size = new System.Drawing.Size(69, 17);
            this.rbLine.TabIndex = 0;
            this.rbLine.TabStop = true;
            this.rbLine.Text = "Draw line";
            this.rbLine.UseVisualStyleBackColor = true;
            // 
            // pb
            // 
            this.pb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb.BackColor = System.Drawing.Color.White;
            this.pb.Location = new System.Drawing.Point(161, 13);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(1105, 570);
            this.pb.TabIndex = 1;
            this.pb.TabStop = false;
            this.pb.Click += new System.EventHandler(this.pb_Click);
            this.pb.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_Paint);
            this.pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_MouseDown);
            this.pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_MouseMove);
            // 
            // btnClearResults
            // 
            this.btnClearResults.Location = new System.Drawing.Point(0, 413);
            this.btnClearResults.Name = "btnClearResults";
            this.btnClearResults.Size = new System.Drawing.Size(136, 23);
            this.btnClearResults.TabIndex = 6;
            this.btnClearResults.Text = "Clear results";
            this.btnClearResults.UseVisualStyleBackColor = true;
            this.btnClearResults.Click += new System.EventHandler(this.btnClearResults_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 587);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.RadioButton rbSelectionArea;
        private System.Windows.Forms.RadioButton rbLine;
        private System.Windows.Forms.Button btnClearLines;
        private System.Windows.Forms.Button btnDeleteArea;
        private System.Windows.Forms.Button btnAlgo;
        private System.Windows.Forms.Button btnClearResults;
    }
}

