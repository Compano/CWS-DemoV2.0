using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Cases
{
    /// <summary>
    /// Update product / prijsinfo data
    /// </summary>
    public static class Case09
    {
        internal static void Execute()
        {
            //Client.Init("http://www.online.compano.nl/");
            //// Client.Init("http://localhost:51114/");

            //string sessionHandle, result, xml;

            //result = Client.Application.Login("webservices", "test", "CWS-Demo", out sessionHandle);
            //// result = Client.Application.Login("xxxxx", "Test", "local", out sessionHandle);
            //TestCase.ShowResult(result, "Login");

            //// Set brand of product
            //var mutXml = @"
            //                <prdproduct>
            //                    <brand>NewBrand</brand>
            //                </prdproduct>";
            //result = Client.PRDProduct.Update(sessionHandle, new ClientPRDProduct.ProductKey() { ManufacturerCode = "WIL", Code = "123456" }, mutXml);
            //TestCase.ShowResult(result, "PRDProduct_Update", mutXml);

            //// Set new price of item
            //result = Client.PRDItem.UpdatePriceInfo(sessionHandle, new ClientPRDItem.ItemKey() { SalesOrganizationCode = "BER", Code = "193455" }, DateTime.Today, 145.00, 1.0);
            //TestCase.ShowResult(result, "UpdatePriceInfo", mutXml);

            //result = Client.Application.Logout(sessionHandle);
            //TestCase.ShowResult(result, "Logout");

            //Client.Init("http://pimtest.compano.com/"); 
    
            Client.Init("https://pimtest.compano.com/services/");
            var sessionHandle = "";

            var result = Client.Application.Login("webservice_test", "huV4UGh", "CWS-Demo", out sessionHandle);
            TestCase.ShowResult(result, "Login");

            var mutXml = @"
                            <prditem>
                                <status>Runin</status>
                                <IsInventory>true</IsInventory>
                                <Master_packing_length>2</Master_packing_length>
                            </prditem>";
            result = Client.PRDItem.Update(sessionHandle, new ClientPRDItem.ItemKey()
            {
                SalesOrganizationCode = "OPP_NL",
                Code = "140056301"

            },  mutXml);
            TestCase.ShowResult(result, "PRDItem_Update", mutXml);


            // Set new price of item
            result = Client.PRDItem.UpdatePriceInfo(sessionHandle, new ClientPRDItem.ItemKey()
            {
                   SalesOrganizationCode = "OPP_NL"
                   , Code = "140056301"
            }, DateTime.Today, 145.00, 1.0);
            TestCase.ShowResult(result, "UpdatePriceInfo", mutXml);


            result = Client.Application.Logout(sessionHandle);
            TestCase.ShowResult(result, "Logout");
        }
    }
}
