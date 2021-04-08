using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{

    /// <summary>
    /// Interpolated version of white noise.
    /// </summary>
    public sealed class Value : Generator
    {

        internal Value(int gen) : base(gen)
        {
        }

    }
}
