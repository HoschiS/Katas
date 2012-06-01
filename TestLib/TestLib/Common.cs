using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLib
{
    public static class Common
    {
        public static void TestThrows<T, T2, T3>(Func<T3, T2> callee, T3 arg) where T : Exception
        {
            try
            {
                T2 result = callee(arg);
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Did not throw exception at all");
            }
            catch (T)
            {
                return;
            }
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Did not throw correct exception");
        }

        public static void TestThrows<T, T2>(Func<T2> callee) where T : Exception
        {
            try
            {
                T2 result = callee();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Did not throw exception at all");
            }
            catch (T)
            {
                return;
            }
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Did not throw correct exception");
        }

        public static void TestThrows<T>(Action callee) where T : Exception
        {
            try
            {
                callee();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Did not throw exception at all");
            }
            catch (T)
            {
                return;
            }
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Did not throw correct exception");
        }

        public static void TestThrows<T, T2>(Action<T2> callee, T2 arg) where T : Exception
        {
            try
            {
                callee(arg);
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Did not throw exception at all");
            }
            catch (T)
            {
                return;
            }
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Did not throw correct exception");
        }
    }

    public static class Ashure
    {
        #region Equals (incl. overloads)

        public static bool Equals(this int value, int testee) { return value == testee; }

        public static bool Equals(this string value, string testee) { return value == testee; }

        public static bool Equals<T>(this T value, T testee) { return value.Equals(testee); }

        public static bool IsEqualTo(this int value, int testee) {
            if (value != testee)
            {
                Console.Error.WriteLine("Should be " + testee + " but was " + value);
                return false;
            }
            return true;
        }

        #endregion Equals (incl. overloads)

        #region Throws (incl. overloads)

        public static bool Throws<T>(this Action call) where T : Exception
        {
            Common.TestThrows<T>(call);
            return true;
        }

        public static bool Throws<T, T2>(this Action<T2> call, T2 arg) where T : Exception
        {
            Common.TestThrows<T, T2>(call, arg);
            return true;
        }

        public static bool Throws<T, T2>(this Func<T2> call) where T : Exception
        {
            Common.TestThrows<T, T2>(call);
            return true;
        }

        public static bool Throws<T, T2, T3>(this Func<T3, T2> call, T3 arg) where T : Exception
        {
            Common.TestThrows<T, T2, T3>(call, arg);
            return true;
        }

        public static bool Throws<T>(this Func<string, int> call, string arg) where T : Exception
        {
            Common.TestThrows<T, int, string>(call, arg);
            return true;
        }

        public static bool Throws<T>(this Func<int, string> call, int arg) where T : Exception
        {
            Common.TestThrows<T, string, int>(call, arg);
            return true;
        }

        public static bool Throws<T>(this Func<string, string> call, string arg) where T : Exception
        {
            Common.TestThrows<T, string, string>(call, arg);
            return true;
        }

        public static bool Throws<T>(this Func<int, int> call, int arg) where T : Exception
        {
            Common.TestThrows<T, int, int>(call, arg);
            return true;
        }

        #endregion Throws (incl. overloads)

        public static bool IsTrue(this bool value) { return value; }
        public static bool IsFalse(this bool value) { return !value; }

        public static void That(bool test)
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(test);
        }
    }
}
