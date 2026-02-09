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
            GenericList<int> genericListClass = new GenericList<int>();
            int[] list = genericListClass.TheList;

            Assert.Throws<Exception>(() => BubbleSort.Sort(list));
            
        }

        [TestMethod]
        public void SingleElementBubbleSort()
        {
            GenericList<int> listClass = new GenericList<int>();

            listClass.Add(5);
            BubbleSort.Sort(listClass.TheList);
            int[] list = listClass.TheList;

            // Added to make sure the number is added, since it's greyed out in the IDE.
            Assert.IsTrue(list.Contains(5));
            Assert.AreEqual(listClass.TheList, list);
        }

        [TestMethod]
        public void IdenticalElementsBubbleSort()
        {
            int[] list = new int[5]
            {
                5, 2, 5, 7, 7
            };
            GenericList<int> listClass = new GenericList<int>(list);
            BubbleSort.Sort(listClass.TheList);
            int[] sortedList = [2, 5, 5, 7, 7];

            bool result = sortedList.SequenceEqual(listClass.TheList);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void PreSortedBubbleSort()
        {
            int[] list = new int[5]
            {
                2, 5, 5, 7, 7
            };

            GenericList<int> listClass = new GenericList<int>(list);
            BubbleSort.Sort(listClass.TheList);
            Assert.AreEqual (list, listClass.TheList);
        }
    }
}
