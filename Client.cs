using System;
using System.Xml;
using System.ServiceModel;


#region Include all web-services
using Demo.ClientApplication;
using Demo.ClientCATTreeNode;
using Demo.ClientCRMContact;
using Demo.ClientCTMCategory;
using Demo.ClientGDBAttachment;
using Demo.ClientGDBUserDefFieldOption;
using Demo.ClientICSClass;
using Demo.ClientICSModellingClass;
using Demo.ClientICSSynonym;
using Demo.ClientPRDAddOnItem;
using Demo.ClientPRDAddOnProduct;
using Demo.ClientPRDItem;
using Demo.ClientPRDItemGroup;
using Demo.ClientPRDItemSet;
using Demo.ClientPRDPackaging;
using Demo.ClientPRDProduct;
using Demo.ClientPRDProductGroup;
using Demo.ClientPRDSalesCondition;
using Demo.ClientPRDSupplier;
using Demo.ClientPRDSupportAgreement;
using Demo.ClientPRDUnit;
using Demo.ClientPRJEstimate;
using Demo.ClientPRJOrder;
using Demo.ClientSUPCall;
using Demo.ClientSUPContract;
using Demo.ClientUSRDataArea;
using Demo.ClientUSRUser;
using Demo.ClientArtConnect;
using Demo.ClientMessageService;
using Demo.MessageService240TestCompano;
using Demo.tstGalvanoMessageService;
using Demo.tstRensaMessageService;
#endregion

namespace Demo
{
    public static class Client
    {
        const int MaxContentSize = 500*1000*1000;

        public static ApplicationWebServiceSoapClient Application;

        public static TreeNodeServiceSoapClient CATTreeNode;
        public static ContactServiceSoapClient CRMContact;
        public static AttachmentServiceSoapClient GDBAttachment;
        public static UserDefFieldOptionServiceSoapClient GDBUserDefFieldOption;
        public static ClassServiceSoapClient ICSClass;
        public static ModellingClassServiceSoapClient ICSModellingClass;
        public static SynonymServiceSoapClient ICSSynonym;
        public static CategoryServiceSoapClient CTMCategory;
        public static AddOnItemServiceSoapClient PRDAddOnItem;
        public static AddOnProductServiceSoapClient PRDAddOnProduct;
        public static ItemServiceSoapClient PRDItem;
        public static ItemSetServiceSoapClient PRDItemSet;
        public static ItemGroupServiceSoapClient PRDItemGroup;
        public static PackagingServiceSoapClient PRDPackaging;
        public static ProductServiceSoapClient PRDProduct;
        public static ProductGroupServiceSoapClient PRDProductGroup;
        public static SalesConditionServiceSoapClient PRDSalesCondition;
        public static SupplierServiceSoapClient PRDSupplier;
        public static SupportAgreementServiceSoapClient PRDSupportAgreement;
        public static UnitServiceSoapClient PRDUnit;
        public static EstimateServiceSoapClient PRJEstimate;
        public static OrderServiceSoapClient PRJOrder;
        public static CallServiceSoapClient SUPCall;
        public static ContractServiceSoapClient SUPContract;
        public static DataAreaServiceSoapClient USRDataArea;
        public static UserServiceSoapClient USRUser;
        public static ClientArtConnect.MessageServiceSoapClient ClientArtConnect;
        public static ClientMessageService.MessageServiceSoapClient ClientMessageService;
        //ED: toegevoegd voor t.b.v case13 (16-10-2018)
        public static MessageService240TestCompano.MessageServiceSoapClient Clienttest;
        //ED: toegevoegd voor t.b.v case14 (02-11-2018)
        public static tstGalvanoMessageService.MessageServiceSoapClient tstGalvano;
        //ED: toegevoegd voor t.b.v case16 (05-03-2019)
        public static tstRensaMessageService.MessageService30Client tstRensa;
 

        /// <summary>
        /// Initializes the client for given url
        /// </summary>
        /// <param name="baseUrl">The usr to use as base url</param>
        public static void Init(string baseUrl)
        {
            var binding = baseUrl.IndexOf("https:", StringComparison.Ordinal) == -1
                ? new BasicHttpBinding
                {
                    MaxReceivedMessageSize = MaxContentSize,
                    ReaderQuotas = new XmlDictionaryReaderQuotas { MaxStringContentLength = MaxContentSize },
                    ReceiveTimeout = new TimeSpan(4, 0, 0),
                    SendTimeout = new TimeSpan(4, 0, 0)
                }
                : new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential)
                {
                    MaxReceivedMessageSize = MaxContentSize,
                    ReaderQuotas = new XmlDictionaryReaderQuotas { MaxStringContentLength = MaxContentSize },
                    ReceiveTimeout = new TimeSpan(4, 0, 0),
                    SendTimeout = new TimeSpan(4, 0, 0)

                };

