using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;
using System.IO;

namespace TubeRun
{
    public partial class FormMainW : FormMainN
    {
        private String lastupdate_temp;
        private String overground_temp;
        private String dlr_temp;
        public FormMainW()
        {
            InitializeComponent();
            last_update.Text = lastupdate_temp;
            if (overground_temp!=null) overground_status.Text = overground_temp;
            if (dlr_temp !=null) dlr_status.Text = dlr_temp;
            paintStatuses();
            menuItem2.MenuItems.Remove(dlr);
            menuItem2.MenuItems.Remove(overground);
        }

        public override void setLineStatusesImplementation(Hashtable statusesReceived, Hashtable problems)
        {
            if (statusesReceived != null && (statusesReceived.Count == 12 || statusesReceived.Count == 14))
            {
                Hashtable statusesClone = (Hashtable)statusesReceived.Clone();
                statusesClone = pruneStatuses(statusesClone);
                String update = (String)statusesReceived["timestamp"];
                if (last_update != null && last_update.Equals("") == false) last_update.Text = "Last Update: " + update;
                else lastupdate_temp = "Last Update: " + update;
                overground_temp = (String)statusesClone["overground"];
                if (overground_status != null) overground_status.Text = (String)statusesReceived["overground"];
                dlr_temp = (String)statusesClone["dlr"];
                if (dlr_status != null) dlr_status.Text = (String)statuses["dlr"];
            }
            base.setLineStatusesImplementation(statusesReceived, problems);
        }

        protected override void picadilly_button_Click(object sender, EventArgs e)
        {
            FormFavoritesW fav = new FormFavoritesW(this, "piccadilly");
            fav.Show();
            this.Hide();
        }
        protected override void circle_button_Click(object sender, EventArgs e)
        {
            FormFavoritesW fav = new FormFavoritesW(this, "circle");
            fav.Show();
            this.Hide();
        }
        protected override void district_button_Click(object sender, EventArgs e)
        {
            FormFavoritesW fav = new FormFavoritesW(this, "district");
            fav.Show();
            this.Hide();
        }
        protected override void hamersmith__button_Click(object sender, EventArgs e)
        {
            FormFavoritesW fav = new FormFavoritesW(this, "hammersmith");
            fav.Show();
            this.Hide();
        }
        protected override void victoria_button_Click(object sender, EventArgs e)
        {
            FormFavoritesW fav = new FormFavoritesW(this, "victoria");
            fav.Show();
            this.Hide();
        }
        protected override void jubilee_button_Click(object sender, EventArgs e)
        {
            FormFavoritesW fav = new FormFavoritesW(this, "jubilee");
            fav.Show();
            this.Hide();
        }
        protected override void northern_button_Click(object sender, EventArgs e)
        {
            FormFavoritesW fav = new FormFavoritesW(this, "northern");
            fav.Show();
            this.Hide();
        }
        protected override void bakerloo_button_Click(object sender, EventArgs e)
        {
            FormFavoritesW fav = new FormFavoritesW(this, "bakerloo");
            fav.Show();
            this.Hide();
        }
        protected override void central_button_Click(object sender, EventArgs e)
        {
            FormFavoritesW fav = new FormFavoritesW(this, "central");
            fav.Show();
            this.Hide();
        }
        protected override void metropolitan_button_Click(object sender, EventArgs e)
        {
            FormFavoritesW fav = new FormFavoritesW(this, "metropolitan");
            fav.Show();
            this.Hide();
        }
        protected override void waterloo_button_Click(object sender, EventArgs e)
        {
            FormFavoritesW fav = new FormFavoritesW(this, "waterlooandcity");
            fav.Show();
            this.Hide();
        }
        private void overground_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TfL does not provide Overground departures data publicly. If they do so, just mail me the link! ;-)", "TubeRun", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }

        protected override void dlr_Click(object sender, EventArgs e)
        {
            FormFavoritesN fav = new FormFavoritesW(this, "dlr");
            fav.Show();
            this.Hide();
        }
        protected override void dlr_status_Click(object sender, EventArgs e)
        {
            FormProblems prob = new FormProblems(this, "dlr",(String)statuses["dlr"], (String)problems["dlr"], weekend.Checked);
            prob.Show();
            this.Hide();
        }

        protected override void overground_status_Click(object sender, EventArgs e)
        {
            FormProblems prob = new FormProblems(this, "overground",(String)statuses["overground"], (String)problems["overground"], weekend.Checked);
            prob.Show();
            this.Hide();
        } 

        protected override void paintStatuses()
        {
            base.paintStatuses();
            String goodservice = "Good service";
            if (overground_status != null)
            {
                if (overground_status.Text.Equals(goodservice))
                {
                    overground_status.BackColor = Color.White;
                    overground_status.ForeColor = Color.Black;
                }
                else
                {
                    overground_status.BackColor = Color.Blue;
                    overground_status.ForeColor = Color.White;
                }
            }
            if (dlr_status != null)
            {
                if (dlr_status.Text.Equals(goodservice))
                {
                    dlr_status.BackColor = Color.WhiteSmoke;
                    dlr_status.ForeColor = Color.Black;
                }
                else
                {
                    dlr_status.BackColor = Color.Blue;
                    dlr_status.ForeColor = Color.White;
                }
            }
        }
      
    }
}