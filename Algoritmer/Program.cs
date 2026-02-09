namespace Algoritmer
{
  internal class Program
  {
    static void Main()
    {
            //var dataService = new DataService<int>();
            //int[] values = dataService.LoadData("notSorted.json");
            //int[] values2 = (int[])values.Clone();

            //values = BubbleSort.Sort(values);
            //Console.WriteLine($"Bubble sort comparisons: {BubbleSort.Comparisons}");

            //values2 = QuickSort.Sort(values2);
            //Console.WriteLine($"Quick sort comparisons: {QuickSort.Comparisons}");

            //Console.WriteLine("Test");
            //int[] test_values = new int[] { };
            //QuickSort.Sort(test_values);

            //dataService.SaveData(values, "BubbleSort_notSorted.json");
            //dataService.SaveData(values2, "QuickSort_notSorted.json");

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

            BFS<string> bFS = new BFS<string>();
            bFS.BFSRoute(graph, graph.FindNode("Entrance"));
        }
  }
}
