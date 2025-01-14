using Json.Schema;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Bluehill.CompilerServices.SourceGenerator;

[Generator]
public sealed class CompilerServicesGenerator : IIncrementalGenerator {
    private static readonly Assembly executingAssembly = Assembly.GetExecutingAssembly();
    private static readonly string[] files = executingAssembly.GetManifestResourceNames();

    public void Initialize(IncrementalGeneratorInitializationContext context) {
        var atp = context.AdditionalTextsProvider.Where(f => f.Path.EndsWith("CompilerServices.json", StringComparison.Ordinal));
        var namesAndContents = atp.Select((text, cancellationToken) => (Path.GetFileNameWithoutExtension(text.Path), text.GetText(cancellationToken)!.ToString()));

        context.RegisterSourceOutput(namesAndContents, register);
    }

    private static void register(SourceProductionContext context, (string, string) tuple) {
        var (name, content) = tuple;

        if (!name.Equals("CompilerServices", StringComparison.Ordinal)) {
            throw new ArgumentException("Something went wrong", nameof(tuple));
        }

        var json = JsonDocument.Parse(content);

        try {
            using HttpClient httpClient = new();

            var schemaUrl = json.RootElement.TryGetProperty("$schema", out var value)
                ? value.GetString() ?? throw new InvalidOperationException("Schema url can't be null.")
                : "https://raw.githubusercontent.com/na1307/Bluehill.CompilerServices/refs/heads/main/CompilerServices.schema.json";

            var schemaText = httpClient.GetStringAsync(new Uri(schemaUrl)).GetAwaiter().GetResult();
            var evaluate = JsonSchema.FromText(schemaText).Evaluate(json);

            if (!evaluate.IsValid) {
                throw new InvalidOperationException($"CompilerServices.json is not valid:\n\n{string.Join("\n", evaluate.Errors.Select(kvp => $"{kvp.Key}: {kvp.Value}"))}");
            }
        } catch (HttpRequestException) {
            context.ReportDiagnostic(Diagnostic.Create("BHCSSG01", string.Empty, "CompilerServices.json validation failed because the schema could not be fetched.", DiagnosticSeverity.Warning, DiagnosticSeverity.Warning, true, 1));
        }

        generate(context, json.Deserialize<GeneratableFiles>()!);
    }

    private static void generate(SourceProductionContext context, GeneratableFiles json) {
        if (json.ExtensionAttribute == true) {
            addSource(context, nameof(GeneratableFiles.ExtensionAttribute));
        }

        if (json.CallerFilePathAttribute == true) {
            addSource(context, nameof(GeneratableFiles.CallerFilePathAttribute));
        }

        if (json.CallerLineNumberAttribute == true) {
            addSource(context, nameof(GeneratableFiles.CallerLineNumberAttribute));
        }

        if (json.CallerMemberNameAttribute == true) {
            addSource(context, nameof(GeneratableFiles.CallerMemberNameAttribute));
        }

        if (json.IsByRefLikeAttribute == true) {
            addSource(context, nameof(GeneratableFiles.IsByRefLikeAttribute));
        }

        if (json.IsReadOnlyAttribute == true) {
            addSource(context, nameof(GeneratableFiles.IsReadOnlyAttribute));
        }

        if (json.CallerArgumentExpressionAttribute == true) {
            addSource(context, nameof(GeneratableFiles.CallerArgumentExpressionAttribute));
        }

        if (json.NullableAnotationAttributes_NETCOREAPP3_0 == true) {
            addSource(context, nameof(GeneratableFiles.NullableAnotationAttributes_NETCOREAPP3_0));
        }

        if (json.IsExternalInit == true) {
            addSource(context, nameof(GeneratableFiles.IsExternalInit));
        }

        if (json.ModuleInitializerAttribute == true) {
            addSource(context, nameof(GeneratableFiles.ModuleInitializerAttribute));
        }

        if (json.NullableAnotationAttributes_NET5_0 == true) {
            addSource(context, nameof(GeneratableFiles.NullableAnotationAttributes_NET5_0));
        }

        if (json.SkipLocalsInitAttribute == true) {
            addSource(context, nameof(GeneratableFiles.SkipLocalsInitAttribute));
        }

        if (json.AsyncMethodBuilderAttribute == true) {
            addSource(context, nameof(GeneratableFiles.AsyncMethodBuilderAttribute));
        }

        if (json.InterpolatedStringHandlerArgumentAttribute == true) {
            addSource(context, nameof(GeneratableFiles.InterpolatedStringHandlerArgumentAttribute));
        }

        if (json.InterpolatedStringHandlerAttribute == true) {
            addSource(context, nameof(GeneratableFiles.InterpolatedStringHandlerAttribute));
        }

        if (json.CompilerFeatureRequiredAttribute == true) {
            addSource(context, nameof(GeneratableFiles.CompilerFeatureRequiredAttribute));
        }

        if (json.NativeIntegerAttribute == true) {
            addSource(context, nameof(GeneratableFiles.NativeIntegerAttribute));
        }

        if (json.RequiredMemberAttribute == true) {
            addSource(context, nameof(GeneratableFiles.RequiredMemberAttribute));
        }

        if (json.SetsRequiredMembersAttribute == true) {
            addSource(context, nameof(GeneratableFiles.SetsRequiredMembersAttribute));
        }

        if (json.NullableAttribute == true) {
            addSource(context, nameof(GeneratableFiles.NullableAttribute));
        }

        if (json.NullableContextAttribute == true) {
            addSource(context, nameof(GeneratableFiles.NullableContextAttribute));
        }

        if (json.RefSafetyRulesAttribute == true) {
            addSource(context, nameof(GeneratableFiles.RefSafetyRulesAttribute));
        }

        if (json.RequiresLocationAttribute == true) {
            addSource(context, nameof(GeneratableFiles.RequiresLocationAttribute));
        }

        if (json.ScopedRefAttribute == true) {
            addSource(context, nameof(GeneratableFiles.ScopedRefAttribute));
        }

        if (json.OverloadResolutionPriorityAttribute == true) {
            addSource(context, nameof(GeneratableFiles.OverloadResolutionPriorityAttribute));
        }

        if (json.ExperimentalAttribute == true) {
            addSource(context, nameof(GeneratableFiles.ExperimentalAttribute));
        }

        static void addSource(SourceProductionContext context, string fileName) => context.AddSource($"{fileName}.g.cs", SourceText.From(executingAssembly.GetManifestResourceStream(files.Single(n => n.Contains(fileName))), Encoding.UTF8, canBeEmbedded: true));
    }
}
