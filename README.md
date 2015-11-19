# MessageParser.NET
MessageParser.NET Is Simple Mesage Parser For XML,ISO 8583,EXCEL,JSON 


EXCEL:

            MessageParser.NET.Tools.ExcelParser excel = new MessageParser.NET.Tools.ExcelParser(@"E:\Path\ExcelFile.xlsx");
            var temp = excel.GetWorksheet(1);
            excel.AddColumn(temp, "test");
            excel.AddData(temp, "test", "123");
            excel.AddRangeColumn(temp, new string[] { "t1", "t2", "t3" });
            excel.Save();
            

OR

            FileStream fs = new FileStream(@"E:\other\book.xlsx", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            byte[] buf = new byte[fs.Length];
            fs.Read(buf, 0, buf.Length);
            fs.Close();

            
            MessageParser.NET.Tools.ExcelParser excel = new MessageParser.NET.Tools.ExcelParser(buf);
            excel.CreateNewSheet("sheetName");
            excel.CreateNewSheet("sheetName2");
            var a = excel.GetWorksheet(2);
            excel.AddColumn(a, "test");
            excel.AddData(a, "test", "123");
            excel.AddRangeColumn(a, new string[] { "t1", "t2", "t3" });
            excel.Save(@"E:\other\book2.xlsx");
            


XML:

            string raw = @"<bookstore>
                    <book genre='autobiography' publicationdate='1981-03-22' ISBN='1-861003-11-0'>
                     <title>The Autobiography of Benjamin Franklin</title>
                      <author>
                       <first-name>Benjamin</first-name>
                       <last-name>Franklin</last-name>
                      </author>
                     <price>8.99</price>
                    </book>
                  </bookstore>";

            MessageParser.NET.Tools.XmlParser xml = new MessageParser.NET.Tools.XmlParser();
            var temp1 = xml.GetAllElements(raw);
            var temp2 = xml.GetAllText(raw);
            var temp3 = xml.GetAttributeValue(raw, "book", "genre");
            
            OR:
            
               String xmlString = @"<?xml version='1.0' encoding='utf - 8'?>
               <Card xmlns:Card = '1234' >
                <item y='12' x='23'>
                 <a></a>
                 <b></b>
                 <a></a>
                </item>
                <item2 x = 'abc' ></item2>
                 <item y='1' x='2'>
                  <a></a>
                 </item>
                <a y='1'></a>
               </Card> ";
               
               var s = xml.SetAttribute(xmlString, "item", "a","val" ,"yes");
               
               //OutPut:
            /*
            <? xml version = '1.0' encoding = 'utf - 8' ?>
           < Card xmlns:Card = "1234" >
              < item y = "12" x = "23" >
               < a val = "yes" ></ a >
               < b ></ b >
               < a val = "yes" ></ a >
              </ item >
              < item2 x = "abc" ></ item2 >
              < item y = "1" x = "2" >
               < a val = "yes" ></ a >
              </ item >
              < a y = "1" ></ a >
           </ Card >

            */
            
//OR
 
             var temp4 = xml.SetElementText(xmlString,"a","new 123 val");
             
             /*Out Put:
             <?xml version='1.0' encoding='utf - 8'?>
           <Card xmlns:Card = '1234' >
            <item y='12' x='23'>
             <a    >new 123 val</a>
             <b></b>
             <a>new 123 val</a>
            </item>
            <item2 x = 'abc' ></item2>
             <item y='1' x='2'>
              <a>new 123 val</a>
             </item>
            <a y='1'>new 123 val</a>
           </Card>*/


JSON:

           student[] stu = new student[3];
            stu[0] = new student { id = 1, name = "a" };
            stu[1] = new student { id = 2, name = "b" };
            stu[2] = new student { id = 3, name = "c" };


          var jsonPack = JsonTools.Serialize<student[]>(stu);

          var myObject = JsonTools.Deserialize<student[]>(jsonPack);
            
        [Serializable]
        [System.Runtime.Serialization.DataContract]
        class student
        {
            [System.Runtime.Serialization.DataMember]
            public int id { get; set; }
            [System.Runtime.Serialization.DataMember]
            public string name { get; set; }
        }
        

ISO8583:


            MessageParser.NET.Tools.ISO8583 iso = new MessageParser.NET.Tools.ISO8583();
            string[] data = iso.Parse("080020200000008000000000000000013239313130303031");
            
            Console.WriteLine(data[(int)MessageParser.NET.Tools.ISO8583.FieldUsage.CardAcceptorTerminalIdentification]);
            
            OR:
            
            string MTI = "0200";
            string PAN = "62737105152193654";
            string ProCode = "001000";
            string Amount = "20000";
            string DateTime = "0239501820";
            string STAN = "456";
            string TID = "44449999";
            string POSEM = "02";

            string[] DE = new string[130];

            DE[2] = PAN;
            DE[3] = ProCode;
            DE[4] = Amount;
            DE[7] = DateTime;
            DE[11] = STAN;
            DE[22] = POSEM;
            DE[41] = TID;

            string NewISOmsg = iso.Build(DE, MTI);
            
            
Refrence:

https://msdn.microsoft.com/en-us/library/cc189056(v=vs.95).aspx

http://www.codeproject.com/Tips/377446/BIM-ISO (BIM_ISO8583 )

http://epplus.codeplex.com/
