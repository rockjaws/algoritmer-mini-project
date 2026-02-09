using System.Diagnostics;

namespace Algoritmer
{
  internal class Program
  {
    static void Main()
    {
      var dataService = new DataService<int>();
      ProcessFile("notSorted.json", dataService);
      ProcessFile("reverseSorted.json", dataService);
    }

    static void ProcessFile(string fileName, DataService<int> dataService)
    {
      int[] values = dataService.LoadData(fileName);

      Stopwatch sw = Stopwatch.StartNew();
      int[] bubbles = BubbleSort.Sort(values.ToArray()); // Use ToArray to pass fresh copy of values
      sw.Stop();
      long bubbleMs = sw.ElapsedMilliseconds;

      var bubbleObject = new
      {
        algorithm = "BubbleSort",
        dataset = fileName,
        comparisons = BubbleSort.Comparisons,
        time = $"{bubbleMs}ms",
        sorted = bubbles
      };
      dataService.SaveData(bubbleObject, $"BubbleSort_{fileName}");

      QuickSort.ResetComparisons(); // QuickSort is recursive so reset counter to 0 before each run

      sw.Restart();
      int[] quickie = QuickSort.Sort(values.ToArray()); // Use ToArray to pass fresh copy of values
      sw.Stop();
      long quickieMs = sw.ElapsedMilliseconds;

      var quickieObject = new
      {
        algorithm = "QuickSort",
        dataset = fileName,
        comparisons = QuickSort.Comparisons,
        time = $"{quickieMs}ms",
        sorted = quickie
      };
      dataService.SaveData(quickieObject, $"QuickSort_{fileName}");
    }
  }
}
