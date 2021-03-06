using Servises.Modells;
using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace Servises
{
    public class MotherBoard
    {
        /// <summary>
        /// Gets the moder board info.
        /// Can only be used on windows. Mac and Linux will throw exeption.
        /// </summary>
        /// <returns>The moder board info.</returns>
        public static MotherBoardModell GetModerBoardInfo()
        {
            MotherBoardModell returninfo = new MotherBoardModell();

            ManagementObjectSearcher MotherboardInfoObject = new ManagementObjectSearcher("select * from Win32_BIOS");
            ManagementObjectSearcher baseboardSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectSearcher motherboardSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_MotherboardDevice");

            try
            {
                foreach (ManagementObject obj in MotherboardInfoObject.Get())
                {
                    returninfo.motherBoradBios = obj["SMBIOSBIOSVersion"].ToString();
                    returninfo.motherBoradBiosDate = (string)obj["ReleaseDate"];
                }

                foreach (ManagementObject queryObj in baseboardSearcher.Get())
                {
                    returninfo.motherBoardName = queryObj["Product"].ToString();
                }

                return returninfo;
            }
            catch
            {
                throw;
            }
        }
    }
}
