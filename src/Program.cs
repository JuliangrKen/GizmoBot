using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public class Program
{
    public static Task Main(string[] args) => new Program().MainAsync();

    const string prefix = "!";
    const string token = @"ODg0MTA3OTAzOTk5NTQ1NDA0.GD7EOX.DODH8C3XouHHuYOy-RwGXGDbY-1xuA66tqU2G4";
    const ulong guildId = 632139836752527360;

    private DiscordSocketClient? _client;
    private CommandService? _commands;
    private IServiceProvider? _services;
    private InteractionService? _interactionService;

    public async Task MainAsync()
    {
        _client = new DiscordSocketClient();
        _commands = new CommandService();
        _services = new ServiceCollection()
            .AddSingleton(_client)
            .AddSingleton(_commands)
            .BuildServiceProvider();

        _client.Log += Log;

        _client.Ready += HandleSlashCommandAsync;
        _client.MessageReceived += HandleCommandAsyncWithPrefix;

        await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        await _client.LoginAsync(Discord.TokenType.Bot, token);
        await _client.StartAsync();

        await Task.Delay(-1);
    }

    private async Task HandleCommandAsyncWithPrefix(SocketMessage msg)
    {
        var message = msg as SocketUserMessage;
        var context = new SocketCommandContext(_client, message);
        if (message != null && message.Author.IsBot)
            return;
        int argPos = 0;
        if (message != null && message.HasStringPrefix(prefix, ref argPos) && _commands != null)
        {
            var result = await _commands.ExecuteAsync(context, argPos, _services);
            if (!result.IsSuccess)
                Console.WriteLine(result.ErrorReason);
            if (result.Error.Equals(CommandError.UnmetPrecondition))
                await message.Channel.SendFileAsync(result.ErrorReason);
        }
    }

    private async Task HandleSlashCommandAsync()
    {
        _interactionService = new InteractionService(_client);
        await _interactionService.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        await _interactionService.RegisterCommandsToGuildAsync(guildId);

        if (_client != null && _services != null)
            _client.InteractionCreated += async interaction =>
            {
                var scope = _services.CreateScope();
                var ctx = new SocketInteractionContext(_client, interaction);
                await _interactionService.ExecuteCommandAsync(ctx, scope.ServiceProvider);
            };
    }

    private Task Log(Discord.LogMessage msg)
    {
        Console.WriteLine(msg);
        return Task.CompletedTask;
    }
}