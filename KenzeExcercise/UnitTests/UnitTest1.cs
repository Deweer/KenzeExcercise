using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Simple_NoDesiredResult()
        {
            List<string> input = new List<string> { "foo" };
            Assert.IsTrue(!KenzeExcercise.Program.Process(input, 6, true).Any());
        }

        [TestMethod]
        public void Test_Simple_SameSize()
        {
            List<string> input = new List<string> { "bar", "foobar", "foo" };
            Assert.IsTrue(KenzeExcercise.Program.Process(input, 6, true).Any());
        }

        [TestMethod]
        public void Test_Simple_DiffrentSize()
        {
            List<string> input = new List<string> { "ar", "foobar", "foob" };
            Assert.IsTrue(KenzeExcercise.Program.Process(input, 6, true).Any());
        }

        [TestMethod]
        public void Test_Simple_NoSelfReferencing()
        {
            List<string> input = new List<string> { "foo", "foofoo" };
            Assert.IsTrue(!KenzeExcercise.Program.Process(input, 6, false).Any());
        }

        [TestMethod]
        public void Test_Simple_NoSelfReferencing_WithResult()
        {
            List<string> input = new List<string> { "foo", "foo", "foofoo" };
            Assert.IsTrue(KenzeExcercise.Program.Process(input, 6, false).Any());
        }

        [TestMethod]
        public void Test_Simple_SelfReferencing()
        {
            List<string> input = new List<string> { "foo", "foofoo" };
            Assert.IsTrue(KenzeExcercise.Program.Process(input, 6, true).Any());
        }

        [TestMethod]
        public void Test_Multiple_SameSize()
        {
            List<string> input = new List<string> { "foo", "foobar", "bar", "barfoo" };
            Assert.IsTrue(KenzeExcercise.Program.Process(input, 6, true).Count == 2);
        }

        [TestMethod]
        public void Test_Multiple_DiffrentSize()
        {
            List<string> input = new List<string> { "foob", "foobar", "ar", "arfoob" };
            Assert.IsTrue(KenzeExcercise.Program.Process(input, 6, true).Count == 2);
        }

        [TestMethod]
        public void Test_Simple_NineChars_NoResult()
        {
            List<string> input = new List<string> { "food", "bars", "foodbars" };
            Assert.IsTrue(!KenzeExcercise.Program.Process(input, 9, true).Any());
        }

        [TestMethod]
        public void Test_Simple_NineChars()
        {
            List<string> input = new List<string> { "food", "barso", "foodbarso" };
            Assert.IsTrue(KenzeExcercise.Program.Process(input, 9, true).Any());
        }

        [TestMethod]
        public void Test_Simple_Duplicates_Result()
        {
            List<string> input = new List<string> { "foo", "bar", "foobar", "foobar" };
            Assert.IsTrue(KenzeExcercise.Program.Process(input, 6, true).Count == 2);
        }

        [TestMethod]
        public void Test_Simple_Duplicates_Input()
        {
            List<string> input = new List<string> { "foo", "bar", "foo", "bar", "foobar" };
            Assert.IsTrue(KenzeExcercise.Program.Process(input, 6, true).Count == 4);
        }
    }
}
