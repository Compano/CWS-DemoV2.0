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

        public static void InitCasedata()
        {
            #pragma warning disable CS0618 // Type or member is obsolete
            Variables.tmpWorkDir = ConfigurationSettings.AppSettings["tempWorkDir"].ToString();
            #pragma warning restore CS0618 // Type or member is obsolete

            #pragma warning disable CS0618 // Type or member is obsolete
            Variables.tmpExportDir = ConfigurationSettings.AppSettings["tempExportDir"].ToString();
            #pragma warning restore CS0618 // Type or member is obsolete




        }

   

    }



}