using Azure.AI.FormRecognizer.Models;

namespace DataBoom.AIAssistant.Brokers.Visions
{
    public interface IVisionBroker
    {
        ValueTask<List<FormPage>> ExtractTextAsync(Stream stream);
    }
}
