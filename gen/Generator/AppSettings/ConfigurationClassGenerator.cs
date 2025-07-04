namespace Generator;

public class ConfigurationClassGenerator
{
    public IEnumerable<(string FileName, string Content)> GenerateConfigurationClasses(string jsonContent)
    {
        if (string.IsNullOrWhiteSpace(jsonContent))
            yield break;

        var jsonDoc = JObject.Parse(jsonContent);

        var classes = new List<ConfigurationClass>();
        var processedTypes = new HashSet<string>();

        // Process root level properties
        foreach (var property in jsonDoc.Properties())
        {
            ProcessProperty(property, classes, processedTypes, isRoot: true);
        }

        // Generate all classes
        foreach (var cls in classes)
        {
            yield return (cls.FileName, GenerateClass(cls));
        }

        // Generate extension methods
        yield return ("ConfigurationExtensions.g.cs", GenerateExtensionMethods(classes));
    }

    private void ProcessProperty(JProperty property, List<ConfigurationClass> classes, HashSet<string> processedTypes, bool isRoot = false)
    {
        var className = FormatClassName(property.Name);

        if (processedTypes.Contains(className))
            return;

        processedTypes.Add(className);

        var configClass = new ConfigurationClass
        {
            Name = className,
            SectionName = property.Name,
            IsRootSection = isRoot,
            Properties = new List<ConfigurationProperty>()
        };

        if (property.Value.Type == JTokenType.Object)
        {
            var obj = (JObject)property.Value;
            foreach (var childProperty in obj.Properties())
            {
                var propType = GetPropertyType(childProperty.Value);
                var propName = FormatPropertyName(childProperty.Name);

                configClass.Properties.Add(new ConfigurationProperty
                {
                    Name = propName,
                    Type = propType,
                    JsonName = childProperty.Name,
                    IsRequired = !IsNullableValue(childProperty.Value)
                });

                // Process nested objects
                if (childProperty.Value.Type == JTokenType.Object)
                {
                    ProcessProperty(childProperty, classes, processedTypes);
                }
                else if (childProperty.Value.Type == JTokenType.Array &&
                         childProperty.Value.HasValues &&
                         childProperty.Value.First.Type == JTokenType.Object)
                {
                    // Process array of objects
                    var arrayItemName = childProperty.Name.TrimEnd('s');
                    var arrayItemProperty = new JProperty(arrayItemName, childProperty.Value.First);
                    ProcessProperty(arrayItemProperty, classes, processedTypes);
                }
            }
        }

        classes.Add(configClass);
    }

    private string GetPropertyType(JToken token)
    {
        return token.Type switch
        {
            JTokenType.String => "string",
            JTokenType.Integer => "int",
            JTokenType.Float => "double",
            JTokenType.Boolean => "bool",
            JTokenType.Array => GetArrayType(token),
            JTokenType.Object => FormatClassName(GetObjectTypeName(token)),
            JTokenType.Null => "string",
            _ => "object"
        };
    }

    private string GetArrayType(JToken arrayToken)
    {
        if (!arrayToken.HasValues)
            return "string[]";

        var firstElement = arrayToken.First;
        var elementType = GetPropertyType(firstElement);

        return $"{elementType}[]";
    }

    private string GetObjectTypeName(JToken obj)
    {
        // Try to get a meaningful name from the object structure
        if (obj is JObject jobj && jobj.Properties().Any())
        {
            return jobj.Properties().First().Name;
        }
        return "Configuration";
    }

    private bool IsNullableValue(JToken token)
    {
        return token.Type == JTokenType.Null;
    }

    private string FormatClassName(string name)
    {
        return ToPascalCase(name) + "Options";
    }

    private string FormatPropertyName(string name)
    {
        return ToPascalCase(name);
    }

