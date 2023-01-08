using WhatsApp.Services;
using WhatsApp.Services.IServices;

namespace WhatsApp
{
    public static class ServiceExtention
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ContactService>();
            services.AddScoped<IConversationRepository, ConversationRepository>();
            services.AddScoped<ConversationService>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<MessageService>();
        }
    }
}
