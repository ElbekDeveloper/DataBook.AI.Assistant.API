using System.Text;
using Azure.AI.FormRecognizer.Models;
using DataBoom.AIAssistant.Brokers.Visions;

namespace DataBoom.AIAssistant.Services.Foundations.Visions
{

    public class VisionService : IVisionService
    {
        private readonly IVisionBroker visionBroker;

        public VisionService(IVisionBroker visionBroker) =>
            this.visionBroker = visionBroker;

        public async ValueTask<string> ExtractTextAsync(Stream stream)
        {
            List<FormPage> pages = await this.visionBroker.ExtractTextAsync(stream);

            var text = new StringBuilder();

            foreach (FormPage page in pages)
            {
                foreach (FormLine line in page.Lines)
                {
                    text.AppendLine(line.Text);
                }
            }

            return text.ToString();
        }
    }
}
