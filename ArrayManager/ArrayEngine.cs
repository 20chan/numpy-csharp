using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayManager
{
    public static class ArrayEngine
    {
        public static T[][] ReshapeJagged<T>(this IEnumerable<T> ary, int width, int height)
        {
            T[][] result = new T[width][];
            for (int i = 0; i < width; i++)
                result[i] = new T[height];

            var trash = ary.Select((e, i) =>
            {
                result[i % width][i / height] = ary.ElementAt(i);
                return e;
            });
            trash.ToArray();
            return result;
        }

        public static T[,] Reshape<T>(this IEnumerable<T> ary, int width, int height)
        {
            T[,] result = new T[width, height];

            ary.Select((e, i) =>
            {
                if (!(ary.Count() <= i))
                    result[i % width, i / height] = ary.ElementAt(i);
                return e;
            });
            return result;
        }

        public static IEnumerable<T> Fill<T>(this IEnumerable<T> ary, T elem, int size)
        {
            for(int i = 0; i < ary.Count() + size; i++)
            {
                if (i < ary.Count())
                    yield return ary.ElementAt(i);
                else
                    yield return elem;
            }
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> ary)
        {
            Random r = new Random();
            return ary.OrderBy(e => r.Next());
        }
    }
}
