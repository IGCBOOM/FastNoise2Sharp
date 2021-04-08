using System.Runtime.InteropServices;
using FastNoiseSharp.Generators;


namespace FastNoiseSharp
{

    /// <summary>
    /// Dimensions. <br/>
    /// Don't use Count.
    /// </summary>
    public enum Dim
    {
        /// <summary>
        /// X Dimension.
        /// </summary>
        X, 
        /// <summary>
        /// Y Dimension.
        /// </summary>
        Y, 
        /// <summary>
        /// Z Dimension.
        /// </summary>
        Z, 
        /// <summary>
        /// W Dimension.
        /// </summary>
        W,
        /// <summary>
        /// Helper enum.
        /// </summary>
        Count
    };

    /// <summary>
    /// Distance functions.
    /// </summary>
    public enum DistanceFunction
    {
        /// <summary>
        /// Euclidean function.
        /// </summary>
        Euclidean,
        /// <summary>
        /// Euclidean squared function.
        /// </summary>
        EuclideanSquared,
        /// <summary>
        /// Manhattan function.
        /// </summary>
        Manhattan,
        /// <summary>
        /// Hybrid function.
        /// </summary>
        Hybrid,
        /// <summary>
        /// Max Axis function.
        /// </summary>
        MaxAxis,
    };

    /// <summary>
    /// Contains API for FastNoise2 for noise generation. <br/>
    /// Used in terrain generation mostly.
    /// </summary>
    public static class FastNoise
    {

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateFromEncodedNodeTree", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateFromEncodedNodeTree(string nodeTree);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateValue", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateValue();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateCellularDistance", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateCellularDistance();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateCellularLookup", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateCellularLookup();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateCellularValue", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateCellularValue();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateOpenSimplex2", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateOpenSimplex2();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreatePerlin", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreatePerlin();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateSimplex", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateSimplex();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateCheckerboard", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateCheckerboard();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateConstant", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateConstant();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateDistanceToPoint", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateDistanceToPoint();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreatePositionOutput", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreatePositionOutput();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateSineWave", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateSineWave();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateWhite", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateWhite();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateAdd", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateAdd();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateDivide", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateDivide();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateFade", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateFade();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateMax", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateMax();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateSubtract", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateSubtract();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateMaxSmooth", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateMaxSmooth();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateMin", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateMin();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateMinSmooth", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateMinSmooth();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateMultiply", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateMultiply();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreatePowFloat", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreatePowFloat();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreatePowInt", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreatePowInt();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateDomainWarpGradient", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateDomainWarpGradient();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateDomainWarpFractalIndependent", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateDomainWarpFractalIndependent();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateDomainWarpFractalProgressive", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateDomainWarpFractalProgressive();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateFractalFBm", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateFractalFBm();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateFractalPingPong", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateFractalPingPong();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateFractalRidged", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateFractalRidged();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateAddDimension", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateAddDimension();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateConvertRGBA8", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateConvertRGBA8();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateDomainAxisScale", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateDomainAxisScale();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateDomainOffset", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateDomainOffset();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateRemap", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateRemap();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateGeneratorCache", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateGeneratorCache();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateDomainScale", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateDomainScale();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateDomainRotate", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateDomainRotate();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateRemoveDimension", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateRemoveDimension();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateSeedOffset", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateSeedOffset();

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_CreateTerrace", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int API_CreateTerrace();

        /// <summary>
        /// Creates a generator from an encoded node tree.<br/>
        /// This is fast and easy way of creating new generators, you can create and modify node trees with NoiseTool.<br/>
        /// This should only be used for quick testing since updates to FastNoise may change node tree behavior.<br/><br/>
        /// https://github.com/Auburn/FastNoise2/releases 
        /// </summary>
        /// <param name="nodeTree">Encoded node tree generated from NoiseTool</param>
        /// <returns>A generator based off of "nodeTree"</returns>
        public static Generator CreateFromEncodedNodeTree(string nodeTree)
        {
            return new Generator(API_CreateFromEncodedNodeTree(nodeTree));
        }
        
        /// <summary>
        /// Creates a "Value" noise generator.
        /// </summary>
        /// <returns>A Value noise generator.</returns>
        public static Value CreateValue()
        {
            return new Value(API_CreateValue());
        }

        /// <summary>
        /// Creates a cellular distance generator.
        /// </summary>
        /// <returns>A cellular distance generator</returns>
        public static CellularDistance CreateCellularDistance()
        {
            return new CellularDistance(API_CreateCellularDistance());
        }

