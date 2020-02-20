using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;


namespace Demo
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
            Variables.InitCasedata();

            tbExportfolder.Text = Variables.tmpExportDir.ToString();
            tbtempWorkDir.Text = Variables.tmpWorkDir.ToString();
            Refresh();
        }


        public void btnCancel_Click(object sender, EventArgs e)
        {
            Form1._Form1.txtConsole.AppendText("Settings closed without saving on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + Environment.NewLine);
            this.Close();
            Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.tmpExportDir = tbExportfolder.Text;
            Properties.Settings.Default.tmpWorkDir = tbtempWorkDir.Text;
            Properties.Settings.Default.Save();
            Variables.tmpExportDir = tbExportfolder.Text;
            Variables.tmpWorkDir = tbtempWorkDir.Text;
            this.Close();
            Refresh();

            Form1._Form1.txtConsole.AppendText("Settings saved on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + Environment.NewLine);
            Form1._Form1.txtConsole.AppendText("Temporary work folder changed to : " + Properties.Settings.Default.tmpWorkDir.ToString() + Environment.NewLine);
            Form1._Form1.txtConsole.AppendText("Temporary export folder changed to : " + Properties.Settings.Default.tmpExportDir.ToString() + Environment.NewLine);
        }
    }
}
