using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLTKSharp;

namespace CommonWordsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int freq = CommonWords.GetFrequency("this");
            Console.WriteLine(freq);
        }
    }
}
