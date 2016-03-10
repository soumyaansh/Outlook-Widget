using System.Drawing;
using System.Windows.Forms;
using _OutlookAddIn1.controls;

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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pnlMenu = new _OutlookAddIn1.CustomPanel();
            this.witsPanel = new _OutlookAddIn1.CustomPanel();
            this.witsPanelContainer = new _OutlookAddIn1.CustomPanel();
            this.searchFormPanel = new _OutlookAddIn1.CustomPanel();
            this.searchPanel = new _OutlookAddIn1.CustomPanel();
            this.searchPanelContainer = new _OutlookAddIn1.CustomPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.myCustomTreeView = new _OutlookAddIn1.CustomTreeView();
            this.witsPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.searchFormPanel.SuspendLayout();
            this.SuspendLayout();
            this.mainTabPanel = new MainTabPanel(this);

            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(77)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 12F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(63, 220);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Log In";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.login);
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.Color.Gray;
            this.textBox1.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            this.textBox1.Location = new System.Drawing.Point(18, 116);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "username";
            this.textBox1.Size = new System.Drawing.Size(246, 25);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Username";
            this.textBox1.GotFocus += loginTextBoxGetHandler;
            this.textBox1.LostFocus += loginTextBoxLostHandler;
            // 
            // textBox2
            // 
            this.textBox2.ForeColor = System.Drawing.Color.Gray;
            this.textBox2.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            this.textBox2.Location = new System.Drawing.Point(18, 148);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Multiline = true;
            this.textBox2.PasswordChar = '*';
            this.textBox2.MaxLength = 20;
            this.textBox2.Name = "password";
            this.textBox2.Size = new System.Drawing.Size(246, 25);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "Password";
            this.textBox2.GotFocus += loginTextBoxGetHandler;
            this.textBox2.LostFocus += loginTextBoxLostHandler;
            this.textBox2.KeyDown += loginWhenEnter;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.Gray;
            this.checkBox1.Location = new System.Drawing.Point(18, 180);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(105, 21);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Stay Logged In";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            // 
            // pnlMenu
            // 
            this.pnlMenu.AutoScroll = true;
            this.pnlMenu.AutoSize = true;
            this.pnlMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 28);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(307, 0);
            this.pnlMenu.TabIndex = 1;


          


            // 
            // witsPanelContainer
            // 

            this.witsPanelContainer.AutoSize = true;  // keep it false so that scroll work
            this.witsPanelContainer.AutoScroll = false;
        
            this.witsPanelContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.witsPanelContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.witsPanelContainer.Location = new System.Drawing.Point(0, 0);
            this.witsPanelContainer.Margin = new System.Windows.Forms.Padding(2);
            this.witsPanelContainer.Name = "witsPanelContainer";
            this.witsPanelContainer.Size = new System.Drawing.Size(300, 665);
            this.witsPanelContainer.TabIndex = 1;
            this.witsPanelContainer.Visible = false;


            // 
            // witsPanel
            //
            this.witsPanel.AutoSize = false;  // keep it false so that scroll work
            this.witsPanel.AutoScroll = true;
            this.witsPanel.VerticalScroll.Enabled = true;
            this.witsPanel.VerticalScroll.Visible = true;
            this.witsPanel.VerticalScroll.Maximum = 100;
            this.witsPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.witsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.witsPanel.Location = new System.Drawing.Point(0, 0);
            this.witsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.witsPanel.Name = "witsPanel";
            this.witsPanel.Size = new System.Drawing.Size(300, 665);
            this.witsPanel.TabIndex = 1;
            this.witsPanel.Visible = false;


            // 
            // searchPanelContainer
            //
            this.searchPanelContainer.AutoSize = true;  // keep it false so that scroll work
            this.searchPanelContainer.AutoScroll = false;

            this.searchPanelContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.searchPanelContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanelContainer.Location = new System.Drawing.Point(0, 0);
            this.searchPanelContainer.Margin = new System.Windows.Forms.Padding(2);
            this.searchPanelContainer.Name = "searchPanelContainer";
            this.searchPanelContainer.Size = new System.Drawing.Size(300, 665);
            this.searchPanelContainer.TabIndex = 1;
            this.searchPanelContainer.Visible = false;

            // 
            // searchFormPanel
            //
            this.searchFormPanel.AutoSize = false;  // keep it false so that scroll work
            this.searchFormPanel.AutoScroll = true;
            this.searchFormPanel.VerticalScroll.Enabled = true;
            this.searchFormPanel.VerticalScroll.Visible = true;
            this.searchFormPanel.VerticalScroll.Maximum = 100;
            this.searchFormPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.searchFormPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchFormPanel.Location = new System.Drawing.Point(0, 0);
            this.searchFormPanel.Margin = new System.Windows.Forms.Padding(2);
            this.searchFormPanel.Name = "searchFormPanel";
            this.searchFormPanel.Size = new System.Drawing.Size(300, 665);
            this.searchFormPanel.TabIndex = 1;
            this.searchFormPanel.Visible = false;

            // 
            // searchPanel
            //
            this.searchPanel.AutoSize = false;  // keep it false so that scroll work
            this.searchPanel.AutoScroll = true;
            this.searchPanel.VerticalScroll.Enabled = true;
            this.searchPanel.VerticalScroll.Visible = true;
            this.searchPanel.VerticalScroll.Maximum = 100;
            this.searchPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Margin = new System.Windows.Forms.Padding(2);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(300, 665);
            this.searchPanel.TabIndex = 1;
            this.searchPanel.Visible = false;


            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(77)))));
            this.label1.Location = new System.Drawing.Point(76, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 45);
            this.label1.TabIndex = 8;
            this.label1.Text = "Log In";
            this.label1.BackColor = System.Drawing.Color.Transparent;


            // 
            // myCustomTreeView
            // 
            this.myCustomTreeView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.myCustomTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.myCustomTreeView.Font = new System.Drawing.Font("Arial", 10F);
            this.myCustomTreeView.ForeColor = System.Drawing.Color.Gray;
            this.myCustomTreeView.FullRowSelect = true;
            this.myCustomTreeView.HideSelection = false;
            this.myCustomTreeView.HotTracking = true;
            this.myCustomTreeView.Indent = 10;
            this.myCustomTreeView.LineColor = System.Drawing.Color.Gray;
            this.myCustomTreeView.Location = new System.Drawing.Point(3, 3);
            this.myCustomTreeView.Name = "myCustomTreeView";
            this.myCustomTreeView.Size = new System.Drawing.Size(450, 428);
            this.myCustomTreeView.TabIndex = 9;
            this.myCustomTreeView.treeNode = null;
            // 
            // MyUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = Resource.login_bg_image_1x;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.witsPanel);
            this.Controls.Add(this.witsPanelContainer);
            this.Controls.Add(this.searchFormPanel);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.searchPanelContainer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.mainTabPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MyUserControl";
            this.Size = new System.Drawing.Size(307, 455);
            this.Load += new System.EventHandler(this.MyUserControl_Load);
            this.witsPanel.ResumeLayout(false);
            this.witsPanel.PerformLayout();
            this.searchFormPanel.ResumeLayout(false);
            this.searchFormPanel.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        public CustomTreeView myCustomTreeView;
        public CustomPanel pnlMenu;
        public CustomPanel witsPanel;
        public CustomPanel searchFormPanel;
        public CustomPanel searchPanel;
        public CustomPanel witsPanelContainer;
        public CustomPanel searchPanelContainer;
        private Label label1;
        public MainTabPanel mainTabPanel;
       
    }
}
