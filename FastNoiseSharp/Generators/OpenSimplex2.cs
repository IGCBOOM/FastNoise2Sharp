using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Successor to Simplex, generating similar curves in much less time.
    /// </summary>
    public sealed class OpenSimplex2 : Generator
    {

        internal OpenSimplex2(int gen) : base(gen)
        {
        }

        public OpenSimplex2() : base()
        {
            _genID = FastNoise.API_CreateOpenSimplex2();
        }

    }
}
