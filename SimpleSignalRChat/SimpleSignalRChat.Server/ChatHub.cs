using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    // Send message to all connected clients
    public async Task BroadcastMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    // Send message to a specific user
    public async Task SendPrivateMessage(string sender, string receiver, string message)
    {
        await Clients.User(receiver).SendAsync("ReceivePrivateMessage", sender, message);
    }

    // Join a group
    public async Task JoinGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }

    // Leave a group
    public async Task LeaveGroup(string groupName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
    }

    // Send message to a group
    public async Task SendGroupMessage(string groupName, string user, string message)
    {
        await Clients.Group(groupName).SendAsync("ReceiveGroupMessage", user, message);
    }
}