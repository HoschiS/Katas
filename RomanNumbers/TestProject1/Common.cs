using System;

namespace TestProject1
{
    internal static class Common
    {
        internal static void TestThrows<T, T2, T3>(Func<T3, T2> callee, T3 arg) where T : Exception
        {
            try
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(callee);
                callee(arg);
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Did not throw exception at all");
            }
            catch (T)
            {
                return;
            }
            // ReSharper disable HeuristicUnreachableCode
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Did not throw correct exception");
            // ReSharper restore HeuristicUnreachableCode
        }
    }

    internal static class Assert
    {
        #region Equals (incl. overloads)

        public static bool Equals(this int value, int testee)
        {
            return value == testee;
        }

        public static bool Equals(this string value, string testee)
        {
            return value == testee;
        }

        public static bool Equals<T>(this T value, T testee)
        {
            return value.Equals(testee);
        }

        #endregion Equals (incl. overloads)

        #region Throws (incl. overloads)

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

        public static void That(bool test)
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(test);
        }
    }
}
