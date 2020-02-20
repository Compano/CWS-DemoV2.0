using System;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;
using System.Collections.Generic;

namespace Demo
{
    
    static class Program
    {
        static Form1 MyForm;

        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MyForm = new Form1();
            Application.Run(MyForm);
        }

    }
}
