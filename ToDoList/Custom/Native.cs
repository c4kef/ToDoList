using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Custom;

public class Native
{
    [DllImport("ToDoLib.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "MyMessageBox")]
    private static extern void MessageBox(string message, string title);
    
    [DllImport("user32.dll", SetLastError = true, CharSet= CharSet.Auto)]//https://www.pinvoke.net/default.aspx/user32.messagebox
    private static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

    public static void MyMessageBox(string message, string title)
    {
        if (File.Exists("ToDoLib.dll"))
            MessageBox(message, title);
        else
            MessageBox(IntPtr.Zero, message, title, 0);
    }
}