using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TubeRun
{
    public partial class FormFavoritesW : FormFavoritesN
    {
        public FormFavoritesW()
        {
            InitializeComponent();
        }

        public FormFavoritesW(FormMainN main, String line):base(main,line)
        {
            InitializeComponent();
            Toolbox.SetButtonStyle(mem5);
            Toolbox.SetButtonStyle(mem6);
            Toolbox.Colorize(this.line, line, false);
            redraw_memories();
        }

        protected override void menuItem1_Click(object sender, EventArgs e)
        {
            String station = (String)stations_mem[comboBox1.Text];
            String direction = comboBox2.Text;
            FormSaveW sm = new FormSaveW(this, favline, station, comboBox1.Text, direction);
            sm.Show();
            this.Hide();
        }

        protected override void run_Click(object sender, EventArgs e)
        {
            String station = (String)stations_mem[comboBox1.Text];
            String direction = comboBox2.Text;
            FormDeparturesW depart = new FormDeparturesW(this, favline, station, comboBox1.Text, direction);
            depart.Show();
            this.Hide();
        }

        private void mem_Click(object sender, EventArgs e)
        {
            String station = null;
            String direction = null;
            String station_nice = null;
            int no = memories.Count;
            if (sender == (Object)mem5)
            {
                if (no >= 5)
                {
                    station = ((Memory)memories[4]).station;
                    direction = ((Memory)memories[4]).direction;
                    station_nice = ((Memory)memories[4]).station_nice;
                }
            }
            else if (sender == (Object)mem6)
            {
                if (no >= 6)
                {
                    station = ((Memory)memories[5]).station;
                    direction = ((Memory)memories[5]).direction;
                    station_nice = ((Memory)memories[5]).station_nice;
                }
            }
            if (station != null)
            {
                FormDeparturesN depart = new_dep_form(this, favline, station, station_nice, direction);
                depart.Show();
                this.Hide();
            }
        }

        protected override FormDeparturesN new_dep_form(FormFavoritesN f, String favline, String station, String station_nice, String direction)
        {
            return new FormDeparturesW(f, favline, station, station_nice, direction);
        }

        public override void redraw_memories()
        {
            base.redraw_memories();
            if (mem5==null || mem6==null) return;
            try
            {
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
                String filePath = appPath + favline + ".tr";
                if (File.Exists(filePath))
                {
                    StreamReader file = null;
                    try
                    {
                        file = new StreamReader(filePath);
                        String rline;
                        for (int i = 1; (rline = file.ReadLine()) != null && i <= 6; i++)
                        {
                            if (i <= 4) continue;
                            String[] parts = rline.Split(new char[] { '|' });
                            Memory mem = new Memory("", "", "", "");
                            if (parts.Length == 4)
                            {
                                mem = new Memory(parts[0], parts[1], parts[2], parts[3]);
                            }
                            switch (i)
                            {
                                case 5:
                                    if (mem.direction != "") Toolbox.paintButtonWColor(mem5, mem);
                                    else
                                    {
                                        Toolbox.paintButtonDefault(mem5);
                                        mem5.Enabled = false;
                                    }
                                    break;
                                case 6:
                                    if (mem.direction != "") Toolbox.paintButtonWColor(mem6, mem);
                                    else
                                    {
                                        Toolbox.paintButtonDefault(mem6);
                                        mem6.Enabled = false;
                                    }
                                    break;
                            }
                            memories.Add(mem);
                        }

                    }
                    finally
                    {
                        if (file != null)
                            file.Close();
                    }
                }
            }
            catch (Exception)
            {
                //Safe to ignore, the file was invalid but it will be ok on next refresh.
            }
        }
    }
}