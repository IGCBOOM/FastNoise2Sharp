using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Offsets the input generator.
    /// </summary>
    public sealed class DomainOffset : Generator
    {

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_DomainOffsetSetSource", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_DomainOffsetSetSource(int gen, int sourceGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_DomainOffsetSetOffsetGen", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_DomainOffsetSetOffsetGen(int gen, int dim, int offsetGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_DomainOffsetSetOffsetFloat", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_DomainOffsetSetOffsetFloat(int gen, int dim, float value);

        internal DomainOffset(int gen) : base(gen)
        {
        }

        /// <summary>
        /// Sets the generator to be offset.
        /// </summary>
        /// <param name="gen">The generator to be offset.</param>
        public void SetSource(Generator gen)
        {
            API_DomainOffsetSetSource(_genID, gen._genID);
        }

        /// <summary>
        /// Sets the offset.
        /// </summary>
        /// <param name="dimension">The axis to set.</param>
        /// <param name="gen">The generator to base the offset on.</param>
        public void SetOffset(Dim dimension, Generator gen)
        {
            API_DomainOffsetSetOffsetGen(_genID, (int)dimension, gen._genID);
        }

        /// <summary>
        /// Sets the offset.
        /// </summary>
        /// <param name="dimension">The axis to set.</param>
        /// <param name="value">The value to offset the generator by.</param>
        public void SetOffset(Dim dimension, float value)
        {
            API_DomainOffsetSetOffsetFloat(_genID, (int)dimension, value);
        }

    }
}
