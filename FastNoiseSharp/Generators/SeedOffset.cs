using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Offsets the input generator's seed.
    /// </summary>
    public sealed class SeedOffset : Generator
    {

        [DllImport("Engine.dll", EntryPoint = "API_SeedOffsetSetSource", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_SeedOffsetSetSource(int gen, int sourceGen);

        [DllImport("Engine.dll", EntryPoint = "API_SeedOffsetSetOffset", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_SeedOffsetSetOffset(int gen, int offset);

        internal SeedOffset(int gen) : base(gen)
        {
        }

        /// <summary>
        /// Set the generator to have it's seed offset.
        /// </summary>
        /// <param name="gen">The generator to have it's seed offset.</param>
        public void SetSource(Generator gen)
        {
            API_SeedOffsetSetSource(_genID, gen._genID);
        }

        /// <summary>
        /// Sets how much the seed should be offset.
        /// </summary>
        /// <param name="offset">How much the seed should be offset.</param>
        public void SetOffset(int offset)
        {
            API_SeedOffsetSetOffset(_genID, offset);
        }

    }
}
