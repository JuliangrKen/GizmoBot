using Discord.Interactions;


namespace src.Commands.Admin
{
    public class Repeat
    {
        public class SlashCommand : InteractionModuleBase<SocketInteractionContext>
        {
            [SlashCommand("repeat", "говорить от лица бота")]
            public async Task Repeat(string Текст)
            {
                // Проверка на админа.
                await RespondAsync(Текст);
            }
        }
    }
}