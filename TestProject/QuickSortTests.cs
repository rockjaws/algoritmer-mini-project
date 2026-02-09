using Algoritmer;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    [TestClass]
    public sealed class QuickSortTests
    {
        [TestMethod]
        public void EmptyQuickSort()
        {
            int[] input = Array.Empty<int>();

            int[] result = QuickSort.Sort(input);

            Assert.IsEmpty(result);
        }

        [TestMethod]
        public void SingleElementQuickSort()
        {
            GenericList<int> listClass = new GenericList<int>();

            listClass.Add(5);
            QuickSort.Sort(listClass.TheList);
            int[] list = listClass.TheList;

            // Added to make sure the number is added, since it's greyed out in the IDE.
            Assert.IsTrue(list.Contains(5));
            Assert.AreEqual(listClass.TheList, list);
        }

        [TestMethod]
        public void IdenticalElementsQuickSort()
        {
            int[] list = new int[5]
            {
                5, 2, 5, 7, 7
            };

            GenericList<int> listClass = new GenericList<int>(list);
           listClass.TheList = QuickSort.Sort(listClass.TheList);
            int[] sortedList = [2, 5, 5, 7, 7];

            bool result = sortedList.SequenceEqual(listClass.TheList);
            CollectionAssert.AreEqual(sortedList, listClass.TheList);


        }

        [TestMethod]
        public void PreSortedQuickSort()
        {
            int[] list = new int[5]
            {
                2, 5, 5, 7, 7
            };

            GenericList<int> listClass = new GenericList<int>(list);
            QuickSort.Sort(listClass.TheList);
            Assert.AreEqual(list, listClass.TheList);
        }

    }
}
