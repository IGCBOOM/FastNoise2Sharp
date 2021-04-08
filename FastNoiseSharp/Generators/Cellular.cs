using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Cellular types.
    /// </summary>
    public enum CellularTypes
    {
        /// <summary>
        /// Cellular distance.
        /// </summary>
        Distance = 0,

        /// <summary>
        /// Cellular lookup.
        /// </summary>
        LookUp,

        /// <summary>
        /// Cellular value.
        /// </summary>
        Value
    }

    /// <summary>
    /// Base class for cellular generators.
    /// </summary>
    public abstract class Cellular : Generator
    {

        [DllImport("Engine.dll", EntryPoint = "API_CellularSetDistanceFunction", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern void API_CellularSetDistanceFunction(int gen, int type, int dist_func);

        [DllImport("Engine.dll", EntryPoint = "API_CellularSetJitterModifier", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern void API_CellularSetJitterModifier(int gen, int type, float value);

        [DllImport("Engine.dll", EntryPoint = "API_CellularSetJitterModifierGen", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern void API_CellularSetJitterModifierGen(int gen, int type, int inputGen);

        private protected CellularTypes _type;

        internal Cellular(int gen) : base(gen)
        {
        }

        /// <summary>
        /// Sets the function applied to the number returned from the center of each cell.<br/>
        /// Can be used to create different shapes for your cells.
        /// </summary>
        /// <param name="distanceFunction">Distance function to use</param>
        public void SetDistanceFunction(DistanceFunction distanceFunction)
        {
            API_CellularSetDistanceFunction(_genID, (int)_type, (int) distanceFunction);
        }

        /// <summary>
        /// Multiplies how much the "vertices" of each cell are skewed.<br/>
        /// 0 will create perfect squares, whereas 1 will push those "vertices" around and create a cellular / fractured look.
        /// </summary>
        /// <param name="value">Vertex skew multiplier</param>
        public void SetJitterModifier(float value)
        {
            API_CellularSetJitterModifier(_genID, (int)_type, value);
        }

        /// <summary>
        /// Multiplies how much the "vertices" of each cell are skewed.<br/>
        /// 0 will create perfect squares, whereas 1 will push those "vertices" around and create a cellular / fractured look.
        /// </summary>
        /// <param name="gen">Generator to use</param>
        public void SetJitterModifier(Generator gen)
        {
            API_CellularSetJitterModifierGen(_genID, (int)_type, gen._genID);
        }

    }

}
