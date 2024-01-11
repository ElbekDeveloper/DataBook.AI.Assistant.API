using Azure;
using Azure.AI.FormRecognizer;
using Azure.AI.FormRecognizer.Models;
using DataBoom.AIAssistant.Models.VisionConfigurations;

namespace DataBoom.AIAssistant.Brokers.Visions
{
    public class VisionBroker : IVisionBroker
    {
        private readonly AzureKeyCredential credential;
        private readonly FormRecognizerClient formRecognizerClient;

        public VisionBroker(IConfiguration configuration)
        {
            var visionConfiguration = new VisionConfiguration();
            configuration.Bind(key: "VisionConfiguration", instance: visionConfiguration);
            credential = new AzureKeyCredential(key: visionConfiguration.VisionKey);

            formRecognizerClient =
                new FormRecognizerClient(endpoint: new Uri(
                    uriString: visionConfiguration.VisionAddress),
                    credential: credential);
        }

        public async ValueTask<List<FormPage>> ExtractTextAsync(Stream stream)
        {
            RecognizeContentOperation operation =
                await formRecognizerClient.StartRecognizeContentAsync(stream);

            await operation.WaitForCompletionAsync();
            FormPageCollection formPages = operation.Value;

            return formPages.ToList();
        }
    }
}
