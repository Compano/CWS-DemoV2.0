using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Cases
{
    /// <summary>
    /// Export ETIM Classification Data 
    /// </summary>
    public static class Case08
    {
        internal static void Execute()
        {
            Client.Init("http://www.online.compano.nl/");

            string sessionHandle, result, xml;

            result = Client.Application.Login("webservices", "test", "CWS-Demo", out sessionHandle);
            TestCase.ShowResult(result, "Login");

            // Set specified language
            Client.Application.SetOutputCulture(sessionHandle, "FR-fr");

            var filterElements = new List<ClientICSClass.FilterElement>
            {
                new ClientICSClass.FilterElement
                {
                    FieldName = ClientICSClass.ClassFilterField.ProductCount.ToString(),
                    ConditionType = ClientICSClass.ConditionTypeOption.GreaterThan,
                    Value1 = "0"
                }
            };
            // Get class info specific classcode
            result = Client.ICSClass.SelectUsingLayoutAsXml(sessionHandle, filterElements.ToArray(), "ETIM", out xml);
            TestCase.ShowResult(result, "SelectUsingLayoutAsXml", xml);

            result = Client.Application.Logout(sessionHandle);
            TestCase.ShowResult(result, "Logout");
        }
    }
}
