using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Tests
{
    [TestClass]
    [TestCategory(TestCategories.LIFECYCLE)]
    public class LifeCycle
    {

        private static string sharedString;

        [ClassInitialize]
        public static void LifecycleClassInit(TestContext context)
        {
            Console.WriteLine("Class Initialize");
            sharedString = "42";
            Console.WriteLine("Shared string is set");
        }

        [ClassCleanup]
        public static void LifecycleClassCleanup()
        {
            Console.WriteLine("Class Initialize");
        }


        [TestInitialize]
        public void LifecycleInit()
        {
            Console.WriteLine("Test Initialize Lifecycle");
        }

        [TestCleanup]
        public void LifeCycleCleanup()
        {

            Console.WriteLine("Test Clean up");

        }

     


        [TestMethod]
        public void TestA()
        {
            Console.WriteLine("Test A");
            Console.WriteLine($"Shared string is {sharedString}");
        }

        [TestMethod]
        public void TestB()
        {
            Console.WriteLine("Test B");
            Console.WriteLine($"Shared string is {sharedString}");
        }
    }
}