using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EdmxToCodeFirst
{
    public static class Extensions
    {
        public static StringBuilder WriteToFile(this StringBuilder sb, string path)
        {
            var contents = sb.ToString();
            File.WriteAllText(path,contents);
            return sb;
        }
        public static void IfZeroOneOrMany<T>(this IEnumerable<T> enumerable,
            Action ifZero = null, Action<T> ifOne = null, Action<IEnumerable<T>> ifMany = null)
        {
            var array = enumerable as IList<T> ?? enumerable.ToArray();
            switch (array.Count)
            {
                case 0:
                    ifZero?.Invoke();
                    return;
                case 1:
                    ifOne?.Invoke(array[0]);
                    return;
                default:
                    ifMany?.Invoke(array);
                    return;
            }
        }
        public static TP MapZeroOneOrMany<T,TP>(this IEnumerable<T> enumerable,
            Func<TP> ifZero, Func<T,TP> ifOne, Func<IEnumerable<T>,TP> ifMany)
        {
            var array = enumerable as IList<T> ?? enumerable.ToArray();
            switch (array.Count)
            {
                case 0:
                    return ifZero();
                case 1:
                    return ifOne(array[0]);
                default:
                    return ifMany(array);
            }
        }
    }
}