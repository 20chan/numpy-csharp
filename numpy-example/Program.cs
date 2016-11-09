using System;
using System.Linq;
using philly.numpy;

namespace philly.numpy_example
{
    class Program
    {
        static void Main(string[] args)
        {
            var ze = NdArray<int>.Zeroes(10, 3);
        }
    }
}
