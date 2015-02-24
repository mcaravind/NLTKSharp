using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLTKSharp;

namespace StemmerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string word = "enumerate";
            int measure = Stemmer.GetWordMeasure(word);
            Assert.AreEqual(4,measure);
        }
    }
}
