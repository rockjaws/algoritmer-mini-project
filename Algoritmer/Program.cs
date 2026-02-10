using System.Diagnostics;

namespace Algoritmer
{
  /// <summary>
  /// Main entry point for the algorithms demonstration program.
  /// Tests sorting algorithms on different datasets and demonstrates graph traversal.
  /// </summary>
  internal class Program
  {
    /// <summary>
    /// Program entry point. Runs sorting algorithm tests and graph traversal demonstrations.
    /// </summary>
    static void Main()
    {
      // Initialize data service for loading/saving integer arrays
      var dataService = new DataService<int>();

      // Test sorting algorithms on three different datasets:
      // 1. Random unsorted data - average case
      // 2. Reverse sorted data - worst case for some algorithms
      // 3. Already sorted data - best case scenario
      ProcessFile("notSorted.json", dataService);
      ProcessFile("reverseSorted.json", dataService);
      ProcessFile("sorted.json", dataService);

      // Build a graph representing an amusement park layout
      Graph<string> graph = new Graph<string>();

      // Add all locations as nodes
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

      // Add connections between locations (undirected edges)
      graph.AddEdge("Entrance", "Carousel");
      graph.AddEdge("Entrance", "Mini Train");
      graph.AddEdge("Entrance", "Ice Cream");
      graph.AddEdge("Carousel", "Roller Coaster");
      graph.AddEdge("Carousel", "Haunted House");
      graph.AddEdge("Roller Coaster", "Climbing Tower");
      graph.AddEdge("Climbing Tower", "Volcano Ride");
      graph.AddEdge("Mini Train", "Water Ride");
      graph.AddEdge("Ice Cream", "Pirate Ship");

      // Compare BFS and DFS pathfinding
      BFS<string> bFS = new BFS<string>();
      bFS.BFSRoute(graph, graph.FindNode("Entrance"), graph.FindNode("Water Ride"));
      bFS.BFSRoute(graph, graph.FindNode("Entrance"), graph.FindNode("Volcano Ride"));

      DFS<string> dFS = new DFS<string>();
      dFS.DFSRoute(graph, graph.FindNode("Entrance"), graph.FindNode("Water Ride"));
      dFS.DFSRoute(graph, graph.FindNode("Entrance"), graph.FindNode("Volcano Ride"));
    }

    /// <summary>
    /// Processes a single data file with both BubbleSort and QuickSort algorithms.
    /// Measures performance and saves results to JSON files.
    /// </summary>
    /// <param name="fileName">The JSON file to load and sort.</param>
    /// <param name="dataService">The data service instance for loading and saving.</param>
    static void ProcessFile(string fileName, DataService<int> dataService)
    {
      // Load data from JSON file
      int[] values = dataService.LoadData(fileName);

      // BubbleSort Test
      Stopwatch sw = Stopwatch.StartNew();
      int[] bubbles = BubbleSort.Sort(values.ToArray()); // ToArray creates fresh copy to avoid modifying original
      sw.Stop();
      long bubbleMs = sw.ElapsedMilliseconds;

      // Create result object
      var bubbleObject = new
      {
        algorithm = "BubbleSort",
        dataset = fileName,
        comparisons = BubbleSort.Comparisons,
        time = $"{bubbleMs}ms",
        sorted = bubbles
      };
      dataService.SaveData(bubbleObject, $"BubbleSort_{fileName}");

      // QuickSort Test
      QuickSort.ResetComparisons(); // Reset counter since QuickSort is recursive

      sw.Restart();
      int[] quickie = QuickSort.Sort(values.ToArray()); // Fresh copy
      sw.Stop();
      long quickieMs = sw.ElapsedMilliseconds;

      // Create result object 
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
