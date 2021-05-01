using CqrsApp.API.Domain;

namespace CqrsApp.API.Messaging.Sender
{
    public interface ITodoSender
    {
        void Send(Todo todo);
    }
}