    private string ToPascalCase(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        var words = input.Split(new[] { '_', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var result = new StringBuilder();

        foreach (var word in words)
        {
            if (word.Length > 0)
            {
                result.Append(char.ToUpper(word[0]));
                if (word.Length > 1)
                    result.Append(word.Substring(1).ToLower());
            }
        }

        return result.ToString();
    }

    private string GenerateClass(ConfigurationClass configClass)
    {
        var sb = new StringBuilder();

        sb.AppendLine("using System;");
        sb.AppendLine("using System.ComponentModel.DataAnnotations;");
        sb.AppendLine("using Newtonsoft.Json;");
        sb.AppendLine();
        sb.AppendLine("namespace Generated.Configuration");
        sb.AppendLine("{");
        sb.AppendLine($"    public class {configClass.Name}");
        sb.AppendLine("    {");

        foreach (var prop in configClass.Properties)
        {
            // Add validation attributes
            if (prop.IsRequired && prop.Type == "string")
            {
                sb.AppendLine("        [Required]");
            }

            // Add JSON property name attribute if different from C# property name
            if (prop.JsonName != prop.Name)
            {
                sb.AppendLine($"        [JsonProperty(\"{prop.JsonName}\")]");
            }

            sb.AppendLine($"        public {prop.Type} {prop.Name} {{ get; set; }}");
            sb.AppendLine();
        }

        sb.AppendLine("    }");
        sb.AppendLine("}");

        return sb.ToString();
    }

    private string GenerateExtensionMethods(List<ConfigurationClass> classes)
    {
        var sb = new StringBuilder();

        sb.AppendLine("using Microsoft.Extensions.Configuration;");
        sb.AppendLine("using Microsoft.Extensions.DependencyInjection;");
        sb.AppendLine("using Microsoft.Extensions.Options;");
        sb.AppendLine("using System;");
        sb.AppendLine("using System.ComponentModel.DataAnnotations;");
        sb.AppendLine("using System.Collections.Generic;");
        sb.AppendLine("using System.Linq;");
        sb.AppendLine("using Generated.Configuration;");
        sb.AppendLine();
        sb.AppendLine("namespace Generated.Configuration");
        sb.AppendLine("{");
        sb.AppendLine("    public static class ConfigurationExtensions");
        sb.AppendLine("    {");

        // Generate single ConfigureAppSettings method
        sb.AppendLine("        public static IServiceCollection ConfigureAppSettings(this IServiceCollection services, IConfiguration configuration)");
        sb.AppendLine("        {");

        foreach (var configClass in classes.Where(c => c.IsRootSection))
        {
            sb.AppendLine($"            services.Configure<{configClass.Name}>(configuration.GetSection(\"{configClass.SectionName}\"));");
            sb.AppendLine($"            services.AddSingleton<IValidateOptions<{configClass.Name}>, {configClass.Name}Validator>();");
        }

        sb.AppendLine("            return services;");
        sb.AppendLine("        }");
        sb.AppendLine();

        // Generate validation method
        sb.AppendLine("        public static void ValidateConfiguration(this IServiceProvider serviceProvider)");
        sb.AppendLine("        {");
        sb.AppendLine("            var validationResults = new List<ValidationResult>();");
        sb.AppendLine();

        foreach (var configClass in classes.Where(c => c.IsRootSection))
        {
            sb.AppendLine($"            var {configClass.Name.ToLowerInvariant()} = serviceProvider.GetRequiredService<IOptions<{configClass.Name}>>();");
            sb.AppendLine($"            var {configClass.Name.ToLowerInvariant()}Context = new ValidationContext({configClass.Name.ToLowerInvariant()}.Value);");
            sb.AppendLine($"            Validator.TryValidateObject({configClass.Name.ToLowerInvariant()}.Value, {configClass.Name.ToLowerInvariant()}Context, validationResults, true);");
            sb.AppendLine();
        }

        sb.AppendLine("            if (validationResults.Any())");
        sb.AppendLine("            {");
        sb.AppendLine("                var errors = string.Join(Environment.NewLine, validationResults.Select(r => r.ErrorMessage));");
        sb.AppendLine("                throw new InvalidOperationException($\"Configuration validation failed:{Environment.NewLine}{errors}\");");
        sb.AppendLine("            }");
        sb.AppendLine("        }");
        sb.AppendLine("    }");
        sb.AppendLine();

        // Generate validators
        foreach (var configClass in classes.Where(c => c.IsRootSection))
        {
            sb.AppendLine($"    public class {configClass.Name}Validator : IValidateOptions<{configClass.Name}>");
            sb.AppendLine("    {");
            sb.AppendLine($"        public ValidateOptionsResult Validate(string name, {configClass.Name} options)");
            sb.AppendLine("        {");
            sb.AppendLine("            var validationResults = new List<ValidationResult>();");
            sb.AppendLine("            var context = new ValidationContext(options);");
            sb.AppendLine("            ");
            sb.AppendLine("            if (Validator.TryValidateObject(options, context, validationResults, true))");
            sb.AppendLine("            {");
            sb.AppendLine("                return ValidateOptionsResult.Success;");
            sb.AppendLine("            }");
            sb.AppendLine("            ");
            sb.AppendLine("            var errors = validationResults.Select(r => r.ErrorMessage).ToArray();");
            sb.AppendLine($"            return ValidateOptionsResult.Fail(errors);");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine();
        }

        sb.AppendLine("}");

        return sb.ToString();
    }
}
