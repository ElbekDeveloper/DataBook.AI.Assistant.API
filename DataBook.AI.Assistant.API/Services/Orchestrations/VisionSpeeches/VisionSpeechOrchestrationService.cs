
using DataBoom.AIAssistant.Services.Foundations.Speeches;
using DataBoom.AIAssistant.Services.Foundations.Visions;

namespace DataBoom.AIAssistant.Services.Orchestrations.VisionSpeeches
{
    public class VisionSpeechOrchestrationService : IVisionSpeechOrchestrationService
    {
        private readonly IVisionService visionService;
        private readonly ISpeechService speechService;

        public VisionSpeechOrchestrationService(
            IVisionService visionService,
            ISpeechService speechService)
        {
            this.visionService = visionService;
            this.speechService = speechService;
        }
        
        public async ValueTask<byte[]> ConvertImageToSpeechAsync(Stream stream)
        {
            string extractedText = await this.visionService.ExtractTextAsync(stream);

            return await this.speechService.SynthesizeTextAsync(extractedText);
        }
    }
}
