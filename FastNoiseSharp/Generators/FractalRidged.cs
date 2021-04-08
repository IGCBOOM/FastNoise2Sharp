using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// A fractal that can give a generator a "ridged" look.
    /// </summary>
    public sealed class FractalRidged : Fractal
    {

        internal FractalRidged(int gen) : base(gen)
        {
            _type = FractalTypes.Ridged;
        }

        public FractalRidged() : base()
        {
            _type = FractalTypes.Ridged;
            _genID = FastNoise.API_CreateFractalRidged();
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
