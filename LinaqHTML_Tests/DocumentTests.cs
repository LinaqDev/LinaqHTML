using LinaqHTML;
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
    class DocumentTests
    {
        [TestMethod]
        public void SaveToFileTest()
        {
            string FileName = "test.pdf";
            Document doc = new Document();
            doc.SaveToFile(FileName);
            Assert.IsTrue(File.Exists(FileName));
            File.Delete(FileName);
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
