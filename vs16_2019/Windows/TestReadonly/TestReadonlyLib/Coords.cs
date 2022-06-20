using System;
using System.Collections.Generic;
using System.Text;

namespace TestReadonlyLib {
    /// <summary>
    /// Coords
    /// </summary>
    /// <remarks>https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/struct#readonly-struct</remarks>
    public readonly struct Coords {
        public Coords(double x, double y) {
            X = x;
            Y = y;
        }

        public double GetLength() {
            return Math.Sqrt((X * X) + (Y * Y));
        }

        public double X { get; }
        public double Y { get; }

        public override string ToString() => $"({X}, {Y})";
    }
}
