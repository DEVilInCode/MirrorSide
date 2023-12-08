using Microsoft.AspNetCore.SignalR;
using Server.GameLogic;
using SharedLibrary;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Server
{
    public class GameHub : Hub
    {
        private List<string> _connections = new List<string>();
        private ConcurrentQueue<Player> _players = new();
        private ConcurrentDictionary<int, GameSession> _sessions = new();

        private const int PlayersPerGame = 2;
        private int _sessionsCount = 0;

        public override async Task OnConnectedAsync()
        {
            _connections.Add(Context.ConnectionId);
            
            await Clients.Caller.SendAsync("Connected");//Connected
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            _connections.Remove(Context.ConnectionId);
            await Clients.Caller.SendAsync("Disconnected");//Disconnected
        }

        public async Task FindGame(Player player1)
        {
            player1.ID = Context.ConnectionId;
            if (_players.Count > 1)
            {
                if (_players.TryDequeue(out Player? player2))
                {
                    //TODO: rewrite sessions storage. Find way to delete session by id or on end. Is only way to do it is make session know its id?
                    _sessions.TryAdd(Interlocked.Increment(ref _sessionsCount), new GameSession(player1, player2));

                    await Clients.Clients(player1.ID, player2.ID).SendAsync("GameStarted");

                    return;
                }
            }

            _players.Enqueue(player1);
            await Clients.Caller.SendAsync("GameSearch");
        }

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
