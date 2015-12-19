# MessageParser.NET
MessageParser.NET Is Simple Mesage Parser For XML,ISO 8583,EXCEL,JSON 

Nuget Url: http://www.nuget.org/packages/MessageParser.NET/

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
            
            //OR:
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

Patterns:

             string txt = @"
              hi my name is alireza.
              this is a test value for messageparser.net.
              messageparser.net can detect date value in the txt like (persian date:1394-01-01).
              or detect Geo position like this (21.422530, 39.826178).
              or mail address like (test123@any.com,t4t@test.com|t5t@any.ir).
              or url like (https://www.nuget.org/profiles/AlirezaP , https://github.com/alirezaP/).
              or currency like ($1,000or$125,100).";

            MessageParser.NET.Tools.Patterns pattern = new MessageParser.NET.Tools.Patterns();

            string[] Mail = pattern.GetMails(txt);
            string[] Currency = pattern.GetCurrency(txt);
            string[] Date = pattern.GetDate(txt);
            string[] Url = pattern.GetUrl(txt);
            string[] Position = pattern.GetPosition(txt);

            Console.WriteLine("all mail address in the txt:");
            foreach (string t in Mail)
            {
                Console.WriteLine(t);
            }

            Console.WriteLine("all Currency in the txt:");
            foreach (string t in Currency)
            {
                Console.WriteLine(t);
            }

            Console.WriteLine("all Date in the txt:");
            foreach (string t in Date)
            {
                Console.WriteLine(t);
            }

            Console.WriteLine("all Url in the txt:");
            foreach (string t in Url)
            {
                Console.WriteLine(t);
            }

            Console.WriteLine("all Position in the txt:");
            foreach (string t in Position)
            {
                Console.WriteLine(t);
            }

           
 Batch Parser:<br/>
 assume we have a txt file with this name "data.txt".<br/>
"data.txt":<br/>

                [alireza,p,0010000000,24,http://github.com/alirezap][ali,pa,0010000230,25,http://nuget.org/alirezap]

first you must create a xml file (syntax) for example:<br/>
"syntax.xml":<br/>

                <?xml version="1.0" encoding="UTF-8"?>
                <body>
                <syntax>
                <record StartWith="[" EndWith="]"/>
                </syntax>
                <content>
                <FIELD1 ID="1" Type="string" Title="name" TERMINATOR=","/>
                <FIELD2 ID="2" Type="string" Title="lastname" TERMINATOR=","/>
                <FIELD3 ID="3" Type="string" Title="shenasname" TERMINATOR=","/>
                <FIELD4 ID="4" Type="int" Title="age" TERMINATOR=","/>
                <FIELD5 ID="5" Type="string" Title="url" TERMINATOR="]"/>
                </content>
                </body>
                
if records has a boundary you must set that in "StartWith" and "EndWith" attribute in the record element. <br/>
in this sample our record is between "[" and "]". ([record]) --> ([alireza,p,0010000000,24,http://github.com/alirezap]).<br/>
so record should be : <br/>
<record StartWith="[" EndWith="]"/>. <br/>

for next step you must set fields info in syntax file. for example each record in the "data.txt" has 5 section (name,lastname,id,age,url)<br/>
so content element should be has 5 field (FIELD1,FIELD2,FIELD3,FIELD4,FIELD5).<br/>
each field has 5 property (ID,Type,Title,TERMINATOR,MAX_LENGTH)<br/>

ID:<br/>
is a unic for field and it must order by data sections.<br/>

Type:<br/>
is type of field (for example if the first section type in the data.txt is string so Type in the Filed1 must be string).<br/>

*Note: supported type: [string , char , int , double , decimal , byte , bool]<br/>

Title:<br/>
is a property name for elemnet.( for example first element in the data.txt is name so Title Value in the Filed1 must be name)<br/>

*Note:Title Value must be match with your class property name. for example if Title value is Age you must craete a class that have a property with Age name.<br/>

TERMINATOR:<br/>
specifid delimiter for field. (for example in the "alireza,p,0010000000,24,http://github.com/alirezap" section splited with ',' so TERMINATOR for each fields must be ',')


Full Example:<br/>

data.txt:<br/>
                [alireza,p,0010000000,24,http://github.com/alirezap][ali,pa,0010000230,25,http://nuget.org/alirezap]

syntax.xml:<br/>

                <?xml version="1.0" encoding="UTF-8"?>
                <body>
                <syntax>
                <record StartWith="[" EndWith="]"/>
                </syntax>
                <content>
                <FIELD1 ID="1" Type="string" Title="name" TERMINATOR=","/>
                <FIELD2 ID="2" Type="string" Title="lastname" TERMINATOR=","/>
                <FIELD3 ID="3" Type="string" Title="shenasname" TERMINATOR=","/>
                <FIELD4 ID="4" Type="int" Title="age" TERMINATOR=","/>
                <FIELD5 ID="5" Type="string" Title="url" TERMINATOR="]"/>
                </content>
                </body>

now in the code:<br/>

define a class for batch file:<br/>

                class student
                {
                public string name { get; set; }
                public string lastname { get; set; }
                public int age { get; set; }
                public string shenasname { get; set; }
                public string url { get; set; }
                }

then call parsefile:<br/>

                student myObj = new student();
                student[] res = batch.ParseFile("e:\\data.txt", "e:\\syntax.xml", myObj);
                
                foreach(student s in res)
                {
                Console.WriteLine("{0} {1} {2} {3} {4}", s.name, s.lastname, s.age, s.shenasname, s.url);
                }
                
Other Sample For Batch Parser:<br/>

data.txt: (without boundary)<br/>

                alireza,paridar,0010000000,24,http://github.com/alirezap,ali,pari,0010000230,25,http://nuget.org/alirezap,

syntax.xml: (without boundary StartWith and EndWith value is null)<br/>

                <?xml version="1.0" encoding="UTF-8"?>
                <body>
                <syntax>
                <record StartWith="" EndWith=""/>
                </syntax>
                <content>
                <FIELD1 ID="1" Type="string" Title="name" TERMINATOR="," MAX_LENGTH="30"/>
                <FIELD2 ID="2" Type="string" Title="lastname" TERMINATOR="," MAX_LENGTH="30"/>
                <FIELD3 ID="3" Type="string" Title="shenasname" TERMINATOR="," MAX_LENGTH="30"/>
                <FIELD4 ID="4" Type="int" Title="age" TERMINATOR="," MAX_LENGTH="3"/>
                <FIELD5 ID="5" Type="string" Title="url" TERMINATOR="," MAX_LENGTH="50"/>
                </content>
                </body>

in the code:<br/>

define a class for batch file:<br/>

                class student
                {
                public string name { get; set; }
                public string lastname { get; set; }
                public int age { get; set; }
                public string shenasname { get; set; }
                public string url { get; set; }
                }

then call parsefile:<br/>

                student myObj = new student();
                student[] res = batch.ParseFile("e:\\data.txt", "e:\\syntax.xml", myObj);
            
                foreach(student s in res)
                {
                Console.WriteLine("{0} {1} {2} {3} {4}", s.name, s.lastname, s.age, s.shenasname, s.url);
                }


            
            
Refrence:

https://msdn.microsoft.com/en-us/library/cc189056(v=vs.95).aspx

http://www.codeproject.com/Tips/377446/BIM-ISO (BIM_ISO8583 )

http://epplus.codeplex.com/
