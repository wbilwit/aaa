using aaa;
using NUnit.Framework;
using System;

namespace aaaTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /*
        [TestCase("0,1,2")]
        public void AddTest(string test)
        {
            StringCalculator obj = new StringCalculator();
            var a = test.Split(',');
            Assert.That(a.Length >= 0 && a.Length <= 2);
        }
        */

        [TestCase("0,1", 1)]
        [TestCase("1,1", 2)]
        [TestCase("0,2,0", 2)]
        [TestCase(" ", 0)]
        [TestCase("", 0)]
        [TestCase("0,1,2,3,4,5,6,7,3", 31)]
        [TestCase("0,1, ,3,4,5,6,7,3", 29)]
        [TestCase("0,3\n2", 5)]
        [TestCase("//;\n1;2", 3)]
        [TestCase("//,\n1,2", 3)]
        [TestCase("0,2,1001", 2)]
        //[TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[***]\n1***2***3", 6)]
        public void AddReturnSumWhenSuppliedMultipleNumbersInString(string numbers, int expectedResult)
        {
            var result = StringCalculator.Add(numbers);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("0,-2,0", "negatives not allowed: -2 ")]
        [TestCase("0,-4,0", "negatives not allowed: -4 ")]
        [TestCase("0,-4,-3", "negatives not allowed: -4 -3 ")]
        public void AddReturnSumWhenSuppliedMultipleNumbersInStringException(string numbers, string expectedResult)
        {
            Assert.That(() => StringCalculator.Add(numbers), Throws.TypeOf<ArgumentException>().With.Message.EqualTo(expectedResult));
        }
    }
}