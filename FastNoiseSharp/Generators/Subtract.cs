using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// It subtracts the values of generators from each other.
    /// </summary>
    public sealed class Subtract : OperatorHybridLHS
    {

        internal Subtract(int gen) : base(gen)
        {
            _type = OperatorHybridLHSTypes.Subtract;
        }

        public Subtract() : base()
        {
            _type = OperatorHybridLHSTypes.Subtract;
            _genID = FastNoise.API_CreateSubtract();
        }

    }
}
