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
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        public void btnCancel_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Settings closed without saving on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "\n");
            this.Close();
            Refresh();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Settings saved on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "\n");
            this.Close();
            Refresh();
        }

        private void settings_Load(object sender, EventArgs e)
        {

        }
    }
}
