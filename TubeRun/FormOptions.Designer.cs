namespace TubeRun
{
    partial class FormOptions
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.combo_map = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.combo_autostart = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.combo_depfix = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.combo_depobsthres = new System.Windows.Forms.ComboBox();
            this.combo_depaction = new System.Windows.Forms.ComboBox();
            this.combo_runthres = new System.Windows.Forms.ComboBox();
            this.combo_linefetch = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Save";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Back";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.combo_map);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.combo_autostart);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.combo_depfix);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.combo_depobsthres);
            this.panel1.Controls.Add(this.combo_depaction);
            this.panel1.Controls.Add(this.combo_runthres);
            this.panel1.Controls.Add(this.combo_linefetch);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 348);
            this.panel1.Tag = "";
            // 
            // combo_map
            // 
            this.combo_map.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_map.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.combo_map.Items.Add("None");
            this.combo_map.Items.Add("Custom");
            this.combo_map.Items.Add("HTC");
            this.combo_map.Items.Add("Opera");
            this.combo_map.Items.Add("Samsung");
            this.combo_map.Location = new System.Drawing.Point(155, 255);
            this.combo_map.Name = "combo_map";
            this.combo_map.Size = new System.Drawing.Size(75, 27);
            this.combo_map.TabIndex = 7;
            this.combo_map.SelectedIndexChanged += new System.EventHandler(this.combo_map_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(3, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 33);
            this.label8.Text = "Map Viewer Application:";
            // 
            // combo_autostart
            // 
            this.combo_autostart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_autostart.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.combo_autostart.Items.Add("Yes");
            this.combo_autostart.Items.Add("No");
            this.combo_autostart.Location = new System.Drawing.Point(155, 39);
            this.combo_autostart.Name = "combo_autostart";
            this.combo_autostart.Size = new System.Drawing.Size(75, 27);
            this.combo_autostart.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(3, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 33);
            this.label6.Text = "Fetch Autostart Station at boot:";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(126, 299);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 35);
            this.button2.TabIndex = 9;
            this.button2.Text = "Reset TubeRun";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // combo_depfix
            // 
            this.combo_depfix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_depfix.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.combo_depfix.Items.Add("Yes");
            this.combo_depfix.Items.Add("No");
            this.combo_depfix.Location = new System.Drawing.Point(155, 111);
            this.combo_depfix.Name = "combo_depfix";
            this.combo_depfix.Size = new System.Drawing.Size(75, 27);
            this.combo_depfix.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(3, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 33);
            this.label7.Text = "Adjust departure board results (-1min)";
            // 
            // combo_depobsthres
            // 
            this.combo_depobsthres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_depobsthres.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.combo_depobsthres.Items.Add("10 sec");
            this.combo_depobsthres.Items.Add("20 sec");
            this.combo_depobsthres.Items.Add("30 sec");
            this.combo_depobsthres.Items.Add("40 sec");
            this.combo_depobsthres.Items.Add("50 sec");
            this.combo_depobsthres.Items.Add("60 sec");
            this.combo_depobsthres.Location = new System.Drawing.Point(155, 219);
            this.combo_depobsthres.Name = "combo_depobsthres";
            this.combo_depobsthres.Size = new System.Drawing.Size(75, 27);
            this.combo_depobsthres.TabIndex = 6;
            // 
            // combo_depaction
            // 
            this.combo_depaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_depaction.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.combo_depaction.Items.Add("None");
            this.combo_depaction.Items.Add("Close");
            this.combo_depaction.Items.Add("Refresh");
            this.combo_depaction.Location = new System.Drawing.Point(155, 183);
            this.combo_depaction.Name = "combo_depaction";
            this.combo_depaction.Size = new System.Drawing.Size(75, 27);
            this.combo_depaction.TabIndex = 5;
            // 
            // combo_runthres
            // 
            this.combo_runthres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_runthres.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.combo_runthres.Items.Add("1 min");
            this.combo_runthres.Items.Add("2 min");
            this.combo_runthres.Items.Add("3 min");
            this.combo_runthres.Items.Add("4 min");
            this.combo_runthres.Items.Add("5 min");
            this.combo_runthres.Items.Add("6 min");
            this.combo_runthres.Location = new System.Drawing.Point(155, 147);
            this.combo_runthres.Name = "combo_runthres";
            this.combo_runthres.Size = new System.Drawing.Size(75, 27);
            this.combo_runthres.TabIndex = 4;
            // 
            // combo_linefetch
            // 
            this.combo_linefetch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_linefetch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.combo_linefetch.Items.Add("Yes");
            this.combo_linefetch.Items.Add("No");
            this.combo_linefetch.Location = new System.Drawing.Point(155, 75);
            this.combo_linefetch.Name = "combo_linefetch";
            this.combo_linefetch.Size = new System.Drawing.Size(75, 27);
            this.combo_linefetch.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 35);
            this.button1.TabIndex = 8;
            this.button1.Text = "Reset Options";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(3, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 33);
            this.label5.Text = "Departure boards obsolete threshold:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(3, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 33);
            this.label4.Text = "Departure boards action when obsolete:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(3, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 33);
            this.label3.Text = "Departure boards \"run\" threshold:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(3, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 33);
            this.label2.Text = "Fetch line statuses at boot:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 21);
            this.label1.Text = "Options";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 348);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "FormOptions";
            this.Text = "TubeRun";
            this.Closed += new System.EventHandler(this.FormOptions_Closed);
            this.Activated += new System.EventHandler(this.FormOptions_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormOptions_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox combo_linefetch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox combo_depobsthres;
        private System.Windows.Forms.ComboBox combo_depaction;
        private System.Windows.Forms.ComboBox combo_runthres;
        private System.Windows.Forms.ComboBox combo_depfix;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox combo_autostart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox combo_map;
        private System.Windows.Forms.Label label8;
    }
}