            Application = new ApplicationWebServiceSoapClient(new BasicHttpBinding(),
                new EndpointAddress(baseUrl + "application.asmx"));
            CATTreeNode = new TreeNodeServiceSoapClient(binding, new EndpointAddress(baseUrl + "cattreenode.asmx"));
            CRMContact = new ContactServiceSoapClient(binding, new EndpointAddress(baseUrl + "crmcontact.asmx"));
            CTMCategory = new CategoryServiceSoapClient(binding, new EndpointAddress(baseUrl + "ctmcategory.asmx"));
            GDBUserDefFieldOption = new UserDefFieldOptionServiceSoapClient(binding,
                new EndpointAddress(baseUrl + "gdbuserdeffieldoption.asmx"));
            GDBAttachment = new AttachmentServiceSoapClient(binding, new EndpointAddress(baseUrl + "gdbattachment.asmx"));
            ICSClass = new ClassServiceSoapClient(binding, new EndpointAddress(baseUrl + "icsclass.asmx"));
            ICSModellingClass = new ModellingClassServiceSoapClient(binding,
                new EndpointAddress(baseUrl + "icsclassdrawing.asmx"));
            ICSSynonym = new SynonymServiceSoapClient(binding, new EndpointAddress(baseUrl + "icssynonym.asmx"));
            PRDAddOnItem = new AddOnItemServiceSoapClient(binding, new EndpointAddress(baseUrl + "prdaddonitem.asmx"));
            PRDAddOnProduct = new AddOnProductServiceSoapClient(binding,
                new EndpointAddress(baseUrl + "prdaddonproduct.asmx"));
            PRDItem = new ItemServiceSoapClient(binding, new EndpointAddress(baseUrl + "prditem.asmx"));
            PRDItemSet = new ItemSetServiceSoapClient(binding, new EndpointAddress(baseUrl + "prditemset.asmx"));
            PRDItemGroup = new ItemGroupServiceSoapClient(binding, new EndpointAddress(baseUrl + "prditemgroup.asmx"));
            PRDPackaging = new PackagingServiceSoapClient(binding, new EndpointAddress(baseUrl + "prdpackaging.asmx"));
            PRDProduct = new ProductServiceSoapClient(binding, new EndpointAddress(baseUrl + "prdproduct.asmx"));
            PRDProductGroup = new ProductGroupServiceSoapClient(binding,
                new EndpointAddress(baseUrl + "prdproductgroup.asmx"));
            PRDSalesCondition = new SalesConditionServiceSoapClient(binding,
                new EndpointAddress(baseUrl + "prdsalescondition.asmx"));
            PRDSupplier = new SupplierServiceSoapClient(binding, new EndpointAddress(baseUrl + "prdsupplier.asmx"));
            PRDSupportAgreement = new SupportAgreementServiceSoapClient(binding,
                new EndpointAddress(baseUrl + "prdsupportagreement.asmx"));
            PRDUnit = new UnitServiceSoapClient(binding, new EndpointAddress(baseUrl + "prdunit.asmx"));
            PRJEstimate = new EstimateServiceSoapClient(binding, new EndpointAddress(baseUrl + "prjestimate.asmx"));
            PRJOrder = new OrderServiceSoapClient(binding, new EndpointAddress(baseUrl + "prjorder.asmx"));
            SUPCall = new CallServiceSoapClient(binding, new EndpointAddress(baseUrl + "supcall.asmx"));
            SUPContract = new ContractServiceSoapClient(binding, new EndpointAddress(baseUrl + "supcontract.asmx"));
            USRDataArea = new DataAreaServiceSoapClient(binding, new EndpointAddress(baseUrl + "usrdataarea.asmx"));
            USRUser = new UserServiceSoapClient(binding, new EndpointAddress(baseUrl + "usruser.asmx"));
            ClientArtConnect = new ClientArtConnect.MessageServiceSoapClient(binding, new EndpointAddress(baseUrl + "ArtConnectV30.svc"));
            ClientMessageService = new ClientMessageService.MessageServiceSoapClient(binding, new EndpointAddress(baseUrl + "MessageService.svc"));
            //ED: toegevoegd voor t.b.v case13 (16-10-2018)
            Clienttest = new MessageService240TestCompano.MessageServiceSoapClient(binding, new EndpointAddress(baseUrl + "MessageService.asmx"));
            tstGalvano = new tstGalvanoMessageService.MessageServiceSoapClient(binding, new EndpointAddress(baseUrl + "MessageService.svc"));

            //ED: toegevoegd voor t.b.v case16 (05-03-2019)
            tstRensa = new tstRensaMessageService.MessageService30Client(binding, new EndpointAddress(baseUrl + "MessageService.svc"));
           



        }
    }
}