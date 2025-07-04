namespace Generator;

public class ConfigurationProperty
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string JsonName { get; set; } = string.Empty;
    public bool IsRequired { get; set; }
}
