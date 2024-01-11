namespace DataBoom.AIAssistant.Brokers.Speeches
{
    public interface ISpeechBroker
    {
        ValueTask<byte[]> SynthesizeTextAsync(string text);
    }
}
