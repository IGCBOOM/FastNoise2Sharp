using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{    
    /// <summary>
    /// Compares two values and returns the lowest.
    /// </summary>
    public sealed class Min : OperatorSourceLHS
    {

        internal Min(int gen) : base(gen)
        {
            _type = OperatorSourceLHSTypes.Min;
        }

    }
}
