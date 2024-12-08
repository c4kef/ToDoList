using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Custom;

public class Native
{
    [DllImport("ToDoLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void MyMessageBox(string message, string title);
}