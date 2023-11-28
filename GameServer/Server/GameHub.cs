using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace Server
{
    public class GameHub : Hub
    {
        public async Task ReceiveMessageFromClient(string message)
        {
            // Process the received message on the server
            // ...

            // Send a response back to the client
            string response = "Server received your message: " + message;
            await Clients.Caller.SendAsync("ReceiveMessageFromServer", response);
        }
    }
}
