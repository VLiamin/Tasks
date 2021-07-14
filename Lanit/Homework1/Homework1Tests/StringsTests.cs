using Homework1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1Tests
{
    class StringsTests
    {
        Strings strings;
        [SetUp]
        public void Setup()
        {
            strings = new Strings();
        }

        [Test]
        public void TestUpper()
        {

            Assert.AreEqual(strings.ToUpper("CatDogParrot"), "CATDOGPARROT");
        }

        [Test]
        public void TestLower()
        {

            Assert.AreEqual(strings.ToLower("CatDogParrot"), "catdogparrot");
        }
    }
}
