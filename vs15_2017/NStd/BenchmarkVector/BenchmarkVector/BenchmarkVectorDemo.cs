﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace BenchmarkVector {
    /// <summary>
    /// Benchmark Vector Demo
    /// </summary>
    static class BenchmarkVectorDemo {
        /// <summary>
        /// Is release make.
        /// </summary>
        public static readonly bool IsRelease =
#if RELEASE
            true
#else
            false
#endif
        ;

        /// <summary>
        /// Output Environment.
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void OutputEnvironment(TextWriter tw, string indent) {
            if (null == tw) return;
            if (null == indent) indent="";
            //string indentNext = indent + "\t";
            tw.WriteLine(indent + string.Format("IsRelease:\t{0}", IsRelease));
            tw.WriteLine(indent + string.Format("EnvironmentVariable(PROCESSOR_IDENTIFIER):\t{0}", Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER")));
            tw.WriteLine(indent + string.Format("Environment.ProcessorCount:\t{0}", Environment.ProcessorCount));
            tw.WriteLine(indent + string.Format("Environment.Is64BitOperatingSystem:\t{0}", Environment.Is64BitOperatingSystem));
            tw.WriteLine(indent + string.Format("Environment.Is64BitProcess:\t{0}", Environment.Is64BitProcess));
            tw.WriteLine(indent + string.Format("Environment.OSVersion:\t{0}", Environment.OSVersion));
            tw.WriteLine(indent + string.Format("Environment.Version:\t{0}", Environment.Version));
            tw.WriteLine(indent + string.Format("RuntimeInformation.FrameworkDescription:\t{0}", System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription));
            tw.WriteLine(indent + string.Format("BitConverter.IsLittleEndian:\t{0}", BitConverter.IsLittleEndian));
            tw.WriteLine(indent + string.Format("IntPtr.Size:\t{0}", IntPtr.Size));
            tw.WriteLine(indent + string.Format("Vector.IsHardwareAccelerated:\t{0}", Vector.IsHardwareAccelerated));
            tw.WriteLine(indent + string.Format("Vector<byte>.Count:\t{0}\t# {1}bit", Vector<byte>.Count, Vector<byte>.Count * sizeof(byte) * 8));
            tw.WriteLine(indent + string.Format("Vector<float>.Count:\t{0}\t# {1}bit", Vector<float>.Count, Vector<float>.Count*sizeof(float)*8));
            tw.WriteLine(indent + string.Format("Vector<double>.Count:\t{0}\t# {1}bit", Vector<double>.Count, Vector<double>.Count * sizeof(double) * 8));
            tw.WriteLine(indent);
        }

        /// <summary>
        /// Do Benchmark.
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void Benchmark(TextWriter tw, string indent) {
            if (null == tw) return;
            if (null == indent) indent = "";
            //string indentNext = indent + "\t";
            // init.
            int tickBegin, msUsed;
            double mFlops; // MFLOPS/Second .
            double scale;
            float rt;
            const int count = 1024*4;
            const int loops = 1024*1024;
            const double countMFlops = count * (double)loops / (1024.0 * 1024 * 1024);
            float[] src = new float[count];
            for(int i=0; i< count; ++i) {
                src[i] = i;
            }
            tw.WriteLine(indent + string.Format("Benchmark: \tcount={0}, loops={1}, countMFlops={2}", count, loops, countMFlops));
            // SumBase.
            tickBegin = Environment.TickCount;
            rt = SumBase(src, count, loops);
            msUsed = Environment.TickCount - tickBegin;
            mFlops = countMFlops * 1000 / msUsed;
            tw.WriteLine(indent + string.Format("SumBase:\t{0}\t# msUsed={1}, MFLOPS/Second={2}", rt, msUsed, mFlops));
            double mFlopsBase = mFlops;
            // SumVector4.
            tickBegin = Environment.TickCount;
            rt = SumVector4(src, count, loops);
            msUsed = Environment.TickCount - tickBegin;
            mFlops = countMFlops * 1000 / msUsed;
            scale = mFlops / mFlopsBase;
            tw.WriteLine(indent + string.Format("SumVector4:\t{0}\t# msUsed={1}, MFLOPS/Second={2}, scale={3}", rt, msUsed, mFlops, scale));
        }

        /// <summary>
        /// Sum - base.
        /// </summary>
        /// <param name="src">Soure array.</param>
        /// <param name="count">Soure array count.</param>
        /// <param name="count">Benchmark loops.</param>
        /// <returns>Return the sum value.</returns>
        private static float SumBase(float[] src, int count, int loops) {
            float rt = 0;
            for(int j=0; j< loops; ++j) {
                for(int i=0; i< count; ++i) {
                    rt += src[i];
                }
            }
            return rt;
        }

        /// <summary>
        /// Sum - Vector4.
        /// </summary>
        /// <param name="src">Soure array.</param>
        /// <param name="count">Soure array count.</param>
        /// <param name="count">Benchmark loops.</param>
        /// <returns>Return the sum value.</returns>
        private static float SumVector4(float[] src, int count, int loops) {
            float rt = 0;
            const int VectorWidth = 4;
            if (0 != count % VectorWidth) throw new ArgumentException("The count can't div 4.", "count");
            int vcount = count / VectorWidth;
            Vector4[] vsrc = new Vector4[vcount];
            int p = 0;
            for(int i=0; i< vcount; ++i) {
                vsrc[i] = new Vector4(src[p], src[p + 1], src[p + 2], src[p + 3]);
                p += VectorWidth;
            }
            // body.
            Vector4 vrt = Vector4.Zero;
            for (int j = 0; j < loops; ++j) {
                for (int i = 0; i < vcount; ++i) {
                    vrt += vsrc[i];
                }
            }
            // reduce.
            rt = vrt.X + vrt.Y + vrt.Z + vrt.W;
            return rt;
        }
    }
}
