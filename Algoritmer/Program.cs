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
            graph.AddNode("Slot Machines");
            graph.AddNode("Ice Blaster");
            graph.AddNode("Funhouse");
            graph.AddNode("Hotdogs");
            graph.AddNode("Rocketships");
            graph.AddNode("3D Cinema");
            graph.AddNode("Log Flume");
            graph.AddNode("Big Dipper");
            graph.AddNode("Ghost Train");
            graph.AddNode("Pirate Ship");
            graph.AddNode("Rollercoaster");
            graph.AddNode("Carousel");
            graph.AddNode("Flying Chairs");


            // Entrance
            graph.AddEdge("Entrance", "Slot Machines");
            graph.AddEdge("Entrance", "Ice Blaster");
            graph.AddEdge("Entrance", "Funhouse");

            // Slot Machines
            graph.AddEdge("Slot Machines", "Hotdogs");
            graph.AddEdge("Slot Machines", "Rocketships");

            // Ice blaster
            graph.AddEdge("Ice Blaster", "Slot Machines");
            graph.AddEdge("Ice Blaster", "Rocketships");
            graph.AddEdge("Ice Blaster", "3D Cinema");
            graph.AddEdge("Ice Blaster", "Funhouse");

            graph.AddEdge("Hotdogs", "Log Flume");
            graph.AddEdge("Log Flume", "Big Dipper");
            graph.AddEdge("Big Dipper", "Rollercoaster");
            graph.AddEdge("Big Dipper", "Ghost Train");
            graph.AddEdge("Ghost Train", "Carousel");
            graph.AddEdge("Ghost Train", "Flying Chairs");
            graph.AddEdge("Carousel", "Flying Chairs");
            graph.AddEdge("Rocketships", "Ghost Train");
            graph.AddEdge("Rocketships", "3D Cinema");
            graph.AddEdge("3D Cinema", "Pirate Ship");
            graph.AddEdge("Funhouse", "3D Cinema");

            //BFS<string> bFS = new BFS<string>();
            //bFS.BFSRoute(graph, graph.FindNode("Entrance"), graph.FindNode("Rollercoaster"));

            DFS<string> dFS = new DFS<string>();
            dFS.DFSRoute(graph, graph.FindNode("Entrance"), graph.FindNode("Rollercoaster"));
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
