using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// It multiplies the values of generators together.
    /// </summary>
    public sealed class Multiply : OperatorSourceLHS
    {

        internal Multiply(int gen) : base(gen)
        {
            _type = OperatorSourceLHSTypes.Multiply;
        }

    }
}
