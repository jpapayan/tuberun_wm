using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Collections;
using System.Runtime.InteropServices;

namespace TubeRun
{
    public partial class FormMainN : Form
    {
        private int tickid = -1;
        private Boolean firstrun = true;
        private Fetcher fetcher = null;
        private DateTime dt_lastupdate=DateTime.MinValue;
        protected Hashtable problems=new Hashtable();
        protected Hashtable statuses=newStatuses();
        private Bitmap bitmap = null;
        private Thread fetchThread = null;
        private Thread fetchThreadTicker = null;
        public delegate void delegateSetLineStatuses(Hashtable statuses, Hashtable problems);
        public delegateSetLineStatuses setLineStatuses;
        public delegate void delegateRefreshStatusLabel(int tid);
        public delegateRefreshStatusLabel callRefreshStatusLabel;
        public delegate void delegateAuto(String line, String station, String station_nice, String direction);
        public delegateAuto callAuto;
        public FormMainN()
        {
            fetcher = new Fetcher(this);
            InitializeComponent();
            callAuto= new delegateAuto(this.AutoImplementation);
            setLineStatuses = new delegateSetLineStatuses(this.setLineStatusesImplementation);
            callRefreshStatusLabel = new delegateRefreshStatusLabel(this.refreshStatusLabelImplementation);
            if (Toolbox.getSetting("linefetch") == "No")
            {
                try
                {
                    string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
                    String filePath = appPath + "statuses.tr";
                    if (File.Exists(filePath))
                    {
                        StreamReader file = null;
                        try
                        {
                            file = new StreamReader(filePath);
                            Hashtable all_statuses = new Hashtable();
                            Hashtable all_details = new Hashtable();
                            String line;
                            line = file.ReadLine();
                            for (int i = 1; line!=null && i < 15; i++)
                            {
                                String prev_line = line;
                                line = file.ReadLine();
                                if (line==null) //last line
                                {
                                    all_statuses["timestamp"] = prev_line;
                                    setLineStatusesImplementation(all_statuses, all_details);
                                    break;
                                }
                                String[] all = prev_line.Split(new char[] { '|' });
                                all_statuses[all[0]] = all[1];
                                all_details[all[0]] = all[2];
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
            else if (Toolbox.getSetting("linefetch") == "Yes") update();
            if (Toolbox.getSetting("autostart") == "Yes")
            {
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
                            String rline = file.ReadLine();
                            String[] parts = rline.Split(new char[] { '|' });
                            if (parts.Length == 4)
                            {
                                Fetcher f = new Fetcher(this, parts[0], parts[1], parts[2], parts[3]);
                                new Thread(new ThreadStart(f.showStation)).Start();
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
        public void setFetcher(Fetcher f)
        {
            if (f!=null && fetcher==null) fetcher = f;
        }
        public virtual void AutoImplementation(String line,String station, String station_nice,String direction)
        {
            String scr = Toolbox.getSetting("screentype");
            if (!scr.Equals("wide"))
            {
                FormDeparturesN depart = new FormDeparturesN(this, line, station, station_nice, direction, "");
                depart.Show();

            }
            else
            {
                FormDeparturesW depart = new FormDeparturesW(this, line, station, station_nice, direction, "");
                depart.Show();
            }
            this.Hide();
        }
        public virtual void setLineStatusesImplementation(Hashtable statusesReceived, Hashtable problems) {
            if (statusesReceived != null && (statusesReceived.Count == 12 || statusesReceived.Count == 14))
            {
                this.problems = problems;
                this.statuses = statusesReceived;
                statusesReceived=pruneStatuses(statusesReceived);
                picadily_status.Text = (String)statuses["piccadilly"];                
                victoria_status.Text = (String)statuses["victoria"];
                circle_status.Text = (String)statuses["circle"];
                district_status.Text = (String)statuses["district"];
                jubilee_status.Text = (String)statuses["jubilee"];
                hammersmith_status.Text = (String)statuses["hammersmithandcity"];
                northern_status.Text = (String)statuses["northern"];
                central_status.Text = (String)statuses["central"];
                bakerloo_status.Text = (String)statuses["bakerloo"];
                waterloo_status.Text = (String)statuses["waterlooandcity"];
                metropolitan_status.Text = (String)statuses["metropolitan"];
                String update = (String)statuses["timestamp"];
                CultureInfo ci = new CultureInfo("en-GB");
                DateTime dt_update = DateTime.Parse(update, ci);
                dt_lastupdate = dt_update;
                //last_update.Text = dt_update.ToString();
                refreshStatusLabelImplementation(tickid);                
            }
            else
            {
                menuItem1.Text = "Failed";
                this.menuItem1.Enabled = true;
            }
            paintStatuses();
            fetchThread = null;
        }
        public void refreshStatusLabelImplementation(int tid)
        {
            if (tid != tickid) return;
            if (dt_lastupdate != DateTime.MinValue)
            {
                DateTime dt = DateTime.Now;
                TimeSpan diff = dt - dt_lastupdate;
                if (diff.Days > 0 || diff.Hours > 0 || diff.Minutes > 5)
                {
                    menuItem1.Text = "Outdated";
                    fetchThreadTicker = null;
                    this.menuItem1.Enabled = true;
                }
                else
                {
                    if (diff.Minutes == 0) menuItem1.Text = "Updated";
                    else menuItem1.Text = diff.Minutes + " min old";
                    Fetcher myfetcher = new Fetcher(this);
                    myfetcher.settickid(tickid);
                    if (fetchThreadTicker != null && Thread.CurrentThread != fetchThreadTicker) fetchThreadTicker.Abort();
                    fetchThreadTicker = new Thread(new ThreadStart(myfetcher.tick));
                    fetchThreadTicker.Name = "Fethcer" + tickid;
                    fetchThreadTicker.Start();
                    this.menuItem1.Enabled = true;                    
                }
            }
            else
            {
                menuItem1.Text = "Reload";
                this.menuItem1.Enabled = true;
            }
        }
        public void update()
        {
            fetcher = new Fetcher(this);
            if (weekend.Checked) fetcher.setWeekendUrl();
            fetcher.settickid(++tickid);
            this.menuItem1.Text = "Wait...";
            this.menuItem1.Enabled = false;
            if (fetchThread != null) fetchThread.Abort();
            fetchThread = new Thread(new ThreadStart(fetcher.updateLineStatus));
            fetchThread.Start();
        }
        private void menuItem1_Click(object sender, EventArgs e)
        {
            update();
        }
        private void menuItem4_Click(object sender, EventArgs e)
        {
            FormAbout af=new FormAbout(this);
            af.Show();
            this.Hide();
        }
        public void exit(object sender, EventArgs e)
        {
            FormMainN_Closing(null, null);            
        }
        private void picadily_status_Click(object sender, EventArgs e)
        {
            FormProblems prob = new FormProblems(this, "piccadilly", (String)statuses["piccadilly"], (String)problems["piccadilly"], weekend.Checked);
            prob.Show();
            this.Hide();
        }
        private void circle_status_Click(object sender, EventArgs e)
        {
            FormProblems prob = new FormProblems(this, "circle",(String)statuses["circle"], (String)problems["circle"], weekend.Checked);
            prob.Show();
            this.Hide();
        }
        private void district_status_Click(object sender, EventArgs e)
        {
            FormProblems prob = new FormProblems(this, "district",(String)statuses["district"], (String)problems["district"], weekend.Checked);
            prob.Show();
            this.Hide();
        }
        private void Hammersmith_status_Click(object sender, EventArgs e)
        {
            FormProblems prob = new FormProblems(this, "hammersmith",(String)statuses["hammersmithandcity"], (String)problems["hammersmithandcity"], weekend.Checked);
            prob.Show();
            this.Hide();
        }
        private void victoria_status_Click(object sender, EventArgs e)
        {
            FormProblems prob = new FormProblems(this, "victoria",(String)statuses["victoria"], (String)problems["victoria"], weekend.Checked);
            prob.Show();
            this.Hide();
        }
        private void jubilee_status_Click(object sender, EventArgs e)
        {
            FormProblems prob = new FormProblems(this, "jubilee",(String)statuses["jubilee"], (String)problems["jubilee"], weekend.Checked);
            prob.Show();
            this.Hide();
        }
        private void northern_status_Click(object sender, EventArgs e)
        {
            FormProblems prob = new FormProblems(this, "northern",(String)statuses["northern"], (String)problems["northern"], weekend.Checked);
            prob.Show();
            this.Hide();
        }
        private void bakerloo_status_Click(object sender, EventArgs e)
        {
            FormProblems prob = new FormProblems(this, "bakerloo",(String)statuses["bakerloo"], (String)problems["bakerloo"], weekend.Checked);
            prob.Show();
            this.Hide();
        }
        private void central_status_Click(object sender, EventArgs e)
        {
            FormProblems prob = new FormProblems(this, "central",(String)statuses["central"], (String)problems["central"], weekend.Checked);
            prob.Show();
            this.Hide();
        }
        private void metropolitan_status_Click(object sender, EventArgs e)
        {
            FormProblems prob = new FormProblems(this, "metropolitan",(String)statuses["metropolitan"], (String)problems["metropolitan"], weekend.Checked);
            prob.Show();
            this.Hide();
        }
        private void waterloo_status_Click(object sender, EventArgs e)
        {
            FormProblems prob = new FormProblems(this, "waterlooandcity",(String)statuses["waterlooandcity"], (String)problems["waterlooandcity"], weekend.Checked);
            prob.Show();
            this.Hide();
        }
        protected virtual void picadilly_button_Click(object sender, EventArgs e)
        {
            FormFavoritesN fav = new FormFavoritesN(this, "piccadilly");
            fav.Show();
            this.Hide();
        }
        protected virtual void circle_button_Click(object sender, EventArgs e)
        {
            FormFavoritesN fav = new FormFavoritesN(this, "circle");
            fav.Show();
            this.Hide();
        }
        protected virtual void district_button_Click(object sender, EventArgs e)
        {
            FormFavoritesN fav = new FormFavoritesN(this, "district");
            fav.Show();
            this.Hide();
        }
        protected virtual void hamersmith__button_Click(object sender, EventArgs e)
        {
            FormFavoritesN fav = new FormFavoritesN(this, "hammersmith");
            fav.Show();
            this.Hide();
        }
        protected virtual void victoria_button_Click(object sender, EventArgs e)
        {
            FormFavoritesN fav = new FormFavoritesN(this, "victoria");
            fav.Show();
            this.Hide();
        }
        protected virtual void jubilee_button_Click(object sender, EventArgs e)
        {
            FormFavoritesN fav = new FormFavoritesN(this, "jubilee");
            fav.Show();
            this.Hide();
        }
        protected virtual void northern_button_Click(object sender, EventArgs e)
        {
            FormFavoritesN fav = new FormFavoritesN(this, "northern");
            fav.Show();
            this.Hide();
        }
        protected virtual void bakerloo_button_Click(object sender, EventArgs e)
        {
            FormFavoritesN fav = new FormFavoritesN(this, "bakerloo");
            fav.Show();
            this.Hide();
        }
        protected virtual void central_button_Click(object sender, EventArgs e)
        {
            FormFavoritesN fav = new FormFavoritesN(this, "central");
            fav.Show();
            this.Hide();
        }
        protected virtual void metropolitan_button_Click(object sender, EventArgs e)
        {
            FormFavoritesN fav = new FormFavoritesN(this, "metropolitan");
            fav.Show();
            this.Hide();
        }
        protected virtual void waterloo_button_Click(object sender, EventArgs e)
        {
            FormFavoritesN fav = new FormFavoritesN(this, "waterlooandcity");
            fav.Show();
            this.Hide();
        }
        protected virtual void dlr_Click(object sender, EventArgs e)
        {
            FormFavoritesN fav = new FormFavoritesN(this, "dlr");
            fav.Show();
            this.Hide();
        }
        protected virtual void dlr_status_Click(object sender, EventArgs e)
        {
            FormProblems prob = new FormProblems(this, "dlr",(String)statuses["dlr"], (String)problems["dlr"], weekend.Checked);
            prob.Show();
            this.Hide();
        }

        protected virtual void overground_status_Click(object sender, EventArgs e)
        {
            FormProblems prob = new FormProblems(this, "overground", (String)statuses["overground"],(String)problems["overground"],weekend.Checked);
            prob.Show();
            this.Hide();
        } 
        private void menuItem3_Click(object sender, EventArgs e)
        {
            FormOptions opt = new FormOptions(this);
            opt.Show();
            this.Hide();
        }
        private void menuItem6_Click(object sender, EventArgs e)
        {
            FormNotes nf = new FormNotes(this);
            nf.Show();
            this.Hide();
        }
        private void FormMainN_Closing(object sender, CancelEventArgs e)
        {
            if (fetchThread != null)
                fetchThread.Abort();
            if (fetchThreadTicker != null)
                fetchThreadTicker.Abort();
            Application.Exit();
            
        }
        private void FormMainN_Activated(object sender, EventArgs e)
        {
            if (firstrun) firstrun = false;
            else refreshStatusLabelImplementation(tickid);
        }
        private void FormMainN_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    if (this.Controls[i].Focused)
                    {
                        this.SelectNextControl(this.Controls[i], false, true, true, true);
                        for (int j = 0; j < this.Controls.Count; j++)
                        {
                            if (this.Controls[j].Focused)
                            {
                                this.SelectNextControl(this.Controls[j], false, true, true, true);
                                break;
                            }
                        } 
                        break;
                    }
                    
                } 
            }
            else if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    if (this.Controls[i].Focused)
                    {
                        this.SelectNextControl(this.Controls[i], true, true, true, true);
                        for (int j = 0; j < this.Controls.Count; j++)
                        {
                            if (this.Controls[j].Focused)
                            {
                                this.SelectNextControl(this.Controls[j], true, true, true, true);
                                break;
                            }
                        } 
                        break;
                    }
                } 
            }
            else if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    if (this.Controls[i].Focused)
                    {
                        if (this.Controls[i] is Button) this.SelectNextControl(this.Controls[i], true, true, true, true);
                        else this.SelectNextControl(this.Controls[i], false, true, true, true);
                        break;
                    }
                } 
            }
            else if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    if (this.Controls[i].Focused)
                    {
                        if (this.Controls[i] is Button) this.SelectNextControl(this.Controls[i], true, true, true, true);
                        else this.SelectNextControl(this.Controls[i], false, true, true, true);
                        break;
                    }
                } 
            }
            e.Handled = true;
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                e.Handled = false;
            }
            
        }
        private int startPositionY = 0;
        private int startPositionX = 0;
        private int Move_ThresholdY = Screen.PrimaryScreen.Bounds.Height / 5;
        private int Move_ThresholdX = Screen.PrimaryScreen.Bounds.Width / 3;
        private int Touch_ThresholdY = Screen.PrimaryScreen.Bounds.Width / 4;
        private int Touch_ThresholdX = Screen.PrimaryScreen.Bounds.Height / 6;
        private void FormMainN_MouseDown(object sender, MouseEventArgs e)
        {
            Point mousePoint = this.PointToClient(((System.Windows.Forms.Control)sender).PointToScreen(new Point(e.X,e.Y)));
            startPositionY = mousePoint.Y;
            startPositionX = mousePoint.X;
        }
        private void FormMainN_MouseUp(object sender, MouseEventArgs e)
        {
            Point mousePoint = this.PointToClient(((System.Windows.Forms.Control)sender).PointToScreen(new Point(e.X, e.Y)));

            //Left-right Gestures
            if (startPositionX < mousePoint.X && mousePoint.X - startPositionX > Move_ThresholdX
                && Math.Abs(mousePoint.Y - startPositionY) < Touch_ThresholdY)
            {
                //MessageBox.Show("back");
            }
            else if (startPositionX > mousePoint.X && startPositionX - mousePoint.X > Move_ThresholdX
                && Math.Abs(mousePoint.Y - startPositionY) < Touch_ThresholdY)
            {
                //MessageBox.Show("next");
            }

            //Up-Down gestures
            else if (startPositionY < mousePoint.Y && mousePoint.Y - startPositionY > Move_ThresholdY
                && Math.Abs(mousePoint.X - startPositionX) < Touch_ThresholdX)
            {
                //finger up-to-down gesture
                //MessageBox.Show("up");
            }
            else if (startPositionY > mousePoint.Y && startPositionY - mousePoint.Y > Move_ThresholdY
                && Math.Abs(mousePoint.X - startPositionX) < Touch_ThresholdX)
            {
                //finger down-to-up gesture
                //MessageBox.Show("down");
            }
        }
        private void picadily_status_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("key pressed");
        }
        private void map_Click(object sender, EventArgs e)
        {
            try
            {
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
                String filePath = appPath + "tubemap.jpg";
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Could not locate the map, did you delete it? Please reinstall the application.", "TubeRun");
                }
                else
                {
                    String apppath = Toolbox.getSetting("mapviewer");                    
                    if (File.Exists(apppath))
                    {
                        Toolbox.LaunchApp(apppath, filePath);
                    }
                    else if (apppath.Equals(""))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        Cursor.Show();
                        FormMap fm = new FormMap(this, bitmap);
                        if (bitmap == null) bitmap = fm.getBitmap();
                        fm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("The mapviewer (JPG) application that you selected does not exist. Please select another option/application.","TubeRun");
                    }
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to start the map. Please make another mapviewer choice in Options.","TubeRun");
            }
        }                
        protected virtual void paintStatuses()
        {
            String goodservice = "Good service";
            if (picadily_status.Text.Equals(goodservice))
            {
                picadily_status.BackColor = Color.White;
                picadily_status.ForeColor = Color.Black;
            }
            else
            {
                picadily_status.BackColor = Color.Blue;
                picadily_status.ForeColor = Color.White;
            }
            if (circle_status.Text.Equals(goodservice))
            {
                circle_status.BackColor = Color.WhiteSmoke;
                circle_status.ForeColor = Color.Black;
            }
            else
            {
                circle_status.BackColor = Color.Blue;
                circle_status.ForeColor = Color.White;
            }
            if (district_status.Text.Equals(goodservice))
            {
                district_status.BackColor = Color.White;
                district_status.ForeColor = Color.Black;
            }
            else
            {
                district_status.BackColor = Color.Blue;
                district_status.ForeColor = Color.White;
            }
            if (hammersmith_status.Text.Equals(goodservice))
            {
                hammersmith_status.BackColor = Color.WhiteSmoke;
                hammersmith_status.ForeColor = Color.Black;
            }
            else
            {
                hammersmith_status.BackColor = Color.Blue;
                hammersmith_status.ForeColor = Color.White;
            }
            if (victoria_status.Text.Equals(goodservice))
            {
                victoria_status.BackColor = Color.White;
                victoria_status.ForeColor = Color.Black;
            }
            else
            {
                victoria_status.BackColor = Color.Blue;
                victoria_status.ForeColor = Color.White;
            }
            if (jubilee_status.Text.Equals(goodservice))
            {
                jubilee_status.BackColor = Color.WhiteSmoke;
                jubilee_status.ForeColor = Color.Black;
            }
            else
            {
                jubilee_status.BackColor = Color.Blue;
                jubilee_status.ForeColor = Color.White;
            }
            if (northern_status.Text.Equals(goodservice))
            {
                northern_status.BackColor = Color.White;
                northern_status.ForeColor = Color.Black;
            }
            else
            {
                northern_status.BackColor = Color.Blue;
                northern_status.ForeColor = Color.White;
            }
            if (bakerloo_status.Text.Equals(goodservice))
            {
                bakerloo_status.BackColor = Color.WhiteSmoke;
                bakerloo_status.ForeColor = Color.Black;
            }
            else
            {
                bakerloo_status.BackColor = Color.Blue;
                bakerloo_status.ForeColor = Color.White;
            }
            if (central_status.Text.Equals(goodservice))
            {
                central_status.BackColor = Color.White;
                central_status.ForeColor = Color.Black;
            }
            else
            {
                central_status.BackColor = Color.Blue;
                central_status.ForeColor = Color.White;
            }
            if (metropolitan_status.Text.Equals(goodservice))
            {
                metropolitan_status.BackColor = Color.WhiteSmoke;
                metropolitan_status.ForeColor = Color.Black;
            }
            else
            {
                metropolitan_status.BackColor = Color.Blue;
                metropolitan_status.ForeColor = Color.White;
            }
            if (waterloo_status.Text.Equals(goodservice))
            {
                waterloo_status.BackColor = Color.White;
                waterloo_status.ForeColor = Color.Black;
            }
            else
            {
                waterloo_status.BackColor = Color.Blue;
                waterloo_status.ForeColor = Color.White;
            }
        }
        private void weekend_Click(object sender, EventArgs e)
        {
            weekend.Checked = !weekend.Checked;
            update();
        }

        protected Hashtable pruneStatuses(Hashtable statuses)
        {
            Hashtable result = new Hashtable();
            foreach (String key in statuses.Keys)
            {
                String status = (String)statuses[key];
                int k = status.IndexOf(",");
                if (k>0) status = status.Substring(0, k);
                result[key] = status;
            }
            return result;
        }
        private static Hashtable newStatuses()
        {
            Hashtable statuses = new Hashtable();
            statuses["piccadilly"]="";
            statuses["district"] = "";
            statuses["hammersmithandcity"] = "";
            statuses["victoria"] = "";
            statuses["jubilee"] = "";
            statuses["northern"] = "";
            statuses["bakerloo"] = "";
            statuses["central"] = "";
            statuses["metropolitan"] = "";
            statuses["waterlooandcity"] = "";
            statuses["dlr"] = "";
            statuses["overground"] = "";
            return statuses;

        }
    }



    public class ProcessInfo
    {
	public IntPtr hProcess;
	public IntPtr hThread;
	public IntPtr ProcessID;
	public IntPtr ThreadID;
    }

 }

