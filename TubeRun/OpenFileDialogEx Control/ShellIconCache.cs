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
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MobilePractices.OpenFileDialogEx
{
    // Implements a cache for shell icons that represent specific
    // directories or files within the file system.
    internal class ShellIconCache
    {
        private ImageList imageList;
        private Dictionary<int, int> shellIndexToOurIndex = new Dictionary<int, int>();

        /// <summary>
        /// Creates a shell icon cache and associates it with a given managed image list.
        /// </summary>
        /// <param name="imageList">The image list to cache the shell icons in</param>
        public ShellIconCache(ImageList imageList)
        {
            // Determine the correct icon size based upon
            // the current screen DPI and resolution settings
            int cx = GetSystemMetrics(SM_CXSMICON);
            int cy = GetSystemMetrics(SM_CYSMICON);

            // Store the image list and set
            // it's size to suit the shell icons
            this.imageList = imageList;
            imageList.ImageSize = new Size(cx, cy);
        }

        /// <summary>
        /// Returns an icon that should be utilised to represent the specified path
        /// within a directory listing.
        /// </summary>
        /// <param name="path">The path (directory or file name) to fetch an icon for</param>
        /// <returns>The index into the image list for the icon associated with the path</returns>
        public int this[string path]
        {
            get
            {
                // Determine the index of the icon in the system image list
                SHFILEINFO shinfo = new SHFILEINFO();
                IntPtr hImageList = SHGetFileInfo(path, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_SYSICONINDEX | SHGFI_SMALLICON);

                // If we haven't fetched this icon yet
                if (!shellIndexToOurIndex.ContainsKey(shinfo.iIcon))
                {
                    // Fetch the icon
                    IntPtr hIcon = ImageList_GetIcon(hImageList, shinfo.iIcon, ILD_NORMAL);
                    Icon myIcon = Icon.FromHandle(hIcon);
                    DestroyIcon(hIcon);

                    // And add it to our managed image list
                    shellIndexToOurIndex.Add(shinfo.iIcon, imageList.Images.Count);
                    imageList.Images.Add(myIcon);
                }

                // Return the index of the icon to use for this path.
                return shellIndexToOurIndex[shinfo.iIcon];
            }
        }

        #region Platform Invoke
        private const uint SHGFI_SYSICONINDEX = 0x000004000;   // get system icon index
        private const uint SHGFI_SMALLICON = 0x1; // Small icon

        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public Int32 iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        [DllImport("coredll.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        private const uint ILD_NORMAL = 0x00;

        [DllImport("coredll.dll")]
        private static extern IntPtr ImageList_GetIcon(IntPtr himl, int i, uint flags);

        [DllImport("coredll.dll")]
        private static extern int DestroyIcon(IntPtr hIcon);

        private const int SM_CXSMICON = 49;
        private const int SM_CYSMICON = 50;

        [DllImport("coredll.dll")]
        private static extern int GetSystemMetrics(int nIndex);
        #endregion
    }
}
