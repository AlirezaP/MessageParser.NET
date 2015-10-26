using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace MessageParser.NET.Tools
{
   public class XmlParser
    {
        public string GetAttributeValue(string xmlString, string element, string attribute)
        {
            using (XmlReader reader = XmlReader.Create(new System.IO.StringReader(xmlString)))
            {
                    reader.ReadToFollowing(element);
                    reader.MoveToAttribute(attribute);
                    return reader.Value;
            }
        }

        public string GetElementContent(string xmlString, string element)
        {
            using (XmlReader reader = XmlReader.Create(new System.IO.StringReader(xmlString)))
            {
                    reader.ReadToFollowing(element);
                    return reader.ReadElementContentAsString();
            }
        }

        public string[] GetAllElements(string xmlString)
        {
            using (XmlReader reader = XmlReader.Create(new System.IO.StringReader(xmlString)))
            {
                List<string> output = new List<string>();

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                        output.Add(reader.Name);
                }

                return output.ToArray();
            }
        }
        public string[] GetAllText(string xmlString)
        {
            using (XmlReader reader = XmlReader.Create(new System.IO.StringReader(xmlString)))
            {
                List<string> output = new List<string>();

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Text)
                        output.Add(reader.Value);
                }

                return output.ToArray();
            }
        }


        //public string GetSubTreeFrom(string xmlString, string element)
        //{
        //    StringBuilder output = new StringBuilder();

        //    using (XmlReader reader = XmlReader.Create(new System.IO.StringReader(xmlString)))
        //    {
        //        XmlWriterSettings ws = new XmlWriterSettings();
        //        ws.Indent = true;
        //        using (XmlWriter writer = XmlWriter.Create(output, ws))
        //        {
        //            if (!reader.ReadToFollowing(element))
        //                return null;

        //            writer.WriteStartElement(element);

        //            while (reader.Read())
        //            {
        //                switch (reader.NodeType)
        //                {
        //                    case XmlNodeType.Element:
        //                        writer.WriteStartElement(reader.Name);
        //                        break;
        //                    case XmlNodeType.Text:
        //                        writer.WriteString(reader.Value);
        //                        break;
        //                    case XmlNodeType.XmlDeclaration:
        //                    case XmlNodeType.ProcessingInstruction:
        //                        writer.WriteProcessingInstruction(reader.Name, reader.Value);
        //                        break;
        //                    case XmlNodeType.Comment:
        //                        writer.WriteComment(reader.Value);
        //                        break;
        //                    case XmlNodeType.EndElement:
        //                        writer.WriteFullEndElement();
        //                        break;
        //                }
        //            }

        //            return output.ToString();
        //        }
        //    }
        //}
    }
}
