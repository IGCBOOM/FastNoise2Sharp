using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Scales the domain's output.
    /// </summary>
    public sealed class DomainScale : Generator
    {

        [DllImport("Engine.dll", EntryPoint = "API_DomainScaleSetSource", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_DomainScaleSetSource(int gen, int sourceGen);

        [DllImport("Engine.dll", EntryPoint = "API_DomainScaleSetScale", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_DomainScaleSetScale(int gen, float value);

        internal DomainScale(int gen) : base(gen)
        {
        }

        /// <summary>
        /// Sets the generator to scale.
        /// </summary>
        /// <param name="gen">The generator to scale.</param>
        public void SetSource(Generator gen)
        {
            API_DomainScaleSetSource(_genID, gen._genID);
        }

        /// <summary>
        /// Sets the amount the generator should be scaled by.
        /// </summary>
        /// <param name="value">The amount to scale the generator.</param>
        public void SetScale(float value)
        {
            API_DomainScaleSetScale(_genID, value);
        }

    }
}
