using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Demo.Cases
{
    /// <summary>
    /// In en uitloggen
    /// </summary>
    public class Case01 : Form1
    {
        private static string sessionHandle,result;

        internal static void Execute()
        {

            var process = new Process();

            try
            {
                
                Client.Init(Variables.url);
                result = Client.Application.Login(Variables.username.ToString(), Variables.password.ToString(), Variables.companyname.ToString(), out sessionHandle);
                TestCase.ShowResult(result, "Login");

                result = Client.Application.Logout(sessionHandle);
                TestCase.ShowResult(result, "Logout");
            }

            catch (Exception ex)
            {
                _Form1.txtConsole.AppendText("Er is een foutmelding opgetreden:");
                _Form1.txtConsole.AppendText(ex.Message);
                process.Close();
            }

            finally
            {
                process.Close();
                TestCase.ShowResult(result, "Logout");
            }
        }
    }
}
