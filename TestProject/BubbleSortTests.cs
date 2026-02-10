using Algoritmer;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    [TestClass]
    public sealed class BubbleSortTests
    {
        [TestMethod]
        public void EmptyBubbleSort()
        {
            int[] list = new int[0];
            Assert.Throws<Exception>(() => BubbleSort.Sort(list));
            
        }

        [TestMethod]
        public void SingleElementBubbleSort()
        {

            int[] list = new int[1];
            list.Append(5);
            BubbleSort.Sort(list);     
        }

        [TestMethod]
        public void IdenticalElementsBubbleSort()
        {
            int[] list = new int[5]
            {
                5, 2, 5, 7, 7
            };
            BubbleSort.Sort(list);
            int[] sortedList = [2, 5, 5, 7, 7];

            CollectionAssert.AreEquivalent(sortedList, list);

        }

        [TestMethod]
        public void PreSortedBubbleSort()
        {
            int[] list = new int[5]
            {
                2, 5, 5, 7, 7
            };

            int[] listCompare = new int[5]
            {
                2, 5, 5, 7, 7
            };

            BubbleSort.Sort(list);
            CollectionAssert.AreEquivalent(list, listCompare);
        }
    }
}
