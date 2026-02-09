namespace Algoritmer
{
  internal class Program
  {
    static void Main()
    {
      var dataService = new DataService<int>();
      int[] values = dataService.LoadData("notSorted.json");
      int[] values2 = (int[])values.Clone();
      int comparisons = 0;
      values = BubbleSort.Sort(values, ref comparisons);
      Console.WriteLine($"Bubble sort comparisons: {comparisons}");
      comparisons = 0;
      values2 = QuickSort.Sort(values2, ref comparisons);
      Console.WriteLine($"Quick sort comparisons: {comparisons}");
      dataService.SaveData(values, "BubbleSort_notSorted.json");
      dataService.SaveData(values2, "QuickSort_notSorted.json");
    }
  }
}