        /// <summary>
        /// Creates a cellular lookup generator.
        /// </summary>
        /// <returns>A cellular lookup generator</returns>
        public static CellularLookup CreateCellularLookup()
        {
            return new CellularLookup(API_CreateCellularLookup());
        }

        /// <summary>
        /// Creates a cellular value generator.
        /// </summary>
        /// <returns>A cellular value generator</returns>
        public static CellularValue CreateCellularValue()
        {
            return new CellularValue(API_CreateCellularValue());
        }

        /// <summary>
        /// Creates an OpenSimplex2 generator.
        /// </summary>
        /// <returns>An OpenSimplex2 generator</returns>
        public static OpenSimplex2 CreateOpenSimplex2()
        {
            return new OpenSimplex2(API_CreateOpenSimplex2());
        }

        /// <summary>
        /// Creates a perlin generator.
        /// </summary>
        /// <returns>A perlin generator.</returns>
        public static Perlin CreatePerlin()
        {
            return new Perlin(API_CreatePerlin());
        }

        /// <summary>
        /// Creates a simplex generator.
        /// </summary>
        /// <returns>A simplex generator.</returns>
        public static Simplex CreateSimplex()
        {
            return new Simplex(API_CreateSimplex());
        }

        /// <summary>
        /// Creates a checkerboard generator.
        /// </summary>
        /// <returns>A checkerboard generator.</returns>
        public static Checkerboard CreateCheckerboard()
        {
            return new Checkerboard(API_CreateCheckerboard());
        }

        /// <summary>
        /// Creates a checkerboard generator.
        /// </summary>
        /// <returns>A checkerboard generator.</returns>
        public static Constant CreateConstant()
        {
            return new Constant(API_CreateConstant());
        }

        /// <summary>
        /// Creates a distance to point generator.
        /// </summary>
        /// <returns>A distance to point generator.</returns>
        public static DistanceToPoint CreateDistanceToPoint()
        {
            return new DistanceToPoint(API_CreateDistanceToPoint());
        }

        /// <summary>
        /// Creates a position output generator.
        /// </summary>
        /// <returns>A position output generator.</returns>
        public static PositionOutput CreatePositionOutput()
        {
            return new PositionOutput(API_CreatePositionOutput());
        }

        /// <summary>
        /// Creates a sine wave generator.
        /// </summary>
        /// <returns>A sine wave generator.</returns>
        public static SineWave CreateSineWave()
        {
            return new SineWave(API_CreateSineWave());
        }

        /// <summary>
        /// Creates a white noise generator.
        /// </summary>
        /// <returns>A white noise generator.</returns>
        public static White CreateWhite()
        {
            return new White(API_CreateWhite());
        }

        /// <summary>
        /// Creates an add blend node.
        /// </summary>
        /// <returns>An add blend node.</returns>
        public static Add CreateAdd()
        {
            return new Add(API_CreateAdd());
        }

        /// <summary>
        /// Creates a divide blend node.
        /// </summary>
        /// <returns>A divide blend node.</returns>
        public static Divide CreateDivide()
        {
            return new Divide(API_CreateDivide());
        }

        /// <summary>
        /// Creates a fade blend node.
        /// </summary>
        /// <returns>A fade blend node.</returns>
        public static Fade CreateFade()
        {
            return new Fade(API_CreateFade());
        }

        /// <summary>
        /// Creates a subtract blend node.
        /// </summary>
        /// <returns>A subtract blend node.</returns>
        public static Subtract CreateSubtract()
        {
            return new Subtract(API_CreateSubtract());
        }

        /// <summary>
        /// Creates a max smooth blend node.
        /// </summary>
        /// <returns>A max smooth blend node.</returns>
        public static MaxSmooth CreateMaxSmooth()
        {
            return new MaxSmooth(API_CreateMaxSmooth());
        }

        /// <summary>
        /// Creates a min blend node.
        /// </summary>
        /// <returns>A min blend node.</returns>
        public static Min CreateMin()
        {
            return new Min(API_CreateMin());
        }

        /// <summary>
        /// Creates a min smooth blend node.
        /// </summary>
        /// <returns>A min smooth blend node.</returns>
        public static MinSmooth CreateMinSmooth()
        {
            return new MinSmooth(API_CreateMinSmooth());
        }

        /// <summary>
        /// Creates a multiply blend node.
        /// </summary>
        /// <returns>A multiply blend node.</returns>
        public static Multiply CreateMultiply()
        {
            return new Multiply(API_CreateMultiply());
        }

        /// <summary>
        /// Creates a exponent blend for floats node.
        /// </summary>
        /// <returns>A exponent blend for floats node.</returns>
        public static PowFloat CreatePowFloat()
        {
            return new PowFloat(API_CreatePowFloat());
        }

