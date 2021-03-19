using System;
using System.Diagnostics;
using System.Threading;
using System.Management;
using Servises.Modells;

namespace Servises
{

    /// <summary>
    /// Get cpu information.
    /// Can only be used on windows. Mac and Linux will throw exeption.
    /// </summary>
    public class Get_Cpu
    {
        public static CpuModell Return_Cpu_Name()
        {
            CpuModell cpumodell = new CpuModell();

            ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Processor");

            try
            {
                foreach (ManagementObject obj in myProcessorObject.Get())
                {
                    cpumodell.Name                  = (string)obj["Name"];
                    cpumodell.NumberOfCores         = (uint)obj["NumberOfCores"];
                    cpumodell.DeviceID              = (string)obj["DeviceID"];
                    cpumodell.Caption               = (string)obj["Caption"];
                    cpumodell.Architecture          = (ushort)obj["Architecture"];
                    cpumodell.Manufacturer          = (string)obj["Manufacturer"];
                    cpumodell.NumberOfEnabledCore   = (uint)obj["NumberOfEnabledCore"];
                    cpumodell.NumberOfLogicalProcessors = (uint)obj["NumberOfLogicalProcessors"];
                }
                return cpumodell;
            }
            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }
        }
    }
}
