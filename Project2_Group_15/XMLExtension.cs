using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Project2_Group_15 {
    public static class XMLExtension {

        public static void WriteStartDocument(this XmlWriter writer)
        {
            writer.WriteStartDocument();
        }

        public static void WriteStartRootElement(this XmlWriter writer, string rootTagName)
        {
            writer.WriteStartElement(rootTagName);
        }

        public static void WriteEndRootElement(this XmlWriter writer)
        {
            writer.WriteEndElement();
        }

        public static void WriteStartElement(this XmlWriter writer, string elementName)
        {
            writer.WriteStartElement(elementName);
        }

        public static void WriteEndElement(this XmlWriter writer)
        {
            writer.WriteEndElement();
        }

        public static void WriteAttribute(this XmlWriter writer, string attributeName, string attributeValue)
        {
            writer.WriteElementString(attributeName, attributeValue);
        }
    }
}
