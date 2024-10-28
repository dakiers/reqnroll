internal class StepResult(TimeSpan duration, ScenarioExecutionStatus status, string? error, Output[]? outputs = null)
{
    public TimeSpan Duration { get; } = duration;
    public ScenarioExecutionStatus Status { get; } = status;
    public string? Error { get; } = error;
    public Output[]? Outputs { get; } = outputs;
}
