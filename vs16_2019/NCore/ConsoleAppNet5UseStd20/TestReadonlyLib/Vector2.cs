using System;
using System.Collections.Generic;
using System.Text;

namespace TestReadonlyLib {
    /// <summary>
    /// Vector2
    /// </summary>
    /// <remarks>https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/proposals/csharp-8.0/readonly-instance-members</remarks>
    public struct Vector2 {
        public float x;
        public float y;

        public readonly float GetLengthReadonly() {
            return (float)Math.Sqrt(LengthSquared);
        }

        public float GetLength() {
            return (float)Math.Sqrt(LengthSquared);
        }

        public readonly float GetLengthIllegal() {
            var tmp = (float)Math.Sqrt(LengthSquared);

            //x = tmp;    // Compiler error, cannot write x
            //y = tmp;    // Compiler error, cannot write y

            return tmp;
        }

        public readonly float LengthSquared {
            get {
                return (x * x) +
                       (y * y);
            }
        }
        public override string ToString() => $"({x}, {y})";
    }

}
