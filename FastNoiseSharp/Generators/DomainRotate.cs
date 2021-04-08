using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Rotates the generator's output.
    /// </summary>
    public sealed class DomainRotate : Generator
    {

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_DomainRotateSetSource", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_DomainRotateSetSource(int gen, int sourceGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_DomainRotateSetYaw", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_DomainRotateSetYaw(int gen, float value);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_DomainRotateSetPitch", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_DomainRotateSetPitch(int gen, float value);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_DomainRotateSetRoll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_DomainRotateSetRoll(int gen, float value);

        internal DomainRotate(int gen) : base(gen)
        {
        }

        public DomainRotate() : base()
        {
            _genID = FastNoise.API_CreateDomainRotate();
        }

        /// <summary>
        /// Sets the generator to rotate.
        /// </summary>
        /// <param name="gen">The generator to rotate.</param>
        public void SetSource(Generator gen)
        {
            API_DomainRotateSetSource(_genID, gen._genID);
        }

        /// <summary>
        /// Sets how much the generator rotates in yaw.
        /// </summary>
        /// <param name="value">The yaw to rotate the generator with.</param>
        public void SetYaw(float value)
        {
            API_DomainRotateSetYaw(_genID, value);
        }

        /// <summary>
        /// Sets how much the generator rotates in pitch.
        /// </summary>
        /// <param name="value">The pitch to rotate the generator with.</param>
        public void SetPitch(float value)
        {
            API_DomainRotateSetPitch(_genID, value);
        }

        /// <summary>
        /// Sets how much the generator rotates in roll.
        /// </summary>
        /// <param name="value">The roll to rotate the generator with.</param>
        public void SetRoll(float value)
        {
            API_DomainRotateSetRoll(_genID, value);
        }

    }
}
