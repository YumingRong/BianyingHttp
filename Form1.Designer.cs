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
            this.components = new System.ComponentModel.Container();
            this.textResult = new System.Windows.Forms.TextBox();
            this.buttonIdentify = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.radioSort = new System.Windows.Forms.RadioButton();
            this.radioAngle = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // textResult
            // 
            this.textResult.Font = new System.Drawing.Font("SimSun", 96F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textResult.Location = new System.Drawing.Point(37, 116);
            this.textResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textResult.Name = "textResult";
            this.textResult.ReadOnly = true;
            this.textResult.Size = new System.Drawing.Size(1391, 190);
            this.textResult.TabIndex = 0;
            // 
            // buttonIdentify
            // 
            this.buttonIdentify.Font = new System.Drawing.Font("SimSun", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonIdentify.Location = new System.Drawing.Point(387, 11);
            this.buttonIdentify.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonIdentify.Name = "buttonIdentify";
            this.buttonIdentify.Size = new System.Drawing.Size(155, 98);
            this.buttonIdentify.TabIndex = 1;
            this.buttonIdentify.Text = "识别";
            this.buttonIdentify.UseVisualStyleBackColor = true;
            this.buttonIdentify.Click += new System.EventHandler(this.buttonIdentify_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(37, 28);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 23);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(219, 28);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(100, 29);
            this.buttonConnect.TabIndex = 3;
            this.buttonConnect.Text = "连接";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // radioSort
            // 
            this.radioSort.AutoSize = true;
            this.radioSort.Checked = true;
            this.radioSort.Location = new System.Drawing.Point(620, 51);
            this.radioSort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioSort.Name = "radioSort";
            this.radioSort.Size = new System.Drawing.Size(58, 19);
            this.radioSort.TabIndex = 4;
            this.radioSort.TabStop = true;
            this.radioSort.Text = "排序";
            this.radioSort.UseVisualStyleBackColor = true;
            this.radioSort.CheckedChanged += new System.EventHandler(this.radioSort_CheckedChanged);
            // 
            // radioAngle
            // 
            this.radioAngle.AutoSize = true;
            this.radioAngle.Location = new System.Drawing.Point(769, 51);
            this.radioAngle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioAngle.Name = "radioAngle";
            this.radioAngle.Size = new System.Drawing.Size(58, 19);
            this.radioAngle.TabIndex = 5;
            this.radioAngle.Text = "角度";
            this.radioAngle.UseVisualStyleBackColor = true;
            this.radioAngle.CheckedChanged += new System.EventHandler(this.radioAngle_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1473, 659);
            this.Controls.Add(this.radioAngle);
            this.Controls.Add(this.radioSort);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonIdentify);
            this.Controls.Add(this.textResult);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textResult;
        private System.Windows.Forms.Button buttonIdentify;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.RadioButton radioSort;
        private System.Windows.Forms.RadioButton radioAngle;
    }
}

