using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Raises a generator to a power. This generator is meant for floats.
    /// </summary>
    public sealed class PowFloat : Generator
    {

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_PowFloatSetValueGen", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_PowFloatSetValueGen(int gen, int valueGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_PowFloatSetValueFloat", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_PowFloatSetValueFloat(int gen, float value);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_PowFloatSetPowGen", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_PowFloatSetPowGen(int gen, int valueGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_PowFloatSetPowFloat", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_PowFloatSetPowFloat(int gen, float value);

        internal PowFloat(int gen) : base(gen)
        {
        }

        /// <summary>
        /// Sets the generator to use as the value.
        /// </summary>
        /// <param name="gen">The generator to use as the value.</param>
        public void SetValue(Generator gen)
        {
            API_PowFloatSetValueGen(_genID, gen._genID);
        }

        /// <summary>
        /// Sets the value to use.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public void SetValue(float value)
        {
            API_PowFloatSetValueFloat(_genID, value);
        }

        /// <summary>
        /// Sets the generator to use as the exponent.
        /// </summary>
        /// <param name="gen">The generator to use as the exponent.</param>
        public void SetPow(Generator gen)
        {
            API_PowFloatSetPowGen(_genID, gen._genID);
        }

        /// <summary>
        /// Sets the exponent.
        /// </summary>
        /// <param name="value">The exponent.</param>
        public void SetPow(float value)
        {
            API_PowFloatSetPowFloat(_genID, value);
        }

    }
}
