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
            this.useproxy = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbiplist = new System.Windows.Forms.ComboBox();
            this.nmccda = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spidertime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nspidernum)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmccda)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 29;
            this.label8.Text = "数据源：";
            // 
            // url_comb
            // 
            this.url_comb.FormattingEnabled = true;
            this.url_comb.Items.AddRange(new object[] {
            "全部",
            "船源",
            "货源",
            "船舶档案"});
            this.url_comb.Location = new System.Drawing.Point(119, 25);
            this.url_comb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.url_comb.Name = "url_comb";
            this.url_comb.Size = new System.Drawing.Size(57, 23);
            this.url_comb.TabIndex = 28;
            this.url_comb.Text = "全部";
            // 
            // spidertime
            // 
            this.spidertime.Location = new System.Drawing.Point(313, 19);
            this.spidertime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.spidertime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spidertime.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spidertime.Name = "spidertime";
            this.spidertime.Size = new System.Drawing.Size(45, 25);
            this.spidertime.TabIndex = 31;
            this.spidertime.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "抓取间隔时间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(536, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 34;
            this.label3.Text = "账号：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(423, 21);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(119, 23);
            this.comboBox1.TabIndex = 33;
            // 
            // btnstart
            // 
            this.btnstart.Location = new System.Drawing.Point(575, 21);
            this.btnstart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(91, 48);
            this.btnstart.TabIndex = 35;
            this.btnstart.Text = "开始";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 39;
            this.label5.Text = "日志记录：";
            // 
            // txtview
            // 
            this.txtview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtview.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtview.Location = new System.Drawing.Point(29, 288);
            this.txtview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtview.Multiline = true;
            this.txtview.Name = "txtview";
            this.txtview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtview.Size = new System.Drawing.Size(831, 459);
            this.txtview.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 40;
            this.label4.Text = "抓取页数：";
            // 
            // Nspidernum
            // 
            this.Nspidernum.Location = new System.Drawing.Point(121, 64);
            this.Nspidernum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.Nspidernum.Size = new System.Drawing.Size(45, 25);
            this.Nspidernum.TabIndex = 41;
            this.Nspidernum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbiplist);
            this.groupBox1.Controls.Add(this.useproxy);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(45, 134);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(759, 96);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "代理设置";
            // 
            // useproxy
            // 
            this.useproxy.AutoSize = true;
            this.useproxy.Checked = true;
            this.useproxy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useproxy.Location = new System.Drawing.Point(452, 29);
            this.useproxy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.useproxy.Name = "useproxy";
            this.useproxy.Size = new System.Drawing.Size(59, 19);
            this.useproxy.TabIndex = 35;
            this.useproxy.Text = "使用";
            this.useproxy.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(349, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 34;
            this.label9.Text = "使用代理：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 30;
            this.label6.Text = "代理IP：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nmccda);
            this.groupBox2.Controls.Add(this.label7);
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
            this.groupBox2.Location = new System.Drawing.Point(45, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(759, 111);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基本设置";
            // 
            // cbiplist
            // 
            this.cbiplist.FormattingEnabled = true;
            this.cbiplist.Location = new System.Drawing.Point(98, 26);
            this.cbiplist.Margin = new System.Windows.Forms.Padding(4);
            this.cbiplist.Name = "cbiplist";
            this.cbiplist.Size = new System.Drawing.Size(163, 23);
            this.cbiplist.TabIndex = 36;
            // 
            // nmccda
            // 
            this.nmccda.Location = new System.Drawing.Point(343, 60);
            this.nmccda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmccda.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nmccda.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmccda.Name = "nmccda";
            this.nmccda.Size = new System.Drawing.Size(45, 25);
            this.nmccda.TabIndex = 43;
            this.nmccda.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(195, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 15);
            this.label7.TabIndex = 42;
            this.label7.Text = "抓取船舶档案页数：";
            // 
            // 船源货源抓取系统
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 788);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtview);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "船源货源抓取系统";
            this.Text = "船源货源抓取系统";
            this.Load += new System.EventHandler(this.船源货源抓取系统_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spidertime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nspidernum)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmccda)).EndInit();
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbiplist;
        private System.Windows.Forms.NumericUpDown nmccda;
        private System.Windows.Forms.Label label7;
    }
}