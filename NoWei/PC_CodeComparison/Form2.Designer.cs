namespace PC_CodeComparison
{
    partial class Form2
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
            this.Btn_Code = new System.Windows.Forms.Button();
            this.Btn_Exit = new System.Windows.Forms.Button();
            this.Btn_ClearScreen = new System.Windows.Forms.Button();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Text_Dy = new System.Windows.Forms.TextBox();
            this.Text_Js = new System.Windows.Forms.TextBox();
            this.Text_Fs = new System.Windows.Forms.TextBox();
            this.Text_Key6 = new System.Windows.Forms.TextBox();
            this.Text_Key5 = new System.Windows.Forms.TextBox();
            this.Text_Key2 = new System.Windows.Forms.TextBox();
            this.Text_Key4 = new System.Windows.Forms.TextBox();
            this.Text_Key1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Text_Key3 = new System.Windows.Forms.TextBox();
            this.OptListBox = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Code
            // 
            this.Btn_Code.Location = new System.Drawing.Point(42, 452);
            this.Btn_Code.Name = "Btn_Code";
            this.Btn_Code.Size = new System.Drawing.Size(75, 23);
            this.Btn_Code.TabIndex = 13;
            this.Btn_Code.Text = "对码";
            this.Btn_Code.UseVisualStyleBackColor = true;
            this.Btn_Code.Click += new System.EventHandler(this.Btn_Code_Click);
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.Location = new System.Drawing.Point(149, 452);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.Size = new System.Drawing.Size(75, 23);
            this.Btn_Exit.TabIndex = 14;
            this.Btn_Exit.Text = "结束";
            this.Btn_Exit.UseVisualStyleBackColor = true;
            this.Btn_Exit.Click += new System.EventHandler(this.Btn_Exit_Click);
            // 
            // Btn_ClearScreen
            // 
            this.Btn_ClearScreen.Location = new System.Drawing.Point(149, 405);
            this.Btn_ClearScreen.Name = "Btn_ClearScreen";
            this.Btn_ClearScreen.Size = new System.Drawing.Size(75, 23);
            this.Btn_ClearScreen.TabIndex = 15;
            this.Btn_ClearScreen.Text = "清屏";
            this.Btn_ClearScreen.UseVisualStyleBackColor = true;
            this.Btn_ClearScreen.Click += new System.EventHandler(this.Btn_ClearScreen_Click);
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.Location = new System.Drawing.Point(40, 405);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.Btn_Clear.TabIndex = 16;
            this.Btn_Clear.Text = "清码";
            this.Btn_Clear.UseVisualStyleBackColor = true;
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(398, 456);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "电池电压（V）";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(398, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "接收器生产序列号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(398, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "发射器生产序列号";
            // 
            // Text_Dy
            // 
            this.Text_Dy.Location = new System.Drawing.Point(292, 453);
            this.Text_Dy.Name = "Text_Dy";
            this.Text_Dy.ReadOnly = true;
            this.Text_Dy.Size = new System.Drawing.Size(100, 21);
            this.Text_Dy.TabIndex = 7;
            // 
            // Text_Js
            // 
            this.Text_Js.Location = new System.Drawing.Point(42, 368);
            this.Text_Js.Name = "Text_Js";
            this.Text_Js.ReadOnly = true;
            this.Text_Js.Size = new System.Drawing.Size(350, 21);
            this.Text_Js.TabIndex = 8;
            // 
            // Text_Fs
            // 
            this.Text_Fs.Location = new System.Drawing.Point(42, 327);
            this.Text_Fs.Name = "Text_Fs";
            this.Text_Fs.ReadOnly = true;
            this.Text_Fs.Size = new System.Drawing.Size(350, 21);
            this.Text_Fs.TabIndex = 9;
            // 
            // Text_Key6
            // 
            this.Text_Key6.BackColor = System.Drawing.Color.White;
            this.Text_Key6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Text_Key6.Enabled = false;
            this.Text_Key6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Text_Key6.Location = new System.Drawing.Point(314, 150);
            this.Text_Key6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Text_Key6.Name = "Text_Key6";
            this.Text_Key6.Size = new System.Drawing.Size(116, 23);
            this.Text_Key6.TabIndex = 0;
            this.Text_Key6.Text = "按键6";
            this.Text_Key6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Text_Key5
            // 
            this.Text_Key5.BackColor = System.Drawing.Color.White;
            this.Text_Key5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Text_Key5.Enabled = false;
            this.Text_Key5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Text_Key5.Location = new System.Drawing.Point(314, 74);
            this.Text_Key5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Text_Key5.Name = "Text_Key5";
            this.Text_Key5.Size = new System.Drawing.Size(116, 23);
            this.Text_Key5.TabIndex = 0;
            this.Text_Key5.Text = "按键5";
            this.Text_Key5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Text_Key2
            // 
            this.Text_Key2.BackColor = System.Drawing.Color.White;
            this.Text_Key2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Text_Key2.Enabled = false;
            this.Text_Key2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Text_Key2.Location = new System.Drawing.Point(174, 115);
            this.Text_Key2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Text_Key2.Name = "Text_Key2";
            this.Text_Key2.Size = new System.Drawing.Size(116, 23);
            this.Text_Key2.TabIndex = 0;
            this.Text_Key2.Text = "按键2";
            this.Text_Key2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Text_Key4
            // 
            this.Text_Key4.BackColor = System.Drawing.Color.White;
            this.Text_Key4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Text_Key4.Enabled = false;
            this.Text_Key4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Text_Key4.Location = new System.Drawing.Point(108, 181);
            this.Text_Key4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Text_Key4.Name = "Text_Key4";
            this.Text_Key4.Size = new System.Drawing.Size(116, 23);
            this.Text_Key4.TabIndex = 0;
            this.Text_Key4.Text = "按键4";
            this.Text_Key4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Text_Key1
            // 
            this.Text_Key1.BackColor = System.Drawing.Color.White;
            this.Text_Key1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Text_Key1.Enabled = false;
            this.Text_Key1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Text_Key1.Location = new System.Drawing.Point(20, 115);
            this.Text_Key1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Text_Key1.Name = "Text_Key1";
            this.Text_Key1.Size = new System.Drawing.Size(110, 23);
            this.Text_Key1.TabIndex = 0;
            this.Text_Key1.Text = "按键1";
            this.Text_Key1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Text_Key6);
            this.groupBox1.Controls.Add(this.Text_Key5);
            this.groupBox1.Controls.Add(this.Text_Key2);
            this.groupBox1.Controls.Add(this.Text_Key4);
            this.groupBox1.Controls.Add(this.Text_Key1);
            this.groupBox1.Controls.Add(this.Text_Key3);
            this.groupBox1.Location = new System.Drawing.Point(42, 61);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(460, 249);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // Text_Key3
            // 
            this.Text_Key3.BackColor = System.Drawing.Color.White;
            this.Text_Key3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Text_Key3.Enabled = false;
            this.Text_Key3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Text_Key3.Location = new System.Drawing.Point(108, 47);
            this.Text_Key3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Text_Key3.Name = "Text_Key3";
            this.Text_Key3.Size = new System.Drawing.Size(116, 23);
            this.Text_Key3.TabIndex = 0;
            this.Text_Key3.Text = "按键3";
            this.Text_Key3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OptListBox
            // 
            this.OptListBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.OptListBox.FormattingEnabled = true;
            this.OptListBox.ItemHeight = 12;
            this.OptListBox.Location = new System.Drawing.Point(523, 73);
            this.OptListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OptListBox.Name = "OptListBox";
            this.OptListBox.Size = new System.Drawing.Size(377, 388);
            this.OptListBox.TabIndex = 5;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 537);
            this.Controls.Add(this.Btn_Code);
            this.Controls.Add(this.Btn_Exit);
            this.Controls.Add(this.Btn_ClearScreen);
            this.Controls.Add(this.Btn_Clear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Text_Dy);
            this.Controls.Add(this.Text_Js);
            this.Controls.Add(this.Text_Fs);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OptListBox);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Code;
        private System.Windows.Forms.Button Btn_Exit;
        private System.Windows.Forms.Button Btn_ClearScreen;
        private System.Windows.Forms.Button Btn_Clear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Text_Dy;
        private System.Windows.Forms.TextBox Text_Js;
        private System.Windows.Forms.TextBox Text_Fs;
        private System.Windows.Forms.TextBox Text_Key6;
        private System.Windows.Forms.TextBox Text_Key5;
        private System.Windows.Forms.TextBox Text_Key2;
        private System.Windows.Forms.TextBox Text_Key4;
        private System.Windows.Forms.TextBox Text_Key1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Text_Key3;
        private System.Windows.Forms.ListBox OptListBox;
    }
}