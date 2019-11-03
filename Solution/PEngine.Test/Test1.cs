using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PEngine.Test
{
    class Test1
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestA()
        {
            Assert.IsFalse(false);
        }
    }
}
