namespace Algoritmer
{
  internal class Program
  {
    static void Main()
    {
      var dataService = new DataService<int>();
      int[] values = dataService.LoadData("notSorted.json");
      values = BubbleSort.Sort(values);
      foreach (var i in values)
      {
        Console.WriteLine(i);
      }
    }
  }
}
