using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Creates many cells, each pixel's value is based on the distance from itself and the nearest cell.
    /// </summary>
    public sealed class CellularDistance : Cellular
    {
        /// <summary>
        /// Return types.
        /// </summary>
        public enum ReturnType
        {
            /// <summary>
            /// Returns only Index0
            /// </summary>
            Index0,

            /// <summary>
            /// Returns Index0 with Index1 added to it.
            /// </summary>
            Index0Add1,

            /// <summary>
            /// Returns Index0 with Index1 subtracted from it.
            /// </summary>
            Index0Sub1,

            /// <summary>
            /// Returns Index0 and Index1 multiplied with each other.
            /// </summary>
            Index0Mul1,

            /// <summary>
            /// Returns Index0 divided by Index1.
            /// </summary>
            Index0Div1
        }

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CellularDistanceSetDistanceIndex0", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_CellularDistanceSetDistanceIndex0(int gen, int value);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CellularDistanceSetDistanceIndex1", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_CellularDistanceSetDistanceIndex1(int gen, int value);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CellularDistanceSetReturnType", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_CellularDistanceSetReturnType(int gen, int returnType);

        internal CellularDistance(int gen) : base(gen)
        {
            _type = CellularTypes.Distance;
        }

        /// <summary>
        /// Each pixel has a sorted array of the distance to the nearest cell, and the distance index is what's used to access that array per pixel.<br/>
        /// It's probably a good idea to check out NoiseTool, so you get a nice visualization of what's happening.
        /// </summary>
        /// <param name="value">Index to use</param>
        public void SetDistanceIndex0(int value)
        {
            API_CellularDistanceSetDistanceIndex0(_genID, value);
        }

        /// <summary>
        /// Each pixel has a sorted array of the distance to the nearest cell, and the distance index is what's used to access that array per pixel.<br/>
        /// This is the second distance index, you can use this with return type to quickly layer multiple cellular types.<br/>
        /// It's probably a good idea to check out NoiseTool, so you get a nice visualization of what's happening.
        /// </summary>
        /// <param name="value">Index to use</param>
        public void SetDistanceIndex1(int value)
        {
            API_CellularDistanceSetDistanceIndex1(_genID, value);
        }

        /// <summary>
        /// This modifies the return using both values obtained from the distance array.<br/>
        /// It's probably a good idea to check out NoiseTool, so you get a nice visualization of what's happening.
        /// </summary>
        /// <param name="returnType">Return type to use</param>
        public void SetReturnType(ReturnType returnType)
        {
            API_CellularDistanceSetReturnType(_genID, (int)returnType);
        }

    }
}
