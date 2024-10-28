internal class Execution(Guid pluginUserSpecFlowId)
{
    public string[] Nodes { get; } = [];
    public DateTime ExecutionTime { get; } = DateTime.UtcNow;
    public DateTime GenerationTime { get; set; }
    public Guid PluginUserSpecFlowId { get; } = pluginUserSpecFlowId;
    public string? CLIUserSpecFlowId { get; } = null;

    public List<ExecutionResult> ExecutionResults { get; } = [];

    public string? StepReports { get; } = null;
}