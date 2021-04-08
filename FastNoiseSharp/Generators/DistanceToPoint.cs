using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// Each pixel returns the distance to a point.
    /// </summary>
    public sealed class DistanceToPoint : Generator
    {

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_DistanceToPointSetDistanceFunction", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_DistanceToPointSetDistanceFunction(int gen, int distanceFunction);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_DistanceToPointSetScale", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_DistanceToPointSetScale(int gen, int dim, float value);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_DistanceToPointSetSource", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void API_DistanceToPointSetSource(int gen, int sourceGen);

        internal DistanceToPoint(int gen) : base(gen)
        {
        }

        public DistanceToPoint() : base()
        {
            _genID = FastNoise.API_CreateDistanceToPoint();
        }

        /// <summary>
        /// Sets the method that should be used to get the number.
        /// </summary>
        /// <param name="distanceFunction">The method that should be used to get the number.</param>
        public void SetDistanceFunction(DistanceFunction distanceFunction)
        {
            API_DistanceToPointSetDistanceFunction(_genID, (int) distanceFunction);
        }

        /// <summary>
        /// Sets position of point to get the distance from.
        /// </summary>
        /// <param name="dimension">The axis to change</param>
        /// <param name="value">The position to set it to</param>
        public void SetScale(Dim dimension, float value)
        {
            API_DistanceToPointSetScale(_genID, (int) dimension, value);
        }

        /// <summary>
        /// ?<br/>
        /// We've yet to figure this out.
        /// </summary>
        /// <param name="source">The source generator</param>
        public void SetSource(Generator source)
        {
            API_DistanceToPointSetSource(_genID, source._genID);
        }

    }
}
