using LinaqHTML;
using LinaqHTML.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinaqHTML_Tests
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ATest()
        {
            string FileName = "atest.html";
            Document doc = new Document();

            var link1 = new a();
            link1.Href = "link"; 

            doc.Body.AddChild(link1);
            doc.Body.AddChild(new a() { Href = "kolejny w body"});

            doc.SaveToFile(FileName);
            Assert.IsTrue(File.Exists(FileName));
            //File.Delete(FileName);
        }

        [TestMethod]
        public void SaveToFileTest()
        {
            string FileName = "test.html";
            Document doc = new Document();
            doc.SaveToFile(FileName);
            Assert.IsTrue(File.Exists(FileName));
            //File.Delete(FileName);
        }

        [TestMethod]
        public void SaveToFileTestEmptyPath()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Document doc = new Document();
                doc.SaveToFile("");
            });
        }

        [TestMethod]
        public void SaveToFileTestNullPath()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Document doc = new Document();
                doc.SaveToFile(null);
            });
        }
    }
}
