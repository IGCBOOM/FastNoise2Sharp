using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNoiseSharp.Generators
{

    /// <summary>
    /// The LHS types.
    /// </summary>
    public enum OperatorSourceLHSTypes
    {
        /// <summary>
        /// Add blend.
        /// </summary>
        Add = 0,
        /// <summary>
        /// Max blend.
        /// </summary>
        Max,
        /// <summary>
        /// Max smooth blend.
        /// </summary>
        MaxSmooth,
        /// <summary>
        /// Min blend.
        /// </summary>
        Min,
        /// <summary>
        /// Min smooth blend.
        /// </summary>
        MinSmooth,
        /// <summary>
        /// Multiply blend.
        /// </summary>
        Multiply
    }

    /// <summary>
    /// This is the class that blends with a LHS and a RHS inherits from.<br/>
    /// Source implies that you cannot set the value of LHS, only plug in a generator.
    /// </summary>
    public abstract class OperatorSourceLHS : Generator
    {

        [DllImport("Engine.dll", EntryPoint = "API_OperatorSourceLHSSetLHS", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern void API_OperatorSourceLHSSetLHS(int gen, int type, int lhsGen);

        [DllImport("Engine.dll", EntryPoint = "API_OperatorSourceLHSSetRHSGen", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern void API_OperatorSourceLHSSetRHSGen(int gen, int type, int rhsGen);

        [DllImport("Engine.dll", EntryPoint = "API_OperatorSourceLHSSetRHSFloat", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private protected static extern void API_OperatorSourceLHSSetRHSFloat(int gen, int type, float value);

        private protected OperatorSourceLHSTypes _type;

        internal OperatorSourceLHS(int gen) : base(gen)
        {
        }

        /// <summary>
        /// Sets the LHS (Left hand side).
        /// </summary>
        /// <param name="gen">Generator to get the LHS from.</param>
        public void SetLHS(Generator gen)
        {
            API_OperatorSourceLHSSetLHS(_genID, (int)_type, gen._genID);
        }

        /// <summary>
        /// Sets the RHS (Right hand side).
        /// </summary>
        /// <param name="gen">Generator to get the RHS from.</param>
        public void SetRHS(Generator gen)
        {
            API_OperatorSourceLHSSetRHSGen(_genID, (int)_type, gen._genID);
        }

        /// <summary>
        /// Sets the RHS (Right hand side).
        /// </summary>
        /// <param name="value">Value to set the RHS to.</param>
        public void SetRHS(float value)
        {
            API_OperatorSourceLHSSetRHSFloat(_genID, (int)_type, value);
        }

    }

}
