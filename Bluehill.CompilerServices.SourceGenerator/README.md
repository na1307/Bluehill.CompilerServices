# Bluehill.CompilerServices.SourceGenerator
Provides types for modern language features, powered by Source generator.

Currently supports up to C# 13 types.

## How to use

Create a `CompilerServices.json` file with the following contents (File name is case sensitive):

```json
{
  "ExtensionAttribute": false,
  "CallerFilePathAttribute": false,
  "CallerLineNumberAttribute": false,
  "CallerMemberNameAttribute": false,
  "IsByRefLikeAttribute": false,
  "IsReadOnlyAttribute": false,
  "CallerArgumentExpressionAttribute": false,
  "NullableAnotationAttributes_NETCOREAPP3_0": false,
  "IsExternalInit": false,
  "ModuleInitializerAttribute": false,
  "NullableAnotationAttributes_NET5_0": false,
  "SkipLocalsInitAttribute": false,
  "AsyncMethodBuilderAttribute": false,
  "InterpolatedStringHandlerArgumentAttribute": false,
  "InterpolatedStringHandlerAttribute": false,
  "CompilerFeatureRequiredAttribute": false,
  "NativeIntegerAttribute": false,
  "RequiredMemberAttribute": false,
  "SetsRequiredMembersAttribute": false,
  "NullableAttribute": false,
  "NullableContextAttribute": false,
  "RefSafetyRulesAttribute": false,
  "RequiresLocationAttribute": false,
  "ScopedRefAttribute": false,
  "OverloadResolutionPriorityAttribute": false,
  "ExperimentalAttribute": false
}
```

Change the item you want to use to true.
