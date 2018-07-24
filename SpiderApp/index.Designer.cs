namespace SpiderApp
{
    partial class 船源货源抓取系统
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
            this.label8 = new System.Windows.Forms.Label();
            this.url_comb = new System.Windows.Forms.ComboBox();
            this.spidertime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnstart = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtview = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Nspidernum = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.Port = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.useproxy = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.spidertime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nspidernum)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 26);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 29;
            this.label8.Text = "数据源：";
            // 
            // url_comb
            // 
            this.url_comb.FormattingEnabled = true;
            this.url_comb.Items.AddRange(new object[] {
            "全部",
            "船源",
            "货源"});
            this.url_comb.Location = new System.Drawing.Point(89, 20);
            this.url_comb.Name = "url_comb";
            this.url_comb.Size = new System.Drawing.Size(44, 20);
            this.url_comb.TabIndex = 28;
            this.url_comb.Text = "全部";
            // 
            // spidertime
            // 
            this.spidertime.Location = new System.Drawing.Point(226, 18);
            this.spidertime.Margin = new System.Windows.Forms.Padding(2);
            this.spidertime.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spidertime.Name = "spidertime";
            this.spidertime.Size = new System.Drawing.Size(34, 21);
            this.spidertime.TabIndex = 31;
            this.spidertime.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "抓取间隔时间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(402, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 34;
            this.label3.Text = "账号：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(313, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(90, 20);
            this.comboBox1.TabIndex = 33;
            // 
            // btnstart
            // 
            this.btnstart.Location = new System.Drawing.Point(431, 17);
            this.btnstart.Margin = new System.Windows.Forms.Padding(2);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(68, 38);
            this.btnstart.TabIndex = 35;
            this.btnstart.Text = "开始";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 215);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 39;
            this.label5.Text = "日志记录：";
            // 
            // txtview
            // 
            this.txtview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtview.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtview.Location = new System.Drawing.Point(22, 230);
            this.txtview.Multiline = true;
            this.txtview.Name = "txtview";
            this.txtview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtview.Size = new System.Drawing.Size(624, 368);
            this.txtview.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 40;
            this.label4.Text = "抓取页数：";
            // 
            // Nspidernum
            // 
            this.Nspidernum.Location = new System.Drawing.Point(91, 45);
            this.Nspidernum.Margin = new System.Windows.Forms.Padding(2);
            this.Nspidernum.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.Nspidernum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Nspidernum.Name = "Nspidernum";
            this.Nspidernum.Size = new System.Drawing.Size(34, 21);
            this.Nspidernum.TabIndex = 41;
            this.Nspidernum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.useproxy);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.Port);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtHost);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(34, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 77);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "代理设置";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 27);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "代理IP：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.url_comb);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Nspidernum);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.spidertime);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.btnstart);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(34, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(569, 89);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基本设置";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(65, 20);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(123, 21);
            this.txtHost.TabIndex = 31;
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(239, 20);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(39, 21);
            this.Port.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(193, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 32;
            this.label7.Text = "端口：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(295, 27);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 34;
            this.label9.Text = "使用代理：";
            // 
            // useproxy
            // 
            this.useproxy.AutoSize = true;
            this.useproxy.Location = new System.Drawing.Point(365, 27);
            this.useproxy.Name = "useproxy";
            this.useproxy.Size = new System.Drawing.Size(48, 16);
            this.useproxy.TabIndex = 35;
            this.useproxy.Text = "使用";
            this.useproxy.UseVisualStyleBackColor = true;
            // 
            // 船源货源抓取系统
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 630);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtview);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "船源货源抓取系统";
            this.Text = "船源货源抓取系统";
            this.Load += new System.EventHandler(this.船源货源抓取系统_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spidertime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nspidernum)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox url_comb;
        private System.Windows.Forms.NumericUpDown spidertime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown Nspidernum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox useproxy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}