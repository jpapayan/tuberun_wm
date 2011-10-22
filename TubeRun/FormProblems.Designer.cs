namespace TubeRun
{
    partial class FormProblems
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProblems));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.map = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.linestatusLabel = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.up1 = new System.Windows.Forms.PictureBox();
            this.down1 = new System.Windows.Forms.PictureBox();
            this.right1 = new System.Windows.Forms.PictureBox();
            this.left1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.reasonLink = new System.Windows.Forms.LinkLabel();
            this.rawtextLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.map);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // map
            // 
            this.map.Text = "On Map";
            this.map.Click += new System.EventHandler(this.map_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Back";
            this.menuItem2.Click += new System.EventHandler(this.exit);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 23);
            this.label1.Text = "Line";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // linestatusLabel
            // 
            this.linestatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.linestatusLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.linestatusLabel.Location = new System.Drawing.Point(0, 23);
            this.linestatusLabel.Name = "linestatusLabel";
            this.linestatusLabel.Size = new System.Drawing.Size(240, 21);
            this.linestatusLabel.Text = "Detailed line information:";
            this.linestatusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(12, 56);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(216, 190);
            // 
            // up1
            // 
            this.up1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.up1.Image = ((System.Drawing.Image)(resources.GetObject("up1.Image")));
            this.up1.Location = new System.Drawing.Point(7, 46);
            this.up1.Name = "up1";
            this.up1.Size = new System.Drawing.Size(224, 8);
            this.up1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // down1
            // 
            this.down1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.down1.Image = ((System.Drawing.Image)(resources.GetObject("down1.Image")));
            this.down1.Location = new System.Drawing.Point(7, 241);
            this.down1.Name = "down1";
            this.down1.Size = new System.Drawing.Size(224, 8);
            this.down1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // right1
            // 
            this.right1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.right1.Image = ((System.Drawing.Image)(resources.GetObject("right1.Image")));
            this.right1.Location = new System.Drawing.Point(231, 46);
            this.right1.Name = "right1";
            this.right1.Size = new System.Drawing.Size(8, 69);
            this.right1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // left1
            // 
            this.left1.Image = ((System.Drawing.Image)(resources.GetObject("left1.Image")));
            this.left1.Location = new System.Drawing.Point(1, 46);
            this.left1.Name = "left1";
            this.left1.Size = new System.Drawing.Size(8, 69);
            this.left1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(231, 198);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(8, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(231, 97);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(8, 138);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(1, 198);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(8, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.BackColor = System.Drawing.Color.Black;
            this.pictureBox4.Location = new System.Drawing.Point(1, 97);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(8, 138);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // reasonLink
            // 
            this.reasonLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.reasonLink.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Underline);
            this.reasonLink.Location = new System.Drawing.Point(5, 251);
            this.reasonLink.Name = "reasonLink";
            this.reasonLink.Size = new System.Drawing.Size(121, 15);
            this.reasonLink.TabIndex = 11;
            this.reasonLink.Text = "Is the text messed up?";
            this.reasonLink.Click += new System.EventHandler(this.reasonLink_Click);
            // 
            // rawtextLink
            // 
            this.rawtextLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rawtextLink.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Underline);
            this.rawtextLink.Location = new System.Drawing.Point(135, 251);
            this.rawtextLink.Name = "rawtextLink";
            this.rawtextLink.Size = new System.Drawing.Size(100, 15);
            this.rawtextLink.TabIndex = 12;
            this.rawtextLink.Text = "Plaintext status";
            this.rawtextLink.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.rawtextLink.Click += new System.EventHandler(this.rawtextLink_Click);
            // 
            // FormProblems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.rawtextLink);
            this.Controls.Add(this.reasonLink);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.up1);
            this.Controls.Add(this.down1);
            this.Controls.Add(this.right1);
            this.Controls.Add(this.left1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.linestatusLabel);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "FormProblems";
            this.Text = "TubeRun";
            this.Closed += new System.EventHandler(this.FormProblems_Closed);
            this.Activated += new System.EventHandler(this.FormProblems_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label linestatusLabel;
        private System.Windows.Forms.MenuItem map;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.PictureBox up1;
        private System.Windows.Forms.PictureBox down1;
        private System.Windows.Forms.PictureBox right1;
        private System.Windows.Forms.PictureBox left1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.LinkLabel reasonLink;
        private System.Windows.Forms.LinkLabel rawtextLink;
    }
}