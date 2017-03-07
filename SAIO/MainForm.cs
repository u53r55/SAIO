using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Reactive.Linq;
using System.Drawing;

namespace SAIO
{

    public partial class MainForm : Form
    {

        //Global Variables;
        List<string> ActionList = new List<string>();
        int SourcesCount = 0;

        #region Apply Stored Color Settings
        public MainForm()
        {
            
            //Start all Components;
            InitializeComponent();

            //Refresh the colors based on stored Settings;
            InvalidateColors();

        }
        #endregion
        #region Drag Function

        //Variables;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        //Function;
        private void FormDrag(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IntPtr myHandle = Handle;
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion
        #region Dropshadow

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        };
                        DwmExtendFrameIntoClientArea(Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

        }

        #endregion
        #region Hotkeys

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {

            //If Control is Pressed;
            if (e.Control)
            {

                //And S is also pressed;
                if (e.KeyCode == Keys.S)
                {

                    //Export;
                    Export();

                }

            }

        }

        #endregion
        #region InvalidateColors
        
        private bool InvalidateColors()
        {
            
            //Window Color;
            BackColor = Properties.Settings.Default.WindowColor;
            controlBox1.BackColor = Properties.Settings.Default.WindowColor;

            //Font Color;
            AppTitle.ForeColor = Properties.Settings.Default.FontColor;

            //Highlight Color;
            GrabButton.BackColor = Properties.Settings.Default.HighlightColor;
            CheckButton.BackColor = Properties.Settings.Default.HighlightColor;
            HQifierButton.BackColor = Properties.Settings.Default.HighlightColor;
            ConverterButton.BackColor = Properties.Settings.Default.HighlightColor;
            ExtractorButton.BackColor = Properties.Settings.Default.HighlightColor;
            MainTabControl.Invalidate(); //Redraw;

            return true;

        }

        #endregion

        #region Functions

        #region Tab 1

        #region Grab Button

