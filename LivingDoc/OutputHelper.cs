public class OutputHelper()
{
    private readonly List<Output> _outputs = [];

    public void WriteLine(string line)
    {
        _outputs.Add(new Output(OutputType.Text) { Message = line });
    }

    public void AddAttachment(string filePath)
    {
        _outputs.Add(new Output(OutputType.Attachment) { FilePath = filePath });
    }

    internal Output[]? FlushOutputs(OutputLocation outputLocation)
    {
        _outputs.ForEach(output => output.OutputLocation = outputLocation);
        Output[]? outputs = _outputs.Count > 0 ? [.. _outputs] : null;
        _outputs.Clear();
        return outputs;
    }
}
