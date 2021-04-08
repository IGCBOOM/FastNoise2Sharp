using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Creates many cells, value of each cell is based on the lookup generator.
    /// </summary>
    public sealed class CellularLookup : Cellular
    {

        [DllImport("Engine.dll", EntryPoint = "API_CellularLookupSetLookup", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_CellularLookupSetLookup(int gen, int lookupGen);

        [DllImport("Engine.dll", EntryPoint = "API_CellularLookupSetLookupFrequency", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_CellularLookupSetLookupFrequency(int gen, float frequency);

        internal CellularLookup(int gen) : base(gen)
        {
            _type = CellularTypes.LookUp;
        }

        /// <summary>
        /// The generator to use to get each cell's value.
        /// </summary>
        /// <param name="generator">The generator to use</param>
        public void SetLookup(Generator generator)
        {
            API_CellularLookupSetLookup(_genID, generator._genID);
        }

        /// <summary>
        /// The "zoom" of the noise.<br/>
        /// You can pretend you're just using a domain scale on the input noise.
        /// </summary>
        /// <param name="frequency">The frequency</param>
        public void SetLookupFrequency(float frequency)
        {
            API_CellularLookupSetLookupFrequency(_genID, frequency);
        }

    }
}
