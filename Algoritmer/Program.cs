namespace Algoritmer
{
  internal class Program
  {
    static void Main()
    {
      var dataService = new DataService<int>();
      int[] values = dataService.LoadData("notSorted.json");
      int[] values2 = (int[])values.Clone();

      values = BubbleSort.Sort(values);
      Console.WriteLine($"Bubble sort comparisons: {BubbleSort.Comparisons}");

      values2 = QuickSort.Sort(values2);
      Console.WriteLine($"Quick sort comparisons: {QuickSort.Comparisons}");

      Console.WriteLine("Test");
      int[] test_values = new int[] { };
      QuickSort.Sort(test_values);

      dataService.SaveData(values, "BubbleSort_notSorted.json");
      dataService.SaveData(values2, "QuickSort_notSorted.json");
    }
  }
}
