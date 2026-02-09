namespace Algoritmer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> genericList = new GenericList<int>();
            genericList.Add(1);
            genericList.Add(2);
            genericList.Add(3);
            genericList.Add(4);
            genericList.Add(5);
            genericList.Add(6);
            genericList.Add(7);
            genericList.Add(8);
            genericList.Add(9);
            genericList.Add(10);

            genericList.Add(11);

            foreach (var i in genericList)
            {
                Console.WriteLine(i);
            }
        }
    }
}
