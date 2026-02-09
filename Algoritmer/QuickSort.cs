namespace Algoritmer;

public class QuickSort
{
  private static int comparisons = 0;
  public static int Comparisons => comparisons;

  public static T[] Sort<T>(T[] arr) where T : IComparable<T>
  {
    if (arr.Length <= 1) return arr;

    T pivot = arr[0];
    int beforeSize = 0;
    for (int i = 0; i < arr.Length; i++)
    {
      if (arr[i].CompareTo(pivot) < 0) beforeSize++;
    }
    T[] before = new T[beforeSize];
    int beforeCounter = 0;

    T[] after = new T[arr.Length - beforeSize - 1];
    int afterCounter = 0;

    for (int i = 1; i < arr.Length; i++)
    {
      comparisons++;
      if (arr[i].CompareTo(pivot) < 0)
      {
        before[beforeCounter] = arr[i];
        beforeCounter++;
      }
      else
      {
        after[afterCounter] = arr[i];
        afterCounter++;
      }
    }

    T[] tmpArr = new T[arr.Length];
    Sort(before).CopyTo(tmpArr, 0);
    tmpArr[before.Length] = pivot;
    Sort(after).CopyTo(tmpArr, before.Length + 1);
    return tmpArr;
  }

  public static void ResetComparisons()
  {
    comparisons = 0;
  }
}
