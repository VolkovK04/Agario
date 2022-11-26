using System.Collections.Generic;

namespace Agario
{
    static class ListExtension
    {
        public static void SortAdd<T>(this List<T> list, T obj)
        {
            int index = list.BinarySearch(obj);
            if (index < 0)
                list.Insert(~index, obj);
            else
                list.Insert(index, obj);
        }
    }
}
