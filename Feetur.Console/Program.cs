using System;
using System.Net.Http;
using System.Threading.Tasks;
using Feetur.Shared;
using Feetur.Shared.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace Feetur.Console
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            await Task.WhenAll(RunAsync(), RunAsync());

            System.Console.ReadKey();
        }

        private static async Task<HubConnection> RunAsync()
        {
            var guid = Guid.NewGuid();
            var url = $"https://localhost:7185/featureHub?me={guid}";
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect()
                .Build();
            
            hubConnection.On<Feature>(nameof(IFeatureClient.Notify), async f =>
            {
                System.Console.WriteLine($"Notified {guid}! ({f.Name}:{f.Enabled})");

                await hubConnection.InvokeAsync(nameof(IFeatureHub.Reply), guid, f.Id);
            });

            await hubConnection.StartAsync();

            return hubConnection;
        }
    }
}