using Discord.Interactions;

namespace src.Commands.Admin
{
    public class WhiteList
    {
        public class SlashCommand : InteractionModuleBase<SocketInteractionContext>
        {
            [SlashCommand("whitelist", "назначить человека GMом")]
            public async Task RollCommand(string DiscordID)
            {
                if (false) // Проверка на админа.
                {
                    await RespondAsync("Эта команда доступна только администраторам!");
                }
                else
                {
                    try
                    {
                        // Проверка на корреткность ввода. На существование игрока.
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}
