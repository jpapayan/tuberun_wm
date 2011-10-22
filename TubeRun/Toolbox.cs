using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;

namespace TubeRun
{
    class Toolbox
    {
        [System.Runtime.InteropServices.DllImport("coredll")]
        private static extern IntPtr GetCapture();
        [System.Runtime.InteropServices.DllImport("coredll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [System.Runtime.InteropServices.DllImport("coredll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int
        dwNewLong);
        private const int GWL_STYLE = -16;
        private const int BS_CENTER = 0x00000300;
        private const int BS_VCENTER = 0x00000C00;
        private const int BS_MULTILINE = 0x00002000;
        static private Hashtable settings=null;
        static public void SetButtonStyle(Button ctrl)
        {
            IntPtr hWnd;
            int style;

            ctrl.Capture = true;
            hWnd = GetCapture();
            ctrl.Capture = false;

            style = GetWindowLong(hWnd, GWL_STYLE);
            SetWindowLong(hWnd, GWL_STYLE, (style | BS_CENTER | BS_VCENTER |
          BS_MULTILINE));

            ctrl.Refresh();

        }        
        static public void Colorize(Control c, String line, Boolean charlimit)
        {
            if (line.Equals("piccadilly"))
            {
                c.Text = "Piccadilly";
                c.ForeColor = System.Drawing.Color.White; ;
                c.BackColor = System.Drawing.Color.Blue; ;
            }
            else if (line.Equals("bakerloo"))
            {
                c.Text = "Bakerloo";
                c.ForeColor = System.Drawing.Color.White; ;
                c.BackColor = System.Drawing.Color.DarkGoldenrod;
            }
            else if (line.Equals("central"))
            {
                c.Text = "Central";
                c.ForeColor = System.Drawing.Color.White; ;
                c.BackColor = System.Drawing.Color.Red;
            }
            else if (line.Equals("circle"))
            {
                c.Text = "Circle";
                c.ForeColor = System.Drawing.Color.Black; ;
                c.BackColor = System.Drawing.Color.Yellow; ;
            }
            else if (line.Equals("district"))
            {
                c.Text = "District";
                c.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                c.ForeColor = System.Drawing.Color.White;
            }
            else if (line.Equals("hammersmith"))
            {
                if (!charlimit) c.Text = "Hammersmith and City";
                else c.Text = "Hammersmith";
                c.ForeColor = System.Drawing.Color.DarkBlue;
                c.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            }
            else if (line.Equals("jubilee"))
            {
                c.Text = "Jubilee";
                c.ForeColor = System.Drawing.Color.White;
                c.BackColor = System.Drawing.Color.DarkGray;
            }
            else if (line.Equals("northern"))
            {
                c.Text = "Northern";
                c.ForeColor = System.Drawing.Color.White;
                c.BackColor = System.Drawing.Color.Black; ;
            }
            else if (line.Equals("victoria"))
            {
                c.Text = "Victoria";
                c.ForeColor = System.Drawing.Color.White; ;
                c.BackColor = System.Drawing.Color.DeepSkyBlue; ;
            }
            else if (line.Equals("waterlooandcity"))
            {
                if (!charlimit) c.Text = "Waterloo and City";
                else c.Text = "Waterloo";
                c.ForeColor = System.Drawing.Color.White;
                c.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(200)))));
            }
            else if (line.Equals("metropolitan"))
            {
                c.Text = "Metropolitan";
                c.ForeColor = System.Drawing.Color.White;
                c.BackColor = System.Drawing.Color.MediumVioletRed;
            }
            else if (line.Equals("dlr"))
            {
                c.Text = "DLR";
                c.ForeColor = System.Drawing.Color.White;
                c.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));

            }
            else if (line.Equals("overground"))
            {
                c.Text = "Overground";
                c.ForeColor = System.Drawing.Color.White;
                c.BackColor = System.Drawing.Color.Orange;

            }
            else
            {
                c.Text = "";
                c.ForeColor = System.Drawing.Color.Black;
                c.BackColor = System.Drawing.Color.White;
            }
        }
        static public Hashtable FetchStations(String line) 
        {
            Hashtable res = new Hashtable();
            switch (line) 
            {
                case "dlr":
                    res["All Saints"]= "als";
                    res["Bank"]= "ban";
                    res["Beckton"]= "bec";
                    res["Beckton Park"]= "bep";
                    res["Blackwall"]= "bla";
                    res["Bow Church"]= "boc";
                    res["Canary Wharf"]= "caw";
                    res["Canning Town"]= "cat";
                    res["Crossharbour"]= "cro";
                    res["Custom House"]= "cuh";
                    res["Cutty Sark"]= "cus";
                    res["Cyprus"]= "cyp";
                    res["Deptford Bridge"]= "deb";
                    res["Devons Road"]= "der";
                    res["East India"]= "eai";
                    res["Elverson Road"]= "elr";
                    res["Gallions Reach"]= "gar";
                    res["Greenwich"]= "gre";
                    res["Heron Quays"]= "heq";
                    res["Island Gardens"]= "isg";
                    res["King George V"]= "kgv";
                    res["Langdon Park"]= "lap";
                    res["Lewisham"]= "lew";
                    res["Limehouse"]= "lim";
                    res["London City Airport"]= "lca";
                    res["Mudchute"]= "mud";
                    res["Poplar"]= "pop";
                    res["Pontoon Dock"]= "pdk";
                    res["Prince Regent"]= "prr";
                    res["Pudding Mill Lane"]= "pml";
                    res["Royal Albert"] = "roa";
                    res["Royal Victoria"] = "rov";
                    res["Shadwell"] = "sha";
                    res["South Quay"] = "soq";
                    res["Stratford"] = "str";
                    res["Tower Gateway"] = "tog";
                    res["Westferry"] = "wes";
                    res["West India Quay"] = "wiq";
                    res["West Silvertown"] = "wst";
                    res["Woolwich Arsenal"] = "woa";
                    break;
                 case "piccadilly":
                    res["Acton Town"]="ACT";
                    res["Alperton"]="ALP";
                    res["Gloucester Road"]="GRD";
                    res["Finsbury Park"]="FPK";
                    res["Eastcote"]="ETE";
                    res["Earls Court"]="ECT";
                    res["Ealing Common"]="ECM";
                    res["Covent Garden"]="COV";
                    res["Cockfosters"]="CFS";
                    res["Caledonian Road"]="CRD";
                    res["Bounds Green"]="BGR";
                    res["Boston Manor"]="BOS";
                    res["Barons Court"]="BCT";
                    res["Arsenal"]="ARL";
                    res["Arnos Grove"]="AGR";  
		            res["Green Park"]="GPK";
		            res["Hammersmith"]="HMD";
		            res["Hatton Cross"]="HTX";
		            res["Heathrow T4"]="HRF";
		            res["Heathrow T5"]="HRV";
		            res["Heathrow T123"]="HRC";
		            res["Hillingdon"]="HDN";
		            res["Holborn"]="HOL";
		            res["Holloway Road"]="HRD";
		            res["Hounslow Central"]="HNC";
		            res["Hounslow East"]="HNE";
		            res["Hounslow West"]="HNW";
		            res["Hyde Park Corner"]="HPC";            
		            res["Ickenham"]="ICK";
                    res["King's Cross St. Pancras"] = "KXX";
		            res["Knightsbridge"]="KNB";
		            res["Leicester Square"]="LSQ";
		            res["Manor House"]="MNR";
		            res["North Ealing"]="NEL";
		            res["Northfields"]="NFD";
		            res["Oakwood"]="OAK";
		            res["Osterley"]="OST";
		            res["Park Royal"]="PRY";
		            res["Piccadilly Circus"]="PIC";
		            res["Rayners Lane"]="RLN";
		            res["Ruislip"]="RUI";
		            res["Ruislip Manor"]="RUM";
		            res["Russell Square"]="RSQ";
		            res["South Ealing"]="SEL";
		            res["South Harrow"]="SHR";
		            res["South Kensington"]="SKN";
		            res["Southgate"]="SGT";
		            res["Sudbury Hill"]="SHL";
		            res["Sudbury Town"]="STN";
		            res["Turnham Green"]="TGR";
		            res["Turnpike Lane"]="TPL";
		            res["Uxbridge"]="UXB";
		            res["Wood Green"]="WGN";
                    break;

                case "bakerloo":
		            res["Baker Street"]="BST";
		            res["Charing Cross"]="CHX";
		            res["Edgware Road (Bakerloo)"]="ERB";
		            res["Elephant & Castle"]="ELE";
		            res["Embankment"]="EMB";
	    	        res["Harlesden"]="HSD";
	            	res["Harrow & Wealdstone"]="HAW";
            		res["Kensal Green"]="KGN";
            		res["Kenton"]="KNT";
            		res["Kilburn Park"]="KPK";
            		res["Lambeth North"]="LAM";
            		res["Maida Vale"]="MDV";
            		res["Marylebone"]="MYB";
            		res["North Wembley"]="NWM";
            		res["Oxford Circus"]="OXC";
            		res["Paddington"]="PAD";
		            res["Piccadilly Circus"]="PIC";
	            	res["Queen's Park"]="QPK";
	            	res["Regent's Park"]="RPK";
	            	res["South Kenton"]="SKT";
	            	res["Stonebridge Park"]="SPK";
	            	res["Warwick Avenue"]="WAR";
	            	res["Waterloo"]="WLO";
	            	res["Wembley Central"]="WEM";
	            	res["Willesden Junction"]="WJN";
                    break;
                case "central":
	            	res["Bank"]="BNK";
	            	res["Barkingside"]="BDE";
	            	res["Bethnal Green"]="BNG";
	            	res["Bond Street"]="BDS";
	            	res["Buckhurst Hill"]="BHL";
	            	res["Chancery Lane"]="CYL";
            		res["Chigwell"]="CHG";
            		res["Debden"]="DEB";
            		res["Ealing Broadway"]="EBY";
            		res["East Acton"]="EAC";
            		res["Epping"]="EPP";
	            	res["Fairlop"]="FLP";
	            	res["Gants Hill"]="GHL";
	            	res["Grange Hill"]="GRH";
	            	res["Greenford"]="GFD";
            		res["Hainault"]="HAI";
            		res["Hanger Lane"]="HLN";
            		res["Holborn"]="HOL";
            		res["Holland Park"]="HPK";
	            	res["Lancaster Gate"]="LAN";
	            	res["Leyton"]="LEY";
	            	res["Leytonstone"]="LYS";
	            	res["Liverpool Street"]="LST";
	            	res["Loughton"]="LTN";
	            	res["Marble Arch"]="MAR";
	            	res["Mile End"]="MLE";
	            	res["Newbury Park"]="NEP";
            		res["North Acton"]="NAC";
            		res["Northolt"]="NHT";
            		res["Notting Hill Gate"]="NHG";
            		res["Oxford Circus"]="OXC";
            		res["Perivale"]="PER";
            		res["Queensway"]="QWY";
	            	res["Redbridge"]="RED";
	            	res["Roding Valley"]="ROD";
	            	res["Ruislip Gardens"]="RUG";
	            	res["Shepherds Bush (Central Line)"]="SBC";
	            	res["Snaresbrook"]="SNB";
	            	res["South Ruislip"]="SRP";
	            	res["South Woodford"]="SWF";
	            	res["St. Paul's"]="STP";
	            	res["Stratford"]="SFD";
	            	res["Theydon Bois"]="THB";
            		res["Tottenham Court Road"]="TCR";
            		res["Wanstead"]="WAN";
	            	res["West Acton"]="WAC";
	            	res["West Ruislip"]="WRP";
	            	res["White City"]="WCT";
	            	res["Woodford"]="WFD";
                    break;
                case "circle":
                    res["Aldgate"]="ALD";
                    //res["Aldgate East"]="ALE";
                    res["Baker Street"]="BST";
                    res["Barbican"]="BAR";
                    //res["Barking"]="BKG";
                    res["Bayswater"]="BAY";
                    res["Blackfriars"]="BLF";
                    //res["Bow Road"]="BWR";
                    //res["Bromley-by-Bow"]="BBB";
                    res["Cannon Street"]="CST";
                    //res["East Ham"]="EHM";
                    res["Edgware Road (H & C)"]="ERD";
                    res["Embankment"]="EMB";
                    res["Euston Square"]="ESQ";
                    res["Farringdon"]="FAR";
                    res["Gloucester Road"]="GRD";
                    res["Great Portland Street"]="GPS";
                    res["Hammersmith (Circle and H&C)"]="HMS";
                    res["High Street Kensington"]="HST";
                    res["King's Cross St. Pancras"]="KXX";
                    //res["Ladbroke Grove"]="LBG";
                    res["Liverpool Street"]="LST";
                    res["Mansion House"]="MAN";
                    //res["Mile End"]="MLE";
                    res["Monument"]="MON";
                    res["Moorgate"]="MGT";
                    res["Notting Hill Gate"]="NHG";
                    res["Paddington Circle"]="PADc";
                    res["Paddington H & C"]="PADs";
                    //res["Plaistow"]="PLW";
                    //res["Royal Oak"]="ROA";
                    res["Sloane Square"]="SSQ";
                    res["South Kensington"]="SKN";
                    res["St. James's Park"]="SJP";
                    //res["Stepney Green"]="STG";
                    res["Temple"]="TEM";
                    res["Tower Hill"]="THL";
                    //res["Upton Park"]="UPK";
                    res["Victoria"]="VIC";
                    //res["West Ham"]="WHM";
                    //res["Westbourne Park"]="WBP";
                    res["Westminster"]="WMS";
                    res["Whitechapel"]="WCL";
                    break;
                case "district":                    
                    res["Acton Town"]="ACT";
                    res["Aldgate East"]="ALE";
                    res["Barking"]="BKG";
                    res["Barons Court"]="BCT";
                    res["Becontree"]="BEC";
                    res["Blackfriars"]="BLF";
                    res["Bow Road"]="BWR";
                    res["Bromley-by-Bow"]="BBB";
                    res["Cannon Street"]="CST";
                    res["Chiswick Park"]="CHP";
                    res["Dagenham East"]="DGE";
                    res["Dagenham Heathway"]="DGH";
                    res["Ealing Broadway"]="EBY";
                    res["Ealing Common"]="ECM";
                    res["Earls Court"]="ECT";
                    res["East Ham"]="EHM";
                    res["East Putney"]="EPY";
                    res["Edgware Road (H & C)"]="ERD";
                    res["Elm Park"]="EPK";
                    res["Embankment"]="EMB";
                    res["Fulham Broadway"]="FBY";
                    res["Gloucester Road"]="GRD";
                    res["Gunnersbury"]="GUN";
                    res["Hammersmith (District and Picc)"]="HMD";
                    res["High Street Kensington"]="HST";
                    res["Hornchurch"]="HCH";
                    res["Kew Gardens"]="KEW";
                    res["Mansion House"]="MAN";
                    res["Mile End"]="MLE";
                    res["Monument"]="MON";
                    res["Olympia"]="OLY";
                    res["Parsons Green"]="PGR";
                    res["Plaistow"]="PLW";
                    res["Putney Bridge"]="PUT";
                    res["Ravenscourt Park"]="RCP";
                    res["Richmond"]="RMD";
                    res["Sloane Square"]="SSQ";
                    res["Southfields"]="SFS";
                    res["South Kensington"]="SKN";
                    res["St. James's Park"]="SJP";
                    res["Stamford Brook"]="STB";
                    res["Stepney Green"]="STG";
                    res["Temple"]="TEM";
                    res["Tower Hill"]="THL";
                    res["Turnham Green"]="TGR";
                    res["Upminster"]="UPM";
                    res["Upminster Bridge"]="UPB";
                    res["Upney"]="UPY";
                    res["Upton Park"]="UPK";
                    res["Victoria"]="VIC";
                    res["West Brompton"]="WBT";
                    res["West Ham"]="WHM";
                    res["West Kensington"]="WKN";
                    res["Westminster"]="WMS";
                    res["Whitechapel"]="WCL";
                    res["Wimbledon"]="WDN";
                    res["Wimbledon Park"]="WMP";
                    break;
                case "hammersmith":
                    //res["Aldgate"]="ALD";
                    res["Aldgate East"]="ALE";
                    res["Baker Street"]="BST";
                    res["Barbican"]="BAR";
                    res["Barking"]="BKG";
                    //res["Bayswater"]="BAY";
                    res["Blackfriars"]="BLF";
                    res["Bow Road"]="BWR";
                    res["Bromley-by-Bow"]="BBB";
                    //res["Cannon Street"]="CST";
                    res["East Ham"]="EHM";
                    res["Edgware Road (H & C)"]="ERD";
                    //res["Embankment"]="EMB";
                    res["Euston Square"]="ESQ";
                    res["Farringdon"]="FAR";
                    res["Great Portland Street"]="GPS";
                    res["Hammersmith (Circle and H&C)"]="HMS";
                    //res["High Street Kensington"]="HST";
                    res["King's Cross St. Pancras"]="KXX";
                    res["Ladbroke Grove"]="LBG";
                    res["Liverpool Street"]="LST";
                    //res["Mansion House"]="MAN";
                    res["Mile End"]="MLE";
                    //res["Monument"]="MON";
                    res["Moorgate"]="MGT";
                    //res["Notting Hill Gate"]="NHG";
                    res["Paddington Circle"]="PADc";
                    res["Paddington H & C"]="PADs";
                    res["Plaistow"]="PLW";
                    res["Royal Oak"]="ROA";
                    //res["Sloane Square"]="SSQ";
                    //res["South Kensington"]="SKN";
                    //res["St. James's Park"]="SJP";
                    res["Stepney Green"]="STG";
                    //res["Temple"]="TEM";
                    //res["Tower Hill"]="THL";
                    res["Upton Park"]="UPK";
                    //res["Victoria"]="VIC";
                    res["West Ham"]="WHM";
                    res["Westbourne Park"]="WBP";
                    //res["Westminster"]="WMS";
                    res["Whitechapel"]="WCL";
                    break;
                case "jubilee":
                    res["Baker Street"]="BST";
                    res["Bermondsey"]="BER";
                    res["Bond Street"]="BDS";
                    res["Canada Water"]="CWR";
                    res["Canary Wharf"]="CWF";
                    res["Canning Town"]="CNT";
                    res["Canons Park"]="CPK";
                    //res["Charing Cross"]="CHX";
                    res["Dollis Hill"]="DHL";
                    res["Finchley Road"]="FRD";
                    res["Green Park"]="GPK";
                    res["Kilburn"]="KIL";
                    res["Kingsbury"]="KBY";
                    res["London Bridge"]="LON";
                    res["Neasden"]="NEA";
                    res["North Greenwich"]="NGW";
                    res["Queensbury"]="QBY";
                    res["Southwark"]="SWK";
                    res["St. John's Wood"]="SJW";
                    res["Stanmore"]="STA";
                    res["Stratford"]="SFD";
                    res["Swiss Cottage"]="SWC";
                    res["Waterloo"]="WLO";
                    res["Wembley Park"]="WPK";
                    res["West Ham"]="WHM";
                    res["West Hampstead"]="WHD";
                    res["Westminster"]="WMS";
                    res["Willesden Green"]="WLG";
                    break;
                case "northern":
                    res["Angel"]="ANG";
                    res["Archway"]="ARC";
                    res["Balham"]="BAL";
                    res["Bank"]="BNK";
                    res["Belsize Park"]="BPK";
                    res["Borough"]="BOR";
                    res["Brent Cross"]="BTX";
                    res["Burnt Oak"]="BUR";
                    res["Camden Town"]="CTN";
                    res["Chalk Farm"]="CHF";
                    res["Charing Cross"]="CHX";
                    res["Clapham Common"]="CPC";
                    res["Clapham North"]="CPN";
                    res["Clapham South"]="CPS";
                    res["Colindale"]="COL";
                    res["Colliers Wood"]="CLW";
                    res["East Finchley"]="EFY";
                    res["Edgware"]="EDG";
                    res["Elephant & Castle"]="ELE";
                    res["Embankment"]="EMB";
                    res["Euston"]="EUS";
                    res["Finchley Central"]="FYC";
                    res["Golders Green"]="GGR";
                    res["Goodge Street"]="GST";
                    res["Hampstead"]="HMP";
                    res["Hendon Central"]="HND";
                    res["High Barnet"]="HBT";
                    res["Highgate"]="HIG";
                    res["Kennington"]="KEN";
                    res["Kentish Town"]="KTN";
                    res["King's Cross St. Pancras"]="KXX";
                    res["Leicester Square"]="LSQ";
                    res["London Bridge"]="LON";
                    res["Mill Hill East"]="MHE";
                    res["Moorgate"]="MGT";
                    res["Morden"]="MOR";
                    res["Mornington C"]="MCR";
                    res["Old Street"]="OLD";
                    res["Oval"]="OVL";
                    res["South Wimbledon"]="SWM";
                    res["Stockwell"]="STK";
                    res["Tooting Bec"]="TBE";
                    res["Tooting Broadway"]="TBY";
                    res["Tottenham Court Road"]="TCR";
                    res["Totteridge and Whetstone"]="TOT";
                    res["Tufnell Park"]="TPK";
                    res["Warren Street"]="WST";
                    res["Waterloo"]="WLO";
                    res["West Finchley"]="WFY";
                    res["Woodside Park"]="WSP";
                    break;
                case "victoria":
                    res["Blackhorse Road"]="BHR";
                    res["Brixton"]="BRX";
                    res["Euston"]="EUS";
                    res["Finsbury Park"]="FPK";
                    res["Green Park"]="GPK";
                    res["Highbury & Islington"]="HBY";
                    res["King's Cross St. Pancras"]="KXX";
                    res["Oxford Circus"]="OXC";
                    res["Pimlico"]="PIM";
                    res["Seven Sisters"]="SVS";
                    res["Stockwell"]="STK";
                    res["Tottenham Hale"]="TTH";
                    res["Vauxhall"]="VUX";
                    res["Victoria"]="VIC";
                    res["Walthamstow Central"]="WAL";
                    res["Warren Street"]="WST";
                    break;
                case "waterlooandcity":
                    res["Bank"]="BNK";
                    res["Waterloo"]="WLO";
                    break;
                case "metropolitan":
                    res["Aldgate"]="ALD";
                    res["Amersham"]="AME";
                    res["Baker Street"]="BST";
                    res["Barbican"]="BAR";
                    res["Chalfont & Latimer"]="CLF";
                    res["Chorleywood"]="CWD";
                    res["Croxley"]="CRX";
                    res["Eastcote"]="ETE";
                    res["Euston Square"]="ESQ";
                    res["Farringdon"]="FAR";
                    res["Finchley Road"]="FRD";
                    res["Great Portland Street"]="GPS";
                    res["Harrow on the Hill"]="HOH";
                    res["Hillingdon"]="HDN";
                    res["Ickenham"]="ICK";
                    res["King's Cross St. Pancras"]="KXX";
                    res["Liverpool Street"]="LST";
                    res["Moor Park"]="MPK";
                    res["Moorgate"]="MGT";
                    res["North Harrow"]="NHR";
                    res["Northwick Park"]="NWP";
                    res["Northwood"]="NWD";
                    res["Northwood Hills"]="NWH";
                    res["Pinner"]="PIN";
                    res["Rayners Lane"]="RLN";
                    res["Rickmansworth"]="RKY";
                    res["Ruislip"]="RUI";
                    res["Ruislip Manor"]="RUM";
                    res["Uxbridge"]="UXB";
                    res["Watford"]="WAT";
                    res["Wembley Park"]="WPK";
                    res["West Harrow"]="WHR";
                    res["Whitechapel"]="WCL";
                    break;
            }
            return res;
        }
        static public LinkedList<String> FetchLinesForStation(String station_nice)
        {
            LinkedList<String> result = new LinkedList<String>();
            String[] lines = new String[] { "piccadilly", "circle", "district", "hammersmith", "victoria", "jubilee", "northern", "bakerloo", "central", "metropolitan",  "waterlooandcity", "dlr"  };
            foreach (String s in lines) 
            {
                Hashtable h = FetchStations(s);
                if (h.ContainsKey(station_nice)) result.AddLast(s);
            }
            return result;
        }
        static public void paintButton(Button but, Memory mem)
        {
            if (mem != null)
            {
                String l1;
                String l2;
                if (mem.station_nice.Length > 11) l1 = mem.station_nice.Substring(0, 11) + ".";
                else l1 = mem.station_nice;
                if (mem.direction.Length > 11) l2 = mem.direction.Substring(0, 11) + ".";
                else l2 = mem.direction;
                but.Text = l1 + "\r\n" + l2;
                but.Enabled = true;
            }
            else
            {
                but.Enabled = false;
                but.Text = "Empty";
            }
        }
        static public void paintButtonWColor(Button but, Memory mem)
        {
            Colorize(but,mem.line,true);
            paintButton(but, mem);
        }
        static public void paintButtonDefault(Control c)
        {
            c.Text = "Empty";
            c.BackColor = SystemColors.Control;
            c.ForeColor = SystemColors.ControlText;
        }
        static public void setSettings()
        {
            Hashtable res = new Hashtable();

            //Find the screen's aspect ratio
            double sq=1.0;
            double norm=640.0/480.0;
            double wide = 800.0 / 480.0;
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            double ratio = (double)screenHeight / (double)screenWidth;
            if (ratio == sq) res["screentype"] = "square";
            else if (ratio == norm || ratio == 1/norm) res["screentype"] = "normal";
            else if (ratio == wide || ratio==1/wide) res["screentype"] = "wide";
            else res["screentype"] = "unknown";

            //Read the file to get stored options
            try
            {
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
                String filePath = appPath + "options.tr";
                if (File.Exists(filePath))
                {
                    StreamReader file = null;
                    try
                    {
                        file = new StreamReader(filePath);
                        String rline;
                        for (int i = 1; (rline = file.ReadLine()) != null && i <= 7; i++)
                        {
                            String[] parts = rline.Split(new char[] { '=' });
                            if (parts.Length == 2) res[parts[0]] = parts[1];
                            else throw new Exception();
                        }

                    }
                    catch (Exception)
                    {
                        res = new Hashtable();
                        res["linefetch"] = "No";
                        res["depfix"] = "No";
                        res["runthres"] = "2 min";
                        res["depaction"] = "Refresh";
                        res["depobsthres"] = "20 sec";
                        res["autostart"] = "No";
                        res["mapviewer"] = getDefaultMapViewer();
                    }
                    finally
                    {
                        if (file != null)
                            file.Close();
                    }
                }
                else
                {
                    res["linefetch"] = "No";
                    res["depfix"] = "No";
                    res["runthres"] = "2 min";
                    res["depaction"] = "Refresh";
                    res["depobsthres"] = "20 sec";
                    res["autostart"] = "No";
                    res["mapviewer"] = getDefaultMapViewer();
                }
            }
            catch (Exception)
            {

            }

            //See if this is the 1rst app execution
            try
            {
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
                String filePath1 = appPath + "options.tr";
                String filePath2 = appPath + "statuses.tr";
                if (File.Exists(filePath1) || File.Exists(filePath2)) 
                {
                    res["1rstrun"] = "No";
                }
                else {
                    res["1rstrun"] = "Yes";
                }
            }
            catch (Exception)
            {
                res["1rstrun"] = "No";
            }

            settings = res;
        }
        static public String getSetting(String s)
        {
            if (settings != null) return (String)settings[s];
            else return null;
        }
        static public String getDefaultMapViewer()
        {
            if (File.Exists(FormOptions.htcAlbumPath)) return FormOptions.htcAlbumPath;
            else if (File.Exists(FormOptions.operaPath)) return FormOptions.operaPath;
            else if (File.Exists(FormOptions.samsungPath)) return FormOptions.samsungPath;
            else return "";
        }
        static public void LaunchApp(string strPath, string strParms)
        {
            ProcessInfo pi = new ProcessInfo();
            byte[] si = new byte[128];
            CreateProcess(strPath, strParms, IntPtr.Zero, IntPtr.Zero,
                0, 0, IntPtr.Zero, IntPtr.Zero, si, pi);
            // This line can be commented out if you do not want 
            // to wait for the process to exit
            //WaitForSingleObject(pi.hProcess, 0xFFFFFFFF);
            int exitCode = 0;
            GetExitCodeProcess(pi.hProcess, ref exitCode);
            CloseHandle(pi.hProcess);
            CloseHandle(pi.hThread);
            return;
        }
        [DllImport("CoreDll.DLL", SetLastError = true)]
        private static extern int CreateProcess(String imageName, String cmdLine,
            IntPtr lpProcessAttributes, IntPtr lpThreadAttributes,
            Int32 boolInheritHandles, Int32 dwCreationFlags, IntPtr lpEnvironment,
            IntPtr lpszCurrentDir, byte[] si, ProcessInfo pi);

        [DllImport("coredll")]
        private static extern bool CloseHandle(IntPtr hObject);

        [DllImport("coredll")]
        private static extern uint WaitForSingleObject
                (IntPtr hHandle, uint dwMilliseconds);

        [DllImport("coredll.dll", SetLastError = true)]
        private static extern int GetExitCodeProcess
                (IntPtr hProcess, ref int lpExitCode);
    }
}
