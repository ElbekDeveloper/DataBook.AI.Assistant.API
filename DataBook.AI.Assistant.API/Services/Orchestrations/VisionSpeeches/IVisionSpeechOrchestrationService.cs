namespace DataBoom.AIAssistant.Services.Orchestrations.VisionSpeeches
{
    public interface IVisionSpeechOrchestrationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>Synthesized audio based on the input</returns>
        ValueTask<byte[]> ConvertImageToSpeechAsync(Stream stream);
    }
}