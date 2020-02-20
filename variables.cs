using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Windows.Forms;

namespace Demo
{

    public class Variables 
    {
        public static string caseID = "";
        public static string caseDesc = "";
        public static string tmpWorkDir = "";
        public static string tmpExportDir = "";
        public static string url = "";
        public static string username = "";
        public static string password = "";
        public static string companyname = "";
        public static bool showXMLdata;

        public static void InitCasedata()
        {
            Variables.tmpWorkDir = Properties.Settings.Default.tmpWorkDir.ToString();
            Variables.tmpExportDir = Properties.Settings.Default.tmpExportDir.ToString(); ;
        }

   

    }



}