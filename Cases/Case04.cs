using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.ClientPRJEstimate;

namespace Demo.Cases
{
    /// <summary>
    /// Aanmaken / toevoegen calculatie onderdelen / regels
    /// </summary>
    class Case04
    {
        internal static void Execute()
        {
            Client.Init("http://ttt.online.compano.nl/");

            var sessionHandle = "";
            var result = "";

            result = Client.Application.Login("webservices", "test", "CWS-Demo", out sessionHandle);
            TestCase.ShowResult(result, "Login");

            var xml = "";
            var updateXml = "";

            // Create estimate whith template SJ0001!
            var newXml = @"<prjestimate>
                                    <description>Test estimate</description>
                                    <customercontact>RE170001</customercontact>
                                    <customerlegalentity>RE140001</customerlegalentity>
                                    <sourcetemplate>SJ0001</sourcetemplate>
                                    <enduser>RE140001</enduser>
                                    <enduserlegalentity>RE140001</enduserlegalentity>
                                </prjestimate>";

            var estimateKey = (ClientPRJEstimate.EstimateKey)null;
            result = Client.PRJEstimate.Add(sessionHandle, newXml, out estimateKey);
            TestCase.ShowResult(result, "Add");

            // Create estimatePart
            var newPartXml = @"<prjestimatepart>
                                              <no>II</no>
                                              <description>Onderdeel</description>
                                              </prjestimatepart>";
            var partId = 0;
            result = Client.PRJEstimate.AddPart(sessionHandle, estimateKey, newPartXml, out partId);
            TestCase.ShowResult(result, "AddPart");

            var itemFields = new ClientPRDItem.ItemXmlField[]
            {
                ClientPRDItem.ItemXmlField.Code,
                ClientPRDItem.ItemXmlField.SalesOrganizationCode,
                ClientPRDItem.ItemXmlField.ItemSetCode,
                ClientPRDItem.ItemXmlField.Description
            };
            var itemKey = new ClientPRDItem.ItemKey() { SalesOrganizationCode = "REX", Code = "35100055" };

            result = Client.PRDItem.GetInfo(sessionHandle, new ClientPRDItem.ItemKey[] { itemKey }, itemFields, out xml);
            TestCase.ShowResult(result, "GetInfo 35100055", xml);

            // When xml is empty -> item NOT exists
            if (string.IsNullOrEmpty(xml))
            {
                // Add item
                newXml = @"<prditem>
                                    <code>35100055</code>
                                    <salesorganization>REX</salesorganization>
                                    <itemset>REX</itemset>
                                    <description>Description new item '35100055'</description>
                                  </prditem>";
                result = Client.PRDItem.Add(sessionHandle, newXml, out itemKey);
                TestCase.ShowResult(result, "AddItem");

                result = Client.PRDItem.GetInfo(sessionHandle, new ClientPRDItem.ItemKey[] { itemKey }, itemFields,
                    out xml);
                TestCase.ShowResult(result, "GetInfo 35100055", xml);
            }
            var materialLineId = 0;
            if (!string.IsNullOrEmpty(xml))
            {
                // When xml is filled item is exists or added succesfully!
                // Add itemXml with LineGroupCode
                //var newLineXml =
                //    "<prjestimatelines><prjestimateline><linetype>Material</linetype><LineGroupCode>1234</LineGroupCode><salesorganization>REX</salesorganization><resourcecode>35100055</resourcecode><quantity>1</quantity></prjestimateline></prjestimatelines>";
                //var linesIds = new ClientPRJEstimate.ArrayOfInt();

                //Client.PRJEstimate.AddLines(sessionHandle, partId, newLineXml, out linesIds);
                //TestCase.ShowResult(result, "AddLines 35100055", linesIds.ToString());

                //materialLineId = linesIds.Any() ? linesIds[0] : 0;
            }
            //  updateXml = "<prjestimateline><LineGroupCode>12345</LineGroupCode></prjestimateline>";

            // Update line with LineGroupCode
            //   result = Client.PRJEstimate.UpdateLine(sessionHandle, estimateKey, materialLineId, updateXml);
            //   TestCase.ShowResult(result, "GetLines New Line", xml);

            //// Add a element with a text line + material line!
            const string newHeaderXml = "<prjestimateline><description>Header line</description><quantity>2</quantity></prjestimateline>";
            const string newLinesXml = "<prjestimatelines><prjestimateline><description>Text line</description><linetype>Text</linetype></prjestimateline><prjestimateline><quantity>1.0</quantity><linetype>Material</linetype><salesorganization>WAP</salesorganization><resourcecode>001011298</resourcecode><LineGroupCode>12345</LineGroupCode><Installation_time>1 hour</Installation_time></prjestimateline></prjestimatelines>";
            var textLineIds = new ClientPRJEstimate.ArrayOfInt();
            int packLineId;

            result = Client.PRJEstimate.PackLines(sessionHandle, partId, newHeaderXml, newLinesXml, out packLineId);
            TestCase.ShowResult(result, "Add header line icluding textline / materialline");


            result = Client.PRJEstimate.GetLines(sessionHandle, partId,
                new ClientPRJEstimate.EstimateLineXmlField[]
                {
                    ClientPRJEstimate.EstimateLineXmlField.Description,
                    ClientPRJEstimate.EstimateLineXmlField.LineType, ClientPRJEstimate.EstimateLineXmlField.TotSales,
                    ClientPRJEstimate.EstimateLineXmlField.ResourceCode
                }, out xml);
            TestCase.ShowResult(result, "GetLines partId", xml);

            // Remove line
            // result = Client.PRJEstimate.RemoveLine(sessionHandle, estimateKey, packLineId);
            // TestCase.ShowResult(result, "GetLines New Line", xml);

            // Change purchaseItem for a salesitem
            //var itemKey = new ClientPRDItem.ItemKey() { SalesOrganizationCode = "BADERIE", Code = "10880001821" };

            //// Current values
            //var itemFields = new ClientPRDItem.ItemXmlField[]
            //{
            //    ClientPRDItem.ItemXmlField.Code,
            //    ClientPRDItem.ItemXmlField.SalesOrganizationCode,
            //    ClientPRDItem.ItemXmlField.ItemSetCode,
            //    ClientPRDItem.ItemXmlField.Description,
            //    ClientPRDItem.ItemXmlField.PurchaseOrganizationCode,
            //    ClientPRDItem.ItemXmlField.PurchaseCode
            //};

            //result = Client.PRDItem.GetInfo(sessionHandle, new ClientPRDItem.ItemKey[] { itemKey }, itemFields, out xml);
            //TestCase.ShowResult(result, $"GetInfo before {itemKey.SalesOrganizationCode}- {itemKey.Code}", xml);

            //updateXml = "<prditem><PurchaseOrganization>TU</PurchaseOrganization></prditem>";

            //// Update item with new purchase item
            //result = Client.PRDItem.Update(sessionHandle, itemKey, updateXml);

            //TestCase.ShowResult(result, "Update Item Line", updateXml);

            //result = Client.PRDItem.GetInfo(sessionHandle, new ClientPRDItem.ItemKey[] { itemKey }, itemFields, out xml);
            //TestCase.ShowResult(result, $"GetInfo after {itemKey.SalesOrganizationCode}- {itemKey.Code}", xml);


            /*
            updateXml = "<prditem><Origin>NL</Origin></prditem>";

            // Update item with new Origin code
            result = Client.PRDItem.Update(sessionHandle, itemKey, updateXml);

            TestCase.ShowResult(result, "Update Item Line", xml);

            
            // Update reference field Origin then NEVER use OriginCode
            itemKey = new ClientPRDItem.ItemKey() { SalesOrganizationCode = "COL", Code = "102039" };

            itemFields = new ClientPRDItem.ItemXmlField[]
            {
                ClientPRDItem.ItemXmlField.Code,
                ClientPRDItem.ItemXmlField.SalesOrganizationCode,
                ClientPRDItem.ItemXmlField.ItemSetCode,
                ClientPRDItem.ItemXmlField.Description,
                ClientPRDItem.ItemXmlField.OriginCode
            };
            result = Client.PRDItem.GetInfo(sessionHandle, new ClientPRDItem.ItemKey[] { itemKey }, itemFields, out xml);
            TestCase.ShowResult(result, "GetInfo COL-102039", xml);

 

            updateXml = "<prditem><Origin>NL</Origin></prditem>";

 /*      Client.Init("http://localhost:53133/");

            var sessionHandle = "";
            var result = "";

            result = Client.Application.Login("Piet Bakker", "Test", "CWS-Demo", out sessionHandle);
            TestCase.ShowResult(result, "Login");

            var estimateKey = new EstimateKey() { No = "CA170004" };

            var updateXml = "<prjestimate><Description>TEST UPDATE</Description></prjestimate>";

            result = Client.PRJEstimate.Update(sessionHandle, estimateKey, updateXml);

            var updateLineXml = "<prjestimateline><udf_upc_specialitemcode>TEST UPDATE 123</udf_upc_specialitemcode></prjestimateline>";

            var recordId = 6237;
            result = Client.PRJEstimate.UpdateLine(sessionHandle, estimateKey, recordId, updateLineXml);

            */


            result = Client.Application.Logout(sessionHandle);
            TestCase.ShowResult(result, "Logout");
        }
    }
}
