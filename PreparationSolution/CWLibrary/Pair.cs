using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWLibrary
{
    public class Pair<T, U> : IComparable
        where T : IComparable
        where U : IComparable
    {
        T item1;
        public T Item1
        {
            get
            {
                if (typeof(T) is ICloneable)
                    return (T)((ICloneable)item1).Clone();
                return item1;
            }
        }
        U item2;
        public U Item2
        {
            get
            {
                if (typeof(U) is ICloneable)
                    return (U)((ICloneable)item2).Clone();
                return item2;
            }
        }

        public Pair(T _item1, U _item2)
        {
            item1 = _item1;
            item2 = _item2;
        }

        public int CompareTo(object obj)
        {
            return item1.CompareTo(obj);
        }

        public override string ToString()
        {
            return $"Первый элемент: {item1}; " +
                $"второй элемент: {item2}";
        }
    }
}
