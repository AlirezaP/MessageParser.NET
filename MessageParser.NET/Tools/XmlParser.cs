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

        //public void SetAttribute(string xmlString, string parent, string element, string attributeName, string value)
        //{
        //    using (XmlReader reader = XmlReader.Create(new System.IO.StringReader(xmlString)))
        //    {
        //        if (!reader.ReadToFollowing(parent))
        //            return;

        //        SetAttribute(xmlString, element, attributeName, value,false);
        //    }
        //}

        public string SetAttribute(string xmlString, string parent, string element, string attributeName, string value)
        {
            using (XmlReader reader = XmlReader.Create(new System.IO.StringReader(xmlString)))
            {
                using (XmlReader reader2 = XmlReader.Create(new System.IO.StringReader(xmlString)))
                {
                    string total = xmlSubTree(xmlString);
                    while (reader.ReadToFollowing(parent))
                    {
                        reader2.ReadToFollowing(parent);

                        var mainTree = reader.ReadSubtree();
                        var tempTree = reader2.ReadSubtree();

                        string[] orgStr = System.Text.RegularExpressions.Regex.Split(xmlSubTree(tempTree), System.Environment.NewLine);
                        string[] newStr = System.Text.RegularExpressions.Regex.Split(SetAttribute(mainTree, element, attributeName, value, true), System.Environment.NewLine);

                        for (int i = 0; i < orgStr.Length; i++)
                        {
                            total = total.Replace(orgStr[i], newStr[i]);
                        }

                        //if (!allElements)
                        //    return total;
                    }
                    return total;
                }
            }
        }

        public string SetAttribute(string xmlString, string element, string attributeName, string value, bool allElements)
        {
            StringBuilder output = new StringBuilder();

            bool loop = true;

            // Create an XmlReader
            using (XmlReader reader = XmlReader.Create(new System.IO.StringReader(xmlString)))
            {
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(output, ws))
                {

                    // Parse the file and display each of the nodes.
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                writer.WriteStartElement(reader.Name);

                                if (reader.Name == element && loop)
                                {
                                    UpdateAttribute(reader, writer, attributeName, value);

                                    if (!allElements)
                                        loop = false;

                                    break;
                                }

                                if (reader.HasAttributes)
                                    writer.WriteAttributes(reader, true);

                                break;
                            case XmlNodeType.Text:
                                writer.WriteString(reader.Value);
                                break;
                            case XmlNodeType.XmlDeclaration:
                            case XmlNodeType.ProcessingInstruction:
                                writer.WriteProcessingInstruction(reader.Name, reader.Value);
                                break;
                            case XmlNodeType.Comment:
                                writer.WriteComment(reader.Value);
                                break;
                            case XmlNodeType.EndElement:
                                writer.WriteFullEndElement();
                                break;
                        }
                    }

                }
            }
            return output.ToString();
        }

        public string SetAttribute(XmlReader reader, string element, string attributeName, string value, bool allElements)
        {
            StringBuilder output = new StringBuilder();

            bool loop = true;

            // Create an XmlReader
            {
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(output, ws))
                {

                    // Parse the file and display each of the nodes.
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                writer.WriteStartElement(reader.Name);

                                if (reader.Name == element && loop)
                                {
                                    UpdateAttribute(reader, writer, attributeName, value);

                                    if (!allElements)
                                        loop = false;

                                    break;
                                }

                                if (reader.HasAttributes)
                                    writer.WriteAttributes(reader, true);

                                break;
                            case XmlNodeType.Text:
                                writer.WriteString(reader.Value);
                                break;
                            case XmlNodeType.XmlDeclaration:
                            case XmlNodeType.ProcessingInstruction:
                                writer.WriteProcessingInstruction(reader.Name, reader.Value);
                                break;
                            case XmlNodeType.Comment:
                                writer.WriteComment(reader.Value);
                                break;
                            case XmlNodeType.EndElement:
                                writer.WriteFullEndElement();
                                break;
                        }
                    }

                }
            }
            return output.ToString();
        }

        public bool ISExsistAttribute(XmlReader reader, string attributeName)
        {
            if (reader.HasAttributes)
            {

                while (reader.MoveToNextAttribute())
                {
                    if (reader.Name == attributeName)
                        return true;
                }
            }
            return false;
        }


        public void UpdateAttribute(XmlReader reader, XmlWriter writer, string attributeName, string value)
        {
            bool flag = false;

            if (reader.HasAttributes)
            {
                while (reader.MoveToNextAttribute())
                {
                    if (reader.Name == attributeName)
                    {
                        writer.WriteAttributeString(null, attributeName, null, value);
                        flag = true;
                    }
                    else
                        writer.WriteAttributeString(null, reader.Name, null, reader.Value);
                }
            }

            if (!flag)
                writer.WriteAttributeString(null, attributeName, null, value);
        }

        public string xmlSubTree(string xmlString)
        {
            StringBuilder output = new StringBuilder();
            // Create an XmlReader
            using (XmlReader temp = XmlReader.Create(new System.IO.StringReader(xmlString)))
            {
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(output, ws))
                {

                    // Parse the file and display each of the nodes.
                    while (temp.Read())
                    {
                        switch (temp.NodeType)
                        {
                            case XmlNodeType.Element:
                                writer.WriteStartElement(temp.Name);

                                if (temp.HasAttributes)
                                    writer.WriteAttributes(temp, true);

                                break;
                            case XmlNodeType.Text:
                                writer.WriteString(temp.Value);
                                break;
                            case XmlNodeType.XmlDeclaration:
                            case XmlNodeType.ProcessingInstruction:
                                writer.WriteProcessingInstruction(temp.Name, temp.Value);
                                break;
                            case XmlNodeType.Comment:
                                writer.WriteComment(temp.Value);
                                break;
                            case XmlNodeType.EndElement:
                                writer.WriteFullEndElement();
                                break;
                        }
                    }

                }
            }
            return output.ToString();

        }

        public string xmlSubTree(XmlReader temp)
        {
            StringBuilder output = new StringBuilder();
            // Create an XmlReader
            {
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(output, ws))
                {

                    // Parse the file and display each of the nodes.
                    while (temp.Read())
                    {
                        switch (temp.NodeType)
                        {
                            case XmlNodeType.Element:
                                writer.WriteStartElement(temp.Name);

                                if (temp.HasAttributes)
                                    writer.WriteAttributes(temp, true);

                                break;
                            case XmlNodeType.Text:
                                writer.WriteString(temp.Value);
                                break;
                            case XmlNodeType.XmlDeclaration:
                            case XmlNodeType.ProcessingInstruction:
                                writer.WriteProcessingInstruction(temp.Name, temp.Value);
                                break;
                            case XmlNodeType.Comment:
                                writer.WriteComment(temp.Value);
                                break;
                            case XmlNodeType.EndElement:
                                writer.WriteFullEndElement();
                                break;
                        }
                    }

                }
            }
            return output.ToString();

        }
    }
}
