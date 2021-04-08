using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// A fractal that seems to "feed the input into itself".<br/>
    /// This is probably one you should look at with NoiseTool.
    /// </summary>
    public sealed class FractalPingPong : Fractal
    {

        internal FractalPingPong(int gen) : base(gen)
        {
            _type = FractalTypes.PingPong;
        }

        public FractalPingPong() : base()
        {
            _type = FractalTypes.PingPong;
            _genID = FastNoise.API_CreateFractalPingPong();
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
