using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Generates a checkerboard.
    /// </summary>
    public sealed class Checkerboard : Generator
    {

        [DllImport("Engine.dll", EntryPoint = "API_CheckerboardSetSize", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_CheckerboardSetSize(int gen, float value);

        internal Checkerboard(int gen) : base(gen)
        {
        }

        /// <summary>
        /// Sets the size of the checkerboard.
        /// </summary>
        /// <param name="value">Scale to use</param>
        public void SetSize(float value)
        {
            API_CheckerboardSetSize(_genID, value);
        }

    }
}
