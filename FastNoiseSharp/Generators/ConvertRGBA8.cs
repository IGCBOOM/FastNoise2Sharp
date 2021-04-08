using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Converts to RGBA8 (????)
    /// </summary>
    public sealed class ConvertRGBA8 : Generator
    {

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_ConvertRGBA8SetSource", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_ConvertRGBA8SetSource(int gen, int sourceGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_ConvertRGBA8SetMinMax", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_ConvertRGBA8SetMinMax(int gen, float min, float max);

        internal ConvertRGBA8(int gen) : base(gen)
        {
        }

        public ConvertRGBA8() : base()
        {
            _genID = FastNoise.API_CreateConvertRGBA8();
        }

        /// <summary>
        /// Sets the generator to be converted.
        /// </summary>
        /// <param name="gen">The generator to be converted.</param>
        public void SetSource(Generator gen)
        {
            API_ConvertRGBA8SetSource(_genID, gen._genID);
        }

        /// <summary>
        /// Sets the minimum and maximum.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public void SetMinMax(float min, float max)
        {
            API_ConvertRGBA8SetMinMax(_genID, min, max);
        }

    }
}
