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


      Graph<string> graph = new Graph<string>();
      graph.AddNode("Entrance");
      graph.AddNode("Carousel");
      graph.AddNode("Mini Train");
      graph.AddNode("Ice Cream");
      graph.AddNode("Roller Coaster");
      graph.AddNode("Haunted House");
      graph.AddNode("Climbing Tower");
      graph.AddNode("Volcano Ride");
      graph.AddNode("Water Ride");
      graph.AddNode("Pirate Ship");

      graph.AddEdge("Entrance", "Carousel");
      graph.AddEdge("Entrance", "Mini Train");
      graph.AddEdge("Entrance", "Ice Cream");
      graph.AddEdge("Carousel", "Roller Coaster");
      graph.AddEdge("Carousel", "Haunted House");
      graph.AddEdge("Roller Coaster", "Climbing Tower");
      graph.AddEdge("Climbing Tower", "Volcano Ride");
      graph.AddEdge("Mini Train", "Water Ride");
      graph.AddEdge("Ice Cream", "Pirate Ship");

      BFS<string> bFS = new BFS<string>();
      bFS.BFSRoute(graph, graph.FindNode("Entrance"), graph.FindNode("Water Ride"));
      bFS.BFSRoute(graph, graph.FindNode("Entrance"), graph.FindNode("Volcano Ride"));
      DFS<string> dFS = new DFS<string>();
      dFS.DFSRoute(graph, graph.FindNode("Entrance"), graph.FindNode("Water Ride"));
      dFS.DFSRoute(graph, graph.FindNode("Entrance"), graph.FindNode("Volcano Ride"));

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
