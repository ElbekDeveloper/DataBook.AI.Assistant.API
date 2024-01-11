namespace DataBoom.AIAssistant.Services.Foundations.Speeches
{
    public interface ISpeechService
    {
        ValueTask<byte[]> SynthesizeTextAsync(string text);
    }
}
