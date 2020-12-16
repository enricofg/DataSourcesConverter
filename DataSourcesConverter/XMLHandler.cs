using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace DataSourcesConverter
{
    class XMLHandler
    {
        public XMLHandler(string xmlFile)
        {
            XmlFilePath = xmlFile;
        }

        private string XsdFilePath = "flow_config.xsd";

        public string XmlFilePath { get; set; }

        private bool isValid = true;

        private string validationMessage;
        public string ValidationMessage
        {
            get { return validationMessage; }
        }

        public List<string> GetXMLInfo()
        {
            List<string> listElements = new List<string>();

            XmlDocument doc = new XmlDocument();
            doc.Load(XmlFilePath);

            //vários titles = vários Nodes
            XmlNodeList elements = doc.SelectNodes("/"); //expressão XPath que seleciona todos os elementos

            foreach (XmlNode element in elements)
            {
                listElements.Add(element.InnerText);
            }

            return listElements;
        }

        #region Ex. 6 - 
        public bool ValidateXML()
        {
            isValid = true;
            validationMessage = "Flow configuration valid!";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(XmlFilePath); //load do caminho do ficheiro xml
                ValidationEventHandler eventHandler = new ValidationEventHandler(MyValidateMethod); 
                doc.Schemas.Add(null, XsdFilePath); 
                doc.Validate(eventHandler); 
            }
            catch (XmlException ex)
            {
                isValid = false;
                validationMessage = string.Format("Error: {0}", ex.ToString());
            }
            return isValid;
        }

        //método responsável para as validações que serão necessárias
        private void MyValidateMethod(object sender, ValidationEventArgs args)
        {
            isValid = false;
            switch (args.Severity)
            {
                case XmlSeverityType.Error:
                    validationMessage = string.Format("Config file error: {0}", args.Message);
                    break;
                case XmlSeverityType.Warning:
                    validationMessage = string.Format("Config file warning: {0}", args.Message);
                    break;
                default:
                    break;
            }
        }
        #endregion
    }

    //XML file to 
    //https://social.msdn.microsoft.com/Forums/officeocs/en-US/36758899-1dd9-4b1d-9c37-285e584c151e/xml-to-html-tables?forum=csharpgeneral

}
