using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Raises a generator to a power. This generator is meant for ints.
    /// </summary>
    public sealed class PowInt : Generator
    {

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_PowIntSetValue", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_PowIntSetValue(int gen, int valueGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_PowIntSetPow", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_PowIntSetPow(int gen, int value);

        internal PowInt(int gen) : base(gen)
        {
        }

        /// <summary>
        /// Sets the generator to be raised to a power.
        /// </summary>
        /// <param name="gen">The generator to be raised to a power.</param>
        public void SetValue(Generator gen)
        {
            API_PowIntSetValue(_genID, gen._genID);
        }

        /// <summary>
        /// Sets the power that the generator will be raised to.
        /// </summary>
        /// <param name="value">The power that the generator will be raised to.</param>
        public void SetPow(int value)
        {
            API_PowIntSetPow(_genID, value);
        }

    }
}
