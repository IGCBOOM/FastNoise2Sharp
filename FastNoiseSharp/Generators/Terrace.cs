using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Terraces the input generator.
    /// </summary>
    public sealed class Terrace : Generator
    {

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_TerraceSetSource", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_TerraceSetSource(int gen, int sourceGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_TerraceSetMultiplier", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_TerraceSetMultiplier(int gen, float multiplier);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_TerraceSetSmoothness", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_TerraceSetSmoothness(int gen, float smoothness);

        internal Terrace(int gen) : base(gen)
        {
        }

        /// <summary>
        /// Sets the generator to terrace.
        /// </summary>
        /// <param name="gen">The generator to terrace.</param>
        public void SetSource(Generator gen)
        {
            API_TerraceSetSource(_genID, gen._genID);
        }

        /// <summary>
        /// Multiplies the terrace effect.
        /// </summary>
        /// <param name="multiplier">Terrace effect multiplier.</param>
        public void SetMultiplier(float multiplier)
        {
            API_TerraceSetMultiplier(_genID, multiplier);
        }

        /// <summary>
        /// Smooths out the terrace effect.
        /// </summary>
        /// <param name="smoothness">How much the terrace effect should be smoothed.</param>
        public void SetSmoothness(float smoothness)
        {
            API_TerraceSetSmoothness(_genID, smoothness);
        }

    }
}
