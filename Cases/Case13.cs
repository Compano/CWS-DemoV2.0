using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using Demo.MessageService240TestCompano;



namespace Demo.Cases
{
    class Case13
    {
        private static object cbMessageType;

        /// <summary>
        /// Test MessageService2.40
        /// </summary>
        /// 


        internal static void Execute()
        {
            Client.Init("http://test.online.compano.nl/");

            //Client.Clienttest.ClientCredentials.UserName.UserName = "webservices";
            Client.Clienttest.ClientCredentials.UserName.UserName = Variables.username.ToString();
            Client.Clienttest.ClientCredentials.UserName.Password = Variables.password.ToString();
 
            var AuthenticationInfo = new AuthenticationInfo()
            {
                RelationId = "webservices",
                UserId = "webservices",
                Password = "test"
            };

            var CustomerInfo = new CustomInfo()
            {
                IsTestMessage = true,
                LanguageCode = "NL"
            };

                     

            cbMessageType = Enum.GetValues(typeof(MsgTypeOption));
            
            try
            {
                var messages = Client.Clienttest.GetAvailableMessages(AuthenticationInfo, CustomerInfo, MsgTypeOption.ORDERS);
                var countMessages = messages.Count();

                Console.WriteLine("Aantal berichten retour: " + countMessages.ToString());

                if (messages.Length > 0)
                {
                    foreach (var availableMessage in messages)
                    {

                        Console.WriteLine("MsgID: " + availableMessage.MsgId.ToString());
                        Console.WriteLine("MsgType: " + availableMessage.MsgType.ToString()+"\n");
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


            Console.WriteLine("Result: "  );



        }
    }

}