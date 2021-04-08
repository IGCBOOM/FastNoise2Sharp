using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp
{
    /// <summary>
    /// Base generator class.
    /// </summary>
    public class Generator : IDisposable
    {
        /// <summary>
        /// ...
        /// </summary>
        protected internal int _genID;

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_RemoveGenerator", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern void API_RemoveGenerator(int generatorID);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_GenUniformGrid2D", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern void API_GenUniformGrid2D(int gen, float[] noiseOut, int xStart, int yStart, int xSize, int ySize, float frequency, int seed, float[] minMax);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_GenUniformGrid3D", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern void API_GenUniformGrid3D(int gen, float[] noiseOut, int xStart, int yStart, int zStart, int xSize, int ySize, int zSize, float frequency, int seed, float[] minMax);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_GenUniformGrid4D", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern void API_GenUniformGrid4D(int gen, float[] noiseOut, int xStart, int yStart, int zStart, int wStart, int xSize, int ySize, int zSize, int wSize, float frequency, int seed, float[] minMax);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_GenPositionArray2D", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern void API_GenPositionArray2D(int gen, float[] noiseOut, int count, float[] xPosArray, float[] yPosArray, float xOffset, float yOffset, int seed, float[] minMax);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_GenPositionArray3D", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern void API_GenPositionArray3D(int gen, float[] noiseOut, int count, float[] xPosArray, float[] yPosArray, float[] zPosArray, float xOffset, float yOffset, float zOffset, int seed, float[] minMax);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_GenPositionArray4D", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern void API_GenPositionArray4D(int gen, float[] noiseOut, int count, float[] xPosArray, float[] yPosArray, float[] zPosArray, float[] wPosArray, float xOffset, float yOffset, float zOffset, float wOffset, int seed, float[] minMax);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_GenSingle2D", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern float API_GenSingle2D(int gen, float x, float y, int seed);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_GenSingle3D", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern float API_GenSingle3D(int gen, float x, float y, float z, int seed);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_GenSingle4D", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern float API_GenSingle4D(int gen, float x, float y, float z, float w, int seed);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_GenTileable2D", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern void API_GenTileable2D(int gen, float[] noiseOut, int xSize, int ySize, float frequency, int seed, float[] minMax);

        internal Generator(int gen)
        {
            _genID = gen;
        }

        internal Generator()
        {
        }

        /// <summary>
        /// Generates a flat array of 2D noise.
        /// </summary>
        /// <param name="xStart">Start X Position</param>
        /// <param name="yStart">Start Y Position</param>
        /// <param name="xSize">X Size</param>
        /// <param name="ySize">Y Size</param>
        /// <param name="frequency">The scale of the noise</param>
        /// <param name="seed">The noise's seed</param>
        /// <returns>A 1 dimensional float array of 2D noise.</returns>
        public float[] GenUniformGrid2D(int xStart, int yStart, int xSize, int ySize, float frequency, int seed, out float min, out float max)
        {

            float[] noise = new float[xSize * ySize];
            float[] minMax = new float[2];

            API_GenUniformGrid2D(_genID, noise, xStart, yStart, xSize, ySize, frequency, seed, minMax);

            min = minMax[0];
            max = minMax[1];

            return noise;

        }

        /// <summary>
        /// Generates a flat array of 3D noise.
        /// </summary>
        /// <param name="xStart">Start X Position</param>
        /// <param name="yStart">Start Y Position</param>
        /// <param name="zStart">Start Z Position</param>
        /// <param name="xSize">X Size</param>
        /// <param name="ySize">Y Size</param>
        /// <param name="zSize">Z Size</param>
        /// <param name="frequency">The scale of the noise</param>
        /// <param name="seed">The noise's seed</param>
        /// <returns>A 1 dimensional float array of 3D noise.</returns>
        public float[] GenUniformGrid3D(int xStart, int yStart, int zStart, int xSize, int ySize, int zSize, float frequency, int seed, out float min, out float max)
        {

            float[] noise = new float[xSize * ySize * zSize];
            float[] minMax = new float[2];

            API_GenUniformGrid3D(_genID, noise, xStart, yStart, zStart, xSize, ySize, zSize, frequency, seed, minMax);

            min = minMax[0];
            max = minMax[1];

            return noise;

        }

        /// <summary>
        /// Generates a flat array of 4D noise.
        /// </summary>
        /// <param name="xStart">Start X Position</param>
        /// <param name="yStart">Start Y Position</param>
        /// <param name="zStart">Start Z Position</param>
        /// <param name="wStart">Start W Position</param>
        /// <param name="xSize">X Size</param>
        /// <param name="ySize">Y Size</param>
        /// <param name="zSize">Z Size</param>
        /// <param name="wSize">W Size</param>
        /// <param name="frequency">The scale of the noise</param>
        /// <param name="seed">The noise's seed</param>
        /// <returns>A 1 dimensional float array of 4D noise.</returns>
        public float[] GenUniformGrid4D(int xStart, int yStart, int zStart, int wStart, int xSize, int ySize, int zSize, int wSize, float frequency, int seed, out float min, out float max)
        {

            float[] noise = new float[xSize * ySize * zSize * wSize];
            float[] minMax = new float[2];

            API_GenUniformGrid4D(_genID, noise, xStart, yStart, zStart, wStart, xSize, ySize, zSize, wSize, frequency, seed, minMax);

            min = minMax[0];
            max = minMax[1];

            return noise;

        }

        public float[] GenPositionArray2D(int count, float[] xPosArray, float[] yPosArray, float xOffset, float yOffset, int seed, out float min, out float max)
        {

            float[] noise = new float[count];
            float[] minMax = new float[2];

            API_GenPositionArray2D(_genID, noise, count, xPosArray, yPosArray, xOffset, yOffset, seed, minMax);

            min = minMax[0];
            max = minMax[1];

            return noise;

        }

        public float[] GenPositionArray3D(int count, float[] xPosArray, float[] yPosArray, float[] zPosArray, float xOffset, float yOffset, float zOffset, int seed, out float min, out float max)
        {

            float[] noise = new float[count];
            float[] minMax = new float[2];

            API_GenPositionArray3D(_genID, noise, count, xPosArray, yPosArray, zPosArray, xOffset, yOffset, zOffset, seed, minMax);

            min = minMax[0];
            max = minMax[1];

            return noise;

        }

        public float[] GenPositionArray4D(int count, float[] xPosArray, float[] yPosArray, float[] zPosArray, float[] wPosArray, float xOffset, float yOffset, float zOffset, float wOffset, int seed, out float min, out float max)
        {

            float[] noise = new float[count];
            float[] minMax = new float[2];

            API_GenPositionArray4D(_genID, noise, count, xPosArray, yPosArray, zPosArray, wPosArray, xOffset, yOffset, zOffset, wOffset, seed, minMax);

            min = minMax[0];
            max = minMax[1];

            return noise;

        }

        /// <summary>
        /// Gets a single point of 2D noise.
        /// </summary>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        /// <param name="seed">The noise's seed</param>
        /// <returns>A single point of 2D noise.</returns>
        public float GenSingle2D(float x, float y, int seed)
        {
            return API_GenSingle2D(_genID, x, y, seed);
        }

        /// <summary>
        /// Gets a single point of 3D noise.
        /// </summary>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        /// <param name="z">Z Position</param>
        /// <param name="seed">The noise's seed</param>
        /// <returns>A single point of 3D noise.</returns>
        public float GenSingle3D(float x, float y, float z, int seed)
        {
            return API_GenSingle3D(_genID, x, y, z, seed);
        }

        /// <summary>
        /// Gets a single point of 4D noise.
        /// </summary>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        /// <param name="z">Z Position</param>
        /// <param name="w">W Position</param>
        /// <param name="seed">The noise's seed</param>
        /// <returns>A single point of 4D noise.</returns>
        public float GenSingle4D(float x, float y, float z, float w, int seed)
        {
            return API_GenSingle4D(_genID, x, y, z, w, seed);
        }

        /// <summary>
        /// Generates a square of 2D noise that's tileable like a texture.
        /// </summary>
        /// <param name="xSize">X Size</param>
        /// <param name="ySize">Y Size</param>
        /// <param name="frequency">The scale of the noise</param>
        /// <param name="seed">The noise's seed</param>
        /// <returns>A 1 dimensional float array of 2D noise.</returns>
        public float[] GenTileable2D(int xSize, int ySize, float frequency, int seed, out float min, out float max)
        {

            float[] noise = new float[xSize * ySize];
            float[] minMax = new float[2];

            API_GenTileable2D(_genID, noise, xSize, ySize, frequency, seed, minMax);

            min = minMax[0];
            max = minMax[1];

            return noise;

        }

        private void ReleaseUnmanagedResources()
        {
            API_RemoveGenerator(_genID);
        }

        /// <summary>
        /// Disposes of the generator.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
            }
        }

        /// <summary>
        /// Disposes of the generator.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Deconstructor.
        /// </summary>
        ~Generator()
        {
            Dispose(false);
        }
    }

}
