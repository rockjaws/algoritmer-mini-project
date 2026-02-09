namespace Algoritmer;

public class BubbleSort
{
  private static int comparisons = 0;

  public static int Comparisons => comparisons;

  public static T[] Sort<T>(T[] arr) where T : IComparable<T>
  {
    comparisons = 0;
    if (arr.Length == 0) throw new Exception("Invalid operation. Provided list must contain at least one element.");
    if (arr.Length == 1) return arr;
    for (int pass = 0; pass < arr.Length - 1; pass++)
    {
      bool swapped = false;
      for (int i = 1; i < arr.Length - pass; i++)
      {
        comparisons++;
        if (arr[i - 1].CompareTo(arr[i]) > 0)
        {
          T tmp = arr[i - 1];
          arr[i - 1] = arr[i];
          arr[i] = tmp;
          swapped = true;
        }
      }
      if (!swapped) break;
    }
    return arr;
  }
}
