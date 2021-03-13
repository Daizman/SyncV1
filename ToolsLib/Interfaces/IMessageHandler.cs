using System.Net;
using ToolsLib.UserClasses;

namespace ToolsLib.Interfaces
{
    public interface IMessageHandler
    {
        void HandleMessage(User user, IPEndPoint remote);
    }
}
