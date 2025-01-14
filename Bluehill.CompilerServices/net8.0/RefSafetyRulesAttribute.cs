#if !NET8_0_OR_GREATER
using System.ComponentModel;

namespace System.Runtime.CompilerServices;

/// <summary>Indicates the language version of the ref safety rules used when the module was compiled.</summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[AttributeUsage(AttributeTargets.Module, Inherited = false)]
#if BHCS
public
#else
internal
#endif
sealed class RefSafetyRulesAttribute : Attribute {
    /// <summary>Initializes a new instance of the <see cref="RefSafetyRulesAttribute"/> class.</summary>
    /// <param name="version">The language version of the ref safety rules used when the module was compiled.</param>
    public RefSafetyRulesAttribute(int version) => Version = version;

    /// <summary>Gets the language version of the ref safety rules used when the module was compiled.</summary>
    public int Version { get; }
}
#endif
