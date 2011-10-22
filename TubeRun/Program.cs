using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.Security.Cryptography;

namespace TubeRun
{

    static class Program
    {
        static Boolean USEPROTECTION = false;
        [DllImport("coredll.dll", EntryPoint = "FindWindowW", SetLastError = true)]
        private static extern IntPtr FindWindowCE(string lpClassName, string lpWindowName);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hwnd);
        [DllImport("coredll.dll", EntryPoint = "CloseHandle")]
        internal static extern int CloseHandle(IntPtr hObject);
        static string m_certModulus = "g26T2qnMKdyfWSaI5JOdzQ7/TRJjFHHr7U+i0KP9SSGK07fmW3B+oatjiQFJwxHrJlLIYkmNiA645cygc1WFtNqfr/O5TRCYt+i4U8UAnkhlClVasccywhRnHEpYqEs/qfcAwtv8o3GURtHC8kWSOFy5YJIqDjwantsjyIrDEiE=";
        static string m_certExponent = "AQAB";
        static string m_appSku = "5c81cd0d-3308-44bc-a928-2334cfceebf0";
        [DllImport("coredll.dll")]
        private extern static int GetDeviceUniqueID([In, Out] byte[] appdata, int cbApplictionData, int dwDeviceIDVersion, [In, Out] byte[] deviceIDOuput, out uint pcbDeviceIDOutput);

        [MTAThread]
        static void Main()
        {
            bool isAlreadyRunning = SingleInstance.IsInstanceRunning();
            if (isAlreadyRunning)
            {
                IntPtr hw;
                if ((hw = FindWindowCE(null, "TubeRun")) != IntPtr.Zero)
                {
                    SetForegroundWindow((IntPtr)((int)hw | 0x01));
                    CloseHandle(hw);
                }
                return;
            }
            if (USEPROTECTION)
            {
                try
                {
                    byte[] licenseBytes = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Security\\Software\\Microsoft\\Marketplace\\Licenses\\").GetValue(m_appSku) as byte[];
                    string data = m_appSku.ToLower() + " " + GetUniqueDeviceID();
                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                    //Create a new instance of RSAParameters.
                    RSAParameters RSAKeyInfo = new RSAParameters();
                    //Set RSAKeyInfo to the public key values. 
                    RSAKeyInfo.Modulus = Convert.FromBase64String(m_certModulus);
                    RSAKeyInfo.Exponent = Convert.FromBase64String(m_certExponent);
                    rsa.ImportParameters(RSAKeyInfo);
                    byte[] bData = System.Text.Encoding.ASCII.GetBytes(data);
                    if ((null == licenseBytes || !rsa.VerifyData(bData, new SHA1CryptoServiceProvider(), licenseBytes)))
                    {
                        MessageBox.Show("You don't have a valid licence for TubeRun. Please, reinstall it from Marketplace.", "TubeRun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    else
                    {
                        startApp();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Windows Mobile Marketplace is not installed.", "TubeRun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                try
                {
                    startApp();
                }
                catch (Exception)
                {
                }
            }

        }

        private static void startApp()
        {
            Toolbox.setSettings();
            if (Toolbox.getSetting("1rstrun").Equals("No"))
            {
                FormMainN form;
                String scr = Toolbox.getSetting("screentype");
                if (scr.Equals("wide"))
                {
                    form = new FormMainW();
                }
                else form = new FormMainN();
                Application.Run(form);
            }
            else
            {
                FormNotes nf = new FormNotes(null);
                Application.Run(nf);
            }
        }

        public static string GetUniqueDeviceID()
        {
            // Call the GetDeviceUniqueID
            byte[] appData = Encoding.Unicode.GetBytes("Marketplace");
            int appDataSize = appData.Length;
            byte[] outData = new byte[20];
            uint outSize = 20;
            GetDeviceUniqueID(appData, appDataSize, 1, outData, out outSize);
            StringBuilder resultSB = new StringBuilder();
            foreach (byte b in outData)
            {
                resultSB.Append(string.Format("{0:x2}", b));
            }
            return resultSB.ToString();
        }
    }
}