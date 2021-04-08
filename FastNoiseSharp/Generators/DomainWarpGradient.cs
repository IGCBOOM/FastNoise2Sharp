using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Warps an input generator.
    /// </summary>
    public sealed class DomainWarpGradient : DomainWarp
    {

        internal DomainWarpGradient(int gen) : base(gen)
        {
            _type = DomainWarpTypes.Gradient;
        }

        public DomainWarpGradient() : base()
        {
            _type = DomainWarpTypes.Gradient;
            _genID = FastNoise.API_CreateDomainWarpGradient();
        }

    }
}
