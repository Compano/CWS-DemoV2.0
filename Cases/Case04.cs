using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.ClientPRDItemSet;

namespace Demo.Cases
{
    /// <summary>
    /// Ophalen van de beschikbare artikel downloads
    /// </summary>
    public class Case04 : Form1
    {
        internal static void Execute()
        {
            Client.Init("http://www.online.compano.nl/");

            string sessionHandle, result;

            int counter = 0;

            result = Client.Application.Login("webservices", "test", "CWS-Demo", out sessionHandle);
            TestCase.ShowResult(result, "Login");

            DownloadInfo[] files = new DownloadInfo[] { };

            result = Client.PRDItemSet.GetAvailableDownloads(sessionHandle, out files);
            TestCase.ShowResult(result, "GetAvailableDownloads");
            if (files.Count() > 0 && counter < 10)
            {
                _Form1.txtConsole.AppendText("Available downloads:");
                foreach (var file in files)
                    _Form1.txtConsole.AppendText(file.FileName + " url: " + file.Link);

                // Clear a specific file as available download
                // result = Client.PRDItemSet.DeleteDownload(sessionHandle, files[0].FileName);

                counter = counter + 1;


            }
            else
            {
                _Form1.txtConsole.AppendText("Er zijn geen bestanden beschikbaar voor download!");
            }
            result = Client.Application.Logout(sessionHandle);
            TestCase.ShowResult(result, "Logout");
        }
    }
}
