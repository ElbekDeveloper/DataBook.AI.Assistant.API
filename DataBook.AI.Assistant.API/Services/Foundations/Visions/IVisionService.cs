namespace DataBoom.AIAssistant.Services.Foundations.Visions
{
    public interface IVisionService
    {
        ValueTask<string> ExtractTextAsync(Stream stream);
    }
}
