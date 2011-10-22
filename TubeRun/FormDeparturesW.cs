using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TubeRun
{
    public partial class FormDeparturesW : FormDeparturesN
    {
        public FormDeparturesW()
        {
            InitializeComponent();
        }
        public FormDeparturesW(FormFavoritesN fav, String line, String station, String station_nice, String direction)
            : base(fav, line, station, station_nice, direction)
        {
            InitializeComponent();
            Toolbox.Colorize(this.station_label, line, false);
            this.station_label.Text = station_nice;
            Toolbox.Colorize(label_up_line, upline, true);
            Toolbox.Colorize(label_down_line, downline, true);

            up1.MouseDown += new MouseEventHandler(Form1_MouseDown);
            up2.MouseDown += new MouseEventHandler(Form1_MouseDown);
            up3.MouseDown += new MouseEventHandler(Form1_MouseDown);
            down1.MouseDown += new MouseEventHandler(Form1_MouseDown);
            down2.MouseDown += new MouseEventHandler(Form1_MouseDown);
            down3.MouseDown += new MouseEventHandler(Form1_MouseDown);
            left1.MouseDown += new MouseEventHandler(Form1_MouseDown);
            left2.MouseDown += new MouseEventHandler(Form1_MouseDown);
            left3.MouseDown += new MouseEventHandler(Form1_MouseDown);
            right1.MouseDown += new MouseEventHandler(Form1_MouseDown);
            right2.MouseDown += new MouseEventHandler(Form1_MouseDown);
            right3.MouseDown += new MouseEventHandler(Form1_MouseDown);

            up1.MouseUp += new MouseEventHandler(Form1_MouseUp);
            up2.MouseUp += new MouseEventHandler(Form1_MouseUp);
            up3.MouseUp += new MouseEventHandler(Form1_MouseUp);
            down1.MouseUp += new MouseEventHandler(Form1_MouseUp);
            down2.MouseUp += new MouseEventHandler(Form1_MouseUp);
            down3.MouseUp += new MouseEventHandler(Form1_MouseUp);
            left1.MouseUp += new MouseEventHandler(Form1_MouseUp);
            left2.MouseUp += new MouseEventHandler(Form1_MouseUp);
            left3.MouseUp += new MouseEventHandler(Form1_MouseUp);
            right1.MouseUp += new MouseEventHandler(Form1_MouseUp);
            right2.MouseUp += new MouseEventHandler(Form1_MouseUp);
            right3.MouseUp += new MouseEventHandler(Form1_MouseUp);

        }

        public FormDeparturesW(FormMainN main, String line, String station, String station_nice, String direction, String dummy)
            : this(null, line, station, station_nice, direction)
        {
            this.mainform = main;
        }

        protected override void changeLine(bool go_up)
        {
            base.changeLine(go_up);
            Toolbox.Colorize(label_up_line, upline, true);
            Toolbox.Colorize(label_down_line, downline, true);
        }
    }
}