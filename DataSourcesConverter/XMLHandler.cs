using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            XmlNodeList elements = doc.SelectNodes("/"); 

            foreach (XmlNode element in elements)
            {
                listElements.Add(element.InnerText);
            }

            return listElements;
        }

        public string GetXMLString()
        {
            List<string> listElements = new List<string>();

            XmlDocument doc = new XmlDocument();
            doc.Load(XmlFilePath);

            //vários titles = vários Nodes
            XmlNodeList elements = doc.SelectNodes("/"); //expressão XPath que seleciona todos os elementos

            foreach (XmlNode element in elements)
            {
                listElements.Add(element.OuterXml);
            }

            string outputXML = "";

            foreach (string item in listElements)
            {
                outputXML += item;
            }

            return outputXML;
        }

        public string XMLToJson()
        {
            var xml = XElement.Parse(GetXMLString());
            var jsonText = JsonConvert.SerializeObject(xml);

            return jsonText;
        }

        #region XML validation with XSD
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

        //XML file to HTML table source: https://social.msdn.microsoft.com/Forums/officeocs/en-US/36758899-1dd9-4b1d-9c37-285e584c151e/xml-to-html-tables?forum=csharpgeneral
        public string ConvertXmlToHtmlTable(string xml)
        {
            StringBuilder html = new StringBuilder("<table align='center' " +
               "border='1' class='xmlTable'>\r\n");
            try
            {
                XDocument xDocument = XDocument.Parse(xml);
                XElement root = xDocument.Root;

                var xmlAttributeCollection = root.Elements().Attributes();


                foreach (var ele in root.Elements())
                {
                    if (!ele.HasElements)
                    {
                        string elename = "";
                        html.Append("<tr>");

                        elename = ele.Name.ToString();

                        if (ele.HasAttributes)
                        {
                            IEnumerable<XAttribute> attribs = ele.Attributes();
                            foreach (XAttribute attrib in attribs)
                                elename += Environment.NewLine + attrib.Name.ToString() +
                                  "=" + attrib.Value.ToString();
                        }

                        html.Append("<td>" + elename + "</td>");
                        html.Append("<td>" + ele.Value + "</td>");
                        html.Append("</tr>");
                    }
                    else
                    {
                        string elename = "";
                        html.Append("<tr>");

                        elename = ele.Name.ToString();

                        if (ele.HasAttributes)
                        {
                            IEnumerable<XAttribute> attribs = ele.Attributes();
                            foreach (XAttribute attrib in attribs)
                                elename += Environment.NewLine + attrib.Name.ToString() + "=" + attrib.Value.ToString();
                        }

                        html.Append("<td>" + elename + "</td>");
                        html.Append("<td>" + ConvertXmlToHtmlTable(ele.ToString()) + "</td>");
                        html.Append("</tr>");
                    }
                }

                html.Append("</table>");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Error: {0}", ex.ToString()));
                // Returning the original string incase of error.
            }
            return html.ToString();
        }
    }
}
