using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// The successor to perlin noise. Generates random smooth curves.
    /// </summary>
    public sealed class Simplex : Generator
    {

        internal Simplex(int gen) : base(gen)
        {
        }

        public Simplex() : base()
        {
            _genID = FastNoise.API_CreateSimplex();
        }

    }
}
