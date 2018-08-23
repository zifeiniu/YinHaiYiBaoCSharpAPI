namespace YiBaoHelper
{
    partial class FrmTest
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.txtjybh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInputXml = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtappcode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtjyyzm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtjylsh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOutXml = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(712, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "打开测试文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "测试文件路径";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(124, 34);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(568, 25);
            this.txtFilePath.TabIndex = 2;
            // 
            // txtjybh
            // 
            this.txtjybh.Location = new System.Drawing.Point(207, 24);
            this.txtjybh.Name = "txtjybh";
            this.txtjybh.Size = new System.Drawing.Size(122, 25);
            this.txtjybh.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "交易编号（astr_jybh）";
            // 
            // txtInputXml
            // 
            this.txtInputXml.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtInputXml.Location = new System.Drawing.Point(3, 102);
            this.txtInputXml.Multiline = true;
            this.txtInputXml.Name = "txtInputXml";
            this.txtInputXml.Size = new System.Drawing.Size(1202, 157);
            this.txtInputXml.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "交易输入（astr_jysr_xml）";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtjybh);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtInputXml);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(15, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1208, 262);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入参数";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMsg);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtappcode);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtjyyzm);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtjylsh);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtOutXml);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 367);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1235, 349);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输出参数";
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(213, 60);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(883, 25);
            this.txtMsg.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "交易信息（astr_appmsg）";
            // 
            // txtappcode
            // 
            this.txtappcode.Location = new System.Drawing.Point(917, 24);
            this.txtappcode.Name = "txtappcode";
            this.txtappcode.Size = new System.Drawing.Size(122, 25);
            this.txtappcode.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(719, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "交易标志(along_appcode)\t";
            // 
            // txtjyyzm
            // 
            this.txtjyyzm.Location = new System.Drawing.Point(570, 24);
            this.txtjyyzm.Name = "txtjyyzm";
            this.txtjyyzm.Size = new System.Drawing.Size(122, 25);
            this.txtjyyzm.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(372, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "交易验证码（astr_jyyzm）";
            // 
            // txtjylsh
            // 
            this.txtjylsh.Location = new System.Drawing.Point(213, 24);
            this.txtjylsh.Name = "txtjylsh";
            this.txtjylsh.Size = new System.Drawing.Size(122, 25);
            this.txtjylsh.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "交易流水号（astr_jylsh）";
            // 
            // txtOutXml
            // 
            this.txtOutXml.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtOutXml.Location = new System.Drawing.Point(3, 91);
            this.txtOutXml.Multiline = true;
            this.txtOutXml.Name = "txtOutXml";
            this.txtOutXml.Size = new System.Drawing.Size(1229, 255);
            this.txtOutXml.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(862, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "调用Call";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(989, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "调用Call";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 716);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "FrmTest";
            this.Text = "测试医保";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.TextBox txtjybh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInputXml;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtjylsh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOutXml;
        private System.Windows.Forms.TextBox txtjyyzm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtappcode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
    }
}