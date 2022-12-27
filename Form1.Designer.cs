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
            this.textHttp = new System.Windows.Forms.TextBox();
            this.buttonIdentify = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelRespondTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioSingle = new System.Windows.Forms.RadioButton();
            this.radioContinuous = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textHttp
            // 
            this.textHttp.Font = new System.Drawing.Font("SimSun", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textHttp.Location = new System.Drawing.Point(37, 185);
            this.textHttp.Margin = new System.Windows.Forms.Padding(4);
            this.textHttp.Multiline = true;
            this.textHttp.Name = "textHttp";
            this.textHttp.ReadOnly = true;
            this.textHttp.Size = new System.Drawing.Size(966, 213);
            this.textHttp.TabIndex = 0;
            // 
            // buttonIdentify
            // 
            this.buttonIdentify.Font = new System.Drawing.Font("SimSun", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonIdentify.Location = new System.Drawing.Point(557, 45);
            this.buttonIdentify.Margin = new System.Windows.Forms.Padding(4);
            this.buttonIdentify.Name = "buttonIdentify";
            this.buttonIdentify.Size = new System.Drawing.Size(132, 52);
            this.buttonIdentify.TabIndex = 1;
            this.buttonIdentify.Text = "识别";
            this.buttonIdentify.UseVisualStyleBackColor = true;
            this.buttonIdentify.Click += new System.EventHandler(this.buttonIdentify_Click);
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
            // labelResult
            // 
            this.labelResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelResult.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult.Location = new System.Drawing.Point(134, 117);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(86, 29);
            this.labelResult.TabIndex = 4;
            this.labelResult.Text = "待识别";
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
            this.label2.Location = new System.Drawing.Point(34, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "衬套字码：";
            // 
            // labelRespondTime
            // 
            this.labelRespondTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelRespondTime.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRespondTime.Location = new System.Drawing.Point(438, 117);
            this.labelRespondTime.Name = "labelRespondTime";
            this.labelRespondTime.Size = new System.Drawing.Size(86, 29);
            this.labelRespondTime.TabIndex = 7;
            this.labelRespondTime.Text = "000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "识别时间（毫秒）：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioSingle);
            this.groupBox1.Controls.Add(this.radioContinuous);
            this.groupBox1.Location = new System.Drawing.Point(236, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 54);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // radioSingle
            // 
            this.radioSingle.AutoSize = true;
            this.radioSingle.Checked = true;
            this.radioSingle.Location = new System.Drawing.Point(122, 24);
            this.radioSingle.Name = "radioSingle";
            this.radioSingle.Size = new System.Drawing.Size(88, 19);
            this.radioSingle.TabIndex = 1;
            this.radioSingle.TabStop = true;
            this.radioSingle.Text = "单次识别";
            this.radioSingle.UseVisualStyleBackColor = true;
            // 
            // radioContinuous
            // 
            this.radioContinuous.AutoSize = true;
            this.radioContinuous.Location = new System.Drawing.Point(15, 24);
            this.radioContinuous.Name = "radioContinuous";
            this.radioContinuous.Size = new System.Drawing.Size(88, 19);
            this.radioContinuous.TabIndex = 0;
            this.radioContinuous.Text = "连续识别";
            this.radioContinuous.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 429);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelRespondTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonIdentify);
            this.Controls.Add(this.textHttp);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "衬套字码识别";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textHttp;
        private System.Windows.Forms.Button buttonIdentify;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelRespondTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioSingle;
        private System.Windows.Forms.RadioButton radioContinuous;
    }
}

