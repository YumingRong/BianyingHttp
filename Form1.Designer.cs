namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textJson = new System.Windows.Forms.TextBox();
            this.buttonContinuousRead = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelGetCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTestTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSingleRead = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSetCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelRespondTimes = new System.Windows.Forms.Label();
            this.textCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTimeout = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelAverageTime = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelRequestTimes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textJson
            // 
            this.textJson.Font = new System.Drawing.Font("SimSun", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textJson.Location = new System.Drawing.Point(37, 275);
            this.textJson.Margin = new System.Windows.Forms.Padding(4);
            this.textJson.Multiline = true;
            this.textJson.Name = "textJson";
            this.textJson.ReadOnly = true;
            this.textJson.Size = new System.Drawing.Size(966, 141);
            this.textJson.TabIndex = 0;
            // 
            // buttonContinuousRead
            // 
            this.buttonContinuousRead.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonContinuousRead.Location = new System.Drawing.Point(801, 126);
            this.buttonContinuousRead.Margin = new System.Windows.Forms.Padding(4);
            this.buttonContinuousRead.Name = "buttonContinuousRead";
            this.buttonContinuousRead.Size = new System.Drawing.Size(202, 46);
            this.buttonContinuousRead.TabIndex = 1;
            this.buttonContinuousRead.Text = "连续拍照识别";
            this.buttonContinuousRead.UseVisualStyleBackColor = true;
            this.buttonContinuousRead.Click += new System.EventHandler(this.buttonContinuousRead_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(37, 68);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 23);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "192.168.22.186";
            // 
            // labelGetCode
            // 
            this.labelGetCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelGetCode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGetCode.Location = new System.Drawing.Point(345, 212);
            this.labelGetCode.Name = "labelGetCode";
            this.labelGetCode.Size = new System.Drawing.Size(137, 29);
            this.labelGetCode.TabIndex = 4;
            this.labelGetCode.Text = "待识别";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "辨影相机IP地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "衬套字码读取：";
            // 
            // labelTestTime
            // 
            this.labelTestTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTestTime.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTestTime.Location = new System.Drawing.Point(693, 61);
            this.labelTestTime.Name = "labelTestTime";
            this.labelTestTime.Size = new System.Drawing.Size(86, 29);
            this.labelTestTime.TabIndex = 7;
            this.labelTestTime.Text = "000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(545, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "识别时间（毫秒）：";
            // 
            // buttonSingleRead
            // 
            this.buttonSingleRead.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSingleRead.Location = new System.Drawing.Point(802, 45);
            this.buttonSingleRead.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSingleRead.Name = "buttonSingleRead";
            this.buttonSingleRead.Size = new System.Drawing.Size(201, 46);
            this.buttonSingleRead.TabIndex = 9;
            this.buttonSingleRead.Text = "单次拍照识别";
            this.buttonSingleRead.UseVisualStyleBackColor = true;
            this.buttonSingleRead.Click += new System.EventHandler(this.buttonSingleRead_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "衬套字码设置：";
            // 
            // textBoxSetCode
            // 
            this.textBoxSetCode.Location = new System.Drawing.Point(345, 142);
            this.textBoxSetCode.Name = "textBoxSetCode";
            this.textBoxSetCode.Size = new System.Drawing.Size(137, 25);
            this.textBoxSetCode.TabIndex = 11;
            this.textBoxSetCode.Text = "2182S";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(829, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "解析次数：";
            // 
            // labelRespondTimes
            // 
            this.labelRespondTimes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelRespondTimes.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRespondTimes.Location = new System.Drawing.Point(917, 208);
            this.labelRespondTimes.Name = "labelRespondTimes";
            this.labelRespondTimes.Size = new System.Drawing.Size(86, 29);
            this.labelRespondTimes.TabIndex = 12;
            this.labelRespondTimes.Text = "0";
            // 
            // textCode
            // 
            this.textCode.AcceptsReturn = true;
            this.textCode.Font = new System.Drawing.Font("SimSun", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textCode.Location = new System.Drawing.Point(37, 126);
            this.textCode.Margin = new System.Windows.Forms.Padding(4);
            this.textCode.Multiline = true;
            this.textCode.Name = "textCode";
            this.textCode.ReadOnly = true;
            this.textCode.Size = new System.Drawing.Size(160, 141);
            this.textCode.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(239, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Timeout设置（秒）：";
            // 
            // textBoxTimeout
            // 
            this.textBoxTimeout.Location = new System.Drawing.Point(398, 68);
            this.textBoxTimeout.Name = "textBoxTimeout";
            this.textBoxTimeout.Size = new System.Drawing.Size(86, 25);
            this.textBoxTimeout.TabIndex = 16;
            this.textBoxTimeout.Text = "6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(515, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "平均识别时间（毫秒）：";
            // 
            // labelAverageTime
            // 
            this.labelAverageTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelAverageTime.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAverageTime.Location = new System.Drawing.Point(693, 138);
            this.labelAverageTime.Name = "labelAverageTime";
            this.labelAverageTime.Size = new System.Drawing.Size(86, 29);
            this.labelAverageTime.TabIndex = 17;
            this.labelAverageTime.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "字符      置信率";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(605, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "测试次数：";
            // 
            // labelRequestTimes
            // 
            this.labelRequestTimes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelRequestTimes.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRequestTimes.Location = new System.Drawing.Point(693, 208);
            this.labelRequestTimes.Name = "labelRequestTimes";
            this.labelRequestTimes.Size = new System.Drawing.Size(86, 29);
            this.labelRequestTimes.TabIndex = 20;
            this.labelRequestTimes.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 429);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelRequestTimes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelAverageTime);
            this.Controls.Add(this.textBoxTimeout);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelRespondTimes);
            this.Controls.Add(this.textBoxSetCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSingleRead);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelTestTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelGetCode);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonContinuousRead);
            this.Controls.Add(this.textJson);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "衬套字码识别";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textJson;
        private System.Windows.Forms.Button buttonContinuousRead;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelGetCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTestTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSingleRead;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSetCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelRespondTimes;
        private System.Windows.Forms.TextBox textCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxTimeout;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelAverageTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelRequestTimes;
    }
}

