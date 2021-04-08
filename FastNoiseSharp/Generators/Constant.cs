using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Always returns the same number.
    /// </summary>
    public sealed class Constant : Generator
    {

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_ConstantSetValue", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_ConstantSetValue(int gen, float value);

        internal Constant(int gen) : base(gen)
        {
        }

        public Constant() : base()
        {
            _genID = FastNoise.API_CreateConstant();
        }

        /// <summary>
        /// Sets the constant's value.
        /// </summary>
        /// <param name="value">The value to set the constant to</param>
        public void SetValue(float value)
        {
            API_ConstantSetValue(_genID, value);
        }

    }
}
