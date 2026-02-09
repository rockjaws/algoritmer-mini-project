namespace Algoritmer;

public class QuickSortAlgorithm<T> where T : IComparable<T>
{
  public T[] QuickSort(T[] arr)
  {
    if (arr.Length <= 1) return arr;

    int pivot = arr[0];
    int beforeSize = 0;
    for (int i = 0; i < arr.Length; i++)
    {
      if (arr[i] < pivot) beforeSize++;
    }
    int[] before = new int[beforeSize];
    int beforeCounter = 0;

    int[] after = new int[arr.Length - beforeSize - 1];
    int afterCounter = 0;

    for (int i = 1; i < arr.Length; i++)
    {
      if (arr[i] < pivot)
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

    int[] tmpArr = new int[arr.Length];
    QuickSort(before).CopyTo(tmpArr, 0);
    tmpArr[before.Length] = pivot;
    QuickSort(after).CopyTo(tmpArr, before.Length + 1);
    return tmpArr;
  }
}
