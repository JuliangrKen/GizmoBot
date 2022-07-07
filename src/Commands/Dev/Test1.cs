using Discord;
using Discord.Interactions;

namespace src.Commands.Dev
{
    public class Test1 : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("test", "команда разработчика")]
        public async Task SlashCommand() 
        {
            if (Context.User.Id != 474855275321622538)
            {
                await RespondAsync("`Ты разработчик? Ну-ну... ещё чё скажешь?`");
            }
            else
            {
                var embedBuilder = new EmbedBuilder()
                    .WithAuthor(Context.User)
                    .WithColor(Color.Gold)
                    .WithTitle("Test");
                await RespondAsync(embed: embedBuilder.Build());
            }
        }
    }
}
