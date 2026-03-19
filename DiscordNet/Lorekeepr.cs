using Discord;
using Discord.WebSocket;

namespace Lorekeepr;

public class Lorekeepr
{
    public static async Task Main()
    {
        var _client = new DiscordSocketClient();

        _client.Log += Log;

        var stringPath = @"C:\Users\luans\Downloads\LOREKEEPR TOKEN.txt";

        var token = File.ReadAllText(stringPath);

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        // Block this task until the program is closed.
        await Task.Delay(-1);
    }

    private static Task Log(LogMessage message)
    {
        Console.WriteLine(message.ToString());
        return Task.CompletedTask;
    }
}
