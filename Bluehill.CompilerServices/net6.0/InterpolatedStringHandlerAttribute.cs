﻿#if !NET6_0_OR_GREATER
namespace System.Runtime.CompilerServices;

/// <summary>Indicates the attributed type is to be used as an interpolated string handler.</summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
#if BHCS
public
#else
internal
#endif
sealed class InterpolatedStringHandlerAttribute : Attribute {
    /// <summary>Initializes the <see cref="InterpolatedStringHandlerAttribute"/>.</summary>
    public InterpolatedStringHandlerAttribute() { }
}
#endif
