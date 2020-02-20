using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Linq;
using System.Collections;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()

        {
            InitializeComponent();
            _Form1 = this;

            //Setting default settings
            Variables.InitCasedata();

            // Initial caseID set to 'case01'
            Variables.caseID = "case01";
            Variables.url = "https://test.online.compano.nl/MessageService.asmx";
            Variables.username = "webservices";
            Variables.password = "test";
           
            var resourceSet = Properties.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentUICulture, true, true);
            var caseArray = resourceSet.OfType<DictionaryEntry>()
                .Select((item, i) => new { item.Key, item.Value })
                .ToArray();
            
            // Populate combobox with cases
            AddToCombo(caseArray, comboBox1);           
            comboBox1.ValueMember = "Key";
            comboBox1.DisplayMember = "Key";
            txtConsole.AppendText("Starting application on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + Environment.NewLine);
        }

        public static Form1 _Form1;

        public void update(string message)
        {
            txtConsole.Text = message;
        }


        public void btnStart_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please select any case from list.");
            }
            else
            {
                txtConsole.AppendText("Starting " + comboBox1.Text + " on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:tt") + Environment.NewLine + "===================START===================" + Environment.NewLine);

                if (comboBox1.Text == "Case 01") { Cases.Case01.Execute(); }
                if (comboBox1.Text == "Case 02") { Cases.Case02.Execute(); }
                if (comboBox1.Text == "Case 03") { Cases.Case03.Execute(); }
                if (comboBox1.Text == "Case 04") { Cases.Case04.Execute(); }
                if (comboBox1.Text == "Case 05") { Cases.Case05.Execute(); }
                if (comboBox1.Text == "Case 06") { Cases.Case06.Execute(); }
                if (comboBox1.Text == "Case 07") { Cases.Case07.Execute(); }
                if (comboBox1.Text == "Case 08") { Cases.Case08.Execute(); }
                if (comboBox1.Text == "Case 09") { Cases.Case09.Execute(); }
                if (comboBox1.Text == "Case 10") { Cases.Case10.Execute(); }
                if (comboBox1.Text == "Case 11") { Cases.Case11.Execute(); }
                if (comboBox1.Text == "Case 12") { Cases.Case12.Execute(); }
                if (comboBox1.Text == "Case 13") { Cases.Case13.Execute(); }
                //if (comboBox1.Text == "Case 14") { Cases.Case14.Execute(); }
                //if (comboBox1.Text == "Case 15") { Cases.Case15.Execute(); }
                //if (comboBox1.Text == "Case 16") { Cases.Case16.Execute(); }
                txtConsole.AppendText(Environment.NewLine + "===================END============================" + Environment.NewLine + comboBox1.Text + " done on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + Environment.NewLine);
                Refresh();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            txtConsole.AppendText("Program closed by user at " + comboBox1.Text.ToString() + Environment.NewLine);
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtConsole.AppendText(Environment.NewLine + "Changed case to " + comboBox1.Text.ToString() + Environment.NewLine);
            tbWebserviceURL.Text = Variables.url;
            tbUsername.Text = Variables.username;
            tbPassword.Text = Variables.password;
            tbCompanyName.Text = Variables.companyname;

            //tbCaseDesc.Text = comboBox1.SelectedItem.ToString();
            tbCaseDesc.Text = (comboBox1.SelectedItem).ToString();

            RefreshForm();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
            Form1.ActiveForm.Refresh();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settings settingsForm = new settings();
            settingsForm.Show();
            RefreshForm();
        }

        public void RefreshForm()
        {
            tbWebserviceURL.Text = Variables.url;
            tbUsername.Text = Variables.username;
            tbPassword.Text = Variables.password;
            tbPassword.UseSystemPasswordChar = false;
            tbCompanyName.Text = Variables.companyname;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            RefreshForm();
            txtConsole.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.compano.nl");
        }

        public void AddToCombo(Array array, ComboBox c)
        {
            foreach (var a in array)
            {
                c.Items.Add(a);
            }
        }

        public string updateConsoleText
        {
            get { return txtConsole.Text; }
            set { txtConsole.Text = value; }
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            Variables.username = tbUsername.Text;
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            Variables.password = tbPassword.Text;
        }

        private void tbCompanyName_TextChanged(object sender, EventArgs e)
        {
            Variables.companyname = tbCompanyName.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                    }
    }

}