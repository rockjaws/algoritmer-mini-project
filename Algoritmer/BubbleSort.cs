namespace Algoritmer;

public class BubbleSort
{
  public static T[] Sort<T>(T[] arr, ref int comparisons) where T : IComparable<T>
  {
    for (int pass = 0; pass < arr.Length - 1; pass++)
    {
      bool swapped = false;
      for (int i = 1; i < arr.Length - pass; i++)
      {
        comparisons++;
        if (arr[i - 1].CompareTo(arr[i]) < 0)
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
