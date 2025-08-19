using Microsoft.AspNetCore.SignalR.Client;

public class SignalRChatClient : IAsyncDisposable
{
    private readonly string _hubUrl;
    private HubConnection? _hubConnection;

    public SignalRChatClient(string hubUrl)
    {
        _hubUrl = hubUrl;
    }

    /// <summary>
    /// Builds and starts the hub connection.
    /// </summary>
    public async Task StartAsync()
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl(_hubUrl)
            .Build();

        await _hubConnection.StartAsync();
    }

    /// <summary>
    /// Ensures hub connection is initialized, otherwise throws.
    /// </summary>
    private HubConnection HubConnection =>
        _hubConnection ?? throw new InvalidOperationException("Hub connection not started. Call StartAsync() first.");

    // ---------------- Messaging ----------------

    // Broadcast to all
    public async Task SendBroadcastMessage(string user, string message) =>
        await HubConnection.SendAsync("BroadcastMessage", user, message);

    // Send to specific user
    public async Task SendPrivateMessage(string sender, string receiver, string message) =>
        await HubConnection.SendAsync("SendPrivateMessage", sender, receiver, message);

    // Join group
    public async Task JoinGroup(string groupName) =>
        await HubConnection.SendAsync("JoinGroup", groupName);

    // Leave group
    public async Task LeaveGroup(string groupName) =>
        await HubConnection.SendAsync("LeaveGroup", groupName);

    // Send to group
    public async Task SendGroupMessage(string groupName, string user, string message) =>
        await HubConnection.SendAsync("SendGroupMessage", groupName, user, message);

    // ---------------- Event Handlers ----------------

    public void OnMessageReceived(Action<string, string> handler) =>
        HubConnection.On("ReceiveMessage", handler);

    public void OnPrivateMessageReceived(Action<string, string> handler) =>
        HubConnection.On("ReceivePrivateMessage", handler);

    public void OnGroupMessageReceived(Action<string, string> handler) =>
        HubConnection.On("ReceiveGroupMessage", handler);

    // ---------------- Disposal ----------------

    public async ValueTask DisposeAsync()
    {
        if (_hubConnection is not null)
        {
            await _hubConnection.DisposeAsync();
        }
    }
}
