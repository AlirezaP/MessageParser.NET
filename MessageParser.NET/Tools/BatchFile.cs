using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MessageParser.NET.Tools
{
   public class BatchFile
    {
       private class Field
        {
            public int ID { get; set; }
            public string Type { get; set; }
            public string Title { get; set; }
            public string TERMINATOR { get; set; }
            public int MAX_LENGTH { get; set; }
        }

        private Field[] GetSyntaxt(string syntax)
        {
            XmlParser xml = new XmlParser();

            Queue<Field> res = new Queue<Field>();
            var temp = xml.GetAllElements(syntax).Where(p => p.Contains("FIELD")).ToArray();

            for (int i = 0; i < temp.Length; i++)
            {
                Field obj = new Field();
                obj.ID = Convert.ToInt32(xml.GetAttributeValue(syntax, temp[i], "ID"));
                obj.Type = xml.GetAttributeValue(syntax, temp[i], "Type");
                obj.Title = xml.GetAttributeValue(syntax, temp[i], "Title");
                obj.TERMINATOR = xml.GetAttributeValue(syntax, temp[i], "TERMINATOR");
                obj.MAX_LENGTH = Convert.ToInt32(xml.GetAttributeValue(syntax, temp[i], "MAX_LENGTH"));
                res.Enqueue(obj);
            }

            return res.OrderBy(p => p.ID).ToArray();
        }

        private T ParseWithBoundary<T>(string record, T templateClass, Field[] fields)
        {

            var p = typeof(T).GetProperties();

            object tRes = (T)Activator.CreateInstance(typeof(T));

            int index = 0;
            for (int i = 0; i < fields.Length; i++)
            {

                string delimiter = fields[i].TERMINATOR;
                string temp = "";


                for (int j = 0; j < record.Length; j++)
                {
                    if (record[j].ToString() != delimiter)
                    {
                        temp += record[j].ToString();
                        index++;
                    }
                    else
                    {
                        record = record.Replace(temp + delimiter, "");

                        if (fields[i].Title != null && p.Where(l => l.Name == fields[i].Title).FirstOrDefault() != null)
                        {
                            PropertyInfo prop = templateClass.GetType().GetProperty(fields[i].Title, BindingFlags.Public | BindingFlags.Instance);
                            if (null != prop && prop.CanWrite)
                            {
                                switch (fields[i].Type.ToLower())
                                {
                                    case "string": prop.SetValue(tRes, temp, null); break;
                                    case "int": prop.SetValue(tRes, Convert.ToInt32(temp), null); break;
                                    case "bool": prop.SetValue(tRes, Convert.ToBoolean(temp), null); break;
                                    case "double": prop.SetValue(tRes, Convert.ToDouble(temp), null); break;
                                    case "decimal": prop.SetValue(tRes, Convert.ToDecimal(temp), null); break;
                                    case "char": prop.SetValue(tRes, Convert.ToChar(temp), null); break;
                                    case "byte": prop.SetValue(tRes, Convert.ToByte(temp), null); break;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            return (T)tRes;
        }

        private T[] ParseRaw<T>(string record, T templateClass, Field[] fields)
        {
            Queue<T> res = new Queue<T>();

            var p = typeof(T).GetProperties();

            int index = 0;

            while (index < record.Length)
            {
                object tRes = (T)Activator.CreateInstance(typeof(T));
                for (int i = 0; i < fields.Length; i++)
                {

                    string delimiter = fields[i].TERMINATOR;

                    if (delimiter.ToLower() == @"\r\n")
                        delimiter = Environment.NewLine;

                    string temp = "";

                    for (int j = index; j < record.Length; j++)
                    {
                        //if (record[j].ToString() != delimiter)
                        if(!isEqual(record,ref j,delimiter))
                        {
                            temp += record[j].ToString();
                            index++;
                        }
                        else
                        {
                            index += delimiter.Length;

                            if (fields[i].Title != null && p.Where(l => l.Name == fields[i].Title).FirstOrDefault() != null)
                            {
                                PropertyInfo prop = templateClass.GetType().GetProperty(fields[i].Title, BindingFlags.Public | BindingFlags.Instance);
                                if (null != prop && prop.CanWrite)
                                {
                                    switch (fields[i].Type.ToLower())
                                    {
                                        case "string": prop.SetValue(tRes, temp, null); break;
                                        case "int": prop.SetValue(tRes, Convert.ToInt32(temp), null); break;
                                        case "bool": prop.SetValue(tRes, Convert.ToBoolean(temp), null); break;
                                        case "double": prop.SetValue(tRes, Convert.ToDouble(temp), null); break;
                                        case "decimal": prop.SetValue(tRes, Convert.ToDecimal(temp), null); break;
                                        case "char": prop.SetValue(tRes, Convert.ToChar(temp), null); break;
                                        case "byte": prop.SetValue(tRes, Convert.ToByte(temp), null); break;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                res.Enqueue((T)tRes);
            }

            return res.ToArray();
        }

        public T[] ParseFile<T>(string batchFileAddress,string SyntaxFileAddress, T templateClass)
        {
            try {
                if (!System.IO.File.Exists(batchFileAddress))
                    throw new System.IO.FileNotFoundException("Not Found Batch File");

                if (!System.IO.File.Exists(SyntaxFileAddress))
                    throw new System.IO.FileNotFoundException("Not Found Syntax File");

                System.IO.StreamReader sr = new System.IO.StreamReader(batchFileAddress,Encoding.UTF8);
                System.IO.StreamReader sr2 = new System.IO.StreamReader(SyntaxFileAddress);

                return ParseData(sr.ReadToEnd(), sr2.ReadToEnd(), templateClass);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public T[] ParseData<T>(string data,string syntax,T templateClass)
        {
            Queue<T> res = new Queue<T>();
            XmlParser xml = new XmlParser();

            var start = xml.GetAttributeValue(syntax, "record", "StartWith");
            var end = xml.GetAttributeValue(syntax, "record", "EndWith");
            var fields = GetSyntaxt(syntax);

            int index1 = 0;
            int index2 = 0;

            int l = 0;
            int r = 0;

            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                //if (data[0].ToString() != start)
                //    return null;

                do
                {
                    //if (data[index2].ToString() == sart)
                        if (!isEqual(data, ref index2, start))
                            l++;

                    //if (data[index2].ToString() == end)
                        if (!isEqual(data, ref index2, end))
                            r++;

                    if (r == l)
                    {

                        string sub = data.Substring(index1, index2 - index1 + 1);
                        index1 = index2 + 1;

                        l = 0;
                        r = 0;

                        sub = sub.Substring(1, sub.Length - 1);
                        res.Enqueue(ParseWithBoundary(sub, templateClass, fields));

                    }

                    index2++;

                } while (index2 <= data.Length - 1);


            }
            else
            {
                return ParseRaw(data, templateClass, fields);
            }

            return res.ToArray();
        }

        private bool isEqual(string str, ref int index, string delimiter)
        {
            //if (str[index].ToString() == delimiter)
            //    return true;

            for (int i = 0; i < delimiter.Length; i++)
            {
                if (str[index + i] != delimiter[i])
                {
                    return false;
                }
            }

            //index += delimiter.Length;
            return true;
        }
    }
}
