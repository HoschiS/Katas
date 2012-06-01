using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbers;

namespace TestProject1
{
    [TestClass]
    public class TestingFromArabToRoman
    {
        public Func<string, string> CallToTest = a => NumberTranslator.FromArabic(a);

        // ReSharper disable InconsistentNaming
        [TestMethod]
        public void Test_EmptyString_WillReturn_EmptyString() { Assert.That(CallToTest("").Equals("")); }
        [TestMethod] public void Test_NonNumber_WillThrow() { Assert.That(CallToTest.Throws<ArgumentException>("LSMF")); }
        [TestMethod] public void Test_NegativeNumber_WillThrow() { Assert.That(CallToTest.Throws<ArgumentOutOfRangeException>("-1")); }
        [TestMethod] public void Test_One_WillReturn_I() { Assert.That(CallToTest("1").Equals("I")); }
        [TestMethod] public void Test_Two_WillReturn_II() { Assert.That(CallToTest("2").Equals("II")); }
        [TestMethod] public void Test_Three_WillReturn_III() { Assert.That(CallToTest("3").Equals("III")); }
        [TestMethod] public void Test_Five_WillReturn_V() { Assert.That(CallToTest("5").Equals("V")); }
        [TestMethod] public void Test_Ten_WillReturn_X() { Assert.That(CallToTest("10").Equals("X")); }
        [TestMethod] public void Test_Fivety_WillReturn_L() { Assert.That(CallToTest("50").Equals("L")); }
        [TestMethod] public void Test_Hundred_WillReturn_C() { Assert.That(CallToTest("100").Equals("C")); }
        [TestMethod] public void Test_Fivehundred_WillReturn_D() { Assert.That(CallToTest("500").Equals("D")); }
        [TestMethod] public void Test_Thousand_WillReturn_M() { Assert.That(CallToTest("1000").Equals("M")); }
        [TestMethod] public void Test_1999_WillReturn_MCMXCIX() { Assert.That(CallToTest("1999").Equals("MCMXCIX")); }
        [TestMethod] public void Test_2012_WillReturn_MMXII() { Assert.That(CallToTest("2012").Equals("MMXII")); }
        // ReSharper restore InconsistentNaming
    }
}
