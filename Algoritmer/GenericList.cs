using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmer
{
  /// <summary>
  /// A custom generic list implementation that dynamically grows as elements are added.
  /// Implements IEnumerable to support foreach iteration and LINQ operations.
  /// </summary>
  /// <typeparam name="T">The type of elements in the list.</typeparam>
  public class GenericList<T> : IEnumerable<T>
  {
    /// <summary>
    /// Gets or sets the internal array storing the list elements.
    /// </summary>
    public T[] TheList { get; set; } = new T[] { };

    /// <summary>
    /// Initializes a new GenericList with the specified initial values.
    /// </summary>
    /// <param name="values">The initial values to populate the list with.</param>
    public GenericList(T[] values)
    {
      TheList = values;
    }

    /// <summary>
    /// Initializes a new empty GenericList.
    /// Used primarily for unit testing purposes.
    /// </summary>
    public GenericList() { }

    /// <summary>
    /// Adds a new element to the end of the list.
    /// Creates a new larger array and copies existing elements plus the new element.
    /// </summary>
    /// <param name="value">The value to add to the list.</param>
    public void Add(T value)
    {
      int count = TheList.Length;

      // Create new array with one additional slot
      T[] tmpList = new T[count + 1];

      // Copy existing elements
      TheList.CopyTo(tmpList, 0);

      // Add new element at the end
      tmpList[count] = value;

      // Replace old array with new one
      TheList = tmpList;
    }

    /// <summary>
    /// Returns the number of elements in the list.
    /// </summary>
    /// <returns>The count of elements.</returns>
    public int Count()
    {
      return TheList.Length;
    }

    /// <summary>
    /// Returns an enumerator that iterates through the list.
    /// Enables foreach loops and LINQ queries.
    /// </summary>
    /// <returns>An enumerator for the list.</returns>
    public IEnumerator<T> GetEnumerator()
    {
      foreach (var item in TheList)
      {
        yield return item;
      }
    }

    /// <summary>
    /// Returns a non-generic enumerator that iterates through the list.
    /// Required for IEnumerable interface implementation.
    /// </summary>
    /// <returns>A non-generic enumerator.</returns>
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}
