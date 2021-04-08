using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Adds a dimension to a generator.
    /// </summary>
    public sealed class AddDimension : Generator
    {

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_AddDimensionSetSource", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_AddDimensionSetSource(int gen, int sourceGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_AddDimensionSetNewDimensionPositionGen", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_AddDimensionSetNewDimensionPositionGen(int gen, int dPosGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_AddDimensionSetNewDimensionPositionFloat", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_AddDimensionSetNewDimensionPositionFloat(int gen, float value);

        internal AddDimension(int gen) : base(gen)
        {
        }

        /// <summary>
        /// Sets the generator to add the dimension to.
        /// </summary>
        /// <param name="gen">The generator to add the dimension to.</param>
        public void SetSource(Generator gen)
        {
            API_AddDimensionSetSource(_genID, gen._genID);
        }

        /// <summary>
        /// Sets the new dimension's position.
        /// </summary>
        /// <param name="gen">Sets the new dimension's position using the values from another generator.</param>
        public void SetNewDimensionPosition(Generator gen)
        {
            API_AddDimensionSetNewDimensionPositionGen(_genID, gen._genID);
        }

        /// <summary>
        /// Sets the new dimension's position.
        /// </summary>
        /// <param name="value">The position.</param>
        public void SetNewDimensionPosition(float value)
        {
            API_AddDimensionSetNewDimensionPositionFloat(_genID, value);
        }

    }
}
