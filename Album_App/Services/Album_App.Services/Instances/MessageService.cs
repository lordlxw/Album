using Album_App.Services.Interfaces.Interfaces;

namespace Album_App.Services.Instances
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
