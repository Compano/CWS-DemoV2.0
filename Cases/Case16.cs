using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using Demo.tstRensaMessageService;

namespace Demo.Cases

{

    class Case16
    {

        internal static void Execute()
        {

            Client.Init("https://rensa.viadeportal.nl/MessageService/v3.00/");


            // CustomerInfo
            var customerInfo = new CustomInfoType()
            {
                IsTestMessage = false
                , IsContentCompressed = false
                , ApplicationId = "Compano"
                , VersionId = "3.0"
                , RelationId = "1234567"


            };

            // Authentication
            if (Client.ClientMessageService.ClientCredentials == null) return;

            Client.tstRensa.ClientCredentials.UserName.UserName = "0076960_999";
            Client.tstRensa.ClientCredentials.UserName.Password = "ToonenTest";

            var availableMessagesRequest = new AvailableMessagesRequestType { MsgType = "" };

                var messages = Client.tstRensa.GetAvailableMessages(customerInfo, availableMessagesRequest);

                if (messages.Length > 0)
                {
                    foreach (var availableMessage in messages)
                    {

                        var messageRequest = new MessageRequestType
                        {
                            MsgId = availableMessage.MsgId,
                            MsgFormat = availableMessage.MsgFormat,
                            MsgVersion = availableMessage.MsgVersion
                        };


                        var responseMessages = Client.tstRensa.PostMessage(customerInfo, messageRequest);

                        //success = responseMessages.MessageRequestResult != null;

                    }
                }

        }
    }
}

