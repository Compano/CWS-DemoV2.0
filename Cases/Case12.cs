using System;
using System.Text;

using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;

using Demo.ClientMessageService;

namespace Demo.Cases
{
    class Case12
    {
        internal static void Execute()
        {
            #region MessageService

            Client.Init("https://acceptatie.oosterberg.nl/messageservice30/");
            //Client.Init("https://ws.oosterberg.nl/messageservice30/");

            // Van 't Schip
            //2137372
            //var userNameToken = new UsernameToken()
            //{
            //    Username = "99",
            //    Password = "E45S6dUA"
            //};
            //Test account
            //1234567
            var userNameToken = new UsernameToken()
            {
                Username = "62",
                Password = "B8n!1LH"
            };
            var security = new Security()
            {
                UsernameToken = userNameToken,
                Timestamp = new Timestamp() { Created = DateTime.Now }
            };
            // CustomerInfo
            var customerInfo = new CustomInfoType() { IsTestMessage = false, ApplicationId = "Compano", VersionId = "3.0", RelationId = "1234567" };

            // Authentication
            if (Client.ClientMessageService.ClientCredentials == null) return;

            Client.ClientMessageService.ClientCredentials.UserName.UserName = userNameToken.Username;
            Client.ClientMessageService.ClientCredentials.UserName.Password = userNameToken.Password;
  
            var availableMessagesRequest = new AvailableMessagesRequestType { MsgType = "" };
            try
            {
                var messages = Client.ClientMessageService.GetAvailableMessages(security, customerInfo,
                    availableMessagesRequest);

                if (messages.Length > 0)
                {
                    foreach (var availableMessage in messages)
                    {
                        switch (availableMessage.MsgFormat)
                        {
                            case MsgFormatType.ETIM:
                            case MsgFormatType.INSBOU:
                                // Valid response!
                                var success = false;

                                var messageRequest = new MessageRequestType
                                {
                                    MsgId = availableMessage.MsgId,
                                    MsgFormat = availableMessage.MsgFormat,
                                    MsgVersion = availableMessage.MsgVersion
                                };

                                try
                                {
                                    var responseMessages = Client.ClientMessageService.GetMessage(security,
                                        customerInfo,
                                        messageRequest);

                                  success = responseMessages.MessageRequestResult != null;
                                 //success = responseMessages.MessageRequestResponse != null;

/*                                    if (success)
                                        {
                                            var fileContent = responseMessages.MessageRequestResult.MsgContent;
                                            var fileName = responseMessages.MessageRequestResult.Attachment[0].FileName;
                                            var path = Path.Combine(@"d:\icm\icb",
                                                Path.GetFileNameWithoutExtension(fileName) +
                                                (responseMessages.MessageRequestResult.MsgProperties.MsgFormat ==
                                                    MsgFormatType.INSBOU
                                                    ? ".xml"
                                                    : ".icb"));
                                                                                                                                                                                                                                                
                                            var icbLines = fileContent.Split('\n');
                                                                                                                                                                                                                                                
                                            using (var writer = File.CreateText(path))
                                                foreach (var line in icbLines)
                                                    writer.WriteLine(line);
                                                                                                                                                                                                                                                
                                            if (File.Exists(path))
                                            {
                                                TestCase.ShowResult(
                                                    responseMessages.MessageRequestResult.MsgProperties.MsgId,
                                                    "Response file for message received");
                                                success = true;
                                            }
                                            else
                                            {
                                                TestCase.ShowResult(
                                                    responseMessages.MessageRequestResult.MsgProperties.MsgId,
                                                    "No response file for message");
                                            }
                                        }
                                        */
                                }
                                catch
                                {
                                    success = false;
                                }
                                finally
                                {
                                    if (success)
                                    {
                                        //  var result = Client.ClientMessageService.DeleteMessage(customerInfo,
                                        //      messageRequest);
                                        //  TestCase.ShowResult(result.MessageResult.ToString(), "DeleteMessage");
                                    }
                                }
                                break;
                            case MsgFormatType.CUSTOM:
                                TestCase.ShowResult(availableMessage.MsgType, "Unhandeled message");
                                break;
                        }

                    }
                }
            }
            catch (Exception exception)
            {
                var faultException = exception as FaultException;
                Console.WriteLine(exception);


                if (faultException != null)
                {
                    var message = $"{faultException?.Reason.ToString()} Code: {faultException?.Code}!";
                } //if (faultException == null && !exception.IsWebServiceTimeoutException() && exception.IsSystemException())
            }

            #endregion

        }
}
}
