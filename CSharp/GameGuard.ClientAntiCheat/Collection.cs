using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace GameGuard.ClientAntiCheat
{
    public class CollectInformation
    {
        public string RustClientCollectProcInf()
        {
            String str = String.Empty; //Empty String :D
            Process[] proc = Process.GetProcessesByName("RustClient");
            if(proc.Length == 1)
            {
                foreach(Process process in proc)
                {
                    str = "Process Name: " + process.ProcessName + Environment.NewLine + "Process Id: " + process.Id + Environment.NewLine + "Process Handle: " + process.Handle.ToString();
                }
            }
            return str;
        }
        public IntPtr GetEntryPointAddress()
        {
            return Process.GetCurrentProcess().MainModule.EntryPointAddress;
        }
        public IntPtr GetEntryRustPointAddress()
        {
            IntPtr entrypoint = IntPtr.Zero;
            Process[] proc = Process.GetProcessesByName("RustClient");
            foreach(Process red1234 in proc)
            {
                entrypoint = red1234.MainModule.EntryPointAddress;
            }
            return entrypoint;
        }
        public string CollectAboutDisk()
        {
            String disk = String.Empty;
            ManagementObjectSearcher mos = new ManagementObjectSearcher("ROOT\\CIMV2\\mdm\\dmmap", "SELECT * FROM Win32_Volume"); //Get Disk Information :D
            ManagementObjectCollection moc = mos.Get();
            foreach(ManagementObject m in moc)
            {
                disk = "Device ID: " + m.GetPropertyValue("DeviceID") + Environment.NewLine + "PNP DEVICE ID: " + m.GetPropertyValue("PNPDeviceID");
                if(disk == String.Empty)
                {
                    return "Unknown Disk"; //If Disk is Not Detected, Typing Unknown Disk :D
                }
            }
            return disk;
        }
        public bool CollectAboutPC()
        {
            Directory.CreateDirectory(@"C:\Program Files\GameGuardAntiCheat");
            if(Directory.Exists(@"C:\Program Files\GameGuardAntiCheat"))
            {
                WriteText text = new WriteText();
                text.WriteToTXT(@"C:\Program Files\GameGuardAntiCheat\Disk.txt", CollectAboutDisk());
                text.WriteToTXT(@"C:\Program Files\GameGuardAntiCheat\ProcessInfo.txt", RustClientCollectProcInf());
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
