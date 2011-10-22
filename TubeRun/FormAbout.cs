using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TubeRun
{
    public partial class FormAbout : Form
    {
        private bool killed = true;
        private FormMainN father;
        public FormAbout(FormMainN father)
        {
            this.father = father;
            InitializeComponent();

        }

        private void exit_form(object sender, EventArgs e)
        {
            father.Show();
            killed = false;
            this.Close();
        }

        private bool busy = false;
        void tb_Changed(object sender, EventArgs e)
        {
            if (busy) return;
            busy = true;
            bool wide = this.Size.Height < this.Size.Width;
            if (wide)
            {
                textBox1.ScrollBars = ScrollBars.Vertical;
                textBox2.ScrollBars = ScrollBars.Vertical;
            }
            else 
            {
                textBox1.ScrollBars = ScrollBars.None;
                textBox2.ScrollBars = ScrollBars.None;
            }
            busy = false; 
        }

        private void FormAbout_Activated(object sender, EventArgs e)
        {
            killed = true;
        }

        private void FormAbout_Closed(object sender, EventArgs e)
        {
            if (killed) father.exit(null, null);
        }

    }
}