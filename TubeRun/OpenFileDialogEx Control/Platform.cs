//-----------------------------------------------------------------------
// 
//  Copyright (C) MOBILE PRACTICES.  All rights reserved.
//  http://www.mobilepractices.com/
//
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//-----------------------------------------------------------------------

using System;
using System.Text;
using Microsoft.WindowsCE.Forms;
using System.Runtime.InteropServices;

namespace MobilePractices.OpenFileDialogEx
{
    // Some helper properties that determine what type of device
    // we are currently running on. .NET CF 3.5 provides similiar
    // functionality out of the box making this class redundant
    // if targeting that version of the framework.
    internal static class Platform
    {
        public static bool IsWindowsCE
        {
            get { return Environment.OSVersion.Platform == PlatformID.WinCE; }
        }

        // Returns true if the application is running on a
        // Windows Mobile Standard (i.e. Smartphone) device
        public static bool IsWindowsMobileStandard
        {
            get { return IsWindowsCE && (GetSystemParameter(SPI_GETPLATFORMTYPE) == "SmartPhone"); }
        }

        #region Platform Invoke
        private const uint SPI_GETPLATFORMTYPE = 257;

        [DllImport("coredll.dll")]
        private static extern int SystemParametersInfo(uint uiAction, uint uiParam, StringBuilder pvParam, uint fWiniIni);

        private static string GetSystemParameter(uint uiParam)
        {
            StringBuilder sb = new StringBuilder(128);
            if (SystemParametersInfo(uiParam, (uint)sb.Capacity, sb, 0) == 0)
                throw new ApplicationException("Failed to get system parameter");
            return sb.ToString();
        }
        #endregion
    }
}
