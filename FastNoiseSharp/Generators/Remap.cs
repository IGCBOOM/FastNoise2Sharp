using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Remaps the input.<br/>
    /// This is just a quick way of normalizing many values to fit between two arbitrary values.
    /// </summary>
    public sealed class Remap : Generator
    {

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_RemapSetSource", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_RemapSetSource(int gen, int sourceGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_RemapSetRemap", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_RemapSetRemap(int gen, float fromMin, float fromMax, float toMin, float toMax);

        internal Remap(int gen) : base(gen)
        {
        }

        public Remap() : base()
        {
            _genID = FastNoise.API_CreateRemap();
        }

        /// <summary>
        /// Sets the generator to remap.
        /// </summary>
        /// <param name="gen">The generator to remap.</param>
        public void SetSource(Generator gen)
        {
            API_RemapSetSource(_genID, gen._genID);
        }

        /// <summary>
        /// Change how to remap the input.
        /// </summary>
        /// <param name="fromMin">The minimum value of the input.</param>
        /// <param name="fromMax">The maximum value of the input.</param>
        /// <param name="toMin">The new minimum value.</param>
        /// <param name="toMax">The new maximum value.</param>
        public void SetRemap(float fromMin, float fromMax, float toMin, float toMax)
        {
            API_RemapSetRemap(_genID, fromMin, fromMax, toMin, toMax);
        }

    }
}
