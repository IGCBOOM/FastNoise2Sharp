using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{

    /// <summary>
    /// It divides the values of generators by each other or a constant.
    /// </summary>
    public sealed class Divide : OperatorHybridLHS
    {

        internal Divide(int gen) : base(gen)
        {
            _type = OperatorHybridLHSTypes.Divide;
        }

        public Divide() : base()
        {
            _type = OperatorHybridLHSTypes.Divide;
            _genID = FastNoise.API_CreateDivide();
        }

    }
}
