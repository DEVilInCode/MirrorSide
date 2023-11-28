using Microsoft.AspNetCore.SignalR.Client;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Threading.Tasks;
using UnityEngine;

public class GameClient : MonoBehaviour
{
    private HubConnection connection;

    private async void Start()
    {
        connection = new HubConnectionBuilder()
            .WithUrl($"{Config.ServerUrl}/gameHub")
            .Build();

        // Подписка на событие получения сообщений от сервера
        connection.On<string>("ReceiveMessageFromServer", OnReceiveMessageFromServer);

        await connection.StartAsync();

        await SendMessageToServer("FUCK");
    }

    private void OnReceiveMessageFromServer(string response)
    {
        Debug.Log("Server response: " + response);
    }

    public async Task SendMessageToServer(string message)
    {
        try
        {
            await connection.InvokeAsync("ReceiveMessageFromClient", message);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error sending message to server: {ex.Message}");
        }
    }
}
