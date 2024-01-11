
using DataBoom.AIAssistant.Brokers.Speeches;
using DataBoom.AIAssistant.Brokers.Visions;
using DataBoom.AIAssistant.Services.Foundations.Speeches;
using DataBoom.AIAssistant.Services.Foundations.Visions;
using DataBoom.AIAssistant.Services.Orchestrations.VisionSpeeches;

namespace DataBook.AI.Assistant.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            RegisterBrokers(builder);
            RegisterFoundationServices(builder);
            RegisterOrchestrationServices(builder);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void RegisterOrchestrationServices(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<
                IVisionSpeechOrchestrationService,
                VisionSpeechOrchestrationService>();
        }

        private static void RegisterFoundationServices(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IVisionService, VisionService>();
            builder.Services.AddTransient<ISpeechService, SpeechService>();
        }

        private static void RegisterBrokers(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IVisionBroker, VisionBroker>();
            builder.Services.AddTransient<ISpeechBroker, SpeechBroker>();
        }
    }
}
