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
    class Case11
    {
        internal static void Execute()
        {
            // Example barcode request

            // Read a request file 
            var filePath = @"D:\IMPORTS\JSON\data.txt";

            var resultSet = "";
            using (var reader = File.OpenText(filePath))
                resultSet = reader.ReadToEnd();

            try
            {
                var result = JsonConvert.DeserializeObject<dynamic>(resultSet);

                var serial = result.serial.ToString();

                TestCase.ShowResult("serial", serial);

                TestCase.ShowResult("ok", $"RecordCount {result.scans.Count}");

                foreach (var scan in result.scans)
                {
                    var code = scan.product;
                    var quantity = scan.quantity;
                    var supplier = scan.supplier;

                    TestCase.ShowResult("ok", $"{quantity}-{code}-{supplier}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
