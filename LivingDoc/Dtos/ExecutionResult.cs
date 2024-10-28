internal class ExecutionResult(
    ContextType contextType, string featureFolderPath, string featureTitle, string scenarioTitle, string[] scenarioArguments)
{
    public ContextType ContextType { get; } = contextType;
    public string FeatureFolderPath { get; } = featureFolderPath;
    public string FeatureTitle { get; } = featureTitle;
    public string ScenarioTitle { get; } = scenarioTitle;
    public string[] ScenarioArguments { get; } = scenarioArguments;

    public ScenarioExecutionStatus Status { get; set; } = ScenarioExecutionStatus.TestError;
    public List<StepResult> StepResults { get; } = [];
    public Output[]? Outputs { get; set; } = null;
}
