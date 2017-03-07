namespace SAIO
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.AppTitle = new System.Windows.Forms.Label();
            this.TabFixer = new System.Windows.Forms.Panel();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.controlBox1 = new SAIO.ControlBox();
            this.MainTabControl = new SAIO.CustomTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.StatLabel_Left = new System.Windows.Forms.Label();
            this.StatLabel_Right = new System.Windows.Forms.Label();
            this.ActionLabelTip = new System.Windows.Forms.Label();
            this.ActionLabel = new System.Windows.Forms.Label();
            this.CheckButton = new SAIO.MaterialButton();
            this.GrabButton = new SAIO.MaterialButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.StatLabel_Left2 = new System.Windows.Forms.Label();
            this.StatLabel_Right2 = new System.Windows.Forms.Label();
            this.ActionLabelTip2 = new System.Windows.Forms.Label();
            this.ActionLabel2 = new System.Windows.Forms.Label();
            this.ConverterButton = new SAIO.MaterialButton();
            this.HQifierButton = new SAIO.MaterialButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.StatLabel_Left3 = new System.Windows.Forms.Label();
            this.StatLabel_Right3 = new System.Windows.Forms.Label();
            this.ActionLabelTip3 = new System.Windows.Forms.Label();
            this.ActionLabel3 = new System.Windows.Forms.Label();
            this.ExtractorButton = new SAIO.MaterialButton();
            this.Hidden1 = new System.Windows.Forms.TabPage();
            this.Hidden2 = new System.Windows.Forms.TabPage();
            this.Hidden3 = new System.Windows.Forms.TabPage();
            this.Hidden4 = new System.Windows.Forms.TabPage();
            this.Settings = new System.Windows.Forms.TabPage();
            this.Theme_Default2 = new System.Windows.Forms.Panel();
            this.AutoCheckProxies = new SAIO.CustomCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.separator1 = new SAIO.Separator();
            this.Label2 = new System.Windows.Forms.Label();
            this.Theme_Default = new System.Windows.Forms.Panel();
            this.Theme_Dark2 = new System.Windows.Forms.Panel();
            this.Theme_Dark = new System.Windows.Forms.Panel();
            this.AutoExport = new SAIO.CustomCheckBox();
            this.MainTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // AppTitle
            // 
            this.AppTitle.Font = new System.Drawing.Font("Kozuka Gothic Pro B", 9F);
            this.AppTitle.ForeColor = System.Drawing.Color.White;
            this.AppTitle.Location = new System.Drawing.Point(1, 1);
            this.AppTitle.Name = "AppTitle";
            this.AppTitle.Size = new System.Drawing.Size(51, 29);
            this.AppTitle.TabIndex = 3;
            this.AppTitle.Text = "SAIO";
            this.AppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AppTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormDrag);
            // 
            // TabFixer
            // 
            this.TabFixer.Location = new System.Drawing.Point(0, 27);
            this.TabFixer.Name = "TabFixer";
            this.TabFixer.Size = new System.Drawing.Size(690, 2);
            this.TabFixer.TabIndex = 0;
            this.TabFixer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormDrag);
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(36, 313);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(654, 4);
            this.ProgressBar1.TabIndex = 32;
            // 
            // controlBox1
            // 
            this.controlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(118)))), ((int)(((byte)(138)))));
            this.controlBox1.Font = new System.Drawing.Font("Verdana", 8F);
            this.controlBox1.Location = new System.Drawing.Point(622, 0);
            this.controlBox1.Name = "controlBox1";
            this.controlBox1.Size = new System.Drawing.Size(68, 29);
            this.controlBox1.TabIndex = 1;
            this.controlBox1.Text = "controlBox1";
            // 
            // MainTabControl
            // 
            this.MainTabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.MainTabControl.Controls.Add(this.tabPage1);
            this.MainTabControl.Controls.Add(this.tabPage2);
            this.MainTabControl.Controls.Add(this.tabPage3);
            this.MainTabControl.Controls.Add(this.Hidden1);
            this.MainTabControl.Controls.Add(this.Hidden2);
            this.MainTabControl.Controls.Add(this.Hidden3);
            this.MainTabControl.Controls.Add(this.Hidden4);
            this.MainTabControl.Controls.Add(this.Settings);
            this.MainTabControl.ItemSize = new System.Drawing.Size(36, 38);
            this.MainTabControl.Location = new System.Drawing.Point(-2, 27);
            this.MainTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.MainTabControl.Multiline = true;
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(692, 293);
            this.MainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.MainTabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.tabPage1.Controls.Add(this.StatLabel_Left);
            this.tabPage1.Controls.Add(this.StatLabel_Right);
            this.tabPage1.Controls.Add(this.ActionLabelTip);
            this.tabPage1.Controls.Add(this.ActionLabel);
            this.tabPage1.Controls.Add(this.CheckButton);
            this.tabPage1.Controls.Add(this.GrabButton);
            this.tabPage1.Font = new System.Drawing.Font("Kozuka Gothic Pro B", 9F);
            this.tabPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabPage1.Location = new System.Drawing.Point(38, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(654, 291);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // StatLabel_Left
            // 
            this.StatLabel_Left.AutoSize = true;
            this.StatLabel_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.StatLabel_Left.Font = new System.Drawing.Font("Kozuka Gothic Pro M", 9.5F);
            this.StatLabel_Left.ForeColor = System.Drawing.Color.Black;
            this.StatLabel_Left.Location = new System.Drawing.Point(5, 262);
            this.StatLabel_Left.Name = "StatLabel_Left";
            this.StatLabel_Left.Size = new System.Drawing.Size(0, 18);
            this.StatLabel_Left.TabIndex = 31;
            this.StatLabel_Left.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatLabel_Right
            // 
            this.StatLabel_Right.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StatLabel_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.StatLabel_Right.Font = new System.Drawing.Font("Kozuka Gothic Pro M", 9.5F);
            this.StatLabel_Right.ForeColor = System.Drawing.Color.Black;
            this.StatLabel_Right.Location = new System.Drawing.Point(92, 263);
            this.StatLabel_Right.Margin = new System.Windows.Forms.Padding(0);
            this.StatLabel_Right.Name = "StatLabel_Right";
            this.StatLabel_Right.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StatLabel_Right.Size = new System.Drawing.Size(558, 18);
            this.StatLabel_Right.TabIndex = 30;
            this.StatLabel_Right.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ActionLabelTip
            // 
            this.ActionLabelTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.ActionLabelTip.Font = new System.Drawing.Font("Kozuka Gothic Pro R", 9F);
            this.ActionLabelTip.ForeColor = System.Drawing.Color.Black;
            this.ActionLabelTip.Location = new System.Drawing.Point(1, 167);
            this.ActionLabelTip.Name = "ActionLabelTip";
            this.ActionLabelTip.Size = new System.Drawing.Size(652, 18);
            this.ActionLabelTip.TabIndex = 29;
            this.ActionLabelTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ActionLabel
            // 
            this.ActionLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.ActionLabel.Font = new System.Drawing.Font("Kozuka Gothic Pro L", 16F);
            this.ActionLabel.ForeColor = System.Drawing.Color.Black;
            this.ActionLabel.Location = new System.Drawing.Point(1, 37);
            this.ActionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ActionLabel.Name = "ActionLabel";
            this.ActionLabel.Size = new System.Drawing.Size(652, 226);
            this.ActionLabel.TabIndex = 28;
            this.ActionLabel.Text = "idle...";
            this.ActionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CheckButton
            // 
            this.CheckButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.CheckButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckButton.Font = new System.Drawing.Font("Kozuka Gothic Pro M", 9.5F);
            this.CheckButton.ForeColor = System.Drawing.Color.White;
            this.CheckButton.Location = new System.Drawing.Point(328, 2);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(324, 34);
            this.CheckButton.TabIndex = 1;
            this.CheckButton.Text = "Check Proxies";
            this.CheckButton.UseVisualStyleBackColor = false;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // GrabButton
            // 
            this.GrabButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.GrabButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GrabButton.Font = new System.Drawing.Font("Kozuka Gothic Pro M", 9.5F);
            this.GrabButton.ForeColor = System.Drawing.Color.White;
            this.GrabButton.Location = new System.Drawing.Point(2, 2);
            this.GrabButton.Name = "GrabButton";
            this.GrabButton.Size = new System.Drawing.Size(324, 34);
            this.GrabButton.TabIndex = 0;
            this.GrabButton.Text = "Grab Proxies";
            this.GrabButton.UseVisualStyleBackColor = false;
            this.GrabButton.Click += new System.EventHandler(this.GrabButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.tabPage2.Controls.Add(this.StatLabel_Left2);
            this.tabPage2.Controls.Add(this.StatLabel_Right2);
            this.tabPage2.Controls.Add(this.ActionLabelTip2);
            this.tabPage2.Controls.Add(this.ActionLabel2);
            this.tabPage2.Controls.Add(this.ConverterButton);
            this.tabPage2.Controls.Add(this.HQifierButton);
            this.tabPage2.Font = new System.Drawing.Font("Kozuka Gothic Pro B", 9F);
            this.tabPage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabPage2.Location = new System.Drawing.Point(38, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(654, 291);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // StatLabel_Left2
            // 
            this.StatLabel_Left2.AutoSize = true;
            this.StatLabel_Left2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.StatLabel_Left2.Font = new System.Drawing.Font("Kozuka Gothic Pro M", 9.5F);
            this.StatLabel_Left2.ForeColor = System.Drawing.Color.Black;
            this.StatLabel_Left2.Location = new System.Drawing.Point(5, 244);
            this.StatLabel_Left2.Name = "StatLabel_Left2";
            this.StatLabel_Left2.Size = new System.Drawing.Size(0, 18);
            this.StatLabel_Left2.TabIndex = 33;
            this.StatLabel_Left2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatLabel_Right2
            // 
            this.StatLabel_Right2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StatLabel_Right2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.StatLabel_Right2.Font = new System.Drawing.Font("Kozuka Gothic Pro M", 9.5F);
            this.StatLabel_Right2.ForeColor = System.Drawing.Color.Black;
            this.StatLabel_Right2.Location = new System.Drawing.Point(94, 244);
            this.StatLabel_Right2.Margin = new System.Windows.Forms.Padding(0);
            this.StatLabel_Right2.Name = "StatLabel_Right2";
            this.StatLabel_Right2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StatLabel_Right2.Size = new System.Drawing.Size(558, 18);
            this.StatLabel_Right2.TabIndex = 32;
            this.StatLabel_Right2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ActionLabelTip2
            // 
            this.ActionLabelTip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.ActionLabelTip2.Font = new System.Drawing.Font("Kozuka Gothic Pro R", 9F);
            this.ActionLabelTip2.ForeColor = System.Drawing.Color.Black;
            this.ActionLabelTip2.Location = new System.Drawing.Point(1, 167);
            this.ActionLabelTip2.Name = "ActionLabelTip2";
            this.ActionLabelTip2.Size = new System.Drawing.Size(652, 18);
            this.ActionLabelTip2.TabIndex = 31;
            this.ActionLabelTip2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ActionLabel2
            // 
            this.ActionLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.ActionLabel2.Font = new System.Drawing.Font("Kozuka Gothic Pro L", 16F);
            this.ActionLabel2.ForeColor = System.Drawing.Color.Black;
            this.ActionLabel2.Location = new System.Drawing.Point(1, 37);
            this.ActionLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.ActionLabel2.Name = "ActionLabel2";
            this.ActionLabel2.Size = new System.Drawing.Size(652, 226);
            this.ActionLabel2.TabIndex = 29;
            this.ActionLabel2.Text = "idle...";
            this.ActionLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConverterButton
            // 
            this.ConverterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.ConverterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConverterButton.Font = new System.Drawing.Font("Kozuka Gothic Pro M", 9.5F);
            this.ConverterButton.ForeColor = System.Drawing.Color.White;
            this.ConverterButton.Location = new System.Drawing.Point(328, 2);
            this.ConverterButton.Name = "ConverterButton";
            this.ConverterButton.Size = new System.Drawing.Size(324, 34);
            this.ConverterButton.TabIndex = 3;
            this.ConverterButton.Text = "Converter";
            this.ConverterButton.UseVisualStyleBackColor = false;
            this.ConverterButton.Click += new System.EventHandler(this.ConverterButton_Click);
            // 
            // HQifierButton
            // 
            this.HQifierButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.HQifierButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HQifierButton.Font = new System.Drawing.Font("Kozuka Gothic Pro M", 9.5F);
            this.HQifierButton.ForeColor = System.Drawing.Color.White;
            this.HQifierButton.Location = new System.Drawing.Point(2, 2);
            this.HQifierButton.Name = "HQifierButton";
            this.HQifierButton.Size = new System.Drawing.Size(324, 34);
            this.HQifierButton.TabIndex = 2;
            this.HQifierButton.Text = "HQ\'ifier";
            this.HQifierButton.UseVisualStyleBackColor = false;
            this.HQifierButton.Click += new System.EventHandler(this.HQifierButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.tabPage3.Controls.Add(this.StatLabel_Left3);
            this.tabPage3.Controls.Add(this.StatLabel_Right3);
            this.tabPage3.Controls.Add(this.ActionLabelTip3);
            this.tabPage3.Controls.Add(this.ActionLabel3);
            this.tabPage3.Controls.Add(this.ExtractorButton);
            this.tabPage3.Font = new System.Drawing.Font("Kozuka Gothic Pro B", 9F);
            this.tabPage3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabPage3.Location = new System.Drawing.Point(38, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(654, 291);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // StatLabel_Left3
            // 
            this.StatLabel_Left3.AutoSize = true;
            this.StatLabel_Left3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.StatLabel_Left3.Font = new System.Drawing.Font("Kozuka Gothic Pro M", 9.5F);
            this.StatLabel_Left3.ForeColor = System.Drawing.Color.Black;
            this.StatLabel_Left3.Location = new System.Drawing.Point(5, 244);
            this.StatLabel_Left3.Name = "StatLabel_Left3";
            this.StatLabel_Left3.Size = new System.Drawing.Size(0, 18);
            this.StatLabel_Left3.TabIndex = 37;
            this.StatLabel_Left3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatLabel_Right3
            // 
            this.StatLabel_Right3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StatLabel_Right3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.StatLabel_Right3.Font = new System.Drawing.Font("Kozuka Gothic Pro M", 9.5F);
            this.StatLabel_Right3.ForeColor = System.Drawing.Color.Black;
            this.StatLabel_Right3.Location = new System.Drawing.Point(94, 244);
            this.StatLabel_Right3.Margin = new System.Windows.Forms.Padding(0);
            this.StatLabel_Right3.Name = "StatLabel_Right3";
            this.StatLabel_Right3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StatLabel_Right3.Size = new System.Drawing.Size(558, 18);
            this.StatLabel_Right3.TabIndex = 36;
            this.StatLabel_Right3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ActionLabelTip3
            // 
            this.ActionLabelTip3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.ActionLabelTip3.Font = new System.Drawing.Font("Kozuka Gothic Pro R", 9F);
            this.ActionLabelTip3.ForeColor = System.Drawing.Color.Black;
            this.ActionLabelTip3.Location = new System.Drawing.Point(1, 167);
            this.ActionLabelTip3.Name = "ActionLabelTip3";
            this.ActionLabelTip3.Size = new System.Drawing.Size(652, 18);
            this.ActionLabelTip3.TabIndex = 35;
            this.ActionLabelTip3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ActionLabel3
            // 
            this.ActionLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.ActionLabel3.Font = new System.Drawing.Font("Kozuka Gothic Pro L", 16F);
            this.ActionLabel3.ForeColor = System.Drawing.Color.Black;
            this.ActionLabel3.Location = new System.Drawing.Point(1, 37);
            this.ActionLabel3.Margin = new System.Windows.Forms.Padding(0);
            this.ActionLabel3.Name = "ActionLabel3";
            this.ActionLabel3.Size = new System.Drawing.Size(652, 226);
            this.ActionLabel3.TabIndex = 34;
            this.ActionLabel3.Text = "idle...";
            this.ActionLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExtractorButton
            // 
            this.ExtractorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.ExtractorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExtractorButton.Font = new System.Drawing.Font("Kozuka Gothic Pro M", 9.5F);
            this.ExtractorButton.ForeColor = System.Drawing.Color.White;
            this.ExtractorButton.Location = new System.Drawing.Point(2, 2);
            this.ExtractorButton.Name = "ExtractorButton";
            this.ExtractorButton.Size = new System.Drawing.Size(650, 34);
            this.ExtractorButton.TabIndex = 3;
            this.ExtractorButton.Text = "MD5 Extractor";
            this.ExtractorButton.UseVisualStyleBackColor = false;
            this.ExtractorButton.Click += new System.EventHandler(this.ExtractorButton_Click);
            // 
            // Hidden1
            // 
            this.Hidden1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Hidden1.Font = new System.Drawing.Font("Kozuka Gothic Pro B", 9F);
            this.Hidden1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Hidden1.Location = new System.Drawing.Point(38, 2);
            this.Hidden1.Name = "Hidden1";
            this.Hidden1.Size = new System.Drawing.Size(654, 291);
            this.Hidden1.TabIndex = 3;
            this.Hidden1.Tag = "Hidden";
            this.Hidden1.Text = "tabPage4";
            // 
            // Hidden2
            // 
            this.Hidden2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Hidden2.Font = new System.Drawing.Font("Kozuka Gothic Pro B", 9F);
            this.Hidden2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Hidden2.Location = new System.Drawing.Point(38, 2);
            this.Hidden2.Name = "Hidden2";
            this.Hidden2.Size = new System.Drawing.Size(654, 291);
            this.Hidden2.TabIndex = 4;
            this.Hidden2.Tag = "Hidden";
            this.Hidden2.Text = "tabPage5";
            // 
            // Hidden3
            // 
            this.Hidden3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Hidden3.Font = new System.Drawing.Font("Kozuka Gothic Pro B", 9F);
            this.Hidden3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Hidden3.Location = new System.Drawing.Point(38, 2);
            this.Hidden3.Name = "Hidden3";
            this.Hidden3.Size = new System.Drawing.Size(654, 291);
            this.Hidden3.TabIndex = 5;
            this.Hidden3.Tag = "Hidden";
            this.Hidden3.Text = "tabPage6";
            // 
            // Hidden4
            // 
            this.Hidden4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Hidden4.Font = new System.Drawing.Font("Kozuka Gothic Pro B", 9F);
            this.Hidden4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Hidden4.Location = new System.Drawing.Point(38, 2);
            this.Hidden4.Name = "Hidden4";
            this.Hidden4.Size = new System.Drawing.Size(654, 291);
            this.Hidden4.TabIndex = 6;
            this.Hidden4.Tag = "Hidden";
            this.Hidden4.Text = "tabPage7";
            // 
            // Settings
            // 
            this.Settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Settings.Controls.Add(this.AutoExport);
            this.Settings.Controls.Add(this.Theme_Default2);
            this.Settings.Controls.Add(this.AutoCheckProxies);
            this.Settings.Controls.Add(this.label1);
            this.Settings.Controls.Add(this.separator1);
            this.Settings.Controls.Add(this.Label2);
            this.Settings.Controls.Add(this.Theme_Default);
            this.Settings.Controls.Add(this.Theme_Dark2);
            this.Settings.Controls.Add(this.Theme_Dark);
            this.Settings.Font = new System.Drawing.Font("Kozuka Gothic Pro B", 9F);
            this.Settings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Settings.Location = new System.Drawing.Point(38, 2);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(654, 291);
            this.Settings.TabIndex = 7;
            this.Settings.Text = "tabPage4";
            // 
            // Theme_Default2
            // 
            this.Theme_Default2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.Theme_Default2.Location = new System.Drawing.Point(40, 62);
            this.Theme_Default2.Margin = new System.Windows.Forms.Padding(8);
            this.Theme_Default2.Name = "Theme_Default2";
            this.Theme_Default2.Size = new System.Drawing.Size(30, 30);
            this.Theme_Default2.TabIndex = 30;
            this.Theme_Default2.Tag = "hc";
            this.Theme_Default2.Click += new System.EventHandler(this.Theme_Default_Click);
            // 
            // AutoCheckProxies
            // 
            this.AutoCheckProxies.Checked = false;
            this.AutoCheckProxies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AutoCheckProxies.EnabledCalc = true;
            this.AutoCheckProxies.Location = new System.Drawing.Point(16, 146);
            this.AutoCheckProxies.Name = "AutoCheckProxies";
            this.AutoCheckProxies.Size = new System.Drawing.Size(186, 18);
            this.AutoCheckProxies.TabIndex = 41;
            this.AutoCheckProxies.Text = "Auto-Check Grabbed Proxies";
            this.AutoCheckProxies.CheckedChanged += new SAIO.CustomCheckBox.CheckedChangedEventHandler(this.AutoCheckProxies_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kozuka Gothic Pro M", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 116);
            this.label1.Margin = new System.Windows.Forms.Padding(8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 22);
            this.label1.TabIndex = 40;
            this.label1.Text = "General Settings";
            // 
            // separator1
            // 
            this.separator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.separator1.Location = new System.Drawing.Point(16, 104);
            this.separator1.Margin = new System.Windows.Forms.Padding(8);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(622, 2);
            this.separator1.TabIndex = 39;
            this.separator1.Text = "separator1";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Kozuka Gothic Pro M", 12F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(11, 11);
            this.Label2.Margin = new System.Windows.Forms.Padding(8);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(110, 22);
            this.Label2.TabIndex = 28;
            this.Label2.Text = "Color Themes";
            // 
            // Theme_Default
            // 
            this.Theme_Default.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(118)))), ((int)(((byte)(138)))));
            this.Theme_Default.Location = new System.Drawing.Point(16, 38);
            this.Theme_Default.Margin = new System.Windows.Forms.Padding(8);
            this.Theme_Default.Name = "Theme_Default";
            this.Theme_Default.Size = new System.Drawing.Size(50, 50);
            this.Theme_Default.TabIndex = 29;
            this.Theme_Default.Click += new System.EventHandler(this.Theme_Default_Click);
            // 
            // Theme_Dark2
            // 
            this.Theme_Dark2.BackColor = System.Drawing.Color.Silver;
            this.Theme_Dark2.Location = new System.Drawing.Point(106, 62);
            this.Theme_Dark2.Margin = new System.Windows.Forms.Padding(8);
            this.Theme_Dark2.Name = "Theme_Dark2";
            this.Theme_Dark2.Size = new System.Drawing.Size(30, 30);
            this.Theme_Dark2.TabIndex = 36;
            this.Theme_Dark2.Click += new System.EventHandler(this.Theme_Dark_Click);
            // 
            // Theme_Dark
            // 
            this.Theme_Dark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Theme_Dark.Location = new System.Drawing.Point(82, 38);
            this.Theme_Dark.Margin = new System.Windows.Forms.Padding(8);
            this.Theme_Dark.Name = "Theme_Dark";
            this.Theme_Dark.Size = new System.Drawing.Size(50, 50);
            this.Theme_Dark.TabIndex = 34;
            this.Theme_Dark.Click += new System.EventHandler(this.Theme_Dark_Click);
            // 
            // AutoExport
            // 
            this.AutoExport.Checked = false;
            this.AutoExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AutoExport.EnabledCalc = true;
            this.AutoExport.Location = new System.Drawing.Point(16, 170);
            this.AutoExport.Name = "AutoExport";
            this.AutoExport.Size = new System.Drawing.Size(97, 18);
            this.AutoExport.TabIndex = 42;
            this.AutoExport.Text = "Auto-Export";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(118)))), ((int)(((byte)(138)))));
            this.ClientSize = new System.Drawing.Size(690, 317);
            this.Controls.Add(this.controlBox1);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.TabFixer);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.AppTitle);
            this.Font = new System.Drawing.Font("Kozuka Gothic Pro R", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(690, 317);
            this.MinimumSize = new System.Drawing.Size(690, 317);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAIO";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormDrag);
            this.MainTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Label AppTitle;
        private ControlBox controlBox1;
        private CustomTabControl MainTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel TabFixer;
        private System.Windows.Forms.TabPage tabPage3;
        private MaterialButton CheckButton;
        private MaterialButton GrabButton;
        private MaterialButton HQifierButton;
        private MaterialButton ConverterButton;
        private MaterialButton ExtractorButton;
        internal System.Windows.Forms.Label StatLabel_Left;
        internal System.Windows.Forms.Label StatLabel_Right;
        internal System.Windows.Forms.Label ActionLabelTip;
        internal System.Windows.Forms.Label ActionLabel;
        internal System.Windows.Forms.Label ActionLabel2;
        internal System.Windows.Forms.Label StatLabel_Right2;
        internal System.Windows.Forms.Label ActionLabelTip2;
        internal System.Windows.Forms.Label StatLabel_Left2;
        internal System.Windows.Forms.Label StatLabel_Left3;
        internal System.Windows.Forms.Label StatLabel_Right3;
        internal System.Windows.Forms.Label ActionLabelTip3;
        internal System.Windows.Forms.Label ActionLabel3;
        private System.Windows.Forms.ProgressBar ProgressBar1;
        private System.Windows.Forms.TabPage Hidden1;
        private System.Windows.Forms.TabPage Hidden2;
        private System.Windows.Forms.TabPage Hidden3;
        private System.Windows.Forms.TabPage Hidden4;
        private System.Windows.Forms.TabPage Settings;
        internal System.Windows.Forms.Panel Theme_Default2;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel Theme_Default;
        internal System.Windows.Forms.Panel Theme_Dark2;
        internal System.Windows.Forms.Panel Theme_Dark;
        private Separator separator1;
        internal System.Windows.Forms.Label label1;
        private CustomCheckBox AutoCheckProxies;
        private CustomCheckBox AutoExport;
    }
}

