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
    public partial class FormNotes : Form
    {
        private bool killed = true;
        private int ITEMS = 7; 
        private int caret_pos=0;
        private int num = 2;
        private FormMainN parent;
        private bool found_file=false;
        public FormNotes(FormMainN main)
        {
            parent = main;
            InitializeComponent();
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
            String filePath = appPath + "Help.tr";
            if (File.Exists(filePath))
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(filePath);
                    String line;
                    while ((line = file.ReadLine()) != null)
                    {
                        textBox1.Text += line+"\r\n";
                    }
                    found_file = true;
                }
                catch (Exception)
                {
                    //Safe to ignore, the file was invalid but it will be ok on next refresh.
                }
                finally
                {
                    if (file != null)
                        file.Close();
                }
            }
            else textBox1.Text = "No Notes to display.";
            if (parent == null)
            {
                this.mainMenu1.MenuItems.Remove(this.menuItem2);
                //menuItem2.Text = "Exit";
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (parent != null)
            {
                parent.Show();
                killed = false;
                this.Close();
            }
            else
            {
                FormMainN form;
                String scr = Toolbox.getSetting("screentype");
                if (scr.Equals("wide"))
                {
                    form = new FormMainW();
                }
                else form = new FormMainN();
                form.Show();
                this.Hide();
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            if (num<=ITEMS && found_file)
            {
                String rest = textBox1.Text.Substring(caret_pos);
                int pos = rest.IndexOf(Convert.ToString(num) + ".");
                num++;
                if (pos != -1)
                {
                    rest = rest.Substring(pos);
                    int end = rest.IndexOf("\r\n");                    
                    caret_pos += pos;
                    textBox1.Select(caret_pos + end, 0);
                    textBox1.ScrollToCaret();
                }
                if (num>ITEMS)
                {
                    menuItem1.Text = "OK";
                }                
            }
            else back_Click(null, null);          
            
        }

        private void FormNotes_Activated(object sender, EventArgs e)
        {
            killed = true;
        }

        private void FormNotes_Closed(object sender, EventArgs e)
        {
            if (killed)
            {
                if (parent != null) parent.exit(null, null);
                else Application.Exit();
            }
            
        }
    }
}