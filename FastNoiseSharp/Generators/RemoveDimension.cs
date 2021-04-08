using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Removes a dimension from the input generator.
    /// </summary>
    public sealed class RemoveDimension : Generator
    {

        [DllImport("Engine.dll", EntryPoint = "API_RemoveDimensionSetSource", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_RemoveDimensionSetSource(int gen, int sourceGen);

        [DllImport("Engine.dll", EntryPoint = "API_RemoveDimensionSetRemoveDimension", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_RemoveDimensionSetRemoveDimension(int gen, int dim);

        internal RemoveDimension(int gen) : base(gen)
        {
        }

        /// <summary>
        /// Sets the generator to remove the dimension from.
        /// </summary>
        /// <param name="gen">The generator to remove the dimension from.</param>
        public void SetSource(Generator gen)
        {
            API_RemoveDimensionSetSource(_genID, gen._genID);
        }

        /// <summary>
        /// Sets the dimension to remove.
        /// </summary>
        /// <param name="dimension">The dimension to remove.</param>
        public void SetRemoveDimension(Dim dimension)
        {
            API_RemoveDimensionSetRemoveDimension(_genID, (int)dimension);
        }

    }
}
