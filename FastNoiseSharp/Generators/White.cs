using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// For each pixel, a random number is picked.
    /// </summary>
    public sealed class White : Generator
    {

        internal White(int gen) : base(gen)
        {
        }

        public White() : base()
        {
            _genID = FastNoise.API_CreateWhite();
        }

    }
}
