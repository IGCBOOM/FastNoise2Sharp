using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Compares two values and returns the highest, and allows you to smooth out the cutoff.
    /// </summary>
    public sealed class MaxSmooth : OperatorSourceLHS
    {

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_MaxSmoothSetSmoothnessGen", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_MaxSmoothSetSmoothnessGen(int gen, int smoothGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_MaxSmoothSetSmoothnessFloat", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_MaxSmoothSetSmoothnessFloat(int gen, float value);

        internal MaxSmooth(int gen) : base(gen)
        {
            _type = OperatorSourceLHSTypes.MaxSmooth;
        }

        public MaxSmooth() : base()
        {
            _type = OperatorSourceLHSTypes.MaxSmooth;
            _genID = FastNoise.API_CreateMaxSmooth();
        }

        /// <summary>
        /// Sets how smooth the cutoff should be.
        /// </summary>
        /// <param name="gen">The generator to determine the smoothness.</param>
        public void SetSmoothness(Generator gen)
        {
            API_MaxSmoothSetSmoothnessGen(_genID, gen._genID);
        }

        /// <summary>
        /// Sets how smooth the cutoff should be.
        /// </summary>
        /// <param name="value">How smooth the cutoff should be.</param>
        public void SetSmoothness(float value)
        {
            API_MaxSmoothSetSmoothnessFloat(_genID, value);
        }

    }
}
