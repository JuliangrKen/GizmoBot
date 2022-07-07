using Discord;
using Discord.Interactions;
using src.Modules.Data;
using System.Runtime.Serialization.Formatters.Binary;

namespace src.Commands.Public
{
    public class Profile
    {
        public class SlashCommands : InteractionModuleBase<SocketInteractionContext>
        {
            [SlashCommand("profile", "отправляет профиль игрока")]
            public async Task SlashCommand()
            {
                DataStruct ds = new DataStruct(Context.Guild.Id, false);
                if (!File.Exists($@"{ds.Profiles}\{Context.User.Id}.bin"))
                {
                    var embedBuilder = new EmbedBuilder()
                        .WithAuthor(Context.User)
                        .WithColor(Color.Red)
                        .WithTitle($"❌ Ошибка!")
                        .WithDescription("У вас нет профиля.");

                    await RespondAsync(embed: embedBuilder.Build());
                }
                else
                {
                    try
                    {
                        src.Modules.Profiles.Profile profile;

                        using (var fs = new FileStream($@"{ds.Profiles}\{Context.User.Id}.bin", FileMode.Open))
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            profile = (src.Modules.Profiles.Profile)formatter.Deserialize(fs);
                        }

                        //EmbedFieldBuilder[] fields = new EmbedFieldBuilder[] { }; // Характеристики

                        var embedBuilder = new EmbedBuilder()
                            .WithAuthor(Context.User)
                            .WithColor(Color.Gold)
                            .WithTitle($"= {profile.Name} =")
                            .WithDescription($"")
                            //.WithFields(fields)
                            .WithFooter("");

                        await RespondAsync(embed: embedBuilder.Build());
                    }
                    catch
                    {
                        await RespondAsync("```cs\n# Непредвиденная ошибка. Попробуйте снова или обратитесь к Julik#8946.\n```");
                    }
                }
            }
        }
    }
}
