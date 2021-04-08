using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Creates many cells, value seems to just be random.
    /// </summary>
    public sealed class CellularValue : Cellular
    {

        [DllImport("Engine.dll", EntryPoint = "API_CellularValueSetValueIndex", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_CellularValueSetValueIndex(int gen, int value);

        internal CellularValue(int gen) : base(gen)
        {
            _type = CellularTypes.Value;
        }

        /// <summary>
        /// Every pixel nearby another cell get it's color, and this is seemingly the amount of recursion.
        /// </summary>
        /// <param name="value">Amount of recursion.</param>
        public void SetValueIndex(int value)
        {
            API_CellularValueSetValueIndex(_genID, value);
        }

    }
}
