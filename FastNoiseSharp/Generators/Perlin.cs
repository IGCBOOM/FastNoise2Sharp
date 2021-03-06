using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Creates random smooth curves, although looks locked to a grid from far away.
    /// </summary>
    public sealed class Perlin : Generator
    {

        internal Perlin(int gen) : base(gen)
        {
        }

        public Perlin() : base()
        {
            _genID = FastNoise.API_CreatePerlin();
        }

    }
}
