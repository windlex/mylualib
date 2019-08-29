using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace Terraria
{
    public static class Konsole
    {
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole(); 

        public static void Open()
        {
            AllocConsole();
            Console.WriteLine("注意：启动程序...");
            Console.WriteLine("\tWritten by wuming");
            Console.WriteLine("{0}：{1}", "警告", "这是一条警告信息。");
            Console.WriteLine("{0}：{1}", "错误", "这是一条错误信息！");
            Console.WriteLine("{0}：{1}", "注意", "这是一条需要的注意信息。");
            Console.WriteLine("");
        }
    }
}
