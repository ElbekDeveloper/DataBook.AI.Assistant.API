using DataBoom.AIAssistant.Services.Orchestrations.VisionSpeeches;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CognitiveServices.Speech.Transcription;

namespace DataBook.AI.Assistant.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IVisionSpeechOrchestrationService visionSpeechOrchestrationService;

        public HomeController(IVisionSpeechOrchestrationService visionSpeechOrchestrationService)
        {
            this.visionSpeechOrchestrationService = visionSpeechOrchestrationService;
        }

        [HttpPost]
        public async Task<IActionResult> PostImageAsync()
        {
            IFormFile imageFile = Request.Form.Files[0];

            using (var memoryStream = new MemoryStream())
            {
                string extension = Path.GetExtension(imageFile.FileName);
                imageFile.CopyTo(memoryStream);
                memoryStream.Position = 0;

                var result = await this.visionSpeechOrchestrationService
                    .ConvertImageToSpeechAsync(memoryStream);

                return File(result, "audio/wav");
            }
        }
    }
}
