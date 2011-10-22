using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace TubeRun
{
    public partial class FormProblems : Form
    {
        private bool killed = true;
        private bool isWeekend;
        private FormMainN father;
        private String problem;
        public FormProblems(FormMainN father, String line, String status, String problem, bool isWeekend)
        {
            this.father = father;
            this.isWeekend = isWeekend;
            InitializeComponent();
            label1.Text = "";
            Toolbox.Colorize(label1, line,false);
            linestatusLabel.Text = status;
            if (status.Equals("Good service"))
            {
                linestatusLabel.BackColor = Color.White;
                linestatusLabel.ForeColor = Color.Black;
            }
            else
            {
                linestatusLabel.BackColor = Color.Blue;
                linestatusLabel.ForeColor = Color.White;
            }
            if (problem != null && !problem.Equals("blah"))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<html><body>");
                sb.Append(problem);
                sb.Append("</body></html>");
                webBrowser1.DocumentText = sb.ToString();
                this.problem = problem;
            }
            else
            {
                webBrowser1.DocumentText = "<html><body>No extra information for this line...</body></html>";
                this.problem = "No extra information for this line...";
            }
        }

        private void exit(object sender, EventArgs e)
        {
            father.Show();
            killed = false;
            webBrowser1.Dispose();
            this.Close();
        }

        private void FormProblems_Activated(object sender, EventArgs e)
        {
            killed = true;
        }

        private void FormProblems_Closed(object sender, EventArgs e)
        {
            if (killed) father.exit(null,null);
        }

        private void map_Click(object sender, EventArgs e)
        {
            String apppath = "\\Windows\\iexplore.exe";
            String flashpath = "\\Windows\\flashlite.dll";
            String page;
            if (!isWeekend) page = "http://www.tfl.gov.uk/tfl/common/maps/swf/map-wrapper.swf?offset=now&mode=track";
            else page = "http://www.tfl.gov.uk/tfl/common/maps/swf/map-wrapper.swf?offset=weekend&mode=track";
            if (File.Exists(apppath) && File.Exists(flashpath))
            {
                Toolbox.LaunchApp(apppath, page);
            }
            else
            {
                MessageBox.Show("Flash Lite not detected in your device. This feature only works with WM 6.5.","TubeRun");
            }
        }

        private void reasonLink_Click(object sender, EventArgs e)
        {
            String s="This is because your device runs an outdated build of .NET CF 3.5. "+
                "To solve this, download and install hotfix KB975281 from www.hotfixr.com. "+
                "In the meantime, tap \"Plaintext status\".";
            MessageBox.Show(s, "TubeRun");
        }

        private void rawtextLink_Click(object sender, EventArgs e)
        {
            String myproblem = problem.Length > 250 ? problem.Substring(0, 250)+" (...)" : problem;
            MessageBox.Show(myproblem, "TubeRun");
        }
    }
}