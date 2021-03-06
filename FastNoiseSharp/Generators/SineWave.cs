using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{

    /// <summary>
    /// Generates sine waves in many dimensions.
    /// </summary>
    public sealed class SineWave : Generator
    {

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_SineWaveSetScale", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_SineWaveSetScale(int gen, float value);

        internal SineWave(int gen) : base(gen)
        {
        }

        public SineWave() : base()
        {
            _genID = FastNoise.API_CreateSineWave();
        }

        /// <summary>
        /// Sets the scale of the sine waves.
        /// </summary>
        /// <param name="value">The scale to set the sine waves to</param>
        public void SetScale(float value)
        {
            API_SineWaveSetScale(_genID, value);
        }

    }
}
