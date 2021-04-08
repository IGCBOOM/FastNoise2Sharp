using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{

    /// <summary>
    /// Domain warp types.
    /// </summary>
    public enum DomainWarpTypes
    {
        /// <summary>
        /// Gradient warp.
        /// </summary>
        Gradient = 0
    }

    /// <summary>
    /// Warps the output of a generator.
    /// </summary>
    public abstract class DomainWarp : Generator
    {

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_DomainWarpSetSource", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_DomainWarpSetSource(int gen, int type, int sourceGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_DomainWarpSetWarpAmplitudeGen", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_DomainWarpSetWarpAmplitudeGen(int gen, int type, int wAmpGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_DomainWarpSetWarpAmplitudeFloat", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_DomainWarpSetWarpAmplitudeFloat(int gen, int type, float value);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_DomainWarpSetWarpFrequency", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_DomainWarpSetWarpFrequency(int gen, int type, float value);

        private protected DomainWarpTypes _type;

        internal DomainWarp(int gen) : base(gen)
        {
        }

        /// <summary>
        /// Sets the source generator to warp.
        /// </summary>
        /// <param name="gen">Source generator.</param>
        public void SetSource(Generator gen)
        {
            API_DomainWarpSetSource(_genID, (int)_type, gen._genID);
        }

        /// <summary>
        /// Sets how much the generator should be warped depending on the output of another generator.
        /// </summary>
        /// <param name="gen">The amount the generator should be warped depending on the output of another generator.</param>
        public void SetWarpAmplitude(Generator gen)
        {
            API_DomainWarpSetWarpAmplitudeGen(_genID, (int)_type, gen._genID);
        }

        /// <summary>
        /// Sets how much the generator should be warped.
        /// </summary>
        /// <param name="value">The amount the generator should be warped.</param>
        public void SetWarpAmplitude(float value)
        {
            API_DomainWarpSetWarpAmplitudeFloat(_genID, (int)_type, value);
        }

        /// <summary>
        /// Sets the zoom of the warping.
        /// </summary>
        /// <param name="value">The zoom of the warping.</param>
        public void SetWarpFrequency(float value)
        {
            API_DomainWarpSetWarpFrequency(_genID, (int)_type, value);
        }

    }

}
