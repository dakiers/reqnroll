using SpecFlow.Internal.Json;

[Binding]
public class LivingDocHook
{
    private const int BeforeOrder = 0;
    private const int AfterOrder = 10000;
    private const string FileName = "TestExecution.json";
    private const ContextType ExecutionContextType = ContextType.Scenario;

    #region Per Run / Feature
    private static Execution? _execution;
    #endregion

    #region Per Scenario / Step
    private ExecutionResult? _result;
    private DateTime? _stepStartTime;
    #endregion

    [BeforeTestRun(Order = BeforeOrder)]
    public static void BeforeTestRun()
    {
        _execution = new(Guid.NewGuid());
    }

    [BeforeScenario(Order = BeforeOrder)]
    public void BeforeScenario(FeatureInfo feature, ScenarioInfo scenario)
    {
        _result = new(
            ExecutionContextType,
            feature.FolderPath,
            feature.Title, 
            scenario.Title, 
            scenario.Arguments.Values.Cast<string>().ToArray());
    }

    [BeforeStep(Order = BeforeOrder)]
    public void BeforeStep()
    {
        _stepStartTime = DateTime.UtcNow;
    }

    [AfterStep(Order = AfterOrder)]
    public void AfterStep(ScenarioContext scenario, OutputHelper outputHelper)
    {
        var step = scenario.StepContext;
        _result!.StepResults.Add(new(
            (DateTime.UtcNow - _stepStartTime!).Value,
            step.Status,
            step.TestError?.Message,
            outputHelper.FlushOutputs(OutputLocation.AfterStep)));
    }

    [AfterScenario(Order = AfterOrder)]
    public void AfterScenario(ScenarioContext scenario, OutputHelper outputHelper)
    {
        _result!.Status = scenario.ScenarioExecutionStatus;
        _result.Outputs = outputHelper.FlushOutputs(OutputLocation.AfterScenario);
        _execution!.ExecutionResults.Add(_result);
    }

    [AfterTestRun(Order = AfterOrder)]
    public static async Task AfterTestRun()
    {
        _execution!.GenerationTime = DateTime.UtcNow;

        await File.WriteAllTextAsync(FileName, _execution.ToJson(new(false)));
    }
}
