using System.Collections.Concurrent;
using Feetur.Shared;
using Feetur.Shared.Models;
using Microsoft.AspNetCore.SignalR;

namespace Feetur.Api.Hubs;

public class FeatureHub: Hub<Feature>, IFeatureHub
{
    private static readonly ConcurrentDictionary<string, bool> _clients = new();
    public override Task OnConnectedAsync()
    {
        var user = GetUserNameFromContext();
        if(!string.IsNullOrEmpty(user))
            ToggleOnline(user, true);

        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        var user = GetUserNameFromContext();
        if(!string.IsNullOrEmpty(user))
            ToggleOnline(user, false);
        
        return base.OnDisconnectedAsync(exception);
    }

    public Task Reply(Guid user, Guid messageId)
    {
        return Task.CompletedTask;
    }

    private string GetUserNameFromContext()
    {
        var httpContext = Context.GetHttpContext();
        var query = httpContext?.Request.Query;

        if (query?.TryGetValue("me", out var user) == true)
            return user;

        return null;
    }
    
    private static void ToggleOnline(string userIdentifier, bool online)
        => _clients.AddOrUpdate(userIdentifier, online, (_, _) => online);
}