using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Demo.Cases
{
    /// <summary>
    /// JSON Request
    /// </summary>
    class Case10
    {
        internal static void Execute()
        {
            // const string apiKey = "4C927711C613076C4F022910A15DC61A875EC46B5DAC81554FCA0A283D6E19C0";
            const string apiKey = "671E571E440C4ED0B6907FE70207A58353AB510439ECB115B857E23F0F68E7FC40538777AA73C681BEDD1B56240C3172";
            // Example LayoutName Start Count
            //var uri = new Uri("http://artiwebtest.dewetech.local/api/jsonfeed/PIMProduct/1/1 ");

            // Example ItemSetCode is PLI
            //var uri = new Uri("https://ttt.online.compano.nl/API/jsonfeed/itemfeed/1/10?filter=itemsetcode=PLI"); // &filter=itemsetcode=PLI 00?filter=code=021005?Datesince=20170101

            // Example Code is 021005 AND ItemSet is PLI
            //var uri = new Uri("https://ttt.online.compano.nl/API/jsonfeed/itemfeed/1/10?filter=itemsetcode=PLI,code=0060056");

            // Example ConditionGroupCode is 006 AND ItemSet is PLI +  Datesince 20170101
            //var uri = new Uri("https://ttt.online.compano.nl/API/jsonfeed/itemfeed/1/10?filter=itemsetcode=PLI,conditiongroupcode=006&Datesince=20170101"); // &filter=itemsetcode=PLI 00?filter=code=021005?Datesince=20170101

            // Example Code is 4970139 AND Datesince 20170101
            var uri = new Uri("https://ttt.online.compano.nl/API/jsonfeed/itemfeed/1/10?filter=code=4970139&Datesince=20190628"); // &filter=itemsetcode=PLI 00?filter=code=021005?Datesince=20170101

            // Example Code is 22143 Productfeed
            //var uri = new Uri("http://localhost:51114//api/jsonfeed/PIM_item/1/100?filter=ItemSetCode=GAL,niet_voorraadartikel=Y");

            // Example feed Filter on UDF
            //var uri = new Uri("https://ttt.online.compano.nlAPI/jsonfeed/ERP_Feed/1/100?filter=ItemSetCode=PLI,niet_voorraadartikel=Y");

            // Example ConditionGroupCode is 006 AND ItemSet is PLI +  Datesince 20170101
            //var uri = new Uri("https://ttt.online.compano.nl/API/jsonfeed/itemfeed/1/10?filter=itemsetcode=PLI,conditiongroupcode=006&Datesince=20170101"); // &filter=itemsetcode=PLI 00?filter=code=021005?Datesince=20170101

            //var uri = new Uri("http://www.igm.compano.nl/API/jsonfeed/JSON_ExportPrijzen/1/10?filter=SalesOrganizationCode=SOL,conditiongroupcode=448907&Datesince=20180301");

            // Example Sincedate 20170101
            var httpRequest = (HttpWebRequest) WebRequest.Create(uri);
            httpRequest.Headers.Add("APIKEY", apiKey);

            try
            {
                using (var response = (HttpWebResponse) httpRequest.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        var resultSet = reader.ReadToEnd();
                        var result = JsonConvert.DeserializeObject<dynamic>(resultSet);

                        var recordCount = result.Count;

                        TestCase.ShowResult("ok", "RecordCount", recordCount.ToString());

                        foreach (var item in result.Items)
                        {
                            var description = item.Verkorte_omschrijving_Saniceve_BV;
                            var code = item.Code;

                            TestCase.ShowResult("ok", $"{code}-{description}");
                        }

                    }
                }
            }
            catch (WebException e)
            {
                using (var reader = new StreamReader(e.Response.GetResponseStream()))
                {
                    var message = reader.ReadToEnd();
                    Console.WriteLine(message);
                }
            }
        }
    }
}
