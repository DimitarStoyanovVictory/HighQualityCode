using System;
using CustomLinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomLinkedListTest.LinkedListTest
{
    [TestClass]
    public class DymaicListTest
    {
        [TestMethod]
        public void TestCountAfterAddingTwoItems()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(2);
            list.Add(3);

            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void TestDynamicListIndexator()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            
            Assert.AreEqual(3, list[2]);
        }

        [TestMethod]
        public void TestDynamicListAdd()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void TestDynamicListRemoveAt()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(10);

            Assert.AreEqual(2, list.Remove(3));
        }

        [TestMethod]
        public void TestDynamicListRemove()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(10);
            list.Remove(4);

            Assert.AreEqual(3, list.Remove(10));
        }

        [TestMethod]
        public void TestDynamicListIndexOf()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(10);

            Assert.AreEqual(3, list.IndexOf(10));
        }

        [TestMethod]
        public void TestDynamicContains()
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(10);

            Assert.IsTrue(list.Contains(10));
        }

    }
}
