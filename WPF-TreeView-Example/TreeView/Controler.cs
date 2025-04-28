using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Resources;
using System.Collections;
using WPF_TreeView_Example.TreeView.DataModel;

namespace WPF_TreeView_Example.TreeView
{
    public static class Controler
    {
        /// <summary>
        /// Removes all characters in a string that 
        /// are not one of the printable Ascii Characters.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveNonPrintableCharacters(string str)
        {

            /*      var valid = new char[] { 
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 
            'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 
            'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 
            'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7', '8', 
            '9', '0', '.', '_','>' , '<','?','/',' ','=','"'};
            */

            //Create an Array of Characters that only hold visible characters
            var valid = new char[118];
            for (int x = 10; x < 128; x++)
            {
                valid[x - 10] = (char)x;
            }

            var result = string.Join("",
                        (from x in str.ToCharArray()
                         where valid.Contains(x)
                         select x.ToString())
                        .ToArray());

            return result;
        }

        /// <summary>
        /// Retrieves the Application XML from the Resouce XML
        /// </summary>
        /// <returns></returns>
        private static XElement GetApplicationsXMLFromResource()
        {
            XElement xRoot = null;


            var assembly = Assembly.GetExecutingAssembly();
            var topLevelNamespace = assembly.GetTypes()
                   .Select(t => t.Namespace)
                   .Where(ns => ns != null)
                   .Where(ns => !ns.Contains(".") && ns != "XamlGeneratedNamespace")
                   .Distinct()
                   .FirstOrDefault();

          


            Stream resourceStream =
                Assembly.GetExecutingAssembly().GetManifestResourceStream($"{topLevelNamespace}.Applications.xml");
            if (resourceStream != null)
                using (var resourceReader = new StreamReader(resourceStream))
                {
                    string data = resourceReader.ReadToEnd();
                    xRoot = XElement.Parse(data);
                }

            return xRoot;
        }

        public static List<ActionToDisplay> GetActions(ApplicationToDisplay AppToDisplay)
        {
            XElement xRoot = GetApplicationsXMLFromResource();
            List<ActionToDisplay> actionsToDisplay = new List<ActionToDisplay>();

            string xpath = string.Format("//APPLICATION[@Name='{0}']", AppToDisplay.Name);
            XElement xApplication = xRoot.XPathSelectElement(xpath);
            foreach (var xAction in xApplication.XPathSelectElements("ACTION"))
            {
                ActionToDisplay actionToDisplay = new ActionToDisplay()
                {
                    Name = xAction.Attribute("Name").Value,
                    ClassName = xAction.Attribute("ClassToCreate").Value
                };
                actionsToDisplay.Add(actionToDisplay);
            }

            return actionsToDisplay;
        }

        /// <summary>
        /// Retrieves a list of all the Applications held within the Application XML
        /// </summary>
        /// <returns></returns>
        public static List<ApplicationToDisplay> GetApplications()
        {
            XElement xRoot = GetApplicationsXMLFromResource();



            IEnumerable<XElement> xApps = xRoot.XPathSelectElements("//APPLICATION");
            List<ApplicationToDisplay> AppsToDisplay = new List<ApplicationToDisplay>();

            foreach (XElement xApp in xApps)
            {
                string Name = xApp.Attribute("Name").Value;
                ApplicationToDisplay AppToDisplay = new ApplicationToDisplay(Name);
                AppsToDisplay.Add(AppToDisplay);
            }

            return AppsToDisplay;

        }

    }
}
