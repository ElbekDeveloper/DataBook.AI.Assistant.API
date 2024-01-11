using DataBoom.AIAssistant.Brokers.Speeches;

namespace DataBoom.AIAssistant.Services.Foundations.Speeches
{
    public class SpeechService : ISpeechService
    {
        private readonly ISpeechBroker speechBroker;
        
        public SpeechService(ISpeechBroker speechBroker) =>
            this.speechBroker = speechBroker;

        public async ValueTask<byte[]> SynthesizeTextAsync(string text) =>
            await this.speechBroker.SynthesizeTextAsync(text);
    }
}
