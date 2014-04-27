namespace CBRemoteControl.Monitor
{
    partial class Main
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.splitListContainer = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.splitInfoContainer = new System.Windows.Forms.SplitContainer();
            this.labGuid = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPicBox = new System.Windows.Forms.GroupBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitListContainer)).BeginInit();
            this.splitListContainer.Panel1.SuspendLayout();
            this.splitListContainer.Panel2.SuspendLayout();
            this.splitListContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitInfoContainer)).BeginInit();
            this.splitInfoContainer.Panel1.SuspendLayout();
            this.splitInfoContainer.Panel2.SuspendLayout();
            this.splitInfoContainer.SuspendLayout();
            this.groupPicBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.splitListContainer);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.splitInfoContainer);
            this.splitContainer.Size = new System.Drawing.Size(812, 460);
            this.splitContainer.SplitterDistance = 188;
            this.splitContainer.TabIndex = 5;
            // 
            // splitListContainer
            // 
            this.splitListContainer.Location = new System.Drawing.Point(0, 0);
            this.splitListContainer.Name = "splitListContainer";
            this.splitListContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitListContainer.Panel1
            // 
            this.splitListContainer.Panel1.Controls.Add(this.button1);
            this.splitListContainer.Panel1.Controls.Add(this.button2);
            // 
            // splitListContainer.Panel2
            // 
            this.splitListContainer.Panel2.Controls.Add(this.groupBox1);
            this.splitListContainer.Size = new System.Drawing.Size(190, 460);
            this.splitListContainer.SplitterDistance = 52;
            this.splitListContainer.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(111, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // splitInfoContainer
            // 
            this.splitInfoContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitInfoContainer.Location = new System.Drawing.Point(0, 0);
            this.splitInfoContainer.Name = "splitInfoContainer";
            this.splitInfoContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitInfoContainer.Panel1
            // 
            this.splitInfoContainer.Panel1.Controls.Add(this.labGuid);
            this.splitInfoContainer.Panel1.Controls.Add(this.label4);
            this.splitInfoContainer.Panel1.Controls.Add(this.labName);
            this.splitInfoContainer.Panel1.Controls.Add(this.label1);
            // 
            // splitInfoContainer.Panel2
            // 
            this.splitInfoContainer.Panel2.Controls.Add(this.groupPicBox);
            this.splitInfoContainer.Size = new System.Drawing.Size(620, 460);
            this.splitInfoContainer.SplitterDistance = 52;
            this.splitInfoContainer.TabIndex = 0;
            // 
            // labGuid
            // 
            this.labGuid.AutoSize = true;
            this.labGuid.Location = new System.Drawing.Point(55, 33);
            this.labGuid.Name = "labGuid";
            this.labGuid.Size = new System.Drawing.Size(41, 12);
            this.labGuid.TabIndex = 4;
            this.labGuid.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Guid:";
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(55, 9);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(41, 12);
            this.labName.TabIndex = 1;
            this.labName.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // groupPicBox
            // 
            this.groupPicBox.Controls.Add(this.pictureBox);
            this.groupPicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPicBox.Location = new System.Drawing.Point(0, 0);
            this.groupPicBox.Name = "groupPicBox";
            this.groupPicBox.Size = new System.Drawing.Size(620, 404);
            this.groupPicBox.TabIndex = 1;
            this.groupPicBox.TabStop = false;
            this.groupPicBox.Text = "groupBox1";
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(3, 17);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(614, 384);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 404);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(3, 17);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(184, 384);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // columnHeader
            // 
            this.columnHeader.Text = "Machine Name";
            this.columnHeader.Width = 180;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 460);
            this.Controls.Add(this.splitContainer);
            this.Name = "Main";
            this.Text = "CBRemoteControl Monitor";
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.splitListContainer.Panel1.ResumeLayout(false);
            this.splitListContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitListContainer)).EndInit();
            this.splitListContainer.ResumeLayout(false);
            this.splitInfoContainer.Panel1.ResumeLayout(false);
            this.splitInfoContainer.Panel1.PerformLayout();
            this.splitInfoContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitInfoContainer)).EndInit();
            this.splitInfoContainer.ResumeLayout(false);
            this.groupPicBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.SplitContainer splitInfoContainer;
        private System.Windows.Forms.SplitContainer splitListContainer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labGuid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupPicBox;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader;
    }
}

