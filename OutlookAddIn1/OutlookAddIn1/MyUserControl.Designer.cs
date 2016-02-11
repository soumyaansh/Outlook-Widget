using System.Windows.Forms;

namespace _OutlookAddIn1
{
    partial class MyUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.myCustomListView = new _OutlookAddIn1.CustomListView();
            this.myCustomTreeView = new _OutlookAddIn1.CustomTreeView();
            this.myRichTextBox = new _OutlookAddIn1.CustomRichTextBox();
            this.pnlMenu = new _OutlookAddIn1.CustomPanel();
            this.witsPanel = new _OutlookAddIn1.CustomPanel();
           
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.witsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button1.Location = new System.Drawing.Point(69, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(160, 178);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 26);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(160, 227);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(161, 26);
            this.textBox2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Logging...";
            this.label3.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(69, 271);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(140, 24);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Remember me";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::_OutlookAddIn1.Resource.animatedCircle;
            this.pictureBox2.Location = new System.Drawing.Point(209, 310);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(87, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::_OutlookAddIn1.Resource.wp;
            this.pictureBox1.Location = new System.Drawing.Point(69, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // myCustomListView
            // 
            this.myCustomListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.myCustomListView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.myCustomListView.AutoArrange = false;
            this.myCustomListView.BackColor = System.Drawing.Color.White;
            this.myCustomListView.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.myCustomListView.ForeColor = System.Drawing.Color.Gray;
            this.myCustomListView.FullRowSelect = true;
            this.myCustomListView.GridLines = true;
            this.myCustomListView.HideSelection = false;
            this.myCustomListView.HotTracking = true;
            this.myCustomListView.HoverSelection = true;
            this.myCustomListView.Location = new System.Drawing.Point(0, 0);
            this.myCustomListView.Name = "myCustomListView";
            this.myCustomListView.Size = new System.Drawing.Size(460, 635);
            this.myCustomListView.TabIndex = 10;
            this.myCustomListView.UseCompatibleStateImageBehavior = false;
            // 
            // myCustomTreeView
            // 
            this.myCustomTreeView.BackColor = System.Drawing.Color.Silver;
            this.myCustomTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.myCustomTreeView.Font = new System.Drawing.Font("Arial", 10F);
            this.myCustomTreeView.ForeColor = System.Drawing.Color.Gray;
            this.myCustomTreeView.FullRowSelect = true;
            this.myCustomTreeView.HideSelection = false;
            this.myCustomTreeView.HotTracking = true;
            this.myCustomTreeView.Indent = 10;
            this.myCustomTreeView.LineColor = System.Drawing.Color.Empty;
            this.myCustomTreeView.Location = new System.Drawing.Point(3, 3);
            this.myCustomTreeView.Name = "myCustomTreeView";
            this.myCustomTreeView.ShowLines = false;
            this.myCustomTreeView.ShowPlusMinus = false;
            this.myCustomTreeView.Size = new System.Drawing.Size(417, 300);
            this.myCustomTreeView.TabIndex = 9;
            this.myCustomTreeView.treeNode = null;
            this.myCustomTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.myCustomTreeView_AfterSelect);
           
         
            // 
            // pnlMenu
            // 
            this.pnlMenu.AutoScroll = true;
            this.pnlMenu.AutoSize = true;
            this.pnlMenu.BackColor = System.Drawing.Color.Silver;
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 1200);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(460, 0);
            this.pnlMenu.TabIndex = 1;
            // 
            // witsPanel
            // 
            this.witsPanel.AutoScroll = true;
            this.witsPanel.BackColor = System.Drawing.Color.Silver;
          
            this.witsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.witsPanel.Location = new System.Drawing.Point(0, 0);
            this.witsPanel.Name = "witsPanel";
            this.witsPanel.Size = new System.Drawing.Size(460, 800);
            this.witsPanel.TabIndex = 1;
            this.witsPanel.Visible = false;
            // 
            // webBrowser1
            // 
         
            // 
            // MyUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.witsPanel);
            this.Controls.Add(this.myRichTextBox);
            this.Name = "MyUserControl";
            this.Size = new System.Drawing.Size(460, 613);
            this.Load += new System.EventHandler(this.MyUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.witsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        public CustomTreeView myCustomTreeView;
        public CustomListView myCustomListView;
        public CustomRichTextBox myRichTextBox;
      
        public CustomPanel pnlMenu;
        public CustomPanel witsPanel;
    }
}
