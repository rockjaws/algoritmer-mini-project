using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmer
{
    public class GenericList<T> : IEnumerable<T>
    {
        T[] TheList { get; set; } = new T[] {};

        public GenericList(T[] values) 
        {
            TheList = values;
        }

        // Empty ctor for unit testing purposes.
        public GenericList() { }

        public void Add(T value)
        {
            int count = TheList.Length;
            T[] tmpList = new T[count + 1];
            TheList.CopyTo(tmpList, 0);
            tmpList[count] = value;
            TheList = tmpList;
        }

        public int Count()
        {
            return TheList.Length;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in TheList)
            {
                yield return item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
