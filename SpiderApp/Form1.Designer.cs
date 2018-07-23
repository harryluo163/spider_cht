namespace SpiderApp
{
    partial class Spider
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
            this.txtview = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblnum2 = new System.Windows.Forms.Label();
            this.btbse = new System.Windows.Forms.Button();
            this.btnstart = new System.Windows.Forms.Button();
            this.txtbusernum = new System.Windows.Forms.NumericUpDown();
            this.spidertime = new System.Windows.Forms.NumericUpDown();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.url_comb = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.phonebutnum = new System.Windows.Forms.NumericUpDown();
            this.btnout = new System.Windows.Forms.Button();
            this.btbupdata = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btbadd = new System.Windows.Forms.Button();
            this.txtphone = new System.Windows.Forms.TextBox();
            this.lblphone = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtbusernum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spidertime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phonebutnum)).BeginInit();
            this.SuspendLayout();
            // 
            // txtview
            // 
            this.txtview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtview.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtview.Location = new System.Drawing.Point(405, 274);
            this.txtview.Margin = new System.Windows.Forms.Padding(4);
            this.txtview.Multiline = true;
            this.txtview.Name = "txtview";
            this.txtview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtview.Size = new System.Drawing.Size(583, 412);
            this.txtview.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "账号采集次数：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(551, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "抓取间隔时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "手机号导入：";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(36, 274);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(327, 400);
            this.textBox1.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "已抓手机号：";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(403, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "日志记录：";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblnum2
            // 
            this.lblnum2.AutoSize = true;
            this.lblnum2.Location = new System.Drawing.Point(167, 244);
            this.lblnum2.Name = "lblnum2";
            this.lblnum2.Size = new System.Drawing.Size(30, 15);
            this.lblnum2.TabIndex = 16;
            this.lblnum2.Text = "0条";
            // 
            // btbse
            // 
            this.btbse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btbse.Location = new System.Drawing.Point(151, 125);
            this.btbse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btbse.Name = "btbse";
            this.btbse.Size = new System.Drawing.Size(109, 26);
            this.btbse.TabIndex = 17;
            this.btbse.Text = "选择文件";
            this.btbse.UseVisualStyleBackColor = true;
            this.btbse.Click += new System.EventHandler(this.btbse_Click);
            // 
            // btnstart
            // 
            this.btnstart.Location = new System.Drawing.Point(835, 68);
            this.btnstart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(107, 68);
            this.btnstart.TabIndex = 19;
            this.btnstart.Text = "开始";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // txtbusernum
            // 
            this.txtbusernum.Location = new System.Drawing.Point(157, 26);
            this.txtbusernum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbusernum.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.txtbusernum.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtbusernum.Name = "txtbusernum";
            this.txtbusernum.Size = new System.Drawing.Size(120, 25);
            this.txtbusernum.TabIndex = 23;
            this.txtbusernum.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // spidertime
            // 
            this.spidertime.Location = new System.Drawing.Point(688, 28);
            this.spidertime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.spidertime.Name = "spidertime";
            this.spidertime.Size = new System.Drawing.Size(120, 25);
            this.spidertime.TabIndex = 24;
            this.spidertime.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // tbFilePath
            // 
            this.tbFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilePath.Location = new System.Drawing.Point(275, 126);
            this.tbFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(241, 25);
            this.tbFilePath.TabIndex = 25;
            // 
            // url_comb
            // 
            this.url_comb.FormattingEnabled = true;
            this.url_comb.Location = new System.Drawing.Point(405, 28);
            this.url_comb.Margin = new System.Windows.Forms.Padding(4);
            this.url_comb.Name = "url_comb";
            this.url_comb.Size = new System.Drawing.Size(119, 23);
            this.url_comb.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(319, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 27;
            this.label8.Text = "账号：";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(947, 99);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 36);
            this.button1.TabIndex = 28;
            this.button1.Text = "暂停";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 15);
            this.label6.TabIndex = 29;
            this.label6.Text = "自动导出行数：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(319, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(227, 15);
            this.label9.TabIndex = 30;
            this.label9.Text = "（一个excel保存多少手机信息）";
            // 
            // phonebutnum
            // 
            this.phonebutnum.Location = new System.Drawing.Point(151, 181);
            this.phonebutnum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.phonebutnum.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.phonebutnum.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.phonebutnum.Name = "phonebutnum";
            this.phonebutnum.Size = new System.Drawing.Size(120, 25);
            this.phonebutnum.TabIndex = 31;
            this.phonebutnum.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnout
            // 
            this.btnout.Location = new System.Drawing.Point(947, 62);
            this.btnout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnout.Name = "btnout";
            this.btnout.Size = new System.Drawing.Size(59, 36);
            this.btnout.TabIndex = 32;
            this.btnout.Text = "结束";
            this.btnout.UseVisualStyleBackColor = true;
            this.btnout.Click += new System.EventHandler(this.btnout_Click);
            // 
            // btbupdata
            // 
            this.btbupdata.Location = new System.Drawing.Point(835, 28);
            this.btbupdata.Name = "btbupdata";
            this.btbupdata.Size = new System.Drawing.Size(75, 23);
            this.btbupdata.TabIndex = 33;
            this.btbupdata.Text = "刷新账号";
            this.btbupdata.UseVisualStyleBackColor = true;
            this.btbupdata.Click += new System.EventHandler(this.btbupdata_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(555, 125);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 30);
            this.button3.TabIndex = 21;
            this.button3.Text = "导入";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(665, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "0条";
            // 
            // btbadd
            // 
            this.btbadd.Location = new System.Drawing.Point(555, 62);
            this.btbadd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btbadd.Name = "btbadd";
            this.btbadd.Size = new System.Drawing.Size(75, 32);
            this.btbadd.TabIndex = 20;
            this.btbadd.Text = "查询";
            this.btbadd.UseVisualStyleBackColor = true;
            this.btbadd.Click += new System.EventHandler(this.btbadd_Click_1);
            // 
            // txtphone
            // 
            this.txtphone.Location = new System.Drawing.Point(151, 68);
            this.txtphone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(365, 25);
            this.txtphone.TabIndex = 1;
            // 
            // lblphone
            // 
            this.lblphone.AutoSize = true;
            this.lblphone.Location = new System.Drawing.Point(80, 71);
            this.lblphone.Name = "lblphone";
            this.lblphone.Size = new System.Drawing.Size(67, 15);
            this.lblphone.TabIndex = 0;
            this.lblphone.Text = "手机号：";
            // 
            // Spider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 698);
            this.Controls.Add(this.btbupdata);
            this.Controls.Add(this.btnout);
            this.Controls.Add(this.phonebutnum);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.url_comb);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.spidertime);
            this.Controls.Add(this.txtbusernum);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btbadd);
            this.Controls.Add(this.btnstart);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btbse);
            this.Controls.Add(this.lblnum2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtview);
            this.Controls.Add(this.txtphone);
            this.Controls.Add(this.lblphone);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Spider";
            this.Text = "和商汇";
            this.Load += new System.EventHandler(this.Spider_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtbusernum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spidertime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phonebutnum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblnum2;
        private System.Windows.Forms.Button btbse;
        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.NumericUpDown txtbusernum;
        private System.Windows.Forms.NumericUpDown spidertime;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.ComboBox url_comb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown phonebutnum;
        private System.Windows.Forms.Button btnout;
        private System.Windows.Forms.Button btbupdata;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btbadd;
        private System.Windows.Forms.TextBox txtphone;
        private System.Windows.Forms.Label lblphone;
    }
}

