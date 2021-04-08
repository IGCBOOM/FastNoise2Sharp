using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// The "generic" fractal. Makes input look "more detailed."
    /// </summary>
    public sealed class FractalFBm : Fractal
    {

        internal FractalFBm(int gen) : base(gen)
        {
            _type = FractalTypes.FBm;
        }

        /// <summary>
        /// Sets the generator to modify.
        /// </summary>
        /// <param name="gen">The generator to modify.</param>
        public new void SetSource(Generator gen)
        {
            base.SetSource(gen);
        }

    }
}
