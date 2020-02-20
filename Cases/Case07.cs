using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

using Demo.ClientArtConnect;

namespace Demo.Cases
{
    /// <summary>
    /// Bestellen ArtConnect MessageService
    /// </summary>
    public static class Case07
    {
        const string Crlf = "\r\n";

        internal static void Execute()
        {

            Client.Init("https://ttt.webservices.inka.nl/");

            // CustomerInfo
            var customerInfo = new CustomInfoType() { IsTestMessage = true };

            // Authentication
            if (Client.ClientArtConnect.ClientCredentials != null)
            {
                Client.ClientArtConnect.ClientCredentials.UserName.UserName = "ICM LENTING";
                Client.ClientArtConnect.ClientCredentials.UserName.Password = "Nzmwby";
                
                // Read a XML file
                var filePath = @"C:\_test\icm_xml_1604.xml";

                var fileContent = "";
                using (var reader = File.OpenText(filePath))
                    fileContent = reader.ReadToEnd();

                //var orderbString =
               //     "TVUNCjk5OVRFU1QyDQpCZXN0ZWxsaW5nDQoNCjQ0MDE3NzcwDQpCDQowMDENCkxlbnRpbmcgUHJvamVjdCBMb29kZ2lldGVycyBCLg0KDQpTY2hyZXBlbA0KREUgR09PUk4NCjE2NDhHQw0KOQ0KMDIyOSA1NCAxMiA2OQ0KMzAtMDYtMjAxOA0KDQpURVNUISEhISENCg0KMDAxDQowMDAxMDAwDQoxMDQwNQ0KWmVsZmJvcmVuZGUgc2Nocm9lZiBTLU1EMDFaIDQsMngxNg ==";

                //fileContent = SetMsgContent(MsgFormatType.ETIM, orderbString);
                //fileContent = SetMsgContent(MsgFormatType.INSBOU, orderbString);

                var icmLines = fileContent.IndexOf(Crlf, StringComparison.InvariantCultureIgnoreCase) > -1
               ? fileContent.Split(new string[] { Crlf }, StringSplitOptions.None)
               : fileContent.Split('\n');

                #region Example ICM

                // ICM File
                //            PL
                //IN170010
                //TEST ORDER!

                //1216734
                //B
                //001
                //Installatiebedrijf Compano

                //Dyk
                //Snits
                //5151DJ
                //46
                //0566 37 50 26
                //04 - 02 - 2017

                //001
                //0000020
                //3420469
                //Viega verlengstuk verchroomd 1 / 2"x15mm

                #endregion

                #region Example INSBOU3

                //         <? xml version = "1.0" encoding = "utf-8" ?>
                //< Order >

                //  < OrderType > 220 </ OrderType >

                //  < OrderNumber > IN170001 </ OrderNumber >

                //  < OrderDate > 2017 - 02 - 02 </ OrderDate >

                //  < DraftOrderIndicator > 16 </ DraftOrderIndicator >

                //  < EndCustomerOrderNumber > TEST ORDER!</ EndCustomerOrderNumber >

                //     < FreeText > TEST ORDER!</ FreeText >

                //        < DeliveryDateTimeInformation >

                //          < RequiredDeliveryDate > 2017 - 02 - 04 </ RequiredDeliveryDate >

                //        </ DeliveryDateTimeInformation >

                //        < Buyer >

                //          < GLN > 1216734 </ GLN >

                //          < Country > NL </ Country >

                //          < ContactInformation />

                //        </ Buyer >

                //        < Supplier >

                //          < GLN > 8711238011103 </ GLN >

                //        </ Supplier >

                //        < DeliveryParty >

                //          < Name > Installatiebedrijf Compano </ Name >

                //             < Name2 > Plieger </ Name2 >

                //             < StreetAndNumber > Weg 46 </ StreetAndNumber >

                //                < City > Sneek </ City >

                //                < PostalCode > 5151DJ </ PostalCode >

                //                   < Country > NL </ Country >

                //                   < Contactgegevens />

                //                 </ DeliveryParty >

                //                 < OrderLine >

                //                   < LineNumber > 1 </ LineNumber >

                //                   < OrderedQuantity > 20 </ OrderedQuantity >

                //                   < OrderedQuantityMeasureUnitCode > PCE </ OrderedQuantityMeasureUnitCode >

                //                   < LineIdentitfication > 1 </ LineIdentitfication >

                //                   < TradeItemIdentification >

                //                     < GTIN />

                //                     < SuppliersTradeItemIdentification > 3420469 </ SuppliersTradeItemIdentification >

                //                     < AdditionalItemIdentification >

                //                       < TradeItemDescription > Viega verlengstuk verchroomd 1 / 2"x15mm</TradeItemDescription>
                //                          </ AdditionalItemIdentification >

                //                        </ TradeItemIdentification >

                //                      </ OrderLine >
                //                    </ Order >

                #endregion

                #region ClientArtConnect

                var message = new ClientArtConnect.MessageType()
                {
                    Attachment =
                        new AttachmentType[]
                            {new AttachmentType() {FileName = Path.GetFileName(filePath), DocumentType = "DOC"}},
                    MsgContent = GetMsgContent(string.Equals(Path.GetExtension(filePath), ".xml",
                                StringComparison.InvariantCultureIgnoreCase)
                                ? MsgFormatType.INSBOU
                                : MsgFormatType.ETIM, fileContent), 
                    MsgProperties = new MessagePropertiesType()
                    {
                        MsgFormat =
                            string.Equals(Path.GetExtension(filePath), ".xml",
                                StringComparison.InvariantCultureIgnoreCase)
                                ? MsgFormatType.INSBOU
                                : MsgFormatType.ETIM,
                        MsgId = DateTime.Now.ToString("yyMMdd-HHmmssff"),
                        MsgVersion = "3.0",
                        MsgType = "ORDERS",
                        MsgDateTime = DateTime.Now
                    }
                };

                try
                {
                    var messageResponse = Client.ClientArtConnect.PostMessage(customerInfo, message);

                    if (messageResponse.MessageResult)
                    {
                        TestCase.ShowResult("PostMessage", "PostMessage has correct response");

                        fileContent = messageResponse.Message.MsgContent;
                        var fileName = messageResponse.Message.Attachment[0].FileName;
                        var path = Path.Combine(@"c:\_test\",
                            Path.GetFileNameWithoutExtension(fileName) +
                            (messageResponse.Message.MsgProperties.MsgFormat == MsgFormatType.INSBOU ? ".xml" : ".icb"));

                        var icbLines = fileContent.Split('\n');

                        using (var writer = File.CreateText(path))
                            foreach (var line in icbLines)
                                writer.WriteLine(line);

                        TestCase.ShowResult(path, "Save reponsefile");
                    }
                    else
                    {
                        TestCase.ShowResult(messageResponse.Message.MsgContent,
                            !string.IsNullOrEmpty(messageResponse.Message.MsgContent)
                                ? "PostMessage has error response"
                                : "PostMessage a-synch response");

                        var availableMessagesRequest = new AvailableMessagesRequestType { MsgType = "ORDRSP" };

                        var messages = Client.ClientArtConnect.GetAvailableMessages(customerInfo, availableMessagesRequest);


                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Foutmelding van de webservice:");
                    Console.WriteLine(ex.Message.ToString());
                    Console.ResetColor();
                }

            }

            #endregion
        }

        static string GetMsgContent(MsgFormatType? msgFormat, string content)
        {
            if (!msgFormat.HasValue)
                return content;

            switch (msgFormat.Value)
            {
                // Bij ASCII bestanden dient de MsgContent als Base64 string te worden gecodeerd.
                case MsgFormatType.ETIM:
                    return Base64UrlEncode(content);
                default:
                    return content;
            }
        }

        static string Base64UrlEncode(string content)
        {
            var inputBytes = Encoding.UTF8.GetBytes(content);
            // Special "url-safe" base64 encode UTF8.
            return Convert.ToBase64String(inputBytes);
        }

        static string SetMsgContent(MsgFormatType? msgFormat, string content)
        {
            if (!msgFormat.HasValue)
                return content;

            switch (msgFormat.Value)
            {
                // Bij ASCII bestanden dient de MsgContent van Base64 string te worden gedecodeerd.
                case MsgFormatType.ETIM:
                    return Base64UrlDecode(content);
                default:
                    return content;
            }
        }

        static string Base64UrlDecode(string content)
        {
            var inputBytes = Convert.FromBase64String(content);
            // Special "url-safe" base64 encode UTF8.
            return Encoding.UTF8.GetString(inputBytes, 0, inputBytes.Length);
        }
    }
}
