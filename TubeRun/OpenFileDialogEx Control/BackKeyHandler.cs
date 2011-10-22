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
using Microsoft.WindowsCE.Forms;
using System.Runtime.InteropServices;

namespace MobilePractices.OpenFileDialogEx
{
    // .NET CF 2.0 has a "bug" where you don't get a chance to handle
    // the Back (<--) key once a ListView or similiar control has been
    // added to a form (even if the KeyPreview property is set). This
    // class implements a work around that enables us to fire a
    // "BackKeyPress" event whenever the user presses the back key.
    // This work around isn't needed if using .NET CF 3.5 since it
    // appears the problem has been resolved in that release of the
    // framework.
    public class BackKeyHandler : MessageWindow
    {
        public EventHandler BackKeyPress;

        public BackKeyHandler()
        {
            // register to listen for the back key
            UnregisterFunc1(0x1000, VK_TBACK);
            RegisterHotKey(this.Hwnd, 100, 0x1000, VK_TBACK);
        }

        ~BackKeyHandler()
        {
            // stop listening for back key presses
            UnregisterHotKey(this.Hwnd, 100);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                if ((int)m.WParam == 100)
                {
                    // Back key has been pressed so fire our
                    // event
                    EventHandler eh = BackKeyPress;
                    if (eh != null)
                    {
                        eh(this, null);
                    }
                }
            }

            base.WndProc(ref m);
        }

        #region Platform Invoke

        private const int VK_TBACK = 0x1b;
        private const int WM_HOTKEY = 0x0312;

        [DllImport("coredll.dll")]
        public static extern int UnregisterFunc1(int modifiers, int key);

        [DllImport("coredll.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int Modifiers, int key);

        [DllImport("coredll.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        #endregion
    }
}
