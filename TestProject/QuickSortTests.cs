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
            int[] list = new int[1];
            list.Append(5);
            QuickSort.Sort(list);
        }

        [TestMethod]
        public void IdenticalElementsQuickSort()
        {
            int[] list = new int[5]
            {
                5, 2, 5, 7, 7
            };
            QuickSort.Sort(list);
            int[] sortedList = [2, 5, 5, 7, 7];

            CollectionAssert.AreEquivalent(sortedList, list);
        }

        [TestMethod]
        public void PreSortedQuickSort()
        {
            int[] list = new int[5]
            {
                2, 5, 5, 7, 7
            };

            int[] listCompare = new int[5]
            {
                2, 5, 5, 7, 7
            };

            QuickSort.Sort(list);
            CollectionAssert.AreEquivalent(list, listCompare);
        }

    }
}
