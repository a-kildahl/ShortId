using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortId;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class ShortIdGeneratorTest
    {
        [TestMethod]
        public void Generate_GeneratesUniqueIds_IfNormalSettings()
        {
            ShortIdGenerator sut = new ShortIdGenerator();
            List<string> ids = new List<string>();

            for (int i = 0; i < 1000; i++)
            {
                string id = sut.Generate();
                ids.Add(id);
            }

            Assert.AreEqual(ids.Count, ids.Distinct().Count());
        }
    }
}
