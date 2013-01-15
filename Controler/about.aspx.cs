using System;
using GS.Utility;
using System.Runtime.InteropServices;



public partial class Controler_about : System.Web.UI.Page
{
    public string ramStatusStr = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Tools.authentication(this, "1");
        getRamStatus();
    }
    [DllImport("kernel32")]
    public static extern void GlobalMemoryStatus(ref MEMORY_INFO meminfo);
    //定义内存的信息结构 
    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORY_INFO
    {
        public uint dwLength;
        public uint dwMemoryLoad;
        public uint dwTotalPhys;
        public uint dwAvailPhys;
        public uint dwTotalPageFile;
        public uint dwAvailPageFile;
        public uint dwTotalVirtual;
        public uint dwAvailVirtual;
    }

    protected void getRamStatus()
    {
        MEMORY_INFO MemInfo;
        MemInfo = new MEMORY_INFO();
        GlobalMemoryStatus(ref MemInfo);
        ramStatusStr = "<b>系统内存使用情况：</b><br/>内存使用率：<div class=\"graph\"><strong class=\"bar\" style=\"width:"
    + MemInfo.dwMemoryLoad.ToString() + "%;\">" + MemInfo.dwMemoryLoad.ToString() + "%</strong></div>物理内存共有"
            + (Convert.ToDouble(MemInfo.dwTotalPhys) / 1024 / 1024).ToString("N2") + "MB；<br/>可使用的物理内存有"
        + (Convert.ToDouble(MemInfo.dwAvailPhys) / 1024 / 1024).ToString("N2") + "MB；<br/>交换文件总大小为"
        + (Convert.ToDouble(MemInfo.dwTotalPageFile) / 1024 / 1024).ToString("N2") + "MB；<br/>尚可交换文件大小为"
        + (Convert.ToDouble(MemInfo.dwAvailPageFile) / 1024 / 1024).ToString("N2") + "MB；<br/>总虚拟内存有"
        + (Convert.ToDouble(MemInfo.dwTotalVirtual) / 1024 / 1024).ToString("N2") + "MB；<br/>未用虚拟内存有"
        + (Convert.ToDouble(MemInfo.dwAvailVirtual) / 1024 / 1024).ToString("N2") + "MB。";

    }
}