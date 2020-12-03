using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace DataSourcesConverter
{
    class XMLHandler
    {
        public XMLHandler(string xmlFile)
        {
            XmlFilePath = xmlFile;
        }

        public string XmlFilePath { get; set; }

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
    }

    //XML file to 
    //https://social.msdn.microsoft.com/Forums/officeocs/en-US/36758899-1dd9-4b1d-9c37-285e584c151e/xml-to-html-tables?forum=csharpgeneral
}