        /// <summary>
        /// Creates a exponent blend for ints node.
        /// </summary>
        /// <returns>A exponent blend for ints node.</returns>
        public static PowInt CreatePowInt()
        {
            return new PowInt(API_CreatePowInt());
        }

        /// <summary>
        /// Creates a domain warp gradient node.
        /// </summary>
        /// <returns>A domain warp gradient node.</returns>
        public static DomainWarpGradient CreateDomainWarpGradient()
        {
            return new DomainWarpGradient(API_CreateDomainWarpGradient());
        }

        /// <summary>
        /// Creates an independent domain warp fractal node.
        /// </summary>
        /// <returns>A independent domain warp fractal node.</returns>
        public static DomainWarpFractalIndependent CreateDomainWarpFractalIndependent()
        {
            return new DomainWarpFractalIndependent(API_CreateDomainWarpFractalIndependent());
        }

        /// <summary>
        /// Creates a progressive domain warp fractal node.
        /// </summary>
        /// <returns>A progressive domain warp fractal node.</returns>
        public static DomainWarpFractalProgressive CreateDomainWarpFractalProgressive()
        {
            return new DomainWarpFractalProgressive(API_CreateDomainWarpFractalProgressive());
        }

        /// <summary>
        /// Creates a fractal FBm node.
        /// </summary>
        /// <returns>A fractal FBm node.</returns>
        public static FractalFBm CreateFractalFBm()
        {
            return new FractalFBm(API_CreateFractalFBm());
        }

        /// <summary>
        /// Create a fractal ping pong node.
        /// </summary>
        /// <returns>A fractal ping pong node.</returns>
        public static FractalPingPong CreateFractalPingPong()
        {
            return new FractalPingPong(API_CreateFractalPingPong());
        }

        /// <summary>
        /// Create a fractal ridged node.
        /// </summary>
        /// <returns>A fractal ridged node.</returns>
        public static FractalRidged CreateFractalRidged()
        {
            return new FractalRidged(API_CreateFractalRidged());
        }

        /// <summary>
        /// Creates an Add Dimension node.
        /// </summary>
        /// <returns>An add dimension node.</returns>
        public static AddDimension CreateAddDimension()
        {
            return new AddDimension(API_CreateAddDimension());
        }

        /// <summary>
        /// Creates a ConvertRGBA8 node.
        /// </summary>
        /// <returns>A ConvertRGBA8 node.</returns>
        public static ConvertRGBA8 CreateConvertRGBA8()
        {
            return new ConvertRGBA8(API_CreateConvertRGBA8());
        }

        /// <summary>
        /// Creates a DomainAxisScale node.
        /// </summary>
        /// <returns>A DomainAxisScale node.</returns>
        public static DomainAxisScale CreateDomainAxisScale()
        {
            return new DomainAxisScale(API_CreateDomainAxisScale());
        }

        /// <summary>
        /// Creates a DomainOffset node.
        /// </summary>
        /// <returns>A DomainOffset node.</returns>
        public static DomainOffset CreateDomainOffset()
        {
            return new DomainOffset(API_CreateDomainOffset());
        }

        /// <summary>
        /// Creates a remap node.
        /// </summary>
        /// <returns>A remap node.</returns>
        public static Remap CreateRemap()
        {
            return new Remap(API_CreateRemap());
        }

        /// <summary>
        /// Creates a generator cache node.
        /// </summary>
        /// <returns>A generator cache node.</returns>
        public static GeneratorCache CreateGeneratorCache()
        {
            return new GeneratorCache(API_CreateGeneratorCache());
        }

        /// <summary>
        /// Creates a domain scale node.
        /// </summary>
        /// <returns>A domain scale node.</returns>
        public static DomainScale CreateDomainScale()
        {
            return new DomainScale(API_CreateDomainScale());
        }

        /// <summary>
        /// Creates a domain rotate node.
        /// </summary>
        /// <returns>A domain rotate node.</returns>
        public static DomainRotate CreateDomainRotate()
        {
            return new DomainRotate(API_CreateDomainRotate());
        }

        /// <summary>
        /// Creates a remove dimension node.
        /// </summary>
        /// <returns>A remove dimension node.</returns>
        public static RemoveDimension CreateRemoveDimension()
        {
            return new RemoveDimension(API_CreateRemoveDimension());
        }

        /// <summary>
        /// Creates a seed offset node.
        /// </summary>
        /// <returns>A seed offset node.</returns>
        public static SeedOffset CreateSeedOffset()
        {
            return new SeedOffset(API_CreateSeedOffset());
        }

        /// <summary>
        /// Creates a terrace node.
        /// </summary>
        /// <returns>A terrace node.</returns>
        public static Terrace CreateTerrace()
        {
            return new Terrace(API_CreateTerrace());
        }

    }

}
