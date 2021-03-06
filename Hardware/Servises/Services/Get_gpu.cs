using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using Servises.Modells;

namespace Servises
{
    // windows only

    public class Get_gpu
    {
        /// <summary>
        /// Get information of the gpu
        /// Can only be used on windows. Mac and Linux will throw exeption.
        /// </summary>
        /// <returns>The name.</returns>
        public static GpuModell GpuInfo()
        {
            GpuModell Gpumodell = new GpuModell();

                ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");

            try
            {
                foreach (ManagementObject obj in myVideoObject.Get())
                {
                    Gpumodell.gpuName               = (string)obj["Name"];
                    Gpumodell.GpuStatus             = (string)obj["Status"];
                    Gpumodell.GpuAdapterRAM         = (uint)obj["AdapterRAM"];
                    Gpumodell.GpuVideoArchitecture  = (ushort)obj["VideoArchitecture"];
                    Gpumodell.GpuDriverVersion      = (string)obj["DriverVersion"];
                    Gpumodell.GpuVideoMemoryType    = (ushort)obj["VideoMemoryType"];
                    Gpumodell.GpuInstalledDisplayDrivers = (string)obj["InstalledDisplayDrivers"];
                    Gpumodell.GpuDeviceID           = (string)obj["DeviceID"];
                }

                var scope = new System.Management.ManagementScope();
                var q = new System.Management.ObjectQuery("SELECT * FROM CIM_VideoControllerResolution");

                using (var searcher = new System.Management.ManagementObjectSearcher(scope, q))
                {
                    var results = searcher.Get();
                    foreach (var item in results)
                    {
                        Gpumodell.GpuHighestResAmountSupport = item["Caption"].ToString();
                    }
                }

                return Gpumodell;
            }
            catch
            {
                throw;
            }
        }
    }
}
