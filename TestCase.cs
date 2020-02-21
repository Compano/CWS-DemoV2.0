using System;
using System.Text;
using System.IO;
using System.Configuration;

namespace Demo
{
    public class TestCase :Form1
    {
        static string application;
       
        public static void SetApplication(string app)
        {
            application = app;
            _Form1.update(application);
        }

        static void ShowResult(string text)
        {
            _Form1.txtConsole.AppendText(Environment.NewLine + DateTime.Now.ToShortTimeString().PadLeft(5) + " => " + text + Environment.NewLine);
        }

        public static void ShowResult(string testDescription, bool result)
        {
            ShowResult(testDescription.PadRight(60, '.') + (result ? "Ok" : "Error"));
        }

        public static void ShowResult(string result, string testDescription)
        {
            try
            {
                ShowResult(testDescription.PadRight(60, '.') + (result.Length == 0 ? "Ok" : Environment.NewLine + result));
            }
            catch (Exception ex)
            {
                _Form1.txtConsole.AppendText("Er is onbekende een foutmelding opgetreden: " + ex.Message + Environment.NewLine);

            }

            finally
            {
                
            }

        }

        public static void ShowResult(string result, string testDescription, bool testResult)
        {
            ShowResult(testDescription.PadRight(60, '.') + (result.Length == 0 && testResult ? "Ok" : result.Length == 0 ? "Fail" : result));
        }

        public static void ShowResult(string result, string testDescription, string xml)
        {
            string warning = "";

            if (result.Length == 0)
            {

                var directory = Variables.tmpExportDir;

                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                var path = Path.Combine(directory, testDescription + ".xml");

                if (File.Exists(path))
                {
                    string oldXml, newXml;
                    using (var reader = new StreamReader(path, Encoding.UTF8))
                    {
                        oldXml = RemoveAllWhiteSpace(reader.ReadToEnd());
                        newXml = RemoveAllWhiteSpace(xml);
                    }
                    if (!string.Equals(oldXml, newXml, StringComparison.InvariantCulture))
                    {
                        var newPath = Path.Combine(directory, string.Format("{0} {1:yy-MM-dd}.xml", testDescription, File.GetLastWriteTime(path)));
                        if (!File.Exists(newPath))
                            File.Move(path, newPath);
                        warning = " output changed!";
                    }
                }
                
                    using (var writer = File.CreateText(path))
                    writer.Write(xml);
            }
            
                ShowResult(testDescription.PadRight(60, '.') + (result.Length == 0 ? "Ok" : result) + warning);
            
        }

        static string RemoveAllWhiteSpace(string text)
        {
            StringBuilder newText = new StringBuilder(text.Length);

            foreach (char character in text)
                if (!char.IsWhiteSpace(character))
                    newText.Append(character);

            return newText.ToString();
        }
    }
}
