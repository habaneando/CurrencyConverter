namespace Generator;

[Generator]
public class ConfigurationSourceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Get appsettings.json files
        var appSettingsFiles = context.AdditionalTextsProvider
            .Where(static file => file.Path.EndsWith("appsettings.json", StringComparison.OrdinalIgnoreCase))
            .Select(static (file, ct) => new
            {
                Path = file.Path,
                Content = file.GetText(ct)?.ToString() ?? string.Empty
            });

        // Generate configuration classes
        context.RegisterSourceOutput(appSettingsFiles, static (context, file) =>
        {
            try
            {
                var generator = new ConfigurationClassGenerator();
                var sources = generator.GenerateConfigurationClasses(file.Content);

                foreach (var source in sources)
                {
                    context.AddSource(source.FileName, SourceText.From(source.Content, Encoding.UTF8));
                }
            }
            catch (Exception ex)
            {
                context.ReportDiagnostic(Diagnostic.Create(
                    new DiagnosticDescriptor(
                        "CFG001",
                        "Configuration Generation Error",
                        "Error generating configuration classes: {0}",
                        "Configuration",
                        DiagnosticSeverity.Warning,
                        true),
                    Location.None,
                    ex.Message));
            }
        });
    }
}
