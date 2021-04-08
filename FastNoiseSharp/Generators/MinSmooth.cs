using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Compares two values and returns the lowest, and allows you to smooth out the cutoff.
    /// </summary>
    public sealed class MinSmooth : OperatorSourceLHS
    {

        [DllImport("Engine.dll", EntryPoint = "API_MinSmoothSetSmoothnessGen", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_MinSmoothSetSmoothnessGen(int gen, int smoothGen);

        [DllImport("Engine.dll", EntryPoint = "API_MinSmoothSetSmoothnessFloat", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_MinSmoothSetSmoothnessFloat(int gen, float value);

        internal MinSmooth(int gen) : base(gen)
        {
            _type = OperatorSourceLHSTypes.MinSmooth;
        }

        /// <summary>
        /// Sets how smooth the cutoff should be.
        /// </summary>
        /// <param name="gen">The generator to determine the smoothness.</param>
        public void SetSmoothness(Generator gen)
        {
            API_MinSmoothSetSmoothnessGen(_genID, gen._genID);
        }

        /// <summary>
        /// Sets how smooth the cutoff should be.
        /// </summary>
        /// <param name="value">How smooth the cutoff should be.</param>
        public void SetSmoothness(float value)
        {
            API_MinSmoothSetSmoothnessFloat(_genID, value);
        }

    }
}
