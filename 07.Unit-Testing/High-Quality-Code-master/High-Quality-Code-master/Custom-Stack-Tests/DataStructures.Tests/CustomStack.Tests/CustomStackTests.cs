namespace DataStructures.Tests.CustomStack.Tests
{
    using System;
    using System.Collections.Generic;
    using DataStructures;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CustomStackTests
    {
        [TestMethod]
        public void TestCountIncreaseAfterPush()
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(4);

            Assert.AreEqual(stack.Count, 1);
        }

        [TestMethod]
        public void TestCountDecreaseAfterPop()
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(4);
            stack.Pop();

            Assert.AreEqual(stack.Count, 0);
        }

        [TestMethod]
        public void TestPeekResultAfterPushing5And6()
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(5);
            stack.Push(6);
            int peekResult = stack.Peek();

            Assert.AreEqual(6, peekResult);
        }

        [TestMethod]
        public void TestPopResultAfterPushing5And6()
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(5);
            stack.Push(6);
            int peekResult = stack.Pop();

            Assert.AreEqual(6, peekResult);
        }

        [TestMethod]
        public void TestContentsPopOrder()
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(4);
            stack.Push(1);
            stack.Push(7);

            var stackContents = new List<int>();
            while (stack.Count > 0)
            {
                stackContents.Add(stack.Pop());
            }

            string actualOutput = string.Join(" ", stackContents);
            Assert.AreEqual("7 1 4", actualOutput, "Incorrect pop order.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopShouldThrowWhenStackIsEmpty()
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekShouldThrowWhenStackIsEmpty()
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Peek();
        }

        [TestMethod]
        public void TestCountWhenPushingOverInternalArrayCapacity()
        {
            CustomStack<int> stack = new CustomStack<int>(2);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(3, stack.Count);
        }

        // Note: Result may vary on different machines!
        [TestMethod]
        [Timeout(10)]
        public void StackShouldPush100IntsUnder10Milliseconds()
        {
            CustomStack<int> stack = new CustomStack<int>();
            for (int i = 0; i < 100; i++)
            {
                stack.Push(i);
            }
        }

        [TestMethod]
        public void StackShouldContainPushedNumber()
        {
            CustomStack<int> stack = new CustomStack<int>(2);
            stack.Push(10);
            bool containsTen = stack.Contains(10);

            Assert.IsTrue(containsTen);
        }

        [TestMethod]
        public void StackShouldNotContainMissingElement()
        {
            CustomStack<int> stack = new CustomStack<int>();
            bool containsFive = stack.Contains(5);

            Assert.IsFalse(containsFive);
        }
    }
}
