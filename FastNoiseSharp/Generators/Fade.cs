using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// "Fades" two generators into each other.
    /// </summary>
    public sealed class Fade : Generator
    {

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_FadeSetA", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_FadeSetA(int gen, int aGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_FadeSetB", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_FadeSetB(int gen, int bGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_FadeSetFadeGen", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_FadeSetFadeGen(int gen, int fadeGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_FadeSetFadeFloat", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_FadeSetFadeFloat(int gen, float value);

        internal Fade(int gen) : base(gen)
        {
        }

        /// <summary>
        /// Sets the first generator.
        /// </summary>
        /// <param name="gen">The first generator.</param>
        public void SetA(Generator gen)
        {
            API_FadeSetA(_genID, gen._genID);
        }

        /// <summary>
        /// Sets the second generator.
        /// </summary>
        /// <param name="gen">The second generator.</param>
        public void SetB(Generator gen)
        {
            API_FadeSetB(_genID, gen._genID);
        }

        /// <summary>
        /// Sets the generator to use to determine how much it should "fade" between the input generators.
        /// </summary>
        /// <param name="gen">The generator that determines the fade amount.</param>
        public void SetFade(Generator gen)
        {
            API_FadeSetFadeGen(_genID, gen._genID);
        }

        /// <summary>
        /// Sets how much it should "fade" between the input generators.
        /// </summary>
        /// <param name="value">Fade amount.</param>
        public void SetFade(float value)
        {
            API_FadeSetFadeFloat(_genID, value);
        }

    }
}
