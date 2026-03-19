using DSharpPlus;

namespace LorekeeprDSharpPlus;

class Program
{
    static async Task Main(string[] args)
    {
        var stringPath = @"C:\Users\luans\Downloads\LOREKEEPR TOKEN.txt";

        var token = File.ReadAllText(stringPath).Trim();

        DiscordClientBuilder builder = DiscordClientBuilder.CreateDefault(token, DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents);

        builder.ConfigureEventHandlers
        (
            b => b.HandleMessageCreated(async (s, e) => 
                {
                    if (e.Message.MentionedUsers.Contains(s.CurrentUser))
                    {
                        await e.Message.RespondAsync("A Revolução Industrial e suas consequências foram um desastre para a raça humana.");
                    }
                }
            )
        );   


        DiscordClient client = builder.Build();

        await client.ConnectAsync();
        await Task.Delay(-1);

    }
}
