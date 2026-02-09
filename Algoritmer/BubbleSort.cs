namespace Algoritmer;

public class BubbleSort
{
  public static T[] Sort<T>(T[] arr) where T : IComparable<T>
  {
        if (arr.Length == 0) throw new Exception("Invalid operation. Provided list must contain at least one element.");
        if (arr.Length == 1) return arr;
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
