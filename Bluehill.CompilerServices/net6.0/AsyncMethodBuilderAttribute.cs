﻿#if !NET6_0_OR_GREATER
namespace System.Runtime.CompilerServices;

/// <summary>
/// Indicates the type of the async method builder that should be used by a language compiler to
/// build the attributed async method or to build the attributed type when used as the return type
/// of an async method.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface | AttributeTargets.Delegate | AttributeTargets.Enum | AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
#if BHCS
public
#else
internal
#endif
sealed class AsyncMethodBuilderAttribute : Attribute {
    /// <summary>Initializes the <see cref="AsyncMethodBuilderAttribute"/>.</summary>
    /// <param name="builderType">The <see cref="Type"/> of the associated builder.</param>
    public AsyncMethodBuilderAttribute(Type builderType) => BuilderType = builderType;

    /// <summary>Gets the <see cref="Type"/> of the associated builder.</summary>
    public Type BuilderType { get; }
}
#endif
