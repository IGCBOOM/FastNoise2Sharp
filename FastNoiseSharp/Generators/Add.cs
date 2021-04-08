using FastNoiseSharp.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// It adds the values of generators together.
    /// </summary>
    public sealed class Add : OperatorSourceLHS
    {

        internal Add(int gen) : base(gen)
        {
            _type = OperatorSourceLHSTypes.Add;
        }

        public Add() : base()
        {
            _type = OperatorSourceLHSTypes.Add;
            _genID = FastNoise.API_CreateAdd();
        }

    }
}
