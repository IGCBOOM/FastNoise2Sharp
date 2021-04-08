using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Compares two values and returns the highest.
    /// </summary>
    public sealed class Max : OperatorSourceLHS
    {

        internal Max(int gen) : base(gen)
        {
            _type = OperatorSourceLHSTypes.Max;
        }

        public Max() : base()
        {
            _type = OperatorSourceLHSTypes.Max;
            _genID = FastNoise.API_CreateMax();
        }

    }
}
