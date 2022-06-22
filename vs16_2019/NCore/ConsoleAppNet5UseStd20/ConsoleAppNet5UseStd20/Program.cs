using LibSysInfo;
using System;
using System.IO;
using TestReadonlyLib;

namespace ConsoleAppNet5UseStd20 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("ConsoleAppNet5UseStd20");
            TestCoords();
            TestVector2();
            TestProductDescription();
            // LibSysInfo.
            TextWriter writer = Console.Out;
            writer.WriteLine();
            SysInfoUtil.OutputAll(writer, "");
            writer.WriteLine("FrameworkDescription:\t" + System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription);
        }

        private static void TestCoords() {
            Coords coords = new Coords(3, 4);
            Console.Write("Coords:\t");
            Console.WriteLine(coords);
            Console.WriteLine(string.Format("GetLength:\t{0}", coords.GetLength()));
            Console.WriteLine();
        }

        private static void TestVector2() {
            Vector2 vector2 = new Vector2();
            vector2.x = 3;
            vector2.y = 4;
            Console.Write("Vector2:\t");
            Console.WriteLine(vector2);
            Console.WriteLine(string.Format("LengthSquared:\t{0}", vector2.LengthSquared));
            Console.WriteLine(string.Format("ExistingBehavior:\t{0}", ExistingBehavior(vector2)));
            Console.WriteLine(string.Format("ReadonlyBehavior:\t{0}", ReadonlyBehavior(vector2)));
            Console.WriteLine();
        }

        public static float ExistingBehavior(in Vector2 vector) {
            // This code causes a hidden copy, the compiler effectively emits:
            //    var tmpVector = vector;
            //    return tmpVector.GetLength();
            //
            // This is done because the compiler doesn't know that `GetLength()`
            // won't mutate `vector`.

            return vector.GetLength();
        }

        public static float ReadonlyBehavior(in Vector2 vector) {
            // This code is emitted exactly as listed. There are no hidden
            // copies as the `readonly` modifier indicates that the method
            // won't mutate `vector`.

            return vector.GetLengthReadonly();
        }

        private static void TestProductDescription() {
            string shortDescription = default; // Warning! non-nullable set to null;
            var product = new ProductDescription(shortDescription); // Warning! static analysis knows shortDescription maybe null.

            string description = "widget";
            var item = new ProductDescription(description);

            item.SetDescriptions(description, "These widgets will do everything.");

            Console.WriteLine(string.Format("ProductDescription:\t{0}", item.FullDescription()));
            Console.WriteLine();
        }
    }

}
