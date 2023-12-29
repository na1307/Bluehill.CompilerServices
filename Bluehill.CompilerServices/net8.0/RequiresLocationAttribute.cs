#if !NET8_0_OR_GREATER
using System.ComponentModel;

namespace System.Runtime.CompilerServices;

/// <summary>
/// Reserved for use by a compiler for tracking metadata.
/// This attribute should not be used by developers in source code.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
public sealed class RequiresLocationAttribute : Attribute {
    /// <summary>Initializes the attribute.</summary>
    public RequiresLocationAttribute() { }
}
#endif
