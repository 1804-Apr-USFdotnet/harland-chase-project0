using System;
using Palindrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PalindromeTest
{
    [TestClass]
    public class PalindromeTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            bool output = Palindrome.Palindrome.IsPalindrome("racecar");
            Assert.IsTrue(output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            bool output = Palindrome.Palindrome.IsPalindrome("Racecar");
            Assert.IsTrue(output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            bool output = Palindrome.Palindrome.IsPalindrome("1221");
            Assert.IsTrue(output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            bool output = Palindrome.Palindrome.IsPalindrome("never Odd, or Even");
            Assert.IsTrue(output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            bool output = Palindrome.Palindrome.IsPalindrome("foobar");
            Assert.IsFalse(output);
        }

        [TestMethod]
        public void TestMethod6()
        {
            bool output = Palindrome.Palindrome.IsPalindrome("veryclosessolcyrev");
            Assert.IsFalse(output);
        }

        [TestMethod]
        public void TestMethod7()
        {
            bool output = Palindrome.Palindrome.IsPalindrome("");
            Assert.IsTrue(output);
        }

        [TestMethod]
        public void TestMethod8()
        {
            bool output = Palindrome.Palindrome.IsPalindrome("a");
            Assert.IsTrue(output);
        }

        [TestMethod]
        public void TestMethod9()
        {
            bool output = Palindrome.Palindrome.IsPalindrome("aaaaaaaaaaaaaa");
            Assert.IsTrue(output);
        }
    }
}
