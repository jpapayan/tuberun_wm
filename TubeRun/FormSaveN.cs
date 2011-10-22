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

namespace TubeRun
{
   
    public partial class FormSaveN : Form
    {
        protected bool killed = true;
        protected FormFavoritesN form;
        protected String station, line, station_nice, direction;
        protected ArrayList memories = new ArrayList(5);
        public FormSaveN()
        {
            InitializeComponent();
        }
        public FormSaveN(FormFavoritesN form, String line, String station, String station_nice, String direction)
        {
            this.form = form;
            this.line = line;
            this.station = station;
            this.station_nice = station_nice;
            this.direction = direction;
            InitializeComponent();
            Toolbox.SetButtonStyle(mem1);
            Toolbox.SetButtonStyle(mem2);
            Toolbox.SetButtonStyle(mem3);
            Toolbox.SetButtonStyle(mem4);
            Toolbox.SetButtonStyle(mem_auto);
            Toolbox.Colorize(line_label, line, false);
            station_label.Text = station_nice;
            direction_Label.Text = direction;
            try
            {
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
                String filePath = appPath + line + ".tr";
                if (File.Exists(filePath))
                {
                    StreamReader file = null;
                    try
                    {
                        file = new StreamReader(filePath);
                        String rline;
                        for (int i = 1; (rline = file.ReadLine()) != null && i<=5; i++)
                        {
                            String[] parts = rline.Split(new char[] {'|'});
                            Memory mem=new Memory("","","","");
                            if (parts.Length == 4)
                            {
                                mem = new Memory(parts[0], parts[1], parts[2], parts[3]);
                            }
                            if (i == 1 && mem.direction!="") Toolbox.paintButtonWColor(mem1, mem);
                            else if (i == 2 && mem.direction != "") Toolbox.paintButtonWColor(mem2, mem);
                            else if (i == 3 && mem.direction != "") Toolbox.paintButtonWColor(mem3, mem);
                            else if (i == 4 && mem.direction != "") Toolbox.paintButtonWColor(mem4, mem);
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
            try
            {
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
                String filePath = appPath + "auto.tr";
                if (File.Exists(filePath))
                {
                    StreamReader file = null;
                    try
                    {
                        file = new StreamReader(filePath);
                        String rline;
                        for (int i = 1; (rline = file.ReadLine()) != null && i <= 1; i++)
                        {
                            String[] parts = rline.Split(new char[] { '|' });
                            Memory mem = null;
                            if (parts.Length == 4)
                            {
                                mem = new Memory(parts[0], parts[1], parts[2], parts[3]);
                            }
                            Toolbox.paintButtonWColor(mem_auto, mem);
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
            mem1.Enabled = true;
            mem2.Enabled = true;
            mem3.Enabled = true;
            mem4.Enabled = true;
            mem_auto.Enabled = true;
        }
        protected virtual void menuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
                String filePath = appPath + line + ".tr";
                if (File.Exists(filePath))
                {
                    FileStream file = new FileStream(filePath, FileMode.Truncate, FileAccess.Write);
                    StreamWriter outw = new StreamWriter(file);
                    outw.Write("\r\n\r\n\r\n\r\n");
                    outw.Close();
                    file.Close();
                    Toolbox.paintButtonDefault(mem1);
                    Toolbox.paintButtonDefault(mem2);
                    Toolbox.paintButtonDefault(mem3);
                    Toolbox.paintButtonDefault(mem4);
                }
            }
            catch (Exception)
            {
                //The file cant be erased, can't do anything...
            }
        }
        protected virtual void menuItem2_Click(object sender, EventArgs e)
        {
            form.redraw_memories();
            form.Show();
            killed = false;
            Close();            
        }
        protected virtual void save(object sender, EventArgs e)
        {
            int mem_no;
            Memory mem = new Memory(line, station, station_nice, direction);
            if (sender == (Object)mem1)
            {
                mem_no = 1;
               Toolbox.paintButtonWColor(mem1, mem);
            }
            else if (sender == (Object)mem2)
            {
                mem_no = 2;
                Toolbox.paintButtonWColor(mem2, mem);
            }
            else if (sender == (Object)mem3)
            {
                mem_no = 3;
                Toolbox.paintButtonWColor(mem3, mem);
            }
            else if (sender == (Object)mem4)
            {
                mem_no = 4;
                Toolbox.paintButtonWColor(mem4, mem);
            }
            else mem_no = 0;
            try
            {
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
                String filePath = appPath + line + ".tr";
                if (File.Exists(filePath))
                {   
                    ArrayList content = new ArrayList();
                    StreamReader inr = null;
                    try
                    {
                        String l;
                        inr = new StreamReader(filePath);
                        for (int i = 1; (l = inr.ReadLine()) != null && i < 5; i++)
                        {
                            if (i == mem_no)
                            {
                                content.Add(line+"|"+station + "|" + station_nice + "|" + direction);
                            }
                            else content.Add(l);
                        }

                    }
                    finally
                    {
                        inr.Close();
                    }
                    StreamWriter outw = null;
                    FileStream file=null;
                    try
                    {
                        file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                        outw = new StreamWriter(file);
                        foreach (String s in content) outw.WriteLine(s);

                    }
                    finally
                    {
                        if (outw!=null) outw.Close();
                        if (file != null) file.Close();
                    }

                }
                else {
                    FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(file);
                    for (int i=1;i<5;i++) {
                        if (i==mem_no) {
                            sw.WriteLine(line+"|"+station+"|"+station_nice+"|"+direction);
                        }
                        else sw.WriteLine("");
                    }
                    sw.Close();
                    file.Close();

                }
            }
            catch (Exception exc)
            {
                Console.Write(exc.StackTrace);
            }

        }
        protected virtual void saveAuto(object sender, EventArgs e)
        {
            Memory mem = new Memory(line, station, station_nice, direction);
            Toolbox.paintButtonWColor(mem_auto, mem);
            try
            {
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
                String filePath = appPath + "auto.tr";
                FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file);
                sw.WriteLine(line + "|" + station + "|" + station_nice + "|" + direction);
                sw.Close();
                file.Close();
            }
            catch (Exception exc)
            {
                Console.Write(exc.StackTrace);
            }

        }
        private void SaveForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }
        private void FormSaveN_Closed(object sender, EventArgs e)
        {
            if (killed) form.exit();
        }
        private void FormSaveN_Activated(object sender, EventArgs e)
        {
            killed = true;
        }

    }
}