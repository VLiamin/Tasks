using NUnit.Framework;
using Homework1;
using System.Collections.Generic;
using System;

namespace Homework1Tests
{
    class FilesTests
    {

        Files files;
        [SetUp]
        public void Setup()
        {
            files = new Files();
        }

        [Test]
        public void TestAdditional()
        {
            List<String> lines = files.ReadFile("newFile.txt");
            List<String> list = new List<String>();
            list.Add("parrot");
            Assert.AreEqual(lines, list);
        }
    }
}
