namespace Generator;

public class ConfigurationClass
{
    public string Name { get; set; } = string.Empty;
    public string SectionName { get; set; } = string.Empty;
    public bool IsRootSection { get; set; }
    public List<ConfigurationProperty> Properties { get; set; } = new();
    public string FileName => $"{Name}.g.cs";
}
