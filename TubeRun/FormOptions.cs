using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.WindowsCE.Forms;
using TubeRun.OpenFileDialogEx;

namespace TubeRun
{
    public partial class FormOptions : Form
    {
        private bool killed = true;
        private Boolean doNothing = false;
        private FormMainN father;
        private String customPath = "";
        private int findIndex(ComboBox cb, String ins)
        {
            if (cb == null) return -1;
            int i=0;
            foreach (String s in cb.Items)
            {
                if (s == ins) return i;
                else i++;
            }
            return -1;
        }
        public FormOptions(FormMainN father)
        {
            this.father = father;
            InitializeComponent();
            int i;
            if ((i = findIndex(combo_autostart, Toolbox.getSetting("autostart"))) != -1) combo_autostart.SelectedIndex = i;
            else combo_autostart.SelectedIndex = 1;
            if ((i=findIndex(combo_depaction,Toolbox.getSetting("depaction")))!=-1) combo_depaction.SelectedIndex = i;
            else combo_depaction.SelectedIndex = 1;
            if ((i = findIndex(combo_depfix, Toolbox.getSetting("depfix"))) != -1) combo_depfix.SelectedIndex = i;
            else combo_depfix.SelectedIndex = 1;
            if ((i = findIndex(combo_depobsthres, Toolbox.getSetting("depobsthres"))) != -1) combo_depobsthres.SelectedIndex = i;
            else combo_depobsthres.SelectedIndex = 2;
            if ((i = findIndex(combo_linefetch, Toolbox.getSetting("linefetch"))) != -1) combo_linefetch.SelectedIndex = i;
            else combo_linefetch.SelectedIndex = 1;
            if ((i = findIndex(combo_runthres, Toolbox.getSetting("runthres"))) != -1) combo_runthres.SelectedIndex = i;
            else combo_runthres.SelectedIndex = 2;
            //populate map options

            updateMapSetting(Toolbox.getSetting("mapviewer"));
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            father.Show();
            killed = false;
            this.Close();
        }
        private void menuItem1_Click(object sender, EventArgs e)
        {
            //save them to a file
            FileStream file=null;
            StreamWriter sw = null;
            try
            {
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
                String filePath = appPath + "options.tr";                
                if (File.Exists(filePath))
                {
                    file = new FileStream(filePath, FileMode.Truncate, FileAccess.Write);
                    sw = new StreamWriter(file);
                }
                else {
                    file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    sw = new StreamWriter(file);
                }
                sw.WriteLine("linefetch="+combo_linefetch.Text);
                sw.WriteLine("depfix=" + combo_depfix.Text);
                sw.WriteLine("runthres=" + combo_runthres.Text);
                sw.WriteLine("depaction=" + combo_depaction.Text);
                sw.WriteLine("depobsthres=" + combo_depobsthres.Text);
                sw.WriteLine("autostart=" + combo_autostart.Text);
                if (combo_map.Text == "None") sw.WriteLine("mapviewer=");
                else if (combo_map.Text.Equals("Custom")) sw.WriteLine("mapviewer="+customPath);
                else if (combo_map.Text == "HTC") sw.WriteLine("mapviewer=" + htcAlbumPath);
                else if (combo_map.Text == "Opera") sw.WriteLine("mapviewer=" + operaPath);
                else if (combo_map.Text == "Samsung") sw.WriteLine("mapviewer=" + samsungPath);
            }            
            catch (Exception)
            {
                
            }
            finally
            {
                if (sw != null) sw.Close();
                if (file != null) file.Close();
            }
            Toolbox.setSettings();
            father.Show();
            killed = false;
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            combo_linefetch.SelectedIndex = 1;
            combo_depfix.SelectedIndex = 1;
            combo_runthres.SelectedIndex = 2;
            combo_depobsthres.SelectedIndex=1;
            combo_depaction.SelectedIndex=2;
            combo_autostart.SelectedIndex = 1;
            updateMapSetting(Toolbox.getDefaultMapViewer());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Delete all files
            try
            {
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
                String filePath = appPath + "statuses.tr";
                if (File.Exists(filePath)) File.Delete(filePath);
                filePath = appPath + "options.tr";
                if (File.Exists(filePath)) File.Delete(filePath);
                filePath = appPath + "piccadilly.tr";
                if (File.Exists(filePath)) File.Delete(filePath);
                filePath = appPath + "bakerloo.tr";
                if (File.Exists(filePath)) File.Delete(filePath);
                filePath = appPath + "central.tr";
                if (File.Exists(filePath)) File.Delete(filePath);
                filePath = appPath + "circle.tr";
                if (File.Exists(filePath)) File.Delete(filePath);
                filePath = appPath + "district.tr";
                if (File.Exists(filePath)) File.Delete(filePath);
                filePath = appPath + "hammersmithandcity.tr";
                if (File.Exists(filePath)) File.Delete(filePath);
                filePath = appPath + "jubilee.tr";
                if (File.Exists(filePath)) File.Delete(filePath);
                filePath = appPath + "northern.tr";
                if (File.Exists(filePath)) File.Delete(filePath);
                filePath = appPath + "victoria.tr";
                if (File.Exists(filePath)) File.Delete(filePath);
                filePath = appPath + "waterlooandcity.tr";
                if (File.Exists(filePath)) File.Delete(filePath);
                filePath = appPath + "metropolitan.tr";
                if (File.Exists(filePath)) File.Delete(filePath);
                filePath = appPath + "auto.tr";
                if (File.Exists(filePath)) File.Delete(filePath);
                filePath = appPath + "dlr.tr";
                if (File.Exists(filePath)) File.Delete(filePath);
            }
            catch (Exception) {}
            killed = false;
            Close();
            father.exit(null,null);
        }
        private void FormOptions_Closed(object sender, EventArgs e)
        {
            if (killed) father.exit(null,null);
        }
        private void FormOptions_Activated(object sender, EventArgs e)
        {
            killed = true;
        }
        private bool isClicked(ComboBox cb)
        {
            const int CB_GETDROPPEDSTATE = 0x157;
            ComboBox _cBox = cb;
            Message comboBoxMessage = Message.Create(_cBox.Handle, CB_GETDROPPEDSTATE, IntPtr.Zero, IntPtr.Zero);
            MessageWindow.SendMessage(ref comboBoxMessage);
            // if isDropped is true, then the combo box is open
            return comboBoxMessage.Result != IntPtr.Zero;
        }
        private void FormOptions_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up) || (e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    if (panel1.Controls[i].Focused)
                    {
                        if (panel1.Controls[i] is ComboBox && isClicked((ComboBox)panel1.Controls[i]))
                        {
                            return;
                        }
                        panel1.SelectNextControl(panel1.Controls[i], false, true, true, true);
                        break;
                    }
                }
                e.Handled = true;
                return;
            }
            else if ((e.KeyCode == System.Windows.Forms.Keys.Down) || (e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    if (panel1.Controls[i].Focused)
                    {
                        if (panel1.Controls[i] is ComboBox && isClicked((ComboBox)panel1.Controls[i]))
                        {
                            return;
                        }
                        panel1.SelectNextControl(panel1.Controls[i], true, true, true, true);
                        break;
                    }
                }
                e.Handled = true;
                return;
            }            
        }

        private void combo_map_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (doNothing == false)
            {
                String path = "";
                try
                {
                    if (combo_map.Text == "HTC") path = htcAlbumPath;
                    else if (combo_map.Text == "Opera") path = operaPath;
                    else if (combo_map.Text == "Samsung") path = samsungPath;
                    else if (combo_map.Text == "Custom")
                    {
                        path = externalViewer();
                        if (path == null) throw new Exception();
                    }
                    if (!path.Equals(""))
                    {
                        if (!File.Exists(path))
                        {
                            throw new Exception();
                        }
                        else customPath = path;
                    }
                }
                catch (Exception)
                {
                    updateMapSetting(Toolbox.getSetting("mapviewer"));
                    MessageBox.Show("Unable to locate \"" + path + "\". The selected application is not available or no application selected.",
                        "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private String externalViewer()
        {   
            OpenFileDialogEx.OpenFileDialogEx ofd = new TubeRun.OpenFileDialogEx.OpenFileDialogEx();
            ofd.Filter = "*.exe";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }
            else return null;
        }
        private void updateMapSetting(String viewerpath)
        {
            String tag = "";
            if (viewerpath == htcAlbumPath) tag = "HTC";
            else if (viewerpath == operaPath) tag = "Opera";
            else if (viewerpath == samsungPath) tag = "Samsung";
            else if (!viewerpath.Equals("")) tag = "Custom";            
            else tag = "None";
            int i;
            doNothing = true;
            if ((i = findIndex(combo_map, tag)) != -1) combo_map.SelectedIndex = i;
            else combo_map.SelectedIndex = 0;
            doNothing = false;
        }
        public static String operaPath = "\\Windows\\OperaL.exe";
        public static String htcAlbumPath = "\\Windows\\HTCAlbum.exe";
        public static String samsungPath = "\\Windows\\PhotoAlbum.exe";
    }
}