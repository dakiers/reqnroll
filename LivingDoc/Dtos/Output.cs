internal class Output(OutputType type)
{
    public OutputLocation OutputLocation { get; set; }
    public OutputType Type { get; } = type;
    public string? Message { get; set; } = null;
    public string? FilePath { get; set; } = null;
}
