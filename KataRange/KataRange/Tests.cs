using System;
using NUnit.Framework;

namespace KataRange {
    [TestFixture]
    public class Tests {
        #region Helpers

        private static void TestCaseContains(string input, string comparison, bool expectedValue) {
            Assert.That(new Range(input).Contains(comparison), Is.EqualTo(expectedValue));
        }

        private static void TestCaseAllPoints(string input, string comparison, bool expectedValue) {
            Assert.That(new Range(input).AllPoints(comparison), Is.EqualTo(expectedValue));
        }

        private static void TestCaseContainsRange(string input, string comparison, bool expectedValue) {
            Assert.That(new Range(input).ContainsRange(comparison), Is.EqualTo(expectedValue));
        }

        private static void TestCaseOverlapsRange(string input, string comparison, bool expectedValue) {
            Assert.That(new Range(input).OverlapsRange(comparison), Is.EqualTo(expectedValue));
        }

        private static void TestCaseEqualsRange(string input, string comparison, bool expectedValue) {
            Assert.That(new Range(input).EqualsRange(comparison), Is.EqualTo(expectedValue));
        }

        #endregion Helpers

        #region Input-Validation

        [Test, ExpectedException(typeof(ArgumentException))]
        public void Teste_Falsche_Eingabe_1() {
            new Range("");
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void Teste_Falsche_Eingabe_2() {
            new Range("(");
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void Teste_Falsche_Eingabe_3() {
            new Range("[");
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void Teste_Falsche_Eingabe_4() {
            new Range("()");
        }

        #endregion Input-Validation

        [Test]
        public void Teste_Contains_1() {
            TestCaseContains("[2,6)", "{2,4}", true);
        }

        [Test]
        public void Teste_Contains_2() {
            TestCaseContains("[2,6)", "{-1,1,6,10}", false);
        }

        [Test]
        public void Teste_AllPoints_1() {
            TestCaseAllPoints("[2,6)", "{2,3,4,5}", true);
        }

        [Test]
        public void Teste_AllPoints_2() {
            TestCaseAllPoints("[2,6)", "{2,3,4,5}", true);
        }

        [Test]
        public void Teste_AllPoints_3() {
            TestCaseAllPoints("[2,6]", "{2,3,4,5,6}", true);
        }

        [Test]
        public void Teste_AllPoints_4() {
            TestCaseAllPoints("(2,6)", "{3,4,5}", true);
        }

        [Test]
        public void Teste_AllPoints_5() {
            TestCaseAllPoints("(2,6]", "{3,4,5,6}", true);
        }

        [Test]
        public void Teste_ContainsRange_1() {
            TestCaseContainsRange("[2,5)", "[7,10)", false);
        }

        [Test]
        public void Teste_ContainsRange_2() {
            TestCaseContainsRange("[3,5)", "[2,10)", false);
        }

        [Test]
        public void Teste_ContainsRange_3() {
            TestCaseContainsRange("[2,10)", "[3,5]", true);
        }

        [Test]
        public void Teste_ContainsRange_4() {
            TestCaseContainsRange("[3,5]", "[3,5)", true);
        }

        [Test]
        public void Teste_OverlapsRange_1() {
            TestCaseOverlapsRange("[2,5)", "[7,10)", false);
        }

        [Test]
        public void Teste_OverlapsRange_2() {
            TestCaseOverlapsRange("[2,10)", "[3,5)", true);
        }

        [Test]
        public void Teste_OverlapsRange_3() {
            TestCaseOverlapsRange("[3,5)", "[3,5)", true);
        }

        [Test]
        public void Teste_OverlapsRange_4() {
            TestCaseOverlapsRange("[2,5)", "[3,10)", true);
        }

        [Test]
        public void Teste_OverlapsRange_5() {
            TestCaseOverlapsRange("[3,5)", "[2,10)", true);
        }

        [Test]
        public void Teste_EqualsRange_1() {
            TestCaseEqualsRange("[3,5)", "[3,5)", true);
        }

        [Test]
        public void Teste_EqualsRange_2() {
            TestCaseEqualsRange("[2,10)", "[3,5)", false);
        }

        [Test]
        public void Teste_EqualsRange_3() {
            TestCaseEqualsRange("[2,5)", "[3,10)", false);
        }

        [Test]
        public void Teste_EqualsRange_4() {
            TestCaseEqualsRange("[3,5)", "[2,10)", false);
        }
    }
}
