﻿namespace my_opencvsharptest
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
            this.button_openimg = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_thread = new System.Windows.Forms.Button();
            this.button_count = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.时间 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.template_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.find_chess = new System.Windows.Forms.Button();
            this.kmeans_test = new System.Windows.Forms.Button();
            this.codetest = new System.Windows.Forms.Button();
            this.model_template_pro = new System.Windows.Forms.Button();
            this.model_pyraid = new System.Windows.Forms.Button();
            this.model_feature = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button_openimg
            // 
            this.button_openimg.AutoSize = true;
            this.button_openimg.Location = new System.Drawing.Point(45, 43);
            this.button_openimg.Margin = new System.Windows.Forms.Padding(2);
            this.button_openimg.Name = "button_openimg";
            this.button_openimg.Size = new System.Drawing.Size(65, 22);
            this.button_openimg.TabIndex = 0;
            this.button_openimg.Text = "读图展示";
            this.button_openimg.UseVisualStyleBackColor = true;
            this.button_openimg.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(527, 443);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button_thread
            // 
            this.button_thread.Location = new System.Drawing.Point(45, 84);
            this.button_thread.Margin = new System.Windows.Forms.Padding(2);
            this.button_thread.Name = "button_thread";
            this.button_thread.Size = new System.Drawing.Size(65, 24);
            this.button_thread.TabIndex = 2;
            this.button_thread.Text = "二值图像";
            this.button_thread.UseVisualStyleBackColor = true;
            this.button_thread.Click += new System.EventHandler(this.button_thread_Click);
            // 
            // button_count
            // 
            this.button_count.Location = new System.Drawing.Point(45, 128);
            this.button_count.Margin = new System.Windows.Forms.Padding(2);
            this.button_count.Name = "button_count";
            this.button_count.Size = new System.Drawing.Size(65, 24);
            this.button_count.TabIndex = 3;
            this.button_count.Text = "边沿查找";
            this.button_count.UseVisualStyleBackColor = true;
            this.button_count.Click += new System.EventHandler(this.button_count_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.时间});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(152, 33);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(219, 775);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "时间";
            this.columnHeader1.Width = 50;
            // 
            // 时间
            // 
            this.时间.Text = "日志";
            this.时间.Width = 300;
            // 
            // mo
            // 
            this.mo.Location = new System.Drawing.Point(45, 181);
            this.mo.Margin = new System.Windows.Forms.Padding(2);
            this.mo.Name = "mo";
            this.mo.Size = new System.Drawing.Size(80, 24);
            this.mo.TabIndex = 5;
            this.mo.Text = "形态学变换";
            this.mo.UseVisualStyleBackColor = true;
            this.mo.Click += new System.EventHandler(this.mo_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(376, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 447);
            this.panel1.TabIndex = 6;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            this.panel1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseWheel);
            // 
            // template_button
            // 
            this.template_button.Location = new System.Drawing.Point(45, 225);
            this.template_button.Margin = new System.Windows.Forms.Padding(2);
            this.template_button.Name = "template_button";
            this.template_button.Size = new System.Drawing.Size(80, 24);
            this.template_button.TabIndex = 7;
            this.template_button.Text = "模板匹配";
            this.template_button.UseVisualStyleBackColor = true;
            this.template_button.Click += new System.EventHandler(this.template_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(522, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 27);
            this.label1.TabIndex = 8;
            this.label1.Text = "可变图像pic1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(1046, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 27);
            this.label2.TabIndex = 9;
            this.label2.Text = "图像pic2";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox2.Location = new System.Drawing.Point(920, 112);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(494, 443);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // find_chess
            // 
            this.find_chess.Location = new System.Drawing.Point(45, 266);
            this.find_chess.Margin = new System.Windows.Forms.Padding(2);
            this.find_chess.Name = "find_chess";
            this.find_chess.Size = new System.Drawing.Size(80, 24);
            this.find_chess.TabIndex = 11;
            this.find_chess.Text = "棋盘格识别";
            this.find_chess.UseVisualStyleBackColor = true;
            this.find_chess.Click += new System.EventHandler(this.find_chess_Click);
            // 
            // kmeans_test
            // 
            this.kmeans_test.Location = new System.Drawing.Point(45, 304);
            this.kmeans_test.Margin = new System.Windows.Forms.Padding(2);
            this.kmeans_test.Name = "kmeans_test";
            this.kmeans_test.Size = new System.Drawing.Size(80, 25);
            this.kmeans_test.TabIndex = 12;
            this.kmeans_test.Text = "kmeans";
            this.kmeans_test.UseVisualStyleBackColor = true;
            this.kmeans_test.Click += new System.EventHandler(this.kmeans_test_Click);
            // 
            // codetest
            // 
            this.codetest.Location = new System.Drawing.Point(35, 534);
            this.codetest.Name = "codetest";
            this.codetest.Size = new System.Drawing.Size(75, 23);
            this.codetest.TabIndex = 13;
            this.codetest.Text = "测试代码";
            this.codetest.UseVisualStyleBackColor = true;
            this.codetest.Click += new System.EventHandler(this.codetest_Click);
            // 
            // model_template_pro
            // 
            this.model_template_pro.Location = new System.Drawing.Point(45, 348);
            this.model_template_pro.Margin = new System.Windows.Forms.Padding(2);
            this.model_template_pro.Name = "model_template_pro";
            this.model_template_pro.Size = new System.Drawing.Size(80, 24);
            this.model_template_pro.TabIndex = 14;
            this.model_template_pro.Text = "模板匹配pro";
            this.model_template_pro.UseVisualStyleBackColor = true;
            this.model_template_pro.Click += new System.EventHandler(this.model_template_pro_Click);
            // 
            // model_pyraid
            // 
            this.model_pyraid.Location = new System.Drawing.Point(45, 395);
            this.model_pyraid.Margin = new System.Windows.Forms.Padding(2);
            this.model_pyraid.Name = "model_pyraid";
            this.model_pyraid.Size = new System.Drawing.Size(80, 24);
            this.model_pyraid.TabIndex = 15;
            this.model_pyraid.Text = "模板匹配_金";
            this.model_pyraid.UseVisualStyleBackColor = true;
            this.model_pyraid.Click += new System.EventHandler(this.model_pyraid_Click);
            // 
            // model_feature
            // 
            this.model_feature.Location = new System.Drawing.Point(11, 438);
            this.model_feature.Margin = new System.Windows.Forms.Padding(2);
            this.model_feature.Name = "model_feature";
            this.model_feature.Size = new System.Drawing.Size(114, 24);
            this.model_feature.TabIndex = 16;
            this.model_feature.Text = "模板匹配_特征";
            this.model_feature.UseVisualStyleBackColor = true;
            this.model_feature.Click += new System.EventHandler(this.model_feature_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 819);
            this.Controls.Add(this.model_feature);
            this.Controls.Add(this.model_pyraid);
            this.Controls.Add(this.model_template_pro);
            this.Controls.Add(this.codetest);
            this.Controls.Add(this.kmeans_test);
            this.Controls.Add(this.find_chess);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.template_button);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mo);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button_count);
            this.Controls.Add(this.button_thread);
            this.Controls.Add(this.button_openimg);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_openimg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_thread;
        private System.Windows.Forms.Button button_count;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader 时间;
        private System.Windows.Forms.Button mo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button template_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button find_chess;
        private System.Windows.Forms.Button kmeans_test;
        private System.Windows.Forms.Button codetest;
        private System.Windows.Forms.Button model_template_pro;
        private System.Windows.Forms.Button model_pyraid;
        private System.Windows.Forms.Button model_feature;
    }
}

