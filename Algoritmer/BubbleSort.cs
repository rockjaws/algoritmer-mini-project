namespace Algoritmer;

/// <summary>
/// Implements the Bubble Sort algorithm for sorting arrays.
/// Time Complexity: O(n²) worst/average case, O(n) best case (already sorted)
/// Space Complexity: O(1) - sorts in place
/// </summary>
public class BubbleSort
{
  private static int comparisons = 0;

  /// <summary>
  /// Gets the total number of comparisons made during the last sort operation.
  /// </summary>
  public static int Comparisons => comparisons;

  /// <summary>
  /// Sorts an array using the Bubble Sort algorithm.
  /// The algorithm repeatedly steps through the array, compares adjacent elements,
  /// and swaps them if they are in the wrong order.
  /// </summary>
  /// <typeparam name="T">The type of elements in the array. Must implement IComparable.</typeparam>
  /// <param name="arr">The array to be sorted.</param>
  /// <returns>The sorted array.</returns>
  public static T[] Sort<T>(T[] arr) where T : IComparable<T>
  {
    comparisons = 0;

    // Edge case: empty array
    if (arr.Length == 0)
      throw new Exception("Invalid operation. Provided list must contain at least one element.");

    // Edge case: single element is already sorted
    if (arr.Length == 1)
      return arr;

    // Outer loop: each pass bubbles the largest unsorted element to its position
    for (int pass = 0; pass < arr.Length - 1; pass++)
    {
      bool swapped = false;

      // Inner loop: compare adjacent elements
      // Note: arr.Length - pass reduces comparisons as largest elements are already in place
      for (int i = 1; i < arr.Length - pass; i++)
      {
        comparisons++;

        // Swap if elements are in wrong order
        if (arr[i - 1].CompareTo(arr[i]) > 0)
        {
          T tmp = arr[i - 1];
          arr[i - 1] = arr[i];
          arr[i] = tmp;
          swapped = true;
        }
      }

      // Optimization: if no swaps occurred, array is sorted
      if (!swapped)
        break;
    }

    return arr;
  }
}
