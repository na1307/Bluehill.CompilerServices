#if !NET45_OR_GREATER && !NETSTANDARD1_0_OR_GREATER && !NETCOREAPP1_0_OR_GREATER
namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
#pragma warning disable CS1591 // ������ ���� �Ǵ� ����� ���� XML �ּ��� �����ϴ�.
public sealed class CallerLineNumberAttribute : Attribute;
#pragma warning restore CS1591 // ������ ���� �Ǵ� ����� ���� XML �ּ��� �����ϴ�.
#endif
