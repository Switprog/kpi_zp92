using System;
using Lab1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab1Tests
{
    [TestClass]
    public class StringAnalyzerTest
    {
        [TestMethod]
        public void CountAverageLengthTest()
        {
            string[] input = { "word", "hello", "string" };
            int expected = 5;
            int actual = StringAnalyzer.CountAverageLength(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMoreThanAverageTest()
        {
            string[] input = { "word", "hello", "string" };
            string[] expected = { "string" };
            string[] actual = StringAnalyzer.FindMoreThanAverage(input);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
