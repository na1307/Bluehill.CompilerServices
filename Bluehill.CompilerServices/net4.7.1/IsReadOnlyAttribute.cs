﻿#if !NET471_OR_GREATER && !NETSTANDARD2_1_OR_GREATER && !NETCOREAPP2_0_OR_GREATER
using System.ComponentModel;

namespace System.Runtime.CompilerServices;

/// <summary>
/// Reserved for use by a compiler for tracking metadata.
/// This attribute should not be used by developers in source code.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[AttributeUsage(AttributeTargets.All, Inherited = false)]
#if BHCS
public
#else
internal
#endif
sealed class IsReadOnlyAttribute : Attribute {
    /// <summary>Initializes the attribute.</summary>
    public IsReadOnlyAttribute() { }
}
#endif
