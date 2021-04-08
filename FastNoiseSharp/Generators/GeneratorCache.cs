using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Outputs the input. Passthrough generator.
    /// </summary>
    public sealed class GeneratorCache : Generator
    {

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_GeneratorCacheSetSource", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_GeneratorCacheSetSource(int gen, int sourceGen);

        internal GeneratorCache(int gen) : base(gen)
        {
        }

        /// <summary>
        /// Sets the generator to passthrough.
        /// </summary>
        /// <param name="gen">The generator to passthrough.</param>
        public void SetSource(Generator gen)
        {
            API_GeneratorCacheSetSource(_genID, gen._genID);
        }

    }
}
