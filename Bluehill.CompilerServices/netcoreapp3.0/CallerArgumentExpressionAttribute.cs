#if !NETCOREAPP3_0_OR_GREATER
namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
#pragma warning disable CS1591 // ������ ���� �Ǵ� ����� ���� XML �ּ��� �����ϴ�.
public sealed class CallerArgumentExpressionAttribute : Attribute {
    public CallerArgumentExpressionAttribute(string parameterName) => ParameterName = parameterName;

    public string ParameterName { get; }
#pragma warning restore CS1591 // ������ ���� �Ǵ� ����� ���� XML �ּ��� �����ϴ�.
}
#endif
