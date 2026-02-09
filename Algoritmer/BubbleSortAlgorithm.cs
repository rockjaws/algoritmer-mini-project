namespace Algoritmer;

public class BubbleSortAlgorithm<T> where T : IComparable<T>
{
  public T[] BubbleSort(T[] arr)
  {
    for (int i = 1; i < arr.Length; i++)
    {
      T val = arr[i];
      int pointer = i;

      while (pointer > 0 && val.CompareTo(arr[pointer - 1]) < 0)
      {
        arr[pointer] = arr[pointer - 1];
        pointer--;
      }
      arr[pointer] = val;
    }
    return arr;
  }
}
