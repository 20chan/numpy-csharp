using System;
using System.Collections.Generic;
using System.Linq;

namespace philly.numpy
{
    public class NdArray<T> : IEnumerable<T>, ICloneable
    {
        public int Dimension { get { return _array.Rank; } }

        public int[] Shape
        {
            get
            {
                var res = new int[_array.Rank + 1];
                for (int i = 0; i < _array.Rank + 1; i++)
                    res[i] = _array.GetLength(i);
                return res;
            }
        }

        private Array _array;
        public NdArray(Array array)
        {
            _array = array;
        }

        public object Clone()
        {
            return new NdArray<T>(_array);
        }

        public override string ToString()
        {
            for(int r = 0; r < _array.Rank; r++)
            {
                //_array.get
            }
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var enumerator = _array.GetEnumerator();

            while (enumerator.MoveNext())
            {
                yield return (T)Convert.ChangeType(enumerator.Current, typeof(T));
            }
        }

        public void Fill(T value)
        {
            for (int i = 0; i < _array.Length; i++)
                _array.SetValue(value, i);
        }

        public static NdArray<T> Full(int width, int height, T value)
        {
            return new NdArray<T>(Enumerable.Repeat(Enumerable.Repeat(value, width), height).ToArray());
        }

        public static NdArray<T> Zeroes(int width, int height)
        {
            return Full(width, height, (T)Convert.ChangeType(0, typeof(T)));
        }

        public static NdArray<T> Ones(int width, int height)
        {
            return Full(width, height, (T)Convert.ChangeType(1, typeof(T)));
        }
    }
}