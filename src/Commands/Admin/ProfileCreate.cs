using Discord.Commands;
using Discord.Interactions;
using src.Modules.Data;
using src.Modules.Profiles;
using System.Runtime.Serialization.Formatters.Binary;

namespace src.Commands.Admin
{
    public class ProfileCreate
    {
        public class PrefixCommands : ModuleBase<SocketCommandContext>
        {
            //[Command("profile-create")]
            //public async Task ProfileCreate()
            //{

            //}
        }
        public class SlashCommands : InteractionModuleBase<SocketInteractionContext>
        {
            [SlashCommand("profile-create", "создать игроку профиль персонажа")]
            public async Task ProfileCreate(string DiscordID, string Имя_Персонажа)
            {
                //// Сделать проверку на админа или т.п.
                //if (false)
                //    await RespondAsync("❌ Ошибка. У вас нет прав на использование данной команды.");


                // Проблема: создаёт файл и класс даже при наличии ошибки. 
                // Вывод: это можно использовать в дальнейшем, но здесь придётся изменить логику.


                ulong dsID = 0;
                try
                {
                    dsID = Convert.ToUInt64(DiscordID);
                }
                catch
                {
                    await RespondAsync("`❌ Ошибка. Вы ввели некорректный Discord ID`");
                }
                //// Сделать проверку на существование такого игрока в данной гильдии.
                //if (false)
                //    await RespondAsync("❌ Ошибка. Такой игрок отсутствует на данном дискорд-сервере");
                //// Сделать проверку на отсутствие профиля у игрока.
                //if (false)
                //    await RespondAsync("❌ Ошибка. У данного игрока уже имеется профиль. Чтобы создать новый, следует удалить старый.");
                try
                {
                    Profile profile = new (dsID, Context.Guild.Id, Имя_Персонажа);

                    DataStruct ds = new DataStruct(Context.Guild.Id);

                    // Ниже экземпляр профиля сериализуется в бинарный формат
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (var fs = new FileStream($@"{ds.Profiles}\{DiscordID}.bin", FileMode.Create))
                    {
                        // Да, устарело, но мне похуй, я панк.
                        formatter.Serialize(fs, profile);
                    }
                    await RespondAsync("`Профиль успешно создан`");
                }
                catch
                {
                    await RespondAsync("```cs\n# Непредвиденная ошибка. Попробуйте снова или обратитесь к Julik#8946.\n```");
                }
            }
        }
    }
}
