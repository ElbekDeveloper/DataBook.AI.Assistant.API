using DataBoom.AIAssistant.Models.SpeechConfigurations;
using Microsoft.CognitiveServices.Speech;

namespace DataBoom.AIAssistant.Brokers.Speeches
{
    public class SpeechBroker : ISpeechBroker
    {
        private SpeechConfig speechConfig;
        private SpeechConfiguration speechConfiguration;
        private readonly IConfiguration configuration;

        public SpeechBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            ConfigureSpeech();
        }

        private void ConfigureSpeech()
        {
            this.speechConfiguration = new SpeechConfiguration();
            this.configuration.Bind(nameof(SpeechConfiguration), this.speechConfiguration);

            this.speechConfig = SpeechConfig.FromSubscription(
                subscriptionKey: this.speechConfiguration.Key,
                region: this.speechConfiguration.Region);
        }

        public async ValueTask<byte[]> SynthesizeTextAsync(string text)
        {
            this.speechConfig.SpeechSynthesisVoiceName = "en-US-AndrewNeural";

            using (var speechSynthesizer = new SpeechSynthesizer(this.speechConfig))
            {
                SpeechSynthesisResult speechSynthesisResult = await speechSynthesizer.SpeakTextAsync(text);

                return speechSynthesisResult.AudioData;
            }
        }

    }
}
