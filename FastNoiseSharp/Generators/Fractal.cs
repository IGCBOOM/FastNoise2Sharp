using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{

    /// <summary>
    /// Types of fractals.
    /// </summary>
    public enum FractalTypes
    {
        /// <summary>
        /// Domain warp independent fractal.
        /// </summary>
        DomainWarpIndependent = 0,
        /// <summary>
        /// Domain warp progressive fractal.
        /// </summary>
        DomainWarpProgressive,
        /// <summary>
        /// FBm fractal.
        /// </summary>
        FBm,
        /// <summary>
        /// Ping pong fractal.
        /// </summary>
        PingPong,
        /// <summary>
        /// Ridged fractal.
        /// </summary>
        Ridged
    }

    /// <summary>
    /// Base class for fractals.
    /// </summary>
    public abstract class Fractal : Generator
    {

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_FractalSetSource", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_FractalSetSource(int gen, int type, int sourceGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_FractalSetGainGen", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_FractalSetGainGen(int gen, int type, int gainGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_FractalSetGainFloat", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_FractalSetGainFloat(int gen, int type, float value);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_FractalSetWeightedStrengthGen", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_FractalSetWeightedStrengthGen(int gen, int type, int strengthGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_FractalSetWeightedStrengthFloat", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_FractalSetWeightedStrengthFloat(int gen, int type, float value);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_FractalSetOctaveCount", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_FractalSetOctaveCount(int gen, int type, int value);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_FractalSetLacunarity", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_FractalSetLacunarity(int gen, int type, float value);

        private protected FractalTypes _type;

        internal Fractal(int gen) : base(gen)
        {
        }

        internal Fractal() : base()
        {
        }

        /// <summary>
        /// Sets the source generator to warp.
        /// </summary>
        /// <param name="gen">Generator to set the source to.</param>
        protected void SetSource(Generator gen)
        {
            API_FractalSetSource(_genID, (int)_type, gen._genID);
        }

        /// <summary>
        /// Sets the gain of the fractal based off of the provided generator.
        /// </summary>
        /// <param name="gen">The generator to base the gain off of.</param>
        public void SetGain(Generator gen)
        {
            API_FractalSetGainGen(_genID, (int)_type, gen._genID);
        }

        /// <summary>
        /// Sets the gain of the fractal.
        /// </summary>
        /// <param name="value">The value to set the gain to.</param>
        public void SetGain(float value)
        {
            API_FractalSetGainFloat(_genID, (int)_type, value);
        }

        /// <summary>
        /// Sets the fractal's weighted strength based on a generator.
        /// </summary>
        /// <param name="gen">The generator to base the weighted strength on.</param>
        public void SetWeightedStrength(Generator gen)
        {
            API_FractalSetWeightedStrengthGen(_genID, (int)_type, gen._genID);
        }

        /// <summary>
        /// Sets the fractal's weighted strength.
        /// </summary>
        /// <param name="value">The value to set the weighted strength to.</param>
        public void SetWeightedStrength(float value)
        {
            API_FractalSetWeightedStrengthFloat(_genID, (int)_type, value);
        }

        /// <summary>
        /// How many octaves the fractal has.
        /// </summary>
        /// <param name="value">The octave count.</param>
        public void SetOctaveCount(int value)
        {
            API_FractalSetOctaveCount(_genID, (int)_type, value);
        }

        /// <summary>
        /// Sets fractal's lacunarity.
        /// </summary>
        /// <param name="value">Sets fractal's lacunarity.</param>
        public void SetLacunarity(float value)
        {
            API_FractalSetLacunarity(_genID, (int)_type, value);
        }

    }

}
