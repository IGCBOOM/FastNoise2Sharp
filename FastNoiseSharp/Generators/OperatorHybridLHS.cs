using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{
    /// <summary>
    /// LHS types.
    /// </summary>
    public enum OperatorHybridLHSTypes
    {
        /// <summary>
        /// Divide blend.
        /// </summary>
        Divide = 0,
        /// <summary>
        /// Subtract blend.
        /// </summary>
        Subtract
    }

    /// <summary>
    /// This is the class that blends with a LHS and a RHS inherits from.<br/>
    /// Hybrid implies that you can set LHS to a number, or plug in a source generator.
    /// </summary>
    public abstract class OperatorHybridLHS : Generator
    {

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_OperatorHybridLHSSetLHSGen", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern void API_OperatorHybridLHSSetLHSGen(int gen, int type, int lhsGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_OperatorHybridLHSSetLHSFloat", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern void API_OperatorHybridLHSSetLHSFloat(int gen, int type, float value);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_OperatorHybridLHSSetRHSGen", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern void API_OperatorHybridLHSSetRHSGen(int gen, int type, int lhsGen);

        [DllImport("FastNoise2Sharp.dll", EntryPoint = "API_OperatorHybridLHSSetRHSFloat", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern void API_OperatorHybridLHSSetRHSFloat(int gen, int type, float value);

        private protected OperatorHybridLHSTypes _type;

        internal OperatorHybridLHS(int gen) : base(gen)
        {
        }

        internal OperatorHybridLHS() : base()
        {
        }

        /// <summary>
        /// Sets the LHS (Left hand side).
        /// </summary>
        /// <param name="gen">Generator to get the LHS from.</param>
        public void SetLHS(Generator gen)
        {
            API_OperatorHybridLHSSetLHSGen(_genID, (int)_type, gen._genID);
        }

        /// <summary>
        /// Sets the LHS (Left hand side).
        /// </summary>
        /// <param name="value">Value to set the LHS to.</param>
        public void SetLHS(float value)
        {
            API_OperatorHybridLHSSetLHSFloat(_genID, (int)_type, value);
        }

        /// <summary>
        /// Sets the RHS (Right hand side).
        /// </summary>
        /// <param name="gen">Generator to get the RHS from.</param>
        public void SetRHS(Generator gen)
        {
            API_OperatorHybridLHSSetRHSGen(_genID, (int)_type, gen._genID);
        }

        /// <summary>
        /// Sets the RHS (Right hand side).
        /// </summary>
        /// <param name="value">Value to set the RHS to.</param>
        public void SetRHS(float value)
        {
            API_OperatorHybridLHSSetRHSFloat(_genID, (int)_type, value);
        }

    }

}