        private void GrabButton_Click(object sender, EventArgs e)
        {

            //If a function isn't already being used;
            if (!Properties.Settings.Default.isBusy)
            {

                //Set the isBusy setting to true;
                Properties.Settings.Default.isBusy = true;

                //Change the button Color Scheme to the "Alert" Scheme;
                GrabButton.Text = "Stop...";
                GrabButton.Tag = "Alert";
                GrabButton.BackColor = Properties.Settings.Default.AlertColor;

                //Disable all other buttons;
                CheckButton.Enabled = false;
                HQifierButton.Enabled = false;
                ConverterButton.Enabled = false;
                ExtractorButton.Enabled = false;

                //Reset the StatLabel, SourceCount Variable and ActionLabel's;
                ActionLabel.Text = "Grabbing proxies...";
                ActionLabelTip.Text = "";
                StatLabel_Left.Text = "0";
                SourcesCount = 0;

                //Make sure the ActionList is Empty;
                ActionList.Clear();
                
                #region Sources

                #region Pre-Determined Sources
                List<string> sources = new List<string>();
                sources.Add("http://saio.pw/leaked.txt");
                sources.Add("http://aliveproxy.com/anonymous-proxy-list");
                sources.Add("http://aliveproxy.com/ca-proxy-list");
                sources.Add("http://aliveproxy.com/de-proxy-list");
                sources.Add("http://aliveproxy.com/fastest-proxies");
                sources.Add("http://aliveproxy.com/fr-proxy-list");
                sources.Add("http://aliveproxy.com/gb-proxy-list");
                sources.Add("http://aliveproxy.com/high-anonymity-proxy-list");
                sources.Add("http://aliveproxy.com/jp-proxy-list");
                sources.Add("http://aliveproxy.com/proxy-list-port-3128");
                sources.Add("http://aliveproxy.com/proxy-list-port-80");
                sources.Add("http://aliveproxy.com/proxy-list-port-8000");
                sources.Add("http://aliveproxy.com/proxy-list-port-8080");
                sources.Add("http://aliveproxy.com/proxy-list-port-81");
                sources.Add("http://aliveproxy.com/ru-proxy-list");
                sources.Add("http://aliveproxy.com/socks4-list");
                sources.Add("http://aliveproxy.com/socks5-list");
                sources.Add("http://aliveproxy.com/transparent-proxy-list");
                sources.Add("http://aliveproxy.com/us-proxy-list");
                sources.Add("http://atomintersoft.com/anonymous_proxy_list");
                sources.Add("http://atomintersoft.com/high_anonymity_elite_proxy_list");
                sources.Add("http://atomintersoft.com/index.php?q=proxy_list_domain&domain=com");
                sources.Add("http://atomintersoft.com/products/alive-proxy/proxy-list");
                sources.Add("http://atomintersoft.com/products/alive-proxy/proxy-list/3128");
                sources.Add("http://atomintersoft.com/products/alive-proxy/proxy-list/high-anonymity");
                sources.Add("http://atomintersoft.com/products/alive-proxy/socks5-list");
                sources.Add("http://atomintersoft.com/proxy_list_domain");
                sources.Add("http://atomintersoft.com/proxy_list_domain_com");
                sources.Add("http://atomintersoft.com/proxy_list_domain_edu");
                sources.Add("http://atomintersoft.com/proxy_list_domain_net");
                sources.Add("http://atomintersoft.com/proxy_list_domain_org");
                sources.Add("http://atomintersoft.com/proxy_list_port");
                sources.Add("http://atomintersoft.com/proxy_list_port_3128");
                sources.Add("http://atomintersoft.com/proxy_list_port_80");
                sources.Add("http://atomintersoft.com/proxy_list_port_8000");
                sources.Add("http://atomintersoft.com/proxy_list_port_81");
                sources.Add("http://atomintersoft.com/transparent_proxy_list");
                sources.Add("http://best-proxy.com/english/search.php?search=anonymous-And-elite&country=any&type=anonymous-And-elite&port=any&ssl=any");
                sources.Add("http://best-proxy.com/english/search.php?search=anonymous-And-elite&country=any&type=anonymous-And-elite&port=any&ssl=any&p=2");
                sources.Add("http://best-proxy.com/english/search.php?search=anonymous-And-elite&country=any&type=anonymous-And-elite&port=any&ssl=any&p=3");
                sources.Add("http://cybersyndrome.net/");
                sources.Add("http://cybersyndrome.net/pla.html");
                sources.Add("http://cybersyndrome.net/pld.html");
                sources.Add("http://cybersyndrome.net/plr.html");
                sources.Add("http://cybersyndrome.net/search.cgi?q=CN");
                sources.Add("http://cybersyndrome.net/search.cgi?q=DE");
                sources.Add("http://cybersyndrome.net/search.cgi?q=FR");
                sources.Add("http://cybersyndrome.net/search.cgi?q=HK");
                sources.Add("http://cybersyndrome.net/search.cgi?q=US");
                sources.Add("http://freeproxy.ru/download/lists/goodproxy.txt");
                sources.Add("http://freeproxy.ru/download/lists/goodproxy.txt");
                sources.Add("http://getproxy.jp/en");
                sources.Add("http://getproxy.jp/en");
                sources.Add("http://getproxy.jp/en/?area=en");
                sources.Add("http://getproxy.jp/en/default/1");
                sources.Add("http://getproxy.jp/en/default/1");
                sources.Add("http://getproxy.jp/en/default/2");
                sources.Add("http://getproxy.jp/en/default/2");
                sources.Add("http://getproxy.jp/en/default/3");
                sources.Add("http://getproxy.jp/en/default/3");
                sources.Add("http://getproxy.jp/en/default/4");
                sources.Add("http://getproxy.jp/en/default/4");
                sources.Add("http://getproxy.jp/en/default/5");
                sources.Add("http://getproxy.jp/en/default/5");
                sources.Add("http://getproxy.jp/en/fastest");
                sources.Add("http://ip-adress.com/proxy_list/?k=time&d=desc");
                sources.Add("http://ipaddress.com/proxy-list/");
                sources.Add("http://irc-proxies24.blogspot.com/feeds/posts/default");
                sources.Add("http://my-proxy.com/free-proxy-list-10.html");
                sources.Add("http://my-proxy.com/free-proxy-list-2.html");
                sources.Add("http://my-proxy.com/free-proxy-list-3.html");
                sources.Add("http://my-proxy.com/free-proxy-list-4.html");
                sources.Add("http://my-proxy.com/free-proxy-list-5.html");
                sources.Add("http://my-proxy.com/free-proxy-list-6.html");
                sources.Add("http://my-proxy.com/free-proxy-list-7.html");
                sources.Add("http://my-proxy.com/free-proxy-list-8.html");
                sources.Add("http://my-proxy.com/free-proxy-list-9.html");
                sources.Add("http://my-proxy.com/free-proxy-list.html");
                sources.Add("http://newfreshproxies24.blogspot.com/feeds/posts/default");
                sources.Add("http://nntime.com/proxy-list-01.htm");
                sources.Add("http://nntime.com/proxy-list-02.htm");
                sources.Add("http://nntime.com/proxy-list-03.htm");
                sources.Add("http://nntime.com/proxy-list-04.htm");
                sources.Add("http://nntime.com/proxy-list-05.htm");
                sources.Add("http://nntime.com/proxy-list-06.htm");
                sources.Add("http://nntime.com/proxy-list-07.htm");
                sources.Add("http://nntime.com/proxy-list-08.htm");
                sources.Add("http://nntime.com/proxy-list-09.htm");
                sources.Add("http://nntime.com/proxy-list-10.htm");
                sources.Add("http://nntime.com/proxy-list-11.htm");
                sources.Add("http://nntime.com/proxy-list-12.htm");
                sources.Add("http://nntime.com/proxy-list-13.htm");
                sources.Add("http://nntime.com/proxy-list-14.htm");
                sources.Add("http://nntime.com/proxy-list-15.htm");
                sources.Add("http://nntime.com/proxy-list-16.htm");
                sources.Add("http://nntime.com/proxy-list-17.htm");
                sources.Add("http://nntime.com/proxy-list-18.htm");
                sources.Add("http://nntime.com/proxy-list-19.htm");
                sources.Add("http://nntime.com/proxy-list-20.htm");
                sources.Add("http://nntime.com/proxy-list-21.htm");
                sources.Add("http://nntime.com/proxy-list-22.htm");
                sources.Add("http://nntime.com/proxy-list-23.htm");
                sources.Add("http://nntime.com/proxy-list-24.htm");
                sources.Add("http://nntime.com/proxy-list-25.htm");
                sources.Add("http://nntime.com/proxy-list-26.htm");
                sources.Add("http://nntime.com/proxy-list-27.htm");
                sources.Add("http://nntime.com/proxy-list-28.htm");
                sources.Add("http://nntime.com/proxy-list-29.htm");
                sources.Add("http://nntime.com/proxy-list-30.htm");
                sources.Add("http://notan.h1.ru/hack/xwww/proxy1.html");
                sources.Add("http://notan.h1.ru/hack/xwww/proxy2.html");
                sources.Add("http://notan.h1.ru/hack/xwww/proxy3.html");
                sources.Add("http://notan.h1.ru/hack/xwww/proxy4.html");
                sources.Add("http://notan.h1.ru/hack/xwww/proxy5.html");
                sources.Add("http://notan.h1.ru/hack/xwww/proxy6.html");
                sources.Add("http://notan.h1.ru/hack/xwww/proxy7.html");
                sources.Add("http://notan.h1.ru/hack/xwww/proxy8.html");
                sources.Add("http://notan.h1.ru/hack/xwww/proxy9.html");
                sources.Add("http://notan.h1.ru/hack/xwww/proxy10.html");
                sources.Add("https://orca.tech/?action=real-time-proxy-list");
                sources.Add("http://proxy-ip-list.com/");
                sources.Add("http://proxy.ipcn.org/proxylist.html");
                sources.Add("http://proxy.ipcn.org/proxylist2.html");
                sources.Add("http://proxy24update.blogspot.com/feeds/posts/default");
                sources.Add("http://proxylistchecker.org/proxylists.php");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=1");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=2");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=3");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=3");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=4");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=4");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=5");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=5");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=6");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=6");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=7");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=7");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=8");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=8");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=9");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=9");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=10");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=10");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=11");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=11");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=12");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=12");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=13");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=13");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=14");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=14");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=15");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=15");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=16");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=17");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=18");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=19");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=20");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=21");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=22");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=23");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=24");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=25");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=26");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=27");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=28");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=29");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=30");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=31");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=32");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=33");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=34");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=35");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=36");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=37");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=38");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=39");
                sources.Add("http://proxylistchecker.org/proxylists.php?t=&p=40");
                sources.Add("http://proxylists.net/");
                sources.Add("http://proxylists.net/http_highanon.txt");
                sources.Add("http://proxylists.net/socks4.txt");
                sources.Add("http://proxysearcher.sourceforge.net/Proxy%20List.php?type=http");
                sources.Add("http://proxysearcher.sourceforge.net/Proxy%20List.php?type=socks");
                sources.Add("http://proxyserverlist-24.blogspot.com/feeds/posts/default");
                sources.Add("http://ps.givemehacks.com/proxies.txt");
                sources.Add("http://samair.ru/proxy/proxy-01.htm");
                sources.Add("http://samair.ru/proxy/proxy-02.htm");
                sources.Add("http://samair.ru/proxy/proxy-03.htm");
                sources.Add("http://samair.ru/proxy/proxy-04.htm");
                sources.Add("http://samair.ru/proxy/proxy-05.htm");
                sources.Add("http://samair.ru/proxy/proxy-06.htm");
                sources.Add("http://samair.ru/proxy/proxy-07.htm");
                sources.Add("http://samair.ru/proxy/proxy-08.htm");
                sources.Add("http://samair.ru/proxy/proxy-09.htm");
                sources.Add("http://samair.ru/proxy/proxy-10.htm");
                sources.Add("http://samair.ru/proxy/proxy-11.htm");
                sources.Add("http://samair.ru/proxy/proxy-12.htm");
                sources.Add("http://samair.ru/proxy/proxy-13.htm");
                sources.Add("http://samair.ru/proxy/proxy-14.htm");
                sources.Add("http://samair.ru/proxy/proxy-15.htm");
                sources.Add("http://samair.ru/proxy/proxy-16.htm");
                sources.Add("http://samair.ru/proxy/proxy-17.htm");
                sources.Add("http://samair.ru/proxy/proxy-18.htm");
                sources.Add("http://samair.ru/proxy/proxy-19.htm");
                sources.Add("http://samair.ru/proxy/proxy-20.htm");
                sources.Add("http://samair.ru/proxy/proxy-21.htm");
                sources.Add("http://samair.ru/proxy/proxy-22.htm");
                sources.Add("http://samair.ru/proxy/proxy-23.htm");
                sources.Add("http://samair.ru/proxy/proxy-24.htm");
                sources.Add("http://samair.ru/proxy/proxy-25.htm");
                sources.Add("http://samair.ru/proxy/proxy-26.htm");
                sources.Add("http://samair.ru/proxy/proxy-27.htm");
                sources.Add("http://samair.ru/proxy/proxy-28.htm");
                sources.Add("http://samair.ru/proxy/proxy-29.htm");
                sources.Add("http://samair.ru/proxy/proxy-30.htm");
                sources.Add("http://samair.ru/proxy/socks01.htm");
                sources.Add("http://samair.ru/proxy/socks02.htm");
                sources.Add("http://samair.ru/proxy/socks03.htm");
                sources.Add("http://samair.ru/proxy/socks04.htm");
                sources.Add("http://samair.ru/proxy/socks05.htm");
                sources.Add("http://socks24.org/feeds/posts/default");
                sources.Add("http://socks24.ru/proxy/httpProxies.txt");
                sources.Add("http://socksproxylist24.blogspot.com/feeds/posts/default");
                sources.Add("http://spys.ru/en");
                sources.Add("http://spys.ru/en/socks-proxy-list");
                sources.Add("http://spys.ru/en/socks-proxy-list/1");
                sources.Add("http://sslproxies24.blogspot.com/feeds/posts/default");
                sources.Add("http://txt.proxyspy.net/proxy.txt");
                sources.Add("http://vip-socks24.blogspot.com/feeds/posts/default");
                sources.Add("http://vipsocks24.net/feeds/posts/default");
                sources.Add("http://eng.fineproxy.org/freshproxy/");
                #endregion
                #region Get Orca Community Proxy Sources

                //Request the Website's Response Data;
                HttpWebRequest init = (HttpWebRequest)WebRequest.Create("https://orca.tech/community-proxy-list/");
                init.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36";
                init.Timeout = 3500;
                init.ReadWriteTimeout = 1500;
                init.KeepAlive = false;
                
                try
                {

                    //Read the Website's Response Data (HTML Source);
                    using (StreamReader sr = new StreamReader(init.GetResponse().GetResponseStream()))
                    {

                        //Get all the Orca Sources that was found from the source HTML using the Regex Condition;
                        MatchCollection orcasources = new Regex("<a href='([^']*)'").Matches(sr.ReadToEnd());
                        int orcasourcecount = 0;
                        
                        //For Each of the found Orca Sources;
                        foreach (Match source in orcasources)
                        {

                            //If it's not already in the Source List and hasn't reached the max sources allowed;
                            if (!(orcasourcecount == Properties.Settings.Default.OrcaSourceMax) & !sources.Contains("https://orca.tech/community-proxy-list/" + source.Groups[1].Value))
                            {
                                //Add the Orca List;
                                sources.Add("https://orca.tech/community-proxy-list/" + source.Groups[1].Value);
                                orcasourcecount += 1;
                            }
                            else if (orcasourcecount == Properties.Settings.Default.OrcaSourceMax)
                            {
                                //It has reached the max - Exit the For Each;
                                break;

                            }

                        }

                    }


                }
                catch (WebException ex)
                {
                    Console.WriteLine("Error with Orca! " + ex.Response);
                }

                #endregion

                //Randomize the Source List;
                var r_Sources = sources.OrderBy(a => Guid.NewGuid()).ToList();

                #endregion

                //Set the Thread Count;
                ThreadPool.SetMinThreads(Properties.Settings.Default.GrabberThreads, Properties.Settings.Default.GrabberThreads);
                ServicePointManager.MaxServicePointIdleTime = 8000;
                ServicePointManager.DefaultConnectionLimit = Properties.Settings.Default.GrabberThreads / 3;

                //For each source, Queue them to the Function, And change the ActionLeft and ActionRight text;
                var query = r_Sources.ToObservable().SelectMany(s => Observable.Start(() => new {
                    source = s,
                    grab = GrabProxies(s)
                })).Select(x => new {
                    x.source,
                    x.grab
                }).ObserveOn(this).Do(x =>
                {
                    int percentComplete = (int)Math.Round((double)(100 * SourcesCount) / sources.Count);
                    ProgressBar1.Value = percentComplete;
                    StatLabel_Left.Text = ActionList.Count.ToString();
                    StatLabel_Right.Text = new Uri(x.source).GetLeftPart(UriPartial.Authority);
                });

                //Execute the Query and once finished ...;
                query.ToArray().ObserveOn(this).Subscribe(x =>
                {

                    #region Once Finished

                    //Reset the GrabButton;
                    GrabButton.Tag = "";
                    GrabButton.BackColor = Properties.Settings.Default.HighlightColor;
                    GrabButton.Text = "Grab Proxies";

                    //Disable the Stop Function;
                    Properties.Settings.Default.StopFunction = false;
                    Properties.Settings.Default.isBusy = false;

                    //Re-enable all other buttons;
                    CheckButton.Enabled = true;
                    HQifierButton.Enabled = true;
                    ConverterButton.Enabled = true;
                    ExtractorButton.Enabled = true;

                    //If no proxies were grabbed;
                    if (StatLabel_Left.Text == "0")
                    {

                        //Setup the Labels;
                        ActionLabel.Text = "Failed! Connection Issue!";
                        ActionLabelTip.Text = "(no proxies were grabbed)";
                        StatLabel_Left.Text = "";
                        StatLabel_Right.Text = "";
                        
                    }
                    else
                    {

                        //If the Auto Check Proxies setting is set to True;
                        if (Properties.Settings.Default.AutoCheckProxies == true)
                        {

                            //Setup the Label;
                            ActionLabelTip.Text = "";

                            //Change the Button Color Scheme to the "Alert" Scheme;
                            CheckButton.Text = "Stop...";
                            CheckButton.Tag = "Alert";
                            CheckButton.BackColor = Properties.Settings.Default.AlertColor;

                            //Disable all other buttons;
                            GrabButton.Enabled = false;
                            HQifierButton.Enabled = false;
                            ConverterButton.Enabled = false;
                            ExtractorButton.Enabled = false;

                            //Start checking the grabbed Proxies;
                            CheckProxies();

                        }
                        else if(Properties.Settings.Default.AutoExport == true)
                        {

                            //Setup the Labels;
                            ActionLabel.Text = "Grabbed " + StatLabel_Left.Text + " proxies";
                            ActionLabelTip.Text = "";
                            StatLabel_Left.Text = "";
                            StatLabel_Right.Text = "";
                            Export();

                        }
                        else
                        {

                            //Setup the Labels;
                            ActionLabel.Text = "Grabbed " + StatLabel_Left.Text + " proxies";
                            ActionLabelTip.Text = "(press CTRL+S to export)";
                            StatLabel_Left.Text = "";
                            StatLabel_Right.Text = "";

                        }

                    }

                    #endregion

                });

            }
            else
            {

                //Start Stop Function;
                Properties.Settings.Default.StopFunction = true;

            }
        }
        private bool GrabProxies(string source)
        {

            //Skip Grabbing if the Stop Function was used;
            if (!Properties.Settings.Default.StopFunction)
            {

                //Request the Website's Response Data;
                HttpWebRequest init = (HttpWebRequest)WebRequest.Create(source);
                init.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36";
                init.Timeout = 3500;
                init.ReadWriteTimeout = 1500;
                init.KeepAlive = false;
                
                try
                {

                    //Read the Website's Response Data (HTML Source);
                    using (StreamReader sr = new StreamReader(init.GetResponse().GetResponseStream()))
                    {
                        
                        //Get all the Proxies that was found from the source HTML using the Regex Condition;
                        MatchCollection proxies = new Regex("[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}:[0-9]{1,4}").Matches(sr.ReadToEnd());
                        
                        //For Each of the found Proxies;
                        foreach (Match proxy in proxies)
                        {

                            //If it's not already in the ActionList;
                            if (!ActionList.Contains(proxy.ToString()))
                            {
                                //Add the Proxy and update the Progressive Information;
                                Invoke(new MethodInvoker(() =>
                                {
                                    ActionList.Add(proxy.ToString());
                                    ActionLabelTip.Text = proxy.ToString();
                                }));
                            }

                        }

                    }

                    return true;
                    
                }
                catch (WebException ex)
                {
                    Console.WriteLine(("Error: " + source + " " + ex.Response));
                    return false;
                }
                finally
                {
                    // Increment the Checked Sources Variable;
                    Invoke(new MethodInvoker(() => { SourcesCount += 1; }));
                }

            }

            return false;

        }

        #endregion
        #region Check Button
        
        private void CheckButton_Click(object sender, EventArgs e)
        {

            //If it isn't already being used;
            if (Properties.Settings.Default.isBusy == false)
            {

                //Create a OpenFileDialog;
                var ofd = new OpenFileDialog();
                ofd.Multiselect = false;

                //If the user chose a file to Import;
                if ((ofd.ShowDialog() == DialogResult.OK & ofd.CheckFileExists == true))
                {

                    //Set the isBusy setting to true;
                    Properties.Settings.Default.isBusy = true;

                    //Change the button Color Scheme to the "Alert" Scheme;
                    CheckButton.Text = "Stop...";
                    CheckButton.Tag = "Alert";
                    CheckButton.BackColor = Properties.Settings.Default.AlertColor;

                    //Disable all other buttons;
                    GrabButton.Enabled = false;
                    HQifierButton.Enabled = false;
                    ConverterButton.Enabled = false;
                    ExtractorButton.Enabled = false;

                    //Create an Array of Proxies from the Selected File;
                    var proxies = new Regex("[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}:[0-9]{1,4}").Matches(File.ReadAllText(ofd.FileName)).OfType<Match>().Select(x => x.ToString()).ToArray();
                    
                    //Add the Proxies to the ActionList;
                    ActionList.Clear();
                    ActionList.AddRange(proxies);

                    //Check the Proxies in the ActionList;
                    CheckProxies();

                }


            }
            else
            {

                //Start Stop Function;
                Properties.Settings.Default.StopFunction = true;

            }

        }
        private bool CheckProxies()
        {

            //Make sure the isBusy setting to true;
            Properties.Settings.Default.isBusy = true;

            //Reset the StatLabel, SourceCount Variable and ActionLabel's;
            ActionLabel.Text = "Grabbing proxies...";
            ActionLabelTip.Text = "";
            StatLabel_Left.Text = "0";
            SourcesCount = 0;

            //Count Variable's;
            int CheckCount = 0;
            int ValidCount = 0;

            //Set the Threads;
            ThreadPool.SetMinThreads(Properties.Settings.Default.CheckerThreads, Properties.Settings.Default.CheckerThreads);
            ServicePointManager.MaxServicePointIdleTime = 8000;
            ServicePointManager.DefaultConnectionLimit = Properties.Settings.Default.CheckerThreads / 3;

            //Start setting up the Lambda Query;
            var query = ActionList.ToObservable().SelectMany(p => Observable.Start(() => new {
                proxy = p,
                check = CheckProxy(p)
            })).Do(x => {
                CheckCount += 1;
                ValidCount += x.check ? 1 : 0;
            }).Select(x => new {
                x.proxy,
                x.check,
                CheckCount,
                ValidCount
            }).ObserveOn(this).Do(x => {
                StatLabel_Left.Text = x.ValidCount.ToString();
                int percentComplete = (int)Math.Round((double)(100 * x.CheckCount) / ActionList.Count);
                StatLabel_Right.Text = percentComplete.ToString() + "%";
                ProgressBar1.Value = percentComplete;
            }).Where(x => x.check).Select(x => x.proxy);

            //Start the Query, Add all working proxies to an Array and Execute OnFinish Code;
            query.ToArray().ObserveOn(this).Subscribe(x =>
            {

                //Reset the CheckButton;
                CheckButton.Tag = "";
                CheckButton.BackColor = Properties.Settings.Default.HighlightColor;
                CheckButton.Text = "Check";

                //Disable the Stop Function;
                Properties.Settings.Default.StopFunction = false;
                Properties.Settings.Default.isBusy = false;

                //Clear the ActionList and Add the working Proxies to the ActionList;
                ActionList.Clear();
                ActionList = x.ToList();

                //Re-enable all other buttons;
                GrabButton.Enabled = true;
                HQifierButton.Enabled = true;
                ConverterButton.Enabled = true;
                ExtractorButton.Enabled = true;

                //If no there is no working proxies;
                if (x.Count() == 0)
                {
                    ActionLabel.Text = "No working proxies!";
                    ActionLabelTip.Text = "(possible connection issue?)";
                }
                else if (Properties.Settings.Default.AutoExport == true)
                {

                    //Setup the Labels;
                    ActionLabel.Text = x.Count().ToString() + " Working Proxies";
                    ActionLabelTip.Text = "";
                    Export();

                }
                else
                {
                    ActionLabel.Text = x.Count().ToString() + " Working Proxies";
                    ActionLabelTip.Text = "(press CTRL+S to export)";
                }

                //Clear the StatLabel's
                StatLabel_Left.Text = "";
                StatLabel_Right.Text = "";

            });

            return true;

        }
        private bool CheckProxy(string proxy)
        {

            //Skip Checking if the Stop Function was used;
            if (!Properties.Settings.Default.StopFunction)
            {

                //Change the ActionLabel to the Current Proxy;
                Invoke(new MethodInvoker(() => ActionLabelTip.Text = proxy));

                HttpWebRequest init = (HttpWebRequest)WebRequest.Create("http://azenv.net");
                init.Timeout = 4500;
                init.ReadWriteTimeout = 2500;
                init.KeepAlive = false;
                init.Proxy = new WebProxy(proxy);
                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)init.GetResponse())
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        #endregion

        #endregion
        #region Tab 2

        #region HQ'ifier

        private void HQifierButton_Click(object sender, EventArgs e)
        {

            //Create a OpenFileDialog;
            var ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            //If the user chose a file to Import;
            if ((ofd.ShowDialog() == DialogResult.OK & ofd.CheckFileExists == true))
            {

                //Notify the user;
                ActionLabel2.Text = "HQ'ifying...";
                ActionLabel2.Refresh();
                ActionLabelTip2.Text = "(this could take a while)";
                ActionLabelTip2.Refresh();

                //Make sure the ActionList is Empty;
                ActionList.Clear();

                //For each selected file;
                foreach (string FileName in ofd.FileNames)
                {

                    //Regex;
                    var regex = new Regex("^.{5,}:.{6,}$", RegexOptions.Multiline);

                    //Use Regex and Match all Combo's with proper syntax;
                    //Remove Non-ASCII Characters, Spaces And NUL/Control Characers then output the final combo;
                    var Combos = regex.Matches(File.ReadAllText(FileName)).OfType<Match>().Select(x => {
                        return Regex.Replace(Regex.Replace(x.ToString(), "[^\\u0000-\\u007F]+", "").Replace(" ", ""), "\\p{C}+", "");
                    }).Distinct(StringComparer.CurrentCultureIgnoreCase).ToArray();

                    //Add the final Combo's to the ActionList;
                    ActionList.AddRange(Combos);

                    //Notify the user;
                    ActionLabel2.Text = "idle...";
                    ActionLabelTip2.Text = "";

                    //If the file HQ'ifies successfully, Export the HQ'ified List;
                    MessageBox.Show("Removed Non-ASCII Characters, Spaces, NUL/Control Characers, Duplicates, Sorted by Alphabetical Order and only exported combos that fit minimum registration requirements. Exporting Now...", "Finished!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Export();

                }

            }

        }

        #endregion
        #region Converter

        private void ConverterButton_Click(object sender, EventArgs e)
        {

            var ofd = new OpenFileDialog();
            ofd.Title = "Import...";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Filter = "Text files|*.txt";
            ofd.Multiselect = false;

            //If the user selects a File;
            if ((ofd.ShowDialog() == DialogResult.OK & ofd.CheckFileExists == true))
            {

                //Make sure there are no previously stored Conversions;
                ActionList.Clear();

                //Variables;
                int ConvertedCount = 0;
                
                try
                {

                    //Read the file loaded by the OpenFileDialog;
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {

                        //File Contents;
                        string filecontents = sr.ReadToEnd();

                        //Get all the Username combo's found from the Regex Condition;
                        MatchCollection UsernameCombos = new Regex("^([a-zA-Z][\\w.]+|[0-9][0-9_.]*[a-zA-Z]+[\\w.]*):(.*)$", RegexOptions.Multiline).Matches(filecontents);
                        MatchCollection EmailCombos = new Regex("^([^@]+)@(.*):(.*)$", RegexOptions.Multiline).Matches(filecontents);

                        //If the Combo contains both Email and Username combo's let the user know;
                        if (EmailCombos.Count > 0 && UsernameCombos.Count > 0)
                        {
                            MessageBox.Show("Does not support mix-converting. (Combo contains both Username:Password and Email:Password lines)", "Failed to Detect Combo Type!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            //If it's an Email:Password combo;
                            if (EmailCombos.Count > 0 && UsernameCombos.Count <= 0)
                            {

                                //Ask if its OK to convert;
                                DialogResult dr = MessageBox.Show("Combo detected as an Email:Password combo - Convert to Username:Password?", "Detected Combo Type!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dr == DialogResult.Yes)
                                {

                                    //Add each Email:Password combo to the ActionList;
                                    foreach (Match combo in EmailCombos)
                                    {

                                        //Make sure no duplicates get Converted;
                                        if (!ActionList.Contains(combo.Groups[1].ToString() + ":" + combo.Groups[3].ToString()))
                                        {

                                            //Convert;
                                            ActionList.Add(combo.Groups[1].ToString() + ":" + combo.Groups[3].ToString());

                                            //Increment the Conversion Count;
                                            ConvertedCount += 1;

                                        }

                                    }

                                }
                                
                            }
                            else if (UsernameCombos.Count > 0 && EmailCombos.Count <= 0)
                            {

                                //Ask if its OK to convert;
                                DialogResult dr = MessageBox.Show("Combo detected as a Username:Password combo - Convert to Email:Password?", "Detected Combo Type!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dr == DialogResult.Yes)
                                {

                                    //Add each Username:Password combo to the ActionList;
                                    foreach (Match combo in UsernameCombos)
                                    {

                                        //Make sure no duplicates get Converted;
                                        if (!ActionList.Contains(combo.Groups[1].ToString() + "@gmail.com:" + combo.Groups[2].ToString()))
                                        {

                                            //Convert;
                                            ActionList.Add(combo.Groups[1].ToString() + "@gmail.com:" + combo.Groups[2].ToString());
                                            ActionList.Add(combo.Groups[1].ToString() + "@yahoo.com:" + combo.Groups[2].ToString());
                                            ActionList.Add(combo.Groups[1].ToString() + "@yahoo.co.uk:" + combo.Groups[2].ToString());
                                            ActionList.Add(combo.Groups[1].ToString() + "@hotmail.com:" + combo.Groups[2].ToString());
                                            ActionList.Add(combo.Groups[1].ToString() + "@outlook.com:" + combo.Groups[2].ToString());
                                            ActionList.Add(combo.Groups[1].ToString() + "@aol.com:" + combo.Groups[2].ToString());

                                            //Increment the Conversion Count;
                                            ConvertedCount += 1;

                                        }

                                    }

                                }
                                
                            }

                        }

                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    
                }
                finally
                {

                    //Show Progression;
                    StatLabel_Left2.Text = "Converted " + ConvertedCount.ToString() + "/" + File.ReadLines(ofd.FileName).Count().ToString();

                }

            }

        }

        #endregion

        #endregion
        #region Tab 3
        
        private void ExtractorButton_Click(object sender, EventArgs e)
        {

            var ofd = new OpenFileDialog();
            ofd.Title = "Import...";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Filter = "Text files|*.txt";
            ofd.Multiselect = false;

            //If the user selects a File;
            if ((ofd.ShowDialog() == DialogResult.OK & ofd.CheckFileExists == true))
            {

                //Notify the user;
                ActionLabel3.Text = "Extracting...";
                ActionLabel3.Refresh();
                ActionLabelTip3.Text = "(this could take a while)";
                ActionLabelTip3.Refresh();

                //Make sure there are no previously stored Conversions;
                ActionList.Clear();
                
                try
                {

                    //Read the file loaded by the OpenFileDialog;
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {

                        //Get all the Proxies that was found from the Regex Condition;
                        MatchCollection matches = new Regex("(.*)@(.*):[a-f0-9]{32}").Matches(sr.ReadToEnd());

                        //For Each MD5 found from the Regex Condition;
                        foreach (Match md5 in matches)
                        {

                            //Add it to the ActionList;
                            ActionList.Add(md5.Value);

                        }

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    
                    //Notify the user;
                    ActionLabel3.Text = "Extracted " + ActionList.Count().ToString() + " MD5 hashes";
                    ActionLabelTip3.Text = "(press CTRL+S to export)";

                }

            }

        }

        #endregion
        
        private bool ImportCombolist()
        {

            try
            {

                //Create a OpenFileDialog;
                var ofd = new OpenFileDialog();
                ofd.Multiselect = true;

                //If the user chose a file to Import;
                if ((ofd.ShowDialog() == DialogResult.OK & ofd.CheckFileExists == true))
                {

                    //Make sure the ActionList is Empty;
                    ActionList.Clear();

                    //For each selected file;
                    foreach (string FileName in ofd.FileNames)
                    {

                        //Regex;
                        var regex = new Regex("^.{5,}:.{6,}$", RegexOptions.Multiline);

                        //Use Regex and Match all Combo's with proper syntax;
                        //Remove Non-ASCII Characters, Spaces And NUL/Control Characers then output the final combo;
                        var Combos = regex.Matches(File.ReadAllText(FileName)).OfType<Match>().Select(x => {
                            return Regex.Replace(Regex.Replace(x.ToString(), "[^\\u0000-\\u007F]+", "").Replace(" ", ""), "\\p{C}+", "");
                        }).Distinct(StringComparer.CurrentCultureIgnoreCase).ToArray();

                        //Add the final Combo's to the ActionList;
                        ActionList.AddRange(Combos);

                    }

                    return true;

                }

                return false;

            }
            catch
            {
                return false;
            }

        }
        private bool Export()
        {

            //If the ActionList isn't Empty;

            if (ActionList.Count > 0)
            {

                //Create a SaveFileDialog;
                SaveFileDialog sfd = new SaveFileDialog();
                TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
                int epoch = (int)t.TotalSeconds;
                sfd.FileName = "SAIO - " + epoch.ToString();
                sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.FilterIndex = 1;
                sfd.RestoreDirectory = true;

                //If the user chose a place to Export;
                if (sfd.ShowDialog() == DialogResult.OK)
                {

                    //Use StreamWrite to write to the selected file;
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {

                        //Sort by Alphabetical order and remove Duplicates;
                        ActionList.Sort();
                        dynamic items = ActionList.Distinct().ToArray();

                        //Write all ActionList's item's to a file one line at a time;
                        foreach (string item in items)
                        {
                            sw.WriteLine(item.Replace("\r", "").Replace("\n", "").ToString());
                        }

                    }

                    //Clear the ActionList as it's items are no longer needed;
                    ActionList.Clear();

                    return true;
                    
                }
                else
                {
                    return false;

                }


            }
            else
            {

                MessageBox.Show("Nothing to Export.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;

            }

        }

        #endregion
        #region Settings
        
        #region Themes

        #region Default

        private void Theme_Default_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.WindowColor = Theme_Default.BackColor;
            Properties.Settings.Default.HighlightColor = Theme_Default2.BackColor;
            Properties.Settings.Default.DisabledColor = Color.FromArgb(90, 90, 90);
            Properties.Settings.Default.AlertColor = Color.IndianRed;
            Properties.Settings.Default.FontColor = Color.White;
            Properties.Settings.Default.IconColor = Color.White;
            InvalidateColors();
        }

        #endregion
        #region Dark

        private void Theme_Dark_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.WindowColor = Theme_Dark.BackColor;
            Properties.Settings.Default.HighlightColor = Theme_Dark2.BackColor;
            Properties.Settings.Default.DisabledColor = Color.FromArgb(90, 90, 90);
            Properties.Settings.Default.AlertColor = Color.IndianRed;
            Properties.Settings.Default.FontColor = Color.White;
            Properties.Settings.Default.IconColor = Color.White;
            InvalidateColors();
        }

        #endregion

        #endregion
        #region Auto-Check Proxies After Grabbing

        private void AutoCheckProxies_CheckedChanged(object sender, EventArgs e)
        {

            if (AutoCheckProxies.Checked == true) {
                Properties.Settings.Default.AutoCheckProxies = true;
            }
            else
            {
                Properties.Settings.Default.AutoCheckProxies = false;
            }

        }

        #endregion
        #region Auto-Export
        private void AutoExport_CheckedChanged(object sender, EventArgs e)
        {

            if (AutoExport.Checked == true)
            {
                Properties.Settings.Default.AutoExport = true;
            }
            else
            {
                Properties.Settings.Default.AutoExport = false;
            }

        }
        #endregion

        #endregion

    }

}
