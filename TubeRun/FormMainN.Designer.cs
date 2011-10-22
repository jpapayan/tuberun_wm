namespace TubeRun
{
    partial class FormMainN
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.map = new System.Windows.Forms.MenuItem();
            this.dlr = new System.Windows.Forms.MenuItem();
            this.dlr_depmenu = new System.Windows.Forms.MenuItem();
            this.dlr_satmenu = new System.Windows.Forms.MenuItem();
            this.overground = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.district_button = new System.Windows.Forms.Button();
            this.picadilly_button = new System.Windows.Forms.Button();
            this.circle_button = new System.Windows.Forms.Button();
            this.hamersmith__button = new System.Windows.Forms.Button();
            this.victoria_button = new System.Windows.Forms.Button();
            this.jubilee_button = new System.Windows.Forms.Button();
            this.northern_button = new System.Windows.Forms.Button();
            this.central_button = new System.Windows.Forms.Button();
            this.bakerloo_button = new System.Windows.Forms.Button();
            this.metropolitan_button = new System.Windows.Forms.Button();
            this.waterloo_button = new System.Windows.Forms.Button();
            this.picadily_status = new System.Windows.Forms.LinkLabel();
            this.circle_status = new System.Windows.Forms.LinkLabel();
            this.district_status = new System.Windows.Forms.LinkLabel();
            this.hammersmith_status = new System.Windows.Forms.LinkLabel();
            this.victoria_status = new System.Windows.Forms.LinkLabel();
            this.jubilee_status = new System.Windows.Forms.LinkLabel();
            this.northern_status = new System.Windows.Forms.LinkLabel();
            this.bakerloo_status = new System.Windows.Forms.LinkLabel();
            this.central_status = new System.Windows.Forms.LinkLabel();
            this.metropolitan_status = new System.Windows.Forms.LinkLabel();
            this.waterloo_status = new System.Windows.Forms.LinkLabel();
            this.weekend = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Reload";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.map);
            this.menuItem2.MenuItems.Add(this.dlr);
            this.menuItem2.MenuItems.Add(this.overground);
            this.menuItem2.MenuItems.Add(this.weekend);
            this.menuItem2.MenuItems.Add(this.menuItem9);
            this.menuItem2.MenuItems.Add(this.menuItem3);
            this.menuItem2.MenuItems.Add(this.menuItem6);
            this.menuItem2.MenuItems.Add(this.menuItem7);
            this.menuItem2.MenuItems.Add(this.menuItem4);
            this.menuItem2.MenuItems.Add(this.menuItem5);
            this.menuItem2.Text = "More";
            // 
            // map
            // 
            this.map.Text = "Tube Map";
            this.map.Click += new System.EventHandler(this.map_Click);
            // 
            // dlr
            // 
            this.dlr.MenuItems.Add(this.dlr_depmenu);
            this.dlr.MenuItems.Add(this.dlr_satmenu);
            this.dlr.Text = "DLR";
            // 
            // dlr_depmenu
            // 
            this.dlr_depmenu.Text = "Departures";
            this.dlr_depmenu.Click += new System.EventHandler(this.dlr_Click);
            // 
            // dlr_satmenu
            // 
            this.dlr_satmenu.Text = "Status";
            this.dlr_satmenu.Click += new System.EventHandler(this.dlr_status_Click);
            // 
            // overground
            // 
            this.overground.Text = "Overground";
            this.overground.Click += new System.EventHandler(this.overground_status_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "Options";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Text = "Notes";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Text = "-";
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "About";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Text = "Exit";
            this.menuItem5.Click += new System.EventHandler(this.exit);
            // 
            // district_button
            // 
            this.district_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.district_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.district_button.ForeColor = System.Drawing.Color.White;
            this.district_button.Location = new System.Drawing.Point(0, 51);
            this.district_button.Name = "district_button";
            this.district_button.Size = new System.Drawing.Size(113, 24);
            this.district_button.TabIndex = 5;
            this.district_button.Text = "District";
            this.district_button.Click += new System.EventHandler(this.district_button_Click);
            // 
            // picadilly_button
            // 
            this.picadilly_button.BackColor = System.Drawing.Color.Blue;
            this.picadilly_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.picadilly_button.ForeColor = System.Drawing.Color.White;
            this.picadilly_button.Location = new System.Drawing.Point(0, 1);
            this.picadilly_button.Name = "picadilly_button";
            this.picadilly_button.Size = new System.Drawing.Size(113, 25);
            this.picadilly_button.TabIndex = 1;
            this.picadilly_button.Text = "Piccadilly";
            this.picadilly_button.Click += new System.EventHandler(this.picadilly_button_Click);
            // 
            // circle_button
            // 
            this.circle_button.BackColor = System.Drawing.Color.Yellow;
            this.circle_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.circle_button.ForeColor = System.Drawing.Color.Black;
            this.circle_button.Location = new System.Drawing.Point(0, 26);
            this.circle_button.Name = "circle_button";
            this.circle_button.Size = new System.Drawing.Size(113, 25);
            this.circle_button.TabIndex = 3;
            this.circle_button.Text = "Circle";
            this.circle_button.Click += new System.EventHandler(this.circle_button_Click);
            // 
            // hamersmith__button
            // 
            this.hamersmith__button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.hamersmith__button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.hamersmith__button.ForeColor = System.Drawing.Color.DarkBlue;
            this.hamersmith__button.Location = new System.Drawing.Point(0, 75);
            this.hamersmith__button.Name = "hamersmith__button";
            this.hamersmith__button.Size = new System.Drawing.Size(113, 24);
            this.hamersmith__button.TabIndex = 7;
            this.hamersmith__button.Text = "Hamsmith";
            this.hamersmith__button.Click += new System.EventHandler(this.hamersmith__button_Click);
            // 
            // victoria_button
            // 
            this.victoria_button.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.victoria_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.victoria_button.ForeColor = System.Drawing.Color.White;
            this.victoria_button.Location = new System.Drawing.Point(0, 99);
            this.victoria_button.Name = "victoria_button";
            this.victoria_button.Size = new System.Drawing.Size(113, 24);
            this.victoria_button.TabIndex = 9;
            this.victoria_button.Text = "Victoria";
            this.victoria_button.Click += new System.EventHandler(this.victoria_button_Click);
            // 
            // jubilee_button
            // 
            this.jubilee_button.BackColor = System.Drawing.Color.DarkGray;
            this.jubilee_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.jubilee_button.ForeColor = System.Drawing.Color.White;
            this.jubilee_button.Location = new System.Drawing.Point(0, 123);
            this.jubilee_button.Name = "jubilee_button";
            this.jubilee_button.Size = new System.Drawing.Size(113, 24);
            this.jubilee_button.TabIndex = 11;
            this.jubilee_button.Text = "Jubilee";
            this.jubilee_button.Click += new System.EventHandler(this.jubilee_button_Click);
            // 
            // northern_button
            // 
            this.northern_button.BackColor = System.Drawing.Color.Black;
            this.northern_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.northern_button.ForeColor = System.Drawing.Color.White;
            this.northern_button.Location = new System.Drawing.Point(0, 147);
            this.northern_button.Name = "northern_button";
            this.northern_button.Size = new System.Drawing.Size(113, 24);
            this.northern_button.TabIndex = 13;
            this.northern_button.Text = "Northern";
            this.northern_button.Click += new System.EventHandler(this.northern_button_Click);
            // 
            // central_button
            // 
            this.central_button.BackColor = System.Drawing.Color.Red;
            this.central_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.central_button.ForeColor = System.Drawing.Color.White;
            this.central_button.Location = new System.Drawing.Point(0, 195);
            this.central_button.Name = "central_button";
            this.central_button.Size = new System.Drawing.Size(113, 24);
            this.central_button.TabIndex = 17;
            this.central_button.Text = "Central";
            this.central_button.Click += new System.EventHandler(this.central_button_Click);
            // 
            // bakerloo_button
            // 
            this.bakerloo_button.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.bakerloo_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.bakerloo_button.ForeColor = System.Drawing.Color.White;
            this.bakerloo_button.Location = new System.Drawing.Point(0, 171);
            this.bakerloo_button.Name = "bakerloo_button";
            this.bakerloo_button.Size = new System.Drawing.Size(113, 24);
            this.bakerloo_button.TabIndex = 15;
            this.bakerloo_button.Text = "Bakerloo";
            this.bakerloo_button.Click += new System.EventHandler(this.bakerloo_button_Click);
            // 
            // metropolitan_button
            // 
            this.metropolitan_button.BackColor = System.Drawing.Color.MediumVioletRed;
            this.metropolitan_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.metropolitan_button.ForeColor = System.Drawing.Color.White;
            this.metropolitan_button.Location = new System.Drawing.Point(0, 219);
            this.metropolitan_button.Name = "metropolitan_button";
            this.metropolitan_button.Size = new System.Drawing.Size(113, 24);
            this.metropolitan_button.TabIndex = 19;
            this.metropolitan_button.Text = "Metropolitan";
            this.metropolitan_button.Click += new System.EventHandler(this.metropolitan_button_Click);
            // 
            // waterloo_button
            // 
            this.waterloo_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(200)))));
            this.waterloo_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.waterloo_button.ForeColor = System.Drawing.Color.White;
            this.waterloo_button.Location = new System.Drawing.Point(0, 243);
            this.waterloo_button.Name = "waterloo_button";
            this.waterloo_button.Size = new System.Drawing.Size(113, 24);
            this.waterloo_button.TabIndex = 21;
            this.waterloo_button.Text = "Waterloo";
            this.waterloo_button.Click += new System.EventHandler(this.waterloo_button_Click);
            // 
            // picadily_status
            // 
            this.picadily_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picadily_status.BackColor = System.Drawing.Color.White;
            this.picadily_status.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.picadily_status.ForeColor = System.Drawing.Color.Black;
            this.picadily_status.Location = new System.Drawing.Point(113, 3);
            this.picadily_status.Name = "picadily_status";
            this.picadily_status.Size = new System.Drawing.Size(127, 24);
            this.picadily_status.TabIndex = 2;
            this.picadily_status.Text = "No data...";
            this.picadily_status.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.picadily_status.Click += new System.EventHandler(this.picadily_status_Click);
            // 
            // circle_status
            // 
            this.circle_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.circle_status.BackColor = System.Drawing.Color.WhiteSmoke;
            this.circle_status.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.circle_status.ForeColor = System.Drawing.Color.Black;
            this.circle_status.Location = new System.Drawing.Point(113, 27);
            this.circle_status.Name = "circle_status";
            this.circle_status.Size = new System.Drawing.Size(127, 24);
            this.circle_status.TabIndex = 4;
            this.circle_status.Text = "No data...";
            this.circle_status.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.circle_status.Click += new System.EventHandler(this.circle_status_Click);
            // 
            // district_status
            // 
            this.district_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.district_status.BackColor = System.Drawing.Color.White;
            this.district_status.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.district_status.ForeColor = System.Drawing.Color.Black;
            this.district_status.Location = new System.Drawing.Point(113, 51);
            this.district_status.Name = "district_status";
            this.district_status.Size = new System.Drawing.Size(127, 24);
            this.district_status.TabIndex = 6;
            this.district_status.Text = "No data...";
            this.district_status.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.district_status.Click += new System.EventHandler(this.district_status_Click);
            // 
            // hammersmith_status
            // 
            this.hammersmith_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hammersmith_status.BackColor = System.Drawing.Color.WhiteSmoke;
            this.hammersmith_status.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.hammersmith_status.ForeColor = System.Drawing.Color.Black;
            this.hammersmith_status.Location = new System.Drawing.Point(113, 75);
            this.hammersmith_status.Name = "hammersmith_status";
            this.hammersmith_status.Size = new System.Drawing.Size(127, 24);
            this.hammersmith_status.TabIndex = 8;
            this.hammersmith_status.Text = "No data...";
            this.hammersmith_status.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hammersmith_status.Click += new System.EventHandler(this.Hammersmith_status_Click);
            // 
            // victoria_status
            // 
            this.victoria_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.victoria_status.BackColor = System.Drawing.Color.White;
            this.victoria_status.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.victoria_status.ForeColor = System.Drawing.Color.Black;
            this.victoria_status.Location = new System.Drawing.Point(113, 99);
            this.victoria_status.Name = "victoria_status";
            this.victoria_status.Size = new System.Drawing.Size(127, 24);
            this.victoria_status.TabIndex = 10;
            this.victoria_status.Text = "No data...";
            this.victoria_status.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.victoria_status.Click += new System.EventHandler(this.victoria_status_Click);
            // 
            // jubilee_status
            // 
            this.jubilee_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.jubilee_status.BackColor = System.Drawing.Color.WhiteSmoke;
            this.jubilee_status.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.jubilee_status.ForeColor = System.Drawing.Color.Black;
            this.jubilee_status.Location = new System.Drawing.Point(113, 123);
            this.jubilee_status.Name = "jubilee_status";
            this.jubilee_status.Size = new System.Drawing.Size(127, 24);
            this.jubilee_status.TabIndex = 12;
            this.jubilee_status.Text = "No data...";
            this.jubilee_status.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.jubilee_status.Click += new System.EventHandler(this.jubilee_status_Click);
            // 
            // northern_status
            // 
            this.northern_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.northern_status.BackColor = System.Drawing.Color.White;
            this.northern_status.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.northern_status.ForeColor = System.Drawing.Color.Black;
            this.northern_status.Location = new System.Drawing.Point(113, 147);
            this.northern_status.Name = "northern_status";
            this.northern_status.Size = new System.Drawing.Size(127, 24);
            this.northern_status.TabIndex = 14;
            this.northern_status.Text = "No data...";
            this.northern_status.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.northern_status.Click += new System.EventHandler(this.northern_status_Click);
            // 
            // bakerloo_status
            // 
            this.bakerloo_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bakerloo_status.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bakerloo_status.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.bakerloo_status.ForeColor = System.Drawing.Color.Black;
            this.bakerloo_status.Location = new System.Drawing.Point(113, 171);
            this.bakerloo_status.Name = "bakerloo_status";
            this.bakerloo_status.Size = new System.Drawing.Size(127, 24);
            this.bakerloo_status.TabIndex = 16;
            this.bakerloo_status.Text = "No data...";
            this.bakerloo_status.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bakerloo_status.Click += new System.EventHandler(this.bakerloo_status_Click);
            // 
            // central_status
            // 
            this.central_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.central_status.BackColor = System.Drawing.Color.White;
            this.central_status.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.central_status.ForeColor = System.Drawing.Color.Black;
            this.central_status.Location = new System.Drawing.Point(113, 195);
            this.central_status.Name = "central_status";
            this.central_status.Size = new System.Drawing.Size(127, 24);
            this.central_status.TabIndex = 18;
            this.central_status.Text = "No data...";
            this.central_status.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.central_status.Click += new System.EventHandler(this.central_status_Click);
            // 
            // metropolitan_status
            // 
            this.metropolitan_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.metropolitan_status.BackColor = System.Drawing.Color.WhiteSmoke;
            this.metropolitan_status.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.metropolitan_status.ForeColor = System.Drawing.Color.Black;
            this.metropolitan_status.Location = new System.Drawing.Point(113, 219);
            this.metropolitan_status.Name = "metropolitan_status";
            this.metropolitan_status.Size = new System.Drawing.Size(127, 24);
            this.metropolitan_status.TabIndex = 20;
            this.metropolitan_status.Text = "No data...";
            this.metropolitan_status.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metropolitan_status.Click += new System.EventHandler(this.metropolitan_status_Click);
            // 
            // waterloo_status
            // 
            this.waterloo_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.waterloo_status.BackColor = System.Drawing.Color.White;
            this.waterloo_status.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.waterloo_status.ForeColor = System.Drawing.Color.Black;
            this.waterloo_status.Location = new System.Drawing.Point(113, 243);
            this.waterloo_status.Name = "waterloo_status";
            this.waterloo_status.Size = new System.Drawing.Size(127, 24);
            this.waterloo_status.TabIndex = 22;
            this.waterloo_status.Text = "No data...";
            this.waterloo_status.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.waterloo_status.Click += new System.EventHandler(this.waterloo_status_Click);
            // 
            // weekend
            // 
            this.weekend.Text = "This Weekend";
            this.weekend.Click += new System.EventHandler(this.weekend_Click);
            // 
            // FormMainN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.waterloo_status);
            this.Controls.Add(this.metropolitan_status);
            this.Controls.Add(this.central_status);
            this.Controls.Add(this.bakerloo_status);
            this.Controls.Add(this.northern_status);
            this.Controls.Add(this.jubilee_status);
            this.Controls.Add(this.victoria_status);
            this.Controls.Add(this.hammersmith_status);
            this.Controls.Add(this.district_status);
            this.Controls.Add(this.circle_status);
            this.Controls.Add(this.picadily_status);
            this.Controls.Add(this.picadilly_button);
            this.Controls.Add(this.circle_button);
            this.Controls.Add(this.district_button);
            this.Controls.Add(this.hamersmith__button);
            this.Controls.Add(this.victoria_button);
            this.Controls.Add(this.jubilee_button);
            this.Controls.Add(this.northern_button);
            this.Controls.Add(this.bakerloo_button);
            this.Controls.Add(this.central_button);
            this.Controls.Add(this.metropolitan_button);
            this.Controls.Add(this.waterloo_button);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "FormMainN";
            this.Text = "TubeRun";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMainN_MouseUp);
            this.Activated += new System.EventHandler(this.FormMainN_Activated);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMainN_MouseDown);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormMainN_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMainN_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.MenuItem menuItem1;
        protected System.Windows.Forms.MenuItem menuItem2;
        protected System.Windows.Forms.Button district_button;
        protected System.Windows.Forms.Button picadilly_button;
        protected System.Windows.Forms.Button circle_button;
        protected System.Windows.Forms.Button hamersmith__button;
        protected System.Windows.Forms.Button victoria_button;
        protected System.Windows.Forms.Button jubilee_button;
        protected System.Windows.Forms.Button northern_button;
        protected System.Windows.Forms.Button central_button;
        protected System.Windows.Forms.Button bakerloo_button;
        protected System.Windows.Forms.MenuItem menuItem4;
        protected System.Windows.Forms.MenuItem menuItem3;
        protected System.Windows.Forms.MenuItem menuItem5;
        protected System.Windows.Forms.Button metropolitan_button;
        protected System.Windows.Forms.Button waterloo_button;
        protected System.Windows.Forms.MenuItem menuItem6;
        protected System.Windows.Forms.MenuItem menuItem7;
        protected System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem9;
        protected System.Windows.Forms.LinkLabel picadily_status;
        protected System.Windows.Forms.LinkLabel circle_status;
        protected System.Windows.Forms.LinkLabel district_status;
        protected System.Windows.Forms.LinkLabel hammersmith_status;
        protected System.Windows.Forms.LinkLabel victoria_status;
        protected System.Windows.Forms.LinkLabel jubilee_status;
        protected System.Windows.Forms.LinkLabel northern_status;
        protected System.Windows.Forms.LinkLabel bakerloo_status;
        protected System.Windows.Forms.LinkLabel central_status;
        protected System.Windows.Forms.LinkLabel metropolitan_status;
        protected System.Windows.Forms.LinkLabel waterloo_status;
        protected System.Windows.Forms.MenuItem map;
        protected System.Windows.Forms.MenuItem dlr;
        protected System.Windows.Forms.MenuItem overground;
        private System.Windows.Forms.MenuItem dlr_depmenu;
        protected System.Windows.Forms.MenuItem dlr_satmenu;
        protected System.Windows.Forms.MenuItem weekend;
    }
}

