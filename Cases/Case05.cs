using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Cases
{
    /// <summary>
    /// In en uitloggen
    /// </summary>
    public static class Case05
    {
        internal static void Execute()
        {
            Client.Init("http://www.online.compano.nl/");

            string sessionHandle, result, xml, url;

            result = Client.Application.Login("webservices", "test", "CWS-Demo", out sessionHandle);
            TestCase.ShowResult(result, "Login");

            result = Client.Application.Logout(sessionHandle);
            TestCase.ShowResult(result, "Logout");
        }
    }
}
