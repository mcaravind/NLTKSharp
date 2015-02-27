using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLTKSharp;

namespace StemmerTest
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void TestStemming()
        {
            string word = "caresses";
            string stemmed = Stemmer.GetStem(word);
            Assert.AreEqual(stemmed,"caress");
        }
    }
}
