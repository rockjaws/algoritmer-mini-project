namespace Algoritmer;

/// <summary>
/// Implements the QuickSort algorithm for sorting arrays.
/// Time Complexity: O(n log n) average case, O(n²) worst case (when pivot selection is poor)
/// Space Complexity: O(n) due to creating new arrays in each recursive call
/// 
/// NOTE: Current implementation always selects first element as pivot, which causes
/// worst-case O(n²) performance on already sorted or reverse-sorted data.
/// </summary>
public class QuickSort
{
  private static int comparisons = 0;

  /// <summary>
  /// Gets the total number of comparisons made during the last sort operation.
  /// </summary>
  public static int Comparisons => comparisons;

  /// <summary>
  /// Sorts an array using the QuickSort algorithm with recursive partitioning.
  /// Selects a pivot element and partitions the array into elements less than
  /// and greater than or equal to the pivot, then recursively sorts each partition.
  /// </summary>
  /// <typeparam name="T">The type of elements in the array. Must implement IComparable.</typeparam>
  /// <param name="arr">The array to be sorted.</param>
  /// <returns>A new sorted array.</returns>
  public static T[] Sort<T>(T[] arr) where T : IComparable<T>
  {
    // Base case: arrays with 0 or 1 elements are already sorted
    if (arr.Length <= 1)
      return arr;

    T pivot = arr[0];

    // First pass: count elements less than pivot to size the 'before' array
    int beforeSize = 0;
    for (int i = 0; i < arr.Length; i++)
    {
      if (arr[i].CompareTo(pivot) < 0)
        beforeSize++;
    }

    // Create partitions: before (< pivot) and after (>= pivot)
    T[] before = new T[beforeSize];
    int beforeCounter = 0;
    T[] after = new T[arr.Length - beforeSize - 1];
    int afterCounter = 0;

    // Second pass: partition elements into before and after arrays
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

    // Recursively sort partitions and combine: [sorted before] + [pivot] + [sorted after]
    T[] tmpArr = new T[arr.Length];
    Sort(before).CopyTo(tmpArr, 0);
    tmpArr[before.Length] = pivot;
    Sort(after).CopyTo(tmpArr, before.Length + 1);

    return tmpArr;
  }

  /// <summary>
  /// Resets the comparison counter to zero.
  /// Should be called before each independent sort operation.
  /// </summary>
  public static void ResetComparisons()
  {
    comparisons = 0;
  }
}
