using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.WindowsCE.Forms;

namespace TubeRun
{
    public partial class FormFavoritesN : Form
    {
        private bool killed = true;
        private FormMainN main;
        protected String favline;
        protected Hashtable stations_mem;
        protected ArrayList memories = new ArrayList();
        //Useless constructor in order to make the designer work
        public FormFavoritesN()
        {
            InitializeComponent();
        }

        public FormFavoritesN(FormMainN main, String line)
        {
            try
            {
                InitializeComponent();
                this.main = main;
                this.favline = line;
                Toolbox.Colorize(this.line, favline, false);
                Hashtable stations = Toolbox.FetchStations(line);
                stations_mem = stations;
                ICollection keys = stations.Keys;
                ArrayList sorter = new ArrayList();
                sorter.AddRange(keys);
                sorter.Sort();
                foreach (String s in sorter)
                {
                    comboBox1.Items.Add(s);
                }
                Toolbox.SetButtonStyle(mem1);
                Toolbox.SetButtonStyle(mem2);
                Toolbox.SetButtonStyle(mem3);
                Toolbox.SetButtonStyle(mem4);
                redraw_memories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public virtual void redraw_memories()
        {
            try
            {
                memories = new ArrayList();
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
                String filePath = appPath + favline + ".tr";
                if (File.Exists(filePath))
                {
                    StreamReader file = null;
                    try
                    {
                        file = new StreamReader(filePath);
                        String rline;
                        for (int i = 1; (rline = file.ReadLine()) != null && i <= 4; i++)
                        {
                            String[] parts = rline.Split(new char[] { '|' });
                            Memory mem = new Memory("","","","");
                            if (parts.Length == 4)
                            {
                                mem = new Memory(parts[0], parts[1], parts[2], parts[3]);
                            }
                            switch (i)
                            {
                                case 1:
                                    if (mem.direction != "") Toolbox.paintButtonWColor(mem1, mem);
                                    else
                                    {
                                        Toolbox.paintButtonDefault(mem1);
                                        mem1.Enabled = false;
                                    }
                                    break;
                                case 2:
                                    if (mem.direction != "") Toolbox.paintButtonWColor(mem2, mem);
                                    else
                                    {
                                        Toolbox.paintButtonDefault(mem2);
                                        mem2.Enabled = false;
                                    }
                                    break;
                                case 3:
                                    if (mem.direction != "") Toolbox.paintButtonWColor(mem3, mem);
                                    else
                                    {
                                        Toolbox.paintButtonDefault(mem3);
                                        mem3.Enabled = false;
                                    }
                                    break;
                                case 4:
                                    if (mem.direction != "") Toolbox.paintButtonWColor(mem4, mem);
                                    else
                                    {
                                        Toolbox.paintButtonDefault(mem4);
                                        mem4.Enabled = false;
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
        private void menuItem2_Click(object sender, EventArgs e)
        {
            main.Show();
            killed = false;
            this.Close();
        }
        private void activate_run(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex >= 0 && comboBox2.SelectedIndex >= 0)
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDeparturesN));
                run.Image = ((System.Drawing.Image)(resources.GetObject("next")));
                run.Enabled = true;
                menuItem1.Enabled = true;
            }
        }
        protected virtual void run_Click(object sender, EventArgs e)
        {
            String station = (String)stations_mem[comboBox1.Text];
            String direction = comboBox2.Text;
            FormDeparturesN depart = new FormDeparturesN(this, favline, station, comboBox1.Text, direction);
            depart.Show();
            this.Hide();
        }
        protected virtual void menuItem1_Click(object sender, EventArgs e)
        {
            String station = (String)stations_mem[comboBox1.Text];
            String direction = comboBox2.Text;
            FormSaveN sm = new FormSaveN(this, favline, station, comboBox1.Text, direction);
            sm.Show();
            this.Hide();
        }
        private void mem_Click(object sender, EventArgs e)
        {
            String station = null;
            String direction = null;
            String station_nice = null;
            int no = memories.Count;
            if (sender == (Object)mem1)
            {
                if (no >= 1)
                {
                    station = ((Memory)memories[0]).station;
                    direction = ((Memory)memories[0]).direction;
                    station_nice = ((Memory)memories[0]).station_nice;
                }
            }
            else if (sender == (Object)mem2)
            {
                if (no >= 2)
                {
                    station = ((Memory)memories[1]).station;
                    direction = ((Memory)memories[1]).direction;
                    station_nice = ((Memory)memories[1]).station_nice;
                }
            }
            else if (sender == (Object)mem3)
            {
                if (no >= 3)
                {
                    station = ((Memory)memories[2]).station;
                    direction = ((Memory)memories[2]).direction;
                    station_nice = ((Memory)memories[2]).station_nice;
                }
            }
            else if (sender == (Object)mem4)
            {
                if (no >= 4)
                {
                    station = ((Memory)memories[3]).station;
                    direction = ((Memory)memories[3]).direction;
                    station_nice = ((Memory)memories[3]).station_nice;
                }
            }
            if (station != null)
            {
                FormDeparturesN depart = new_dep_form(this, favline, station, station_nice, direction);
                depart.Show();
                this.Hide();
            }
        }
        protected virtual FormDeparturesN new_dep_form(FormFavoritesN f, String favline, String station, String station_nice, String direction)
        {
            return new FormDeparturesN(f, favline, station, station_nice, direction);
        }

        private void FormFavoritesN_Activated(object sender, EventArgs e)
        {
            killed = true;
        }
        private void FormFavoritesN_Closed(object sender, EventArgs e)
        {
            if (killed) main.exit(null, null);
        }
        public void exit()
        {
            main.exit(null, null);
        }
        private bool isClicked(ComboBox cb)
        {
            const int CB_GETDROPPEDSTATE = 0x157;
            ComboBox _cBox = cb;
            Message comboBoxMessage = Message.Create(_cBox.Handle, CB_GETDROPPEDSTATE, IntPtr.Zero, IntPtr.Zero);
            MessageWindow.SendMessage(ref comboBoxMessage);
            // if isDropped is true, then the combo box is open
            return  comboBoxMessage.Result != IntPtr.Zero;
        }
        private Button getFirstActive()
        {
            if (mem1.Enabled == true) return mem1;
            for (int i = 0; i < panel_mem.Controls.Count; i++)
            {
                if (panel_mem.Controls[i].Enabled)
                {
                    if (panel_mem.Controls[i] is Button)
                        return (Button)panel_mem.Controls[i];
                }
            }
            return mem1; //no luck
        }
        private void FormFavoritesN_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                if (comboBox1.Focused)
                {
                    if (!isClicked(comboBox1)) e.Handled=true;
                    return;
                }
                else if (run.Focused)
                {
                    e.Handled = true;
                    return;
                }
                else if (comboBox2.Focused)
                {
                    if (!isClicked(comboBox2))
                    {
                        comboBox1.Focus();
                        e.Handled = true;
                        return;
                    }
                    else return;
                }
                else if (mem1.Focused) 
                {
                    comboBox2.Focus();
                    e.Handled = true;
                    return;
                }
                else if (mem2.Focused)
                {
                    if (run.Enabled == true) run.Focus();
                    else comboBox2.Focus();
                    e.Handled = true;
                    return;
                }
                return;
            }
            else if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                if (comboBox1.Focused)
                {
                    if (!isClicked(comboBox1))
                    {
                        comboBox2.Focus();
                        e.Handled = true;
                    }
                    return;
                }
                if (comboBox2.Focused)
                {
                    if (!isClicked(comboBox2))
                    {
                        getFirstActive().Focus();
                        e.Handled = true;
                    }
                    return;
                }
                else if (run.Focused)
                {
                    getFirstActive().Focus();
                    e.Handled = true;
                    return;
                }
                return;
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                if (comboBox1.Focused)
                {
                    if (run.Enabled == true) run.Focus();
                    e.Handled = true;
                    return;
                }
                if (comboBox2.Focused)
                {
                    if (run.Enabled == true) run.Focus();
                    e.Handled = true;
                    return;
                }
                else if (run.Focused)
                {
                    comboBox1.Focus();
                    e.Handled = true;
                    return;
                }
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                if (comboBox1.Focused)
                {
                    if (run.Enabled == true) run.Focus();
                    e.Handled = true;
                    return;
                }
                if (comboBox2.Focused)
                {
                    if (run.Enabled == true) run.Focus();
                    e.Handled = true;
                    return;
                }
                else if (run.Focused)
                {
                    comboBox1.Focus();
                    e.Handled = true;
                    return;
                }
                return;
            }
        }
        System.Drawing.Image unhighlighted=null;
        System.Drawing.Image highlighted = null;
        private void highlight(object sender, MouseEventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDeparturesN));
            if (highlighted == null)
            {
                highlighted = ((System.Drawing.Image)(resources.GetObject("next_sel")));
                unhighlighted = run.Image;
            }
            run.Image = highlighted;
        }
        private void unhighlight(object sender, MouseEventArgs e)
        {
            run_Click(null, null);            
            run.Image = unhighlighted;
        }
    }
}