using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace TubeRun
{
    public partial class FormDeparturesN : Form
    {
        private bool killed = true;
        private int startPositionY = 0;
        private int startPositionX = 0;
        private int Move_ThresholdY = Screen.PrimaryScreen.Bounds.Height / 5;
        private int Move_ThresholdX = Screen.PrimaryScreen.Bounds.Width/3;
        private int Touch_ThresholdY = Screen.PrimaryScreen.Bounds.Width / 4;
        private int Touch_ThresholdX = Screen.PrimaryScreen.Bounds.Height/6;

        //used to store the train times as we count down!
        private int time1=-1;
        private int time2=-1;
        private int time3=-1;
        private int time_tot=0;

        public delegate void delegateShow();
        public delegateShow callShow;
        Thread fetchThread=null;
        System.Windows.Forms.Timer clock = new System.Windows.Forms.Timer();
        Image pr_temp;
        Image n_temp;
        Fetcher fetcher;
        protected FormFavoritesN favform;
        protected FormMainN mainform;
        String depline, station, direction, station_nice;
        private LinkedList<String> alternative_lines;
        private Boolean hasup, hasdown;
        protected String upline, downline;
        ArrayList ar_train1=null, ar_train2 =null, ar_train3 = null, ar_platforms;
        int index = -1;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDeparturesN));
        public delegate void delegateSetTrains(ArrayList ar1, ArrayList ar2, ArrayList ar3, ArrayList ar_platforms, int index, bool isnew);
        public delegateSetTrains setTrains;
        private String adjustTime(String s)
        {
            if (s == "") return s;
            else if (s == "1 min") return "";
            else
            {
                String[] tok = s.Split(new char[] { ' ' });
                if (tok.Length != 2) return s;
                else
                {
                    int i = Convert.ToInt32(tok[0]);
                    return Convert.ToString(i - 1) + " min";
                }

            }
        }
        private Boolean mustRun(String s)
        {
            if (s==null || s=="") return true;
            String thres=Toolbox.getSetting("runthres");
            String[] tok_thres = thres.Split(new char[] { ' ' });
            String[] tok_s = s.Split(new char[] { ' ' });
            if (tok_thres.Length != 2 || tok_s.Length != 2) return false;
            else
            {
                int i = Convert.ToInt32(tok_thres[0]);
                int j = Convert.ToInt32(tok_s[0]);
                if (j <= i) return true;
                else return false;                
            }
        }        
        public void setTrainsImplementation(ArrayList ar1, ArrayList ar2, ArrayList ar3, ArrayList ar_platforms, int index, bool isnew)
        {
            fetchThread = null;
            this.ar_train1 = ar1;
            this.ar_train2 = ar2;
            this.ar_train3 = ar3;
            this.ar_platforms = ar_platforms;
            this.index = index;
            Hashtable train1 = null;
            Hashtable train2 = null;
            Hashtable train3 = null;
            try
            {
                platform_label.BackColor=System.Drawing.Color.White;
                if (index==-1) {
                    this.index=0;
                    index = 0;
                    platform_label.BackColor = System.Drawing.Color.Red;
                }
                if (index > -1)
                {
                    platform_label.Text = (String)ar_platforms[index];
                    direction = platform_label.Text;
                    train1 = (Hashtable)ar_train1[index];
                    train2 = (Hashtable)ar_train2[index];
                    train3 = (Hashtable)ar_train3[index];                    
                }
            }
            catch (Exception) {

            }
            if (index>=0 && index < ar1.Count - 1)
            {
                this.next.Enabled = true;
                this.next.Image = ((System.Drawing.Image)(resources.GetObject("next")));
                this.n_temp = this.next.Image;
            }
            else
            {
                this.next.Enabled = false;
                this.next.Image = ((System.Drawing.Image)(resources.GetObject("empty")));
                this.n_temp = this.next.Image;
            }
            if (index > 0)
            {
                this.back.Enabled = true;
                this.back.Image = ((System.Drawing.Image)(resources.GetObject("previous")));
                this.pr_temp = this.back.Image;
            }
            else
            {
                this.back.Enabled = false;
                this.back.Image = ((System.Drawing.Image)(resources.GetObject("empty")));
                this.pr_temp = this.back.Image;
            }
            if (train1 != null)
            {
                train1_label_dest.Text = (String)train1["dest"];                
                train1_label_where.Text = (String)train1["where"];
                String time = (String)train1["time"];
                if (Toolbox.getSetting("depfix") == "Yes")
                {
                    time =adjustTime(time);
                }
                train1_label_time.Text = time;
                train1_label_time.BackColor = System.Drawing.Color.White;
                if (mustRun(time))
                {
                    train1_label_run.Text = "RUN!";
                    train1_label_run.BackColor=System.Drawing.Color.Red;
                }
                else {
                    train1_label_run.Text = "";
                    train1_label_run.BackColor=System.Drawing.Color.White;
                }
                time1 = toMinutes(time);
                //restart the no signal timer, new data!
                timer_nosignal.Enabled = false;
                timer_nosignal.Enabled = true;
                if (isnew) time_tot = 0;
                else if (time_tot>0) estimateTime(time1 - time_tot, train1_label_time, train1_label_run, train1_label_where);

            }
            if (train2 != null)
            {
                train2_label_dest.Text = (String)train2["dest"];
                train2_label_where.Text = (String)train2["where"];
                String time = (String)train2["time"];
                if (Toolbox.getSetting("depfix") == "Yes")
                {
                    time = adjustTime(time);
                }
                train2_label_time.Text = time;
                train2_label_time.BackColor = System.Drawing.Color.White;
                if (mustRun(time))
                {
                    train2_label_run.Text = "RUN!";
                    train2_label_run.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    train2_label_run.Text = "";
                    train2_label_run.BackColor = System.Drawing.Color.White;
                }
                time2 = toMinutes(time);
                if (!isnew && time_tot > 0) estimateTime(time2 - time_tot, train2_label_time, train2_label_run, train2_label_where);
            }
            if (train3 != null)
            {
                train3_label_dest.Text = (String)train3["dest"];
                train3_label_where.Text = (String)train3["where"];
                String time = (String)train3["time"];
                if (Toolbox.getSetting("depfix") == "Yes")
                {
                    time = adjustTime(time);
                }
                train3_label_time.Text = time;
                train3_label_time.BackColor = System.Drawing.Color.White;
                if (mustRun(time))
                {
                    train3_label_run.Text = "RUN!";
                    train3_label_run.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    train3_label_run.Text = "";
                    train3_label_run.BackColor = System.Drawing.Color.White;
                }
                time3 = toMinutes(time);
                if (!isnew && time_tot>0) estimateTime(time3-time_tot,train3_label_time,train3_label_run,train3_label_where);
            }
            menuItem1.Enabled = true;
            this.menuItem1.Text = "Reload";
            if (Toolbox.getSetting("depaction") == "Refresh" || Toolbox.getSetting("depaction") == "Close")
            {
                String time=Toolbox.getSetting("depobsthres");
                String[] secs = time.Split(new char[]{' '});
                int sec = Convert.ToInt32(secs[0]);
                //Normal Refresh
                clock.Enabled = false;
                clock.Dispose();
                clock= new System.Windows.Forms.Timer();
                clock.Interval = sec*1000;
                clock.Tick += new EventHandler(Timer_Tick);
                clock.Enabled = true;
                //No signal
                timer_update.Enabled = false;
                timer_update.Dispose();
                timer_update = new System.Windows.Forms.Timer();
                timer_update.Interval = 60*1000;
                //timer_update.Tick += new EventHandler(Timer_Tick);
                timer_update.Enabled = true;
            }
        }
        int toMinutes(String time)
        {
            int res;
            if (time == null || time.Length == 0) res = 0;
            else
            {
                int space = time.IndexOf(" ");
                if (space > 0)
                {
                    try
                    {
                        res = Convert.ToInt32(time.Substring(0, space));
                    }
                    catch (Exception) { res = 0; }
                }
                else res = 0;
            }
            return res;
        }
        public void Timer_Tick(object sender, EventArgs eArgs)
        {
            if (sender == clock)
            {
                if (Toolbox.getSetting("depaction") == "Refresh")
                {
                    clock.Enabled = false;
                    menuItem1_Click(null, null);
                }
                else if (Toolbox.getSetting("depaction") == "Close")
                {
                    clock.Enabled = false;
                    menuItem2_Click(null, null);

                }
            }
        }
        public FormDeparturesN()
        {
            InitializeComponent();
        }
        public FormDeparturesN(FormFavoritesN fav, String line, String station,String station_nice, String direction)
        {
            callShow = new delegateShow(this.ShowImplementation);
            favform = fav;
            mainform = null;
            this.depline = line;
            this.direction = direction;
            this.station = station;
            this.station_nice = station_nice;
            fetcher = new Fetcher(this, line, station, direction);
            setTrains = new delegateSetTrains(this.setTrainsImplementation);
            InitializeComponent();
            try
            {
                Toolbox.Colorize(this.station_label, line, false);
                this.station_label.Text = station_nice.Replace("&", "n");
                this.platform_label.Text = direction;

                //Setup event handlers
                panel1.MouseDown += new MouseEventHandler(Form1_MouseDown);
                panel2.MouseDown += new MouseEventHandler(Form1_MouseDown);
                panel3.MouseDown += new MouseEventHandler(Form1_MouseDown);
                pictureBox1.MouseDown += new MouseEventHandler(Form1_MouseDown);
                pictureBox2.MouseDown += new MouseEventHandler(Form1_MouseDown);
                pictureBox3.MouseDown += new MouseEventHandler(Form1_MouseDown);
                panel1.MouseUp += new MouseEventHandler(Form1_MouseUp);
                panel2.MouseUp += new MouseEventHandler(Form1_MouseUp);
                panel3.MouseUp += new MouseEventHandler(Form1_MouseUp);
                pictureBox1.MouseUp += new MouseEventHandler(Form1_MouseUp);
                pictureBox2.MouseUp += new MouseEventHandler(Form1_MouseUp);
                pictureBox3.MouseUp += new MouseEventHandler(Form1_MouseUp);

                menuItem1_Click(null, null);

                alternative_lines = Toolbox.FetchLinesForStation(station_nice);
                LinkedListNode<String> node = alternative_lines.Find(line);
                if (node!=null && node.Next != null)
                {
                    hasdown = true;
                    downline = node.Next.Value;
                }
                else
                {
                    hasdown = false;
                    downline = "";
                }
                if (node!=null && node.Previous != null)
                {
                    hasup = true;
                    upline = node.Previous.Value;
                }
                else
                {
                    hasup = false;
                    upline = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public FormDeparturesN(FormMainN main, String line, String station, String station_nice, String direction,String dummy)
        :this(null, line, station,station_nice,direction)
        {
            this.mainform = main;
        }
        public virtual void ShowImplementation()
        {
            this.Show();
        }
        private void menuItem1_Click(object sender, EventArgs e)
        {
            menuItem1.Enabled = false;
            this.menuItem1.Text = "Wait...";
            if (fetchThread != null)
            {
                fetchThread.Abort();
                fetchThread = null;
            }
            Hashtable stations = Toolbox.FetchStations(depline);
            station = (String)stations[station_nice];
            fetcher = new Fetcher(this, depline, station, direction);
            if (depline.Equals("dlr"))
            {
                fetchThread = new Thread(new ThreadStart(fetcher.getTrainsDLR));
            }
            else
            {
                fetchThread = new Thread(new ThreadStart(fetcher.getTrains));
            }
            fetchThread.Start();
        }
        private void menuItem2_Click(object sender, EventArgs e)
        {
            if (clock != null) clock.Dispose();
            if (timer_nosignal != null) timer_nosignal.Dispose();
            if (favform != null) favform.Show();
            else if (mainform != null) mainform.Show();
            killed = false;
            this.Close();            
        }
        private void highlight(object sender, MouseEventArgs e)
        {
            if (sender == next)
            {
                n_temp = next.Image;
                this.next.Image = ((System.Drawing.Image)(resources.GetObject("next_sel")));
            }
            else
            {
                pr_temp = back.Image;
                this.back.Image = ((System.Drawing.Image)(resources.GetObject("previous_sel")));
            }
        }
        private void unhighlight(object sender, MouseEventArgs e)
        {
            if (sender == next)
            {
                next.Image = n_temp;
            }
            else
            {
                back.Image = pr_temp;
            }
        }
        private void next_Click(object sender, EventArgs e)
        {
            if (index < ar_train1.Count)
            {
                try
                {
                    setTrainsImplementation(ar_train1, ar_train2, ar_train3, ar_platforms, ++index,false);
                }
                catch(Exception)
                {

                }
            }
        }
        private void back_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                try
                {
                    setTrainsImplementation(ar_train1, ar_train2, ar_train3, ar_platforms, --index,false);
                }
                catch (Exception)
                {

                }
            }
        }
        protected virtual void changeLine(bool go_up)
        {
            bool activated = false;
            if (go_up)
            {
                if (hasup)
                {
                    activated = true;
                    LinkedListNode<String> node = alternative_lines.Find(depline);
                    this.depline = node.Previous.Value;
                }
            }
            else
            {
                if (hasdown)
                {
                    activated = true;
                    LinkedListNode<String> node = alternative_lines.Find(depline);
                    this.depline = node.Next.Value;
                }
            }
            if (activated)
            {
                int i = this.direction.IndexOf('-');
                if (i > 2) this.direction = this.direction.Substring(0, i - 1);
                train1_label_dest.Text = "";
                train2_label_dest.Text = "";
                train3_label_dest.Text = "";
                train1_label_run.Text = "";
                train2_label_run.Text = "";
                train3_label_run.Text = "";
                train1_label_run.BackColor = System.Drawing.Color.White;
                train2_label_run.BackColor = System.Drawing.Color.White;
                train3_label_run.BackColor = System.Drawing.Color.White;
                train1_label_time.BackColor = System.Drawing.Color.White;
                train2_label_time.BackColor = System.Drawing.Color.White;
                train3_label_time.BackColor = System.Drawing.Color.White;
                train1_label_time.Text = "";
                train2_label_time.Text = "";
                train3_label_time.Text = "";
                train1_label_where.Text = "";
                train2_label_where.Text = "";
                train3_label_where.Text = "";
                this.next.Enabled = false;
                this.next.Image = ((System.Drawing.Image)(resources.GetObject("empty")));
                this.back.Enabled = false;
                this.back.Image = ((System.Drawing.Image)(resources.GetObject("empty")));
                Toolbox.Colorize(this.station_label, depline, false);
                this.station_label.Text = station_nice;
                this.platform_label.BackColor = System.Drawing.Color.White;
                LinkedListNode<String> node = alternative_lines.Find(depline);
                if (node.Next != null)
                {
                    hasdown = true;
                    downline = node.Next.Value;
                }
                else
                {
                    hasdown = false;
                    downline = "";
                }
                if (node.Previous != null)
                {
                    hasup = true;
                    upline = node.Previous.Value;
                }
                else
                {
                    hasup = false;
                    upline = "";
                }
                timer_nosignal.Enabled = false;
                menuItem1_Click(null, null);
            }
        }
        private void FormDeparturesN_Closing(object sender, CancelEventArgs e)
        {
            if (fetchThread != null) fetchThread.Abort();
            if (clock!=null) clock.Enabled = false;
            
        }
        private void FormDeparturesN_Activated(object sender, EventArgs e)
        {
            if (clock != null) clock.Enabled = true;
            killed = true;
        }
        private void FormDeparturesN_Deactivate(object sender, EventArgs e)
        {
            FormDeparturesN_Closing(null, null);
            menuItem1.Enabled = true;
            menuItem1.Text = "Reload";
        }
        protected void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Point mousePoint = this.PointToClient(((System.Windows.Forms.Control)sender).PointToScreen(new Point(e.X,e.Y)));
            startPositionY = mousePoint.Y;
            startPositionX = mousePoint.X;
        }
        protected void Form1_MouseUp( object  sender,  MouseEventArgs  e)
        {
            Point mousePoint = this.PointToClient(((System.Windows.Forms.Control)sender).PointToScreen(new Point(e.X, e.Y)));
            
            //Left-right Gestures
            if (startPositionX < mousePoint.X && mousePoint.X - startPositionX > Move_ThresholdX
                && Math.Abs(mousePoint.Y - startPositionY) < Touch_ThresholdY)
            {                
                if (back.Enabled == true) back_Click(null, null);
            }
            else if (startPositionX > mousePoint.X && startPositionX - mousePoint.X > Move_ThresholdX
                && Math.Abs(mousePoint.Y - startPositionY) < Touch_ThresholdY)
            {
                if (next.Enabled == true) next_Click(null, null);
            }

            //Up-Down gestures
            else if (startPositionY < mousePoint.Y && mousePoint.Y - startPositionY > Move_ThresholdY
                && Math.Abs(mousePoint.X - startPositionX) < Touch_ThresholdX)
            {
                //finger up-to-down gesture
                changeLine(true);
            }
            else if (startPositionY > mousePoint.Y && startPositionY - mousePoint.Y > Move_ThresholdY
                && Math.Abs(mousePoint.X - startPositionX) < Touch_ThresholdX)
            {
                //finger down-to-up gesture
                changeLine(false);
            }

        }
        private void FormDeparturesN_Closed(object sender, EventArgs e)
        {
            if (clock != null) clock.Enabled = false;
            if (killed)
            {
              if (favform!=null)  favform.exit();
              else if (mainform != null) mainform.exit(null,null);
            }
        }
        private void FormDeparturesN_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                changeLine(true);
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                changeLine(false);
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                if (back.Enabled == true) back_Click(null, null);
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                if (next.Enabled == true) next_Click(null, null);
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }
        private void timer_nosignal_Tick(object sender, EventArgs e)
        {
            time_tot++;
            estimateTime(time1-time_tot,train1_label_time,train1_label_run,train1_label_where);
            estimateTime(time2-time_tot, train2_label_time, train2_label_run, train2_label_where);
            estimateTime(time3-time_tot, train3_label_time, train3_label_run, train3_label_where);
            if (time1 < time_tot && time2 < time_tot && time3 < time_tot) timer_nosignal.Enabled = false;
        }
        private void estimateTime(int timeint,Label time, Label run, Label where)
        {
            if (timeint > -1)
            {
                if (timeint == 0) time.Text = "";
                else time.Text = timeint + " min";
                if (mustRun(timeint + " min"))
                {
                    run.Text = "RUN!";
                    run.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    run.Text = "";
                    run.BackColor = System.Drawing.Color.White;
                }
            }
            else
            {
                time.Text = "Lost";
                run.Text = "";
                run.BackColor = System.Drawing.Color.White;
            }
            time.BackColor = System.Drawing.Color.Yellow;
            where.Text= "Note: Time is estimated. No data connection...";
        }

    }
}