using Demo.ClientPRDItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Demo.Cases
{
    /// <summary>
    /// Examples for download items
    /// </summary>
    public class Case02 : Form1
    {
        internal static void Execute()
        {
            Client.Init("http://www.online.compano.nl/");
           // Client.Init(Form1.tbWebserviceURL)

            string sessionHandle, result, xml;

            result = Client.Application.Login("webservices", "test", "CWS-Demo", out sessionHandle);
            TestCase.ShowResult(result, "Login");

            //// Pak de key velden van artikel
            //var keyFields = new[]
            //{
            //        ClientPRDItem.ItemXmlField.ProductManufacturerCode,
            //        ClientPRDItem.ItemXmlField.ProductCode,
            //        ClientPRDItem.ItemXmlField.ProductGTIN,
            //        ClientPRDItem.ItemXmlField.Code,
            //        ClientPRDItem.ItemXmlField.DeepLink,
            //        ClientPRDItem.ItemXmlField.ItemSetCode,
            //        ClientPRDItem.ItemXmlField.ConditionGroupCode,
            //        ClientPRDItem.ItemXmlField.ConditionGroupDescription,
            //        ClientPRDItem.ItemXmlField.PriceDate,
            //        ClientPRDItem.ItemXmlField.PriceUnitCode,
            //        ClientPRDItem.ItemXmlField.GrossPriceInfoPrice,
            //        ClientPRDItem.ItemXmlField.OrderPrice,
            //        ClientPRDItem.ItemXmlField.PriceQuantity
            //    };

            //result = Client.PRDItem.Select(sessionHandle, null, null, "8711962101477", keyFields, out xml); 
 
            //if (xml == "")
            //    {
            //        TestCase.ShowResult(result, "XML had no data", false);
            //    return;
            //    }
      
            //TestCase.ShowResult(result, "Item Select", xml);
            //TestCase.ShowResult(result, "Result XML: \n" + XDocument.Parse(xml).ToString() + "\n\n");


            // meerder resultaten ophalen op basis van assortimentscode en conditiegroepcode
            var filterFields = new[] { ItemFilterField.ItemSetCode, ItemFilterField.ConditionGroupCode };
            var filterValues = new ArrayOfString { "SOL", "750031" };


            result = Client.PRDItem.Select(sessionHandle, filterFields, filterValues, "", new[]
                   {
                    ItemXmlField.Code,
                    ItemXmlField.SalesOrganizationCode,
                    ItemXmlField.ItemSetCode,
                    ItemXmlField.ConditionGroupCode,
                    ItemXmlField.Description,
                    ItemXmlField.GrossPricePerUtilizationUnit
                    }, out xml);

            if (xml == "")
            {
                TestCase.ShowResult(result, "XML had no data", false);
                return;
            }

            TestCase.ShowResult(result, "Item select multiple records (array) ", xml);
            //TestCase.ShowResult(result, "Result XML: \n" + XDocument.Parse(xml).ToString() + "\n\n");


            //// Convert xml result in ProductKeys
            //var element = XElement.Parse(xml);
            //var productKeys = element.Elements().Take(10)
            //    .Select(e => new ClientPRDProduct.ProductKey() { ManufacturerCode = e.Element("productmanufacturercode").Value, Code = e.Element("productcode").Value }).ToArray();

            //var fields = new[] { ClientPRDProduct.ItemXmlField.Description, ClientPRDProduct.ItemXmlField.GrossPricePerUtilizationUnit, ClientPRDProduct.ItemXmlField.Availability, ClientPRDProduct.ItemXmlField.ProductManufacturerGLNCode };

            //result = Client.PRDProduct.GetItems(sessionHandle, productKeys[0], null, fields, out xml);
            //TestCase.ShowResult(result, "GetItems", xml);
            //TestCase.ShowResult(result, "Result XML: \n" + XDocument.Parse(xml).ToString() + "\n\n");

            //result = Client.PRDProduct.GetItems(sessionHandle, null, new ClientPRDProduct.ProductKeyGTIN() { GTIN = "5710626495740" }, fields, out xml);
            //TestCase.ShowResult(result, "GetItems by GTIN", xml);
            //TestCase.ShowResult(result, "Result XML: \n" + XDocument.Parse(xml).ToString() + "\n\n");

            //var productkey = new ClientPRDProduct.ProductKey() { ManufacturerCode = "8712423008724", Code = "97924496" };
            //result = Client.PRDProduct.GetItems(sessionHandle, productkey, null, fields, out xml);
            ////result = Client.PRDProduct.GetItems(sessionHandle, null, new ProductKeyGTIN() { GTIN = "8711962101477" }, fields, out xml);
            //TestCase.ShowResult(result, "GetItems by GLN and Code", xml);
            //TestCase.ShowResult(result, "Result XML: \n" + XDocument.Parse(xml).ToString() + "\n\n");

            result = Client.Application.Logout(sessionHandle);
            TestCase.ShowResult(result, "Logout");
        }
    }
}
