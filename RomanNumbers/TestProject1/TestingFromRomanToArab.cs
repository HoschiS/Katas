using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbers;

namespace TestProject1
{
    [TestClass]
    public class TestingFromRomanToArab
    {
        public Func<string, int> CallToTest = a => NumberTranslator.FromRoman(a);

        // ReSharper disable InconsistentNaming
        [TestMethod] public void Test_EmptyString_WillReturn_Zero() { Assert.That(CallToTest("").Equals(0)); }
        [TestMethod] public void Test_UnknownSymbol_WillThrow() { Assert.That(CallToTest.Throws<ArgumentOutOfRangeException>("LSMF")); }
        [TestMethod] public void Test_I_WillReturn_One() { Assert.That(CallToTest("I").Equals(1)); }
        [TestMethod] public void Test_II_WillReturn_Two() { Assert.That(CallToTest("II").Equals(2)); }
        [TestMethod] public void Test_III_WillReturn_Three() { Assert.That(CallToTest("III").Equals(3)); }
        [TestMethod] public void Test_V_WillReturn_Five() { Assert.That(CallToTest("V").Equals(5)); }
        [TestMethod] public void Test_X_WillReturn_10() { Assert.That(CallToTest("X").Equals(10)); }
        [TestMethod] public void Test_L_WillReturn_Fivety() { Assert.That(CallToTest("L").Equals(50)); }
        [TestMethod] public void Test_C_WillReturn_Hundred() { Assert.That(CallToTest("C").Equals(100)); }
        [TestMethod] public void Test_D_WillReturn_Fivehundred() { Assert.That(CallToTest("D").Equals(500)); }
        [TestMethod] public void Test_M_WillReturn_Thousand() { Assert.That(CallToTest("M").Equals(1000)); }
        [TestMethod] public void Test_MCMXCIX_WillReturn_1999() { Assert.That(CallToTest("MCMXCIX").Equals(1999)); }
        [TestMethod] public void Test_MMXII_WillReturn_2012() { Assert.That(CallToTest("MMXII").Equals(2012)); }
        // ReSharper restore InconsistentNaming
    }
}
