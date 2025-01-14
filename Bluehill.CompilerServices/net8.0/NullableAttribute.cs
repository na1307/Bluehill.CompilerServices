﻿#if !NET8_0_OR_GREATER
using System.ComponentModel;

namespace System.Runtime.CompilerServices;

/// <summary>
/// Reserved for use by a compiler for tracking metadata.
/// This attribute should not be used by developers in source code.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, Inherited = false)]
#if BHCS
public
#else
internal
#endif
sealed class NullableAttribute : Attribute {
    /// <summary>Flags specifying metadata related to nullable reference types.</summary>
    public readonly byte[] NullableFlags;

    /// <summary>Initializes the attribute.</summary>
    /// <param name="value">The flags value.</param>
    public NullableAttribute(byte value) => NullableFlags = [value];

    /// <summary>Initializes the attribute.</summary>
    /// <param name="value">The flags value.</param>
    public NullableAttribute(byte[] value) => NullableFlags = value;
}
#endif
