using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;



namespace TubeRun
{
    public class SingleInstance
    {
        private const int ERROR_ALREADY_EXISTS = 183;

        [DllImport("coredll.dll", EntryPoint = "GetLastError")]
        private static extern int GetLastError();

        [DllImport("coredll.dll", EntryPoint = "CreateMutexW")]
        private static extern int CreateMutex(IntPtr lpMutexAttributes, bool InitialOwner, string MutexName);

        public static Boolean IsInstanceRunning()
        {
            GetLastError(); 
            CreateMutex(IntPtr.Zero, true, "TubeRun");
            int errNr = GetLastError();
            return (errNr !=0);
        }


    }

}
