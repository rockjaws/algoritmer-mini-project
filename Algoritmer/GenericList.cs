using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmer
{
    public class GenericList<T>
    {
        T[] TheList { get; set; } = new T[] {};

        public GenericList(T[] values) 
        {
            TheList = values;
        }

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
    }
}
