using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Scales a generator on one axis.
    /// </summary>
    public sealed class DomainAxisScale : Generator
    {

        [DllImport("Engine.dll", EntryPoint = "API_DomainAxisScaleSetSource", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_DomainAxisScaleSetSource(int gen, int sourceGen);

        [DllImport("Engine.dll", EntryPoint = "API_DomainAxisScaleSetScale", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_DomainAxisScaleSetScale(int gen, int dim, float value);

        internal DomainAxisScale(int gen) : base(gen)
        {
        }

        /// <summary>
        /// Sets the generator to be scaled.
        /// </summary>
        /// <param name="gen">The generator to be scaled.</param>
        public void SetSource(Generator gen)
        {
            API_DomainAxisScaleSetSource(_genID, gen._genID);
        }

        /// <summary>
        /// Sets how much the generator should be scaled.
        /// </summary>
        /// <param name="dimension">The axis to scale on.</param>
        /// <param name="value">How much the generator should be scaled by.</param>
        public void SetScale(Dim dimension, float value)
        {
            API_DomainAxisScaleSetScale(_genID, (int)dimension, value);
        }

    }
}
