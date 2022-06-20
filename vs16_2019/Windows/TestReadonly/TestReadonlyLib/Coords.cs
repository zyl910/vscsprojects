using System;
using System.Collections.Generic;
using System.Text;

namespace TestReadonlyLib {
    public readonly struct Coords {
        public Coords(double x, double y) {
            X = x;
            Y = y;
        }

        public double GetLength() {
            return (X * X) + (Y * Y);
        }

        public double X { get; }
        public double Y { get; }

        public override string ToString() => $"({X}, {Y})";
    }
}
