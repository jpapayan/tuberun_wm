using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace TubeRun
{
    public partial class FormSaveW : FormSaveN
    {
        public FormSaveW()
        {
            InitializeComponent();
        }
        public FormSaveW(FormFavoritesN form, String line, String station, String station_nice, String direction)
            : base(form,line,station,station_nice,direction)
        {
            InitializeComponent();
            Toolbox.SetButtonStyle(mem5);
            Toolbox.SetButtonStyle(mem6);
            Toolbox.Colorize(line_label, line, false);
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
                        for (int i = 1; (rline = file.ReadLine()) != null && i<=6; i++)
                        {
                            if (i<5) continue;
                            String[] parts = rline.Split(new char[] {'|'});
                            Memory mem = new Memory("", "", "", "");
                            if (parts.Length == 4)
                            {
                                mem = new Memory(parts[0], parts[1], parts[2], parts[3]);
                            }
                            if (i == 5 && mem.direction!="") Toolbox.paintButtonWColor(mem5, mem);
                            else if (i == 6 && mem.direction != "") Toolbox.paintButtonWColor(mem6, mem);
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
            mem5.Enabled = true;
            mem6.Enabled = true;
        }

        protected override void menuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
                String filePath = appPath + line + ".tr";
                if (File.Exists(filePath))
                {
                    FileStream file = new FileStream(filePath, FileMode.Truncate, FileAccess.Write);
                    StreamWriter outw = new StreamWriter(file);
                    outw.Write("\r\n\r\n\r\n\r\n\r\n\r\n");
                    outw.Close();
                    file.Close();
                    Toolbox.paintButtonDefault(mem1);
                    Toolbox.paintButtonDefault(mem2);
                    Toolbox.paintButtonDefault(mem3);
                    Toolbox.paintButtonDefault(mem4);
                    Toolbox.paintButtonDefault(mem5);
                    Toolbox.paintButtonDefault(mem6);
                }
            }
            catch (Exception)
            {
                //The file cant be erased, can't do anything...
            }
        }

        protected override void menuItem2_Click(object sender, EventArgs e)
        {
            form.redraw_memories();
            form.Show();
            killed = false;
            if (sender == (Object)menuItem2) this.Close();
        }

        protected override void save(object sender, EventArgs e)
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
            else if (sender == (Object)mem5)
            {
                mem_no = 5;
                Toolbox.paintButtonWColor(mem5, mem);
            }
            else if (sender == (Object)mem6)
            {
                mem_no = 6;
                Toolbox.paintButtonWColor(mem6, mem);
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
                        for (int i = 1; (l = inr.ReadLine()) != null && i <= 6; i++)
                        {
                            if (i == mem_no)
                            {
                                content.Add(line + "|" + station + "|" + station_nice + "|" + direction);
                            }
                            else content.Add(l);
                        }

                    }
                    finally
                    {
                        inr.Close();
                    }
                    StreamWriter outw = null;
                    FileStream file = null;
                    try
                    {
                        file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                        outw = new StreamWriter(file);
                        foreach (String s in content) outw.WriteLine(s);

                    }
                    finally
                    {
                        if (outw != null) outw.Close();
                        if (file != null) file.Close();
                    }

                }
                else
                {
                    FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(file);
                    for (int i = 1; i <=6; i++)
                    {
                        if (i == mem_no)
                        {
                            sw.WriteLine(line + "|" + station + "|" + station_nice + "|" + direction);
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

    }
}