using Algoritmer;

namespace TestProject
{
    [TestClass]
    public sealed class GenericListTests
    {  
        [TestMethod]
        public void IntAddItem()
        {
            GenericList<int> list = new GenericList<int>();
            int expected = 5;

            list.Add(5);

            Assert.IsTrue(list.Any(x => x == expected));
        }

        [TestMethod]
        public void StringAddItem()
        {
            GenericList<string> list = new GenericList<string>();
            string expected = "Peter";

            list.Add("Peter");

            Assert.IsTrue(list.Any(x => x == expected));
        }

        [TestMethod]
        public void Count()
        {
            GenericList<int> list = new GenericList<int>()
            {
                1, 4, 7
            };

            int count = list.Count();
            int expected = 3;


            Assert.AreEqual(expected, count);
        }
    }
}
