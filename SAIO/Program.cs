using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace SAIO
{
    static class Program
    {

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Properties.Settings.Default.Reset();
            //On Exit, Save Settings;
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            
            #region Check for an Update

        //If the user is Connected to the Internet;
            if (TestInternetConnection())
            {

                try
                {

                    //Using WebClient, get the Newest File Version;
                    using (System.Net.WebClient wc = new System.Net.WebClient())
                    {

                        //Latest Version;
                        string LatestVersion = wc.DownloadString("https://raw.githubusercontent.com/ImReallyShiny/SAIO/master/version.txt");
                        string ExecutableLocation = typeof(Program).Assembly.CodeBase.Replace("file:///", "");
                        string CurrentVersion = FileVersionInfo.GetVersionInfo(ExecutableLocation).ProductVersion;
                        string CurrentExecutableName = typeof(Program).Assembly.GetName().Name + "-" + LatestVersion + ".exe";

                        //If the Latest Version is Newer then the Current Version;
                        if (LatestVersion != CurrentVersion)
                        {
                            MessageBox.Show(CurrentExecutableName);
                            //Download the Latest Version of the EXE file;
                            wc.DownloadFile("https://github.com/ImReallyShiny/SAIO/raw/master/SAIO.exe", CurrentExecutableName);
                            
                            //Show a MessageBox asking to open Explorer to the file;
                            DialogResult mb = MessageBox.Show("Continue usage on the new update. Open Explorer and go to the Directory containing the updated .exe located at: " + ExecutableLocation.Replace("SAIO.EXE", CurrentExecutableName + " ?\""), "New Update Downloaded!", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            if (mb == DialogResult.Yes)
                            {
                                //Go to where SAIO is and select the New Update.exe;
                                Process.Start("explorer.exe", "/select,\"" + ExecutableLocation.Replace("/", "\\").Replace("SAIO.EXE", CurrentExecutableName) + "\"");
                            }

                        }
                        else
                        {

                            Application.EnableVisualStyles();
                            Application.SetCompatibleTextRenderingDefault(false);
                            Application.Run(new MainForm());

                        }

                    }
                    
                }
                catch (Exception ex)
                {

                    //Updating had an Unexpected Error;
                    MessageBox.Show("Please re-download SAIO manually as an Update Bug Occured! Error: " + ex.ToString(), "Update Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
                
            }
            else
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());

            }

            #endregion

        }

        #region Functions

        private static bool TestInternetConnection()
        {
            try
            {
                System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
                ping.Send("google.com");
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

    }
}
