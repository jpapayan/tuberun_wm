using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Windows.Forms;
using System.Threading;



namespace TubeRun
{
    public class Fetcher
    {
        String nowurl="http://www.tfl.gov.uk/tfl/livetravelnews/realtime/tube/default.html";
        String weekendurl = "http://www.tfl.gov.uk/tfl/livetravelnews/realtime/track.aspx?offset=weekend";
        String statusurl;
        private int tickid;
        private String line, station,  station_nice, direction;
        private FormMainN mainform;
        private FormDeparturesN departuresform;
        public Fetcher(FormMainN form,String line,String station, String station_nice,String direction)
        {
            this.mainform = form;
            this.line = line;
            this.station = station;
            this.station_nice = station_nice;
            this.direction = direction;
            setNowUrl();
        }
        public Fetcher(FormMainN form)
        {
            this.mainform = form;
            setNowUrl();
        }
        public Fetcher(FormDeparturesN form, String line, String station, String direction)
        {
            this.departuresform=form;
            this.line = line;
            this.station = station;
            this.direction = direction;
            setNowUrl();
        }
        public void updateLineStatus()
        {
            HttpWebRequest request = null;
            try
            {
                StringBuilder sb = new StringBuilder();
                // used on each read operation
                byte[] buf = new byte[8 * 8192];
                // prepare the web page we will be asking for
                request = (HttpWebRequest)WebRequest.Create(statusurl);
                // execute the request
                HttpWebResponse response = (HttpWebResponse)
                    request.GetResponse();
                // we will read data via the response stream
                Stream resStream = response.GetResponseStream();
                string tempString = null;
                int count = 0;
                do
                {
                    // fill the buffer with data
                    count = resStream.Read(buf, 0, buf.Length);
                    // make sure we read some data
                    if (count != 0)
                    {
                        // translate from bytes to ASCII text
                        tempString = Encoding.ASCII.GetString(buf, 0, count);
                        // continue building the string
                        sb.Append(tempString);
                    }
                }
                while (count > 0); // any more data to read?
                resStream.Close();
                response.Close();
                String reply = sb.ToString();
                Hashtable result = new Hashtable();
                Hashtable problems = new Hashtable();
                String[] lines = new String[] { "bakerloo", "central", "circle", "district", "hammersmithandcity", "jubilee", "metropolitan", "northern", "piccadilly", "victoria", "waterlooandcity","dlr", "overground" };
                for (int i = 0; i < lines.Length; i++)
                {
                    String filter1 = "<h3 class=\"" + lines[i] + " ltn-name\">";
                    int j = reply.IndexOf(filter1) + filter1.Length;
                    if (j > filter1.Length /*sth found*/)
                    {
                        String rest = reply.Substring(j);
                        String start = "<div class=\"status\">";
                        String start2 = "<div class=\"problem status\">";
                        String end = "</li>";
                        j = rest.IndexOf(start);
                        int k = rest.IndexOf(start2);
                        int e = rest.IndexOf(end);
                        String status;
                        if (j < e || k<e)
                        {
                            if (j<e) rest = rest.Substring(j+start.Length);
                            else rest = rest.Substring(k + start2.Length);
                            j = rest.IndexOf("</div>");
                            String statust = rest.Substring(0, j);
                            if (statust.Contains("<h4"))
                            {
                                String l="<h4 class=\"ltn-title\">";
                                j = statust.IndexOf(l) + l.Length;
                                status = statust.Substring(j);
                                j = status.IndexOf("</h4>");
                                //k = status.IndexOf(",");
                                /*if (k>0 && k<j) status = status.Substring(0, k);
                                else*/ status = status.Substring(0, j);
                            }
                            else status = statust;
                        }
                        else status = "Failed"; 
                        if (!status.Equals("Good service"))
                        {
                            j = rest.IndexOf("<div class=\"message\">") + 21;
                            rest = rest.Substring(j);
                            j = rest.IndexOf("<a");
                            k = rest.IndexOf("<A");
                            if (j ==-1 && k>0) j = k;

                            String problem = rest.Substring(0, j);
                            //must remove hmtl tags here.
                            problem = Regex.Replace(problem, "\n", "");
                            problem = Regex.Replace(problem, "&amp;", "and");
                            problems[lines[i]] = problem;
                        }
                        result[lines[i]] = status;
                    }
                }
                if (result.Count == 13)
                {
                    DateTime now = DateTime.Now;
                    CultureInfo ci = new CultureInfo("en-GB");
                    String dtnow = now.ToString("G", ci);
                    if (statusurl.Equals(nowurl))
                    {
                        //save the data to the file
                        // Specify file, instructions, and privelegdes
                        string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
                        FileStream file = new FileStream(appPath + "statuses.tr", FileMode.Create, FileAccess.Write);
                        // Create a new stream to write to the file
                        StreamWriter sw = new StreamWriter(file);
                        // Write a string to the file
                        ArrayList keySet = new ArrayList(result.Keys);
                        IEnumerator keySetIterator = keySet.GetEnumerator();
                        while (keySetIterator.MoveNext())
                        {
                            Object key = keySetIterator.Current;
                            Object value = result[key];
                            if (problems[key] != null) sw.WriteLine(key + "|" + value + "|" + problems[key]);
                            else sw.WriteLine(key + "|" + value + "|" + "blah");
                        }
                        Console.WriteLine("Fetched: " + dtnow);
                        dtnow = Regex.Replace(dtnow, "\n", "");
                        sw.WriteLine(dtnow);
                        // Close StreamWriter
                        sw.Close();
                        // Close file
                        file.Close();
                    }
                    result["timestamp"] = dtnow;
                }
                mainform.Invoke(mainform.setLineStatuses, new Object[2] { result, problems });
            }
            catch (ThreadAbortException e)
            {
                if (request != null) request.Abort();
                throw e;
            }
            catch (Exception)
            {
                try
                {
                    mainform.Invoke(mainform.setLineStatuses, new Object[2] { new Hashtable(), new Hashtable() });
                }
                catch (ThreadAbortException ex)
                {
                    throw ex;
                }
                catch (Exception) { }
            };
        }
        public void settickid(int tid)
        {
            this.tickid=tid;
        }
        public void tick()
        {
            Thread.Sleep(61000);
            try
            {
                mainform.Invoke(mainform.callRefreshStatusLabel,new Object[]{tickid});
            }
            catch (ThreadAbortException e)
            {
                throw e;
            }
            catch (Exception ) { }
        }
        public void showStation()
        {
            try
            {
                Thread.Sleep(500);
                mainform.Invoke(mainform.callAuto, new Object[4] {line, station, station_nice, direction});
            }
            catch (Exception) { }
        }
        public void getTrains()
        {
            String request_query="http://www.tfl.gov.uk/tfl/livetravelnews/departureboards/tube/default.asp?LineCode="+line+
                            "&StationCode="+station+"&switch=off";
            HttpWebRequest request=null;
            try
            {
                StringBuilder sb = new StringBuilder();
                // used on each read operation
                byte[] buf = new byte[8 * 8192];
                // prepare the web page we will be asking for
                request = (HttpWebRequest)WebRequest.Create(request_query);
                // execute the request
                request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.1.7) Gecko/20091221 MRA 5.5 (build 02842) Firefox/3.5.7 (.NET CLR 3.5.30729)";
                HttpWebResponse response = (HttpWebResponse)
                    request.GetResponse();
                // we will read data via the response stream
                Stream resStream = response.GetResponseStream();
                string tempString = null;
                int count = 0;
                do
                {
                    // fill the buffer with data
                    count = resStream.Read(buf, 0, buf.Length);
                    // make sure we read some data
                    if (count != 0)
                    {
                        // translate from bytes to ASCII text
                        tempString = Encoding.ASCII.GetString(buf, 0, count);
                        // continue building the string
                        sb.Append(tempString);
                    }
                }
                while (count > 0); // any more data to read?
                resStream.Close();
                response.Close();
                String reply = sb.ToString();
                int index = -1;
                ArrayList t1 = new ArrayList();
                ArrayList t2 = new ArrayList();
                ArrayList t3 = new ArrayList();
                ArrayList platforms = new ArrayList();
                for (int it=0;true;it++)
                {
                    int i = reply.IndexOf("Departure times for");
                    if (i != -1)
                    {
                        reply = reply.Substring(i);
                        i = reply.IndexOf("Departure times for");
                    }
                    int j = reply.IndexOf("<td class=\"destination\">");
                    if (i == -1 || j == -1 || j < i) break;
                    String dirpart = reply.Substring(i, j - i);

                    String start="<caption xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">";
                    String end = "</caption>";
                    int si = dirpart.IndexOf(start)+start.Length;
                    int ei = dirpart.IndexOf(end);
                    String plat=dirpart.Substring(si,ei-si);
                    platforms.Add(plat);

                    dirpart = dirpart.ToLower();
                    if (dirpart.Contains(direction.ToLower())) 
                    {
                        index=it;
                    }                    
                    Hashtable train1 = getInfo(reply);
                    j = reply.IndexOf("<td class=\"destination\">") + 24;
                    reply = reply.Substring(j);
                    Hashtable train2 = getInfo(reply);
                    j = reply.IndexOf("<td class=\"destination\">") + 24;
                    reply = reply.Substring(j);
                    Hashtable train3 = getInfo(reply);
                    //The direction exists, go on
                    t1.Add(train1);
                    t2.Add(train2);
                    t3.Add(train3);

                }
                departuresform.Invoke(departuresform.setTrains, new Object[6] { t1, t2, t3, platforms, index,true });
            }
            catch (ThreadAbortException e)
            {
                if (request != null) request.Abort();
                throw e;
            }
            catch (Exception)
            {
                ArrayList tmp = new ArrayList();
                try
                {
                    departuresform.Invoke(departuresform.setTrains, new Object[6] { tmp, tmp, tmp, tmp, -2 ,false});
                }
                catch (ThreadAbortException e)
                {
                    throw e;
                }
                catch (Exception) { }
            };

        }
        public void getTrainsDLR()
        {
            String request_query = "http://dlr-scripts.appius.com/lib/redirect_daisy.asp?daisy="
                + station + "&go=Go";
            HttpWebRequest request = null;
            try
            {
                Boolean gotpath = false;
                String stupid = "";
                String reply="";
                while (true) 
                {
                    StringBuilder sb = new StringBuilder();
                    // used on each read operation
                    byte[] buf = new byte[8 * 8192];
                    // prepare the web page we will be asking for
                    request = (HttpWebRequest)WebRequest.Create(request_query);
                    // execute the request
                    request.AllowAutoRedirect = true;
                    request.MaximumAutomaticRedirections = 10;
                    request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.1.7) Gecko/20091221 MRA 5.5 (build 02842) Firefox/3.5.7 (.NET CLR 3.5.30729)";
                    HttpWebResponse response = (HttpWebResponse)
                        request.GetResponse();
                    // we will read data via the response stream
                    Stream resStream = response.GetResponseStream();
                    string tempString = null;
                    int count = 0;
                    do
                    {
                        // fill the buffer with data
                        count = resStream.Read(buf, 0, buf.Length);
                        // make sure we read some data
                        if (count != 0)
                        {
                            // translate from bytes to ASCII text
                            tempString = Encoding.ASCII.GetString(buf, 0, count);
                            // continue building the string
                            sb.Append(tempString);
                        }
                    }
                    while (count > 0); // any more data to read?
                    resStream.Close();
                    response.Close();
                    reply = sb.ToString();
                    if (gotpath) break;
                    String lookfor = "window.location.replace(\"";
                    int i = reply.IndexOf(lookfor);
                    if (i != -1)
                    {
                        reply = reply.Substring(i+lookfor.Length);
                        i = reply.IndexOf("\"");
                        request_query = reply.Substring(0, i);
                        stupid = request_query;
                    }
                    else stupid = reply;
                    gotpath = true;
                }

                int index = -1;
                ArrayList t1 = new ArrayList();
                ArrayList t2 = new ArrayList();
                ArrayList t3 = new ArrayList();
                ArrayList platforms = new ArrayList();

                for (int it = 0; true; it++)
                {
                    String plat="<div id=\"platformleft\"><img src=\"p";
                    int pi = reply.IndexOf(plat) + plat.Length;
                    if (pi == plat.Length-1) break;
                    reply = reply.Substring(pi); //"eats" the plat string
                    if (reply[1]>='0' && reply[1]<='9') plat=reply.Substring(0,2);
                    else plat = reply.Substring(0, 1);
                    try
                    {
                        Convert.ToInt32(plat);
                    }
                    catch (Exception)
                    {
                        //platform num is not numerical, no more platforms!
                        break;
                    }
                    plat = "Platform " + plat;
                    String start = "<div id=\"line1\">";
                    String end = "</div>";
                    int si = reply.IndexOf(start);
                    if (si == - 1) continue;
                    si+=start.Length;
                    reply = reply.Substring(si);
                    int ei = reply.IndexOf(end);
                    if (ei==-1) continue;                    
                    String r = reply.Substring(0, ei);
                    r = Regex.Replace(r, "<p>", "");
                    r = Regex.Replace(r, "</p>", "");
                    r = Regex.Replace(r, "\n", " ");
                    r = Regex.Replace(r, "\t", " ");
                    r = Regex.Replace(r, "\r", " ");
                    String tr1 = Regex.Replace(r, "&nbsp;", " ");
                    Hashtable train1 = getDLRInfo(tr1);

                    start="<div id=\"line23\">";
                    si = reply.IndexOf(start) + start.Length;
                    reply = reply.Substring(si);
                    String middle="<br />";
                    int mi = reply.IndexOf(middle);
                    r = reply.Substring(0, mi);
                    r = Regex.Replace(r, "<p>", "");
                    r = Regex.Replace(r, "</p>", "");
                    r = Regex.Replace(r, "\n", "");
                    r = Regex.Replace(r, "\t", "");
                    r = Regex.Replace(r, "\r", "");
                    String tr2 = Regex.Replace(r, "&nbsp;", " ");
                    Hashtable train2 = getDLRInfo(tr2);

                    reply = reply.Substring(mi+middle.Length);
                    ei = reply.IndexOf(end);
                    r = reply.Substring(0, ei);
                    r = Regex.Replace(r, "<p>", "");
                    r = Regex.Replace(r, "</p>", "");
                    r = Regex.Replace(r, "\n", "");
                    r = Regex.Replace(r, "\t", "");
                    r = Regex.Replace(r, "\r", "");
                    String tr3 = Regex.Replace(r, "&nbsp;", " ");
                    Hashtable train3 = getDLRInfo(tr3);
                    
                    String dirpart = plat.ToLower();
                    if (dirpart.Contains(direction.ToLower()))
                    {
                        index = it;
                    }
                    t1.Add(train1);
                    t2.Add(train2);
                    t3.Add(train3);
                    platforms.Add(plat);                    
                }
                departuresform.Invoke(departuresform.setTrains, new Object[6] { t1, t2, t3, platforms, index, true });
            }
            catch (ThreadAbortException e)
            {
                if (request != null) request.Abort();
                throw e;
            }
            catch (Exception)
            {
                ArrayList tmp = new ArrayList();
                try
                {
                    departuresform.Invoke(departuresform.setTrains, new Object[6] { tmp, tmp, tmp, tmp, -2, false });
                }
                catch (ThreadAbortException e)
                {
                    throw e;
                }
                catch (Exception) { }
            };

        }
        public string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        private Hashtable getInfo(String reply)
        {
            Hashtable train1 = new Hashtable();
            int i, j;

            String q1 = "<td class=\"destination\">";
            i = reply.IndexOf(q1)+q1.Length;
            if (i == q1.Length-1) return null;

            reply=reply.Substring(i);
            j= reply.IndexOf("<");
            String r = reply.Substring(0, j);
            r = Regex.Replace(r,"\n","");
            r = Regex.Replace(r, "\t", "");
            r = Regex.Replace(r, "\r", "");
            r = Regex.Replace(r, "&amp;", "and");
            r = r.Substring(3);
            r = r.Trim();
            train1["dest"]=r;
            reply=reply.Substring(j);

            String q2="<td class=\"message\">";
            i=reply.IndexOf(q2)+q2.Length;
            reply=reply.Substring(i);
            j= reply.IndexOf("<");
            String s = reply.Substring(0, j);
            s = Regex.Replace(s, "&amp;", "and");
            train1["where"] = s;
            reply=reply.Substring(j);

            String q3="<td class=\"time\">";
            i=reply.IndexOf(q3)+q3.Length;
            reply=reply.Substring(i);
            j= reply.IndexOf("<");
            r = reply.Substring(0, j);
            r = Regex.Replace(r, "\n", "");
            r = Regex.Replace(r, "\t", "");
            r = Regex.Replace(r, "\r", "");
            r = r.Trim();
            train1["time"]=r;
            reply=reply.Substring(j);

            return train1;
        }
        private Hashtable getDLRInfo(String tr1)
        {
            Hashtable train1 = new Hashtable();
            String alphaS = "a|b|c|d|e|f|g|h|i|j|k|l|m|n|o|p|q|r|s|t|u|v|w|z|y|z";
            String alphaC = "A|B|C|D|E|F|G|H|I|J|K|L|M|N|O|P|Q|R|S|T|U|V|W|X|Y|Z";
            String dec = "(1|2|3|4|5|6|7|8|9|0)";
            string alpha = "(" + alphaC + "|" + alphaS + ")";
            Match m = Regex.Match(tr1, "[1-3]( )((([^0-9])+[0-9]+.*)| *)");
            String dest = "";
            String time = "";
            String where = "";
            if (m.Success && m.Index!=-1)
            {
                bool first_nums = false;
                bool seond_nums = false;
                foreach (char c in tr1)
                {
                    if (first_nums == false)
                    {
                        if (!dec.Contains("" + c)) continue;
                        else first_nums = true;
                    }
                    else if (seond_nums == false)
                    {
                        if (!dec.Contains("" + c)) dest = dest + c;
                        else
                        {
                            time = time + c;
                            seond_nums = true;
                        }
                    }
                    else
                    {
                        if (!dec.Contains("" + c)) break;
                        else time = time + c;
                    }
                }
                dest = dest.TrimStart(new char[] { ' ' });
                dest = dest.TrimEnd(new char[] { ' ' });
                if (time != "") time = time + " min";
                where = "No train location information available for DLR.";
                dest = dest.ToLower();
                String destn = "";
                bool white = true;
                foreach (char c in dest)
                {
                    if (white)
                    {
                        white = false;
                        destn += Convert.ToString(c).ToUpper();
                    }
                    else
                    {
                        if (c == ' ') white = true;
                        destn += c;
                    }
                }
                if (destn.Length > 3)
                {
                    train1["time"] = time;
                    train1["dest"] = destn;
                    train1["where"] = where;
                    return train1;
                }
                else return null;                
            }
            else
            {
                return null;
            }
            
        }
        public void setNowUrl()
        {
            statusurl=nowurl;
        }
        public void setWeekendUrl()
        {
            statusurl = weekendurl;
        }
    }
}
