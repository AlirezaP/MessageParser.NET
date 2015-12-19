using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BatchParserUnitTest
{
    [TestClass]
    public class UnitTest1 : MessageParser.NET.Tools.BatchFile
    {
        [TestMethod]
        public void TestMethod1()
        {
            string data1 = @"[alireza,p,0010000000,24,http://github.com/alirezap][ali,pari,0010000230,25,http://nuget.org/alirezap]";
            string syntax1 = @"<?xml version=""1.0"" encoding=""UTF - 8""?>
  <body>
  <syntax>
  <record StartWith = ""["" EndWith = ""]"" />
     </syntax>
     <content>
     <FIELD1 ID = ""1"" Type = ""string"" Title = ""name"" TERMINATOR = "","" MAX_LENGTH = ""30"" />
     <FIELD2 ID = ""2"" Type = ""string"" Title = ""lastname"" TERMINATOR = "","" MAX_LENGTH = ""30"" />
     <FIELD3 ID = ""3"" Type = ""string"" Title = ""shenasname"" TERMINATOR = "","" MAX_LENGTH = ""30"" />
     <FIELD4 ID = ""4"" Type = ""int"" Title = ""age"" TERMINATOR = "","" MAX_LENGTH = ""3"" />
     <FIELD5 ID = ""5"" Type = ""string"" Title = ""url"" TERMINATOR = ""]"" MAX_LENGTH = ""50"" />
     </content>
     </body>";

            student myobj = new student();
            var res = ParseData(data1, syntax1, myobj);

            Assert.AreEqual("alireza", res[0].name);
            Assert.AreEqual("p", res[0].lastname);
            Assert.AreEqual("0010000000", res[0].shenasname);
            Assert.AreEqual("24", res[0].age.ToString());
            Assert.AreEqual("http://github.com/alirezap", res[0].url);


            Assert.AreEqual("ali", res[1].name);
            Assert.AreEqual("pari", res[1].lastname);
            Assert.AreEqual("0010000230", res[1].shenasname);
            Assert.AreEqual("25", res[1].age.ToString());
            Assert.AreEqual("http://nuget.org/alirezap", res[1].url);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string data1 = @"alireza,p,0010000000,24,http://github.com/alirezap,ali,pari,0010000230,25,http://nuget.org/alirezap,";
            string syntax1 = @"<?xml version=""1.0"" encoding=""UTF - 8""?>
  <body>
  <syntax>
  <record StartWith = """" EndWith = """" />
     </syntax>
     <content>
     <FIELD1 ID = ""1"" Type = ""string"" Title = ""name"" TERMINATOR = "","" MAX_LENGTH = ""30"" />
     <FIELD2 ID = ""2"" Type = ""string"" Title = ""lastname"" TERMINATOR = "","" MAX_LENGTH = ""30"" />
     <FIELD3 ID = ""3"" Type = ""string"" Title = ""shenasname"" TERMINATOR = "","" MAX_LENGTH = ""30"" />
     <FIELD4 ID = ""4"" Type = ""int"" Title = ""age"" TERMINATOR = "","" MAX_LENGTH = ""3"" />
     <FIELD5 ID = ""5"" Type = ""string"" Title = ""url"" TERMINATOR = "","" MAX_LENGTH = ""50"" />
     </content>
     </body>";

            student myobj = new student();
            var res = ParseData(data1, syntax1, myobj);

            Assert.AreEqual("alireza", res[0].name);
            Assert.AreEqual("p", res[0].lastname);
            Assert.AreEqual("0010000000", res[0].shenasname);
            Assert.AreEqual("24", res[0].age.ToString());
            Assert.AreEqual("http://github.com/alirezap", res[0].url);


            Assert.AreEqual("ali", res[1].name);
            Assert.AreEqual("pari", res[1].lastname);
            Assert.AreEqual("0010000230", res[1].shenasname);
            Assert.AreEqual("25", res[1].age.ToString());
            Assert.AreEqual("http://nuget.org/alirezap", res[1].url);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string data1 = @"alireza,p,0010000000,24,http://github.com/alirezap"
+Environment.NewLine+
@"ali,pari,0010000230,25,http://nuget.org/alirezap"+ Environment.NewLine;

            string syntax1 = @"<?xml version=""1.0"" encoding=""UTF - 8""?>
  <body>
  <syntax>
  <record StartWith = """" EndWith = """" />
     </syntax>
     <content>
     <FIELD1 ID = ""1"" Type = ""string"" Title = ""name"" TERMINATOR = "","" MAX_LENGTH = ""30"" />
     <FIELD2 ID = ""2"" Type = ""string"" Title = ""lastname"" TERMINATOR = "","" MAX_LENGTH = ""30"" />
     <FIELD3 ID = ""3"" Type = ""string"" Title = ""shenasname"" TERMINATOR = "","" MAX_LENGTH = ""30"" />
     <FIELD4 ID = ""4"" Type = ""int"" Title = ""age"" TERMINATOR = "","" MAX_LENGTH = ""3"" />
     <FIELD5 ID = ""5"" Type = ""string"" Title = ""url"" TERMINATOR = ""\r\n"" MAX_LENGTH = ""50"" />
     </content>
     </body>";

            student myobj = new student();
            var res = ParseData(data1, syntax1, myobj);

            Assert.AreEqual("alireza", res[0].name);
            Assert.AreEqual("p", res[0].lastname);
            Assert.AreEqual("0010000000", res[0].shenasname);
            Assert.AreEqual("24", res[0].age.ToString());
            Assert.AreEqual("http://github.com/alirezap", res[0].url);


            Assert.AreEqual("ali", res[1].name);
            Assert.AreEqual("pari", res[1].lastname);
            Assert.AreEqual("0010000230", res[1].shenasname);
            Assert.AreEqual("25", res[1].age.ToString());
            Assert.AreEqual("http://nuget.org/alirezap", res[1].url);
        }
    }

    class student
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }
        public string shenasname { get; set; }
        public string url { get; set; }
    }
}
