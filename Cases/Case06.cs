using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Cases
{
    /// <summary>
    /// Aanmaken van een feed lay-out
    /// </summary>
    public static class Case06
    {
        internal static void Execute()
        {
            Client.Init("http://www.saniceve.compano.com/");

            string sessionHandle, xml;

            var result = Client.Application.Login("webservices", "test", "CWS-Demo", out sessionHandle);
            TestCase.ShowResult(result, "Login");
            // Example item
            var filterElements = new List<ClientPRDItem.FilterElement>
            {
                new ClientPRDItem.FilterElement
                {
                    FieldName = ClientPRDItem.ItemFilterField.ItemSetCode.ToString(),
                    ConditionType = ClientPRDItem.ConditionTypeOption.EqualsNoCase,
                    Value1 = "SCV2"
                },
                new ClientPRDItem.FilterElement
                {
                    FieldName = ClientPRDItem.ItemFilterField.PurchaseOrganizationCode.ToString(),
                    ConditionType = ClientPRDItem.ConditionTypeOption.EqualsNoCase,
                    Value1 = "VILA"
                },
                new ClientPRDItem.FilterElement
                {
                    FieldName = "niet_voorraadartikel",
                    ConditionType = ClientPRDItem.ConditionTypeOption.Equals,
                    Value1 = true
                }
            };
            //// Get item info
            result = Client.PRDItem.SelectUsingLayoutAsXml(sessionHandle, filterElements.ToArray(), "ERP_Feed", out xml);

            result = Client.Application.Logout(sessionHandle);
        }
    }
}
