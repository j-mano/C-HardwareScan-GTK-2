using System;
using Gtk;
using System.Security.Principal;
using Servises;
using Servises.TempProgramImportApi;
using System.Collections.Generic;
using Servises.Modells;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        // Load in everyting at boot
        // Codeexample: printout ( getInfoFunction )

        PrintOutCPU(getCpu());
        PrintOutGPU(getAktivGpu());
        PrintOutRam(getRam());
        PrintOutGPUS();
        PrintOutOs(getOS());
        printOutAdmin();
        PrintOutVRam(getVram());
        PrintOutCPUTread(getCpusTreads());
    }

    /// <summary>
    /// Closes the aplication.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="a">The alpha component.</param>
    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    private string getCpu()
    {
        string returnstring = "";

        OpenHardwareCpu CpuInfo = new OpenHardwareCpu();

        try
        {
            returnstring = CpuInfo.returnCpuName().ToString();
        }
        catch
        {
            returnstring = "error retriving cpuinfo";
        }

        return Get_Cpu.Return_Cpu_Name().Name;
    }

    private float getCPUTemp()
    {
        float returnCpuTemp = 0F;

        return returnCpuTemp;
    }

    private int getCpusTreads()
    {
        int returnCpuTreads = (int)Get_Cpu.Return_Cpu_Name().NumberOfCores;

        return returnCpuTreads;
    }

    private string getAktivGpu()
    {
        string returngpu = "GPU";

        return returngpu;
    }

    private string getOS()
    {
        string returnOS= "OS";

        return returnOS;
    }

    private void getGpus()
    {

    }

    private string getRam()
    {
        string returnRam = "RAM";

        return returnRam;
    }

    private string getVram()
    {
        string returnVRam = "RAM";

        return returnVRam;
    }

    private bool getAdmin()
    {
        bool returnAdmin = false;

        return returnAdmin;
    }

    private void printOutAdmin()
    {
        using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
        {
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            IsAdminPrintOutlbl.Text = principal.IsInRole(WindowsBuiltInRole.Administrator).ToString();
        }
    }

    private void PrintOutCPU(string cpuName)
    {
        Cpu_LBL_PrintOut.Text = cpuName;
    }

    private void PrintOutCPUTread(int NumbofTreads)
    {
        CpuTreadPrintOutLBL.Text = NumbofTreads.ToString();
    }

    private void PrintOutRam(string ramAmount)
    {
        SysRamPrintOutlbl.Text = ramAmount;
    }

    private void PrintOutVRam(string ramAmount)
    {
        VramPrintoutlbl.Text = ramAmount;
    }

    private void PrintOutGPU(string gpuName)
    {
        AktivGPUPrintOutLBL.Text = gpuName;
    }

    private void PrintOutGPUsList()
    {

    }

    private void PrintOutOs(string osVersion)
    {
        OSVERSIONPrintOutLBL.Text = osVersion;
    }

    private void PrintOutCpuTemp(float cpuTemp)
    {
        CPUTEMPPrintout.Text = cpuTemp.ToString();
    }

    private void PrintOutGPUS()
    {
        Widget piggy = new Label("nvidia piggy gristekxeon 660");
    }

}
