#if !NET7_0_OR_GREATER
namespace System.Runtime.CompilerServices;

[AttributeUsage(
        AttributeTargets.Class |
        AttributeTargets.Event |
        AttributeTargets.Field |
        AttributeTargets.GenericParameter |
        AttributeTargets.Parameter |
        AttributeTargets.Property |
        AttributeTargets.ReturnValue,
        AllowMultiple = false,
        Inherited = false)]
#pragma warning disable CS1591 // 공개된 형식 또는 멤버에 대한 XML 주석이 없습니다.
#if BHCS
public
#else
internal
#endif
sealed class NativeIntegerAttribute : Attribute {
    public NativeIntegerAttribute() => TransformFlags = [true];
    public NativeIntegerAttribute(bool[] flags) => TransformFlags = flags;
    public readonly bool[] TransformFlags;
}
#pragma warning restore CS1591 // 공개된 형식 또는 멤버에 대한 XML 주석이 없습니다.
#endif
