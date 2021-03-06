using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Warps a domain warp with a fractal.
    /// </summary>
    public sealed class DomainWarpFractalIndependent : Fractal
    {

        internal DomainWarpFractalIndependent(int gen) : base(gen)
        {
            _type = FractalTypes.DomainWarpIndependent;
        }

        public DomainWarpFractalIndependent() : base()
        {
            _type = FractalTypes.DomainWarpIndependent;
            _genID = FastNoise.API_CreateDomainWarpFractalIndependent();
        }

        /// <summary>
        /// Call this function if it's a domain warp fractal, not the one in the base class.
        /// </summary>
        /// <param name="gen">Domain warp to set the source to.</param>
        public void SetSource(DomainWarp gen)
        {
            base.SetSource(gen);
        }

    }
}
