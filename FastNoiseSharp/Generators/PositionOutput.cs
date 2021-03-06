using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Outputs a value based on the position of the pixel.<br/>
    /// Multiplies and offsets the final value based on the multipliers and offsets.
    /// </summary>
    public sealed class PositionOutput : Generator
    {

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_PositionOutputSet", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_PositionOutputSet(int gen, int dim, float multiplier, float offset = 0.0f);

        internal PositionOutput(int gen) : base(gen)
        {
        }

        public PositionOutput() : base()
        {
            _genID = FastNoise.API_CreatePositionOutput();
        }

        /// <summary>
        /// Sets a axis's multiplier or offset.
        /// </summary>
        /// <param name="dimension">The axis to set</param>
        /// <param name="multiplier">The multiplier of the axis</param>
        /// <param name="offset">The axis's offset</param>
        public void Set(Dim dimension, float multiplier, float offset = 0.0f)
        {
            API_PositionOutputSet(_genID, (int) dimension, multiplier, offset);
        }

    }
}
