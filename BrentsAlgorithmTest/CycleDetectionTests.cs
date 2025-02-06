using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrentsAlgorithm;

namespace BrentsAlgorithmTest
{
    [TestClass]
    public class CycleDetectionTests
    {
        [TestMethod]
        public void TestFindCycle_NullFunction()
        {
            int x0 = 1;
            CycleDetectionResult result = BrentCycleDetection.FindCycle(x0, (Func<int, int>)(null !));
            Assert.AreEqual(0, result.Mu);
            Assert.AreEqual(0, result.Lambda);
        }

        [TestMethod]
        public void TestFindCycle_SelfCycle()
        {
            int x0 = 42;
            Func<int, int> f = delegate (int x)
            {
                return x;
            };
            CycleDetectionResult result = BrentCycleDetection.FindCycle(x0, f);
            Assert.AreEqual(0, result.Mu);
            Assert.AreEqual(1, result.Lambda);
        }

        [TestMethod]
        public void TestFindCycle_PreCycleCycle()
        {
            int x0 = 1;
            Func<int, int> f = delegate (int x)
            {
                if (x == 1)
                {
                    return 2;
                }
                else if (x == 2)
                {
                    return 3;
                }
                else if (x == 3)
                {
                    return 4;
                }
                else if (x == 4)
                {
                    return 2;
                }

                return x;
            };
            CycleDetectionResult result = BrentCycleDetection.FindCycle(x0, f);
            Assert.AreEqual(1, result.Mu);
            Assert.AreEqual(3, result.Lambda);
        }

        [TestMethod]
        public void TestFindCycle_DoubleLoop()
        {
            int x0 = 0;
            Func<int, int> f = delegate (int x)
            {
                if (x == 0)
                {
                    return 1;
                }

                if (x == 1)
                {
                    return 2;
                }

                if (x == 2)
                {
                    return 3;
                }

                if (x == 3)
                {
                    return 4;
                }

                if (x == 4)
                {
                    return 1;
                }

                return x;
            };
            CycleDetectionResult result = BrentCycleDetection.FindCycle(x0, f);
            Assert.AreEqual(1, result.Mu);
            Assert.AreEqual(4, result.Lambda);
        }

        [TestMethod]
        public void TestFindCycle_StringCycle()
        {
            string x0 = "A";
            Func<string, string> f = delegate (string s)
            {
                if (s == "A")
                {
                    return "B";
                }

                if (s == "B")
                {
                    return "C";
                }

                if (s == "C")
                {
                    return "A";
                }

                return s;
            };
            CycleDetectionResult result = BrentCycleDetection.FindCycle(x0, f);
            Assert.AreEqual(0, result.Mu);
            Assert.AreEqual(3, result.Lambda);
        }
    }
}