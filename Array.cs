using System;
using Xunit;

namespace Test
{
    static class Array
    {
        internal static readonly int[] allTheSameArray = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        internal static readonly int[] from10To1Array = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        internal static readonly int[] sorted1Array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    }
}
