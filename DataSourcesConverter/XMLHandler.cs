using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
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
            CheckXsdExists();
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

        public void CheckXsdExists()
        {
            if (File.Exists("flow_config.xsd"))
            {
                string hashToString = "";

                using (MD5CryptoServiceProvider algorithm = new MD5CryptoServiceProvider())
                {
                    using (var stream = File.OpenRead("flow_config.xsd"))
                    {
                        byte[] hash = algorithm.ComputeHash(stream);
                        hashToString = BitConverter.ToString(hash);
                    }
                }

                if (string.Compare(hashToString, "0F-52-D7-B0-E8-10-76-AB-22-41-C2-F6-1D-03-B0-9A") != 0)
                {
                    File.Delete("flow_config.xsd");
                    GenerateXsd();
                }
            }
            else
            {
                GenerateXsd();
            }
        }

        private static void GenerateXsd()
        {
            using (StreamWriter writer = new StreamWriter("flow_config.xsd"))
            {
                String xsd = @"<?xml version=""1.0"" encoding=""utf-8""?><xs:schema attributeFormDefault=""unqualified"" elementFormDefault=""qualified"" xmlns:xs=""http://www.w3.org/2001/XMLSchema""><xs:element name=""flow"" type=""flowRoot""></xs:element><xs:complexType name=""flowRoot""><xs:sequence><xs:element maxOccurs=""unbounded"" name=""flowRow"" type=""flowElement""></xs:element></xs:sequence></xs:complexType><xs:complexType name=""flowElement""><xs:sequence><xs:element maxOccurs=""1"" name=""inputType"" type=""inputTypes"" /><xs:element maxOccurs=""1"" name=""inputLocation"" type=""xs:string"" /><xs:element maxOccurs=""1"" name=""outputType"" type=""outputTypes"" /><xs:element maxOccurs=""1"" name=""outputLocation"" type=""xs:string"" /></xs:sequence></xs:complexType><xs:simpleType name=""inputTypes""><xs:restriction base=""xs:string""><xs:enumeration value=""Excel File""/><xs:enumeration value=""XML File""/><xs:enumeration value=""RESTful API""/></xs:restriction></xs:simpleType><xs:simpleType name=""outputTypes""><xs:restriction base=""xs:string""><xs:enumeration value=""HTML Page""/><xs:enumeration value=""RESTful API""/></xs:restriction></xs:simpleType></xs:schema>";
                writer.WriteLine(xsd);
            }
        }

        //XML file to HTML table, source: https://social.msdn.microsoft.com/Forums/officeocs/en-US/36758899-1dd9-4b1d-9c37-285e584c151e/xml-to-html-tables?forum=csharpgeneral
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
