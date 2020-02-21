using System;
using System.Diagnostics;
using System.Threading;
using System.Drawing;
using System.Xml.Linq;

namespace Demo.Cases
{
    /// <summary>
    /// Open basket voor het selecteren van artikelen
    /// </summary>
    public class Case02 : Form1
    {
      
        internal static void Execute()
        {

            var sessionHandle = "";
            var result = "";

            var process = new Process();

            try
            {

                _Form1.txtConsole.AppendText("BasketURL changed to http://online.compano.nl/" + Environment.NewLine);
                Variables.url = "http://online.compano.nl/";
                Client.Init(Variables.url);
      
                result = Client.Application.Login(Variables.username.ToString(), Variables.password.ToString(), Variables.companyname.ToString(), out sessionHandle);

                TestCase.ShowResult(result, "Login");

                // Determine basket URL
                var basketUrl = "";
                Client.PRDItem.GetBasketUrl(sessionHandle, "", "", null, null, out basketUrl);

                _Form1.txtConsole.AppendText("BasketURL " + basketUrl.ToString() + Environment.NewLine);
         
                // Open item basket in browser
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.FileName = basketUrl;
                process.Start();

                // Max 1 minute polling for filled basket!
                var pollTimeoutTime = DateTime.Now.AddMinutes(1);

                var selectedQuantities = new ClientPRDItem.ArrayOfDouble();
                var selectedItems = new ClientPRDItem.ItemKey[0];

                do
                {
                    if (DateTime.Compare(DateTime.Now, pollTimeoutTime) <= 0) //AANPASSEN! of scherm gesloten door gebruker zonder items te selecterem
                    {
                        // Wait twenty seconds!
                        Thread.Sleep(20000);

                        result = Client.PRDItem.GetBasketAsArray(sessionHandle, out selectedQuantities, out selectedItems);
                    }
                    else
                        throw new Exception("Time-out error. Basket is empty" + Environment.NewLine);
                        _Form1.txtConsole.AppendText("Time-out error. Basket is empty" + Environment.NewLine);
                }
                while (selectedItems.Length == 0);

                // GetBasketAsArray
                result = Client.PRDItem.GetBasketAsArray(sessionHandle, out selectedQuantities, out selectedItems);
                TestCase.ShowResult(result, "GetBasketAsArray");

                _Form1.txtConsole.AppendText("Basketcount " + selectedItems.Length + Environment.NewLine);

                var index = 0;
                foreach (var selectedItem in selectedItems)
                    _Form1.txtConsole.AppendText("Quantity: " + selectedQuantities[index++] + string.Format(" Item: {0}-{1}", selectedItem.SalesOrganizationCode, selectedItem.Code));

                // GetBasketAsXml
                var xml = "";
                var itemFields = new ClientPRDItem.ItemXmlField[] { ClientPRDItem.ItemXmlField.SalesOrganizationCode, ClientPRDItem.ItemXmlField.Code, ClientPRDItem.ItemXmlField.GrossPricePerUtilizationUnit, ClientPRDItem.ItemXmlField.PurchasePricePerUtilizationUnit };

                result = Client.PRDItem.GetInfo(sessionHandle, selectedItems, itemFields, out xml);

                if (Variables.showXMLdata == true)
                {
                    TestCase.ShowResult(result, "Result XML: " + Environment.NewLine + XDocument.Parse(xml).ToString() + Environment.NewLine);
                }
     
                //_Form1.txtConsole.AppendText(xml + Environment.NewLine);


                TestCase.ShowResult(result, "GetBasketAsXml");

                // Get actualize info for all selected items modified since 01-01-2010
                result = Client.PRDItem.GetModifiedInfo(sessionHandle, selectedItems, itemFields, new DateTime(2010, 1, 1), out xml);
                _Form1.txtConsole.AppendText(xml + Environment.NewLine);

                // Clear current basket
                Client.PRDItem.ClearBasket(sessionHandle);

                _Form1.txtConsole.AppendText("ClearBasket" + Environment.NewLine);

                result = Client.PRDItem.GetBasketAsArray(sessionHandle, out selectedQuantities, out selectedItems);

                _Form1.txtConsole.AppendText("Basketcount after clear " + selectedItems.Length + Environment.NewLine);
                TestCase.ShowResult(result, "GetBasketAsArray");
            }

            catch (Exception ex)
            {
                //_Form1.txtConsole.Font = new Font("Times New Roman", 20);
                _Form1.txtConsole.AppendText("Er is een foutmelding opgetreden:");
                _Form1.txtConsole.AppendText(ex.Message);
                 process.Close();
            }

            finally
            {
                process.Close();

                //result = Client.Application.Logout(sessionHandle);
                TestCase.ShowResult(result, "Logout");



            }
        }
    }
}
