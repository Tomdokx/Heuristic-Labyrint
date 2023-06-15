using Path_Finder.LabyrintLogic;

namespace Labyrint
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
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EndY = new System.Windows.Forms.TextBox();
            this.StartY = new System.Windows.Forms.TextBox();
            this.EndX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.startX = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(176, 42);
            this.button2.TabIndex = 0;
            this.button2.Text = "Načíst labyrint";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EndY);
            this.groupBox1.Controls.Add(this.StartY);
            this.groupBox1.Controls.Add(this.EndX);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.startX);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(219, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 123);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nastavení";
            // 
            // EndY
            // 
            this.EndY.Location = new System.Drawing.Point(233, 71);
            this.EndY.Name = "EndY";
            this.EndY.Size = new System.Drawing.Size(43, 27);
            this.EndY.TabIndex = 7;
            this.EndY.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // StartY
            // 
            this.StartY.Location = new System.Drawing.Point(97, 71);
            this.StartY.Name = "StartY";
            this.StartY.Size = new System.Drawing.Size(43, 27);
            this.StartY.TabIndex = 3;
            // 
            // EndX
            // 
            this.EndX.Location = new System.Drawing.Point(233, 29);
            this.EndX.Name = "EndX";
            this.EndX.Size = new System.Drawing.Size(43, 27);
            this.EndX.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(210, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Y";
            // 
            // startX
            // 
            this.startX.Location = new System.Drawing.Point(97, 29);
            this.startX.Name = "startX";
            this.startX.Size = new System.Drawing.Size(43, 27);
            this.startX.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(209, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "X";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(349, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 58);
            this.button1.TabIndex = 6;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cíl";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Začátek";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(96, 151);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 693);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "LabyrintSolver";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Button button2;
        private GroupBox groupBox1;
        private TextBox EndY;
        private TextBox StartY;
        private TextBox EndX;
        private Label label7;
        private TextBox startX;
        private Label label8;
        private Label label4;
        private Label label3;
        private Point? start;
        private Point? end;
        private Game game;
    }
}