using Discord;
using Discord.Commands;
using Discord.Interactions;

namespace src.Commands.Admin
{
    public class Money
    {
        public class PrefixCommands : ModuleBase<SocketCommandContext>
        {
            [Command("addmoney")]
            public async Task AddMoney(string input)
            {
                var user = Context.User;
                var message = Context.Message;
                // Сделать проверку на админа или вайтлист РП мастеров. 
                await message.ReplyAsync("`Ошибка. Использование отрицательных чисел запрещено.`");
            }

            [Command("setmoney")]
            public async Task SetMoney(string input)
            {
                var user = Context.User;
                var message = Context.Message;
                // Сделать проверку на админа или вайтлист РП мастеров. 
                await message.ReplyAsync("`Ошибка. Использование отрицательных чисел запрещено.`");
            }
        }

        [Discord.Interactions.Group("admin-money", "работа админов с деньгами игроков.")]
        public class SlashCommands : InteractionModuleBase<SocketInteractionContext>
        {
            [SlashCommand("addmoney", "добавить/убавить некую сумму в кошелёк игрока")]
            public async Task AddMoney(string Имя_Персонажа, int Количество)
            {
                var user = Context.User;
                // Сделать проверку на админа или вайтлист РП мастеров. 
                await RespondAsync($"`Вы не имеете права на использование данной команды`");
            }

            [SlashCommand("setmoney", "установить некое количество денег в кошельке игрока")]
            public async Task SetMoney(string Имя_Персонажа, int Количество)
            {
                var user = Context.User;
                // Сделать проверку на админа или вайтлист РП мастеров. 
                await RespondAsync($"`Вы не имеете права на использование данной команды`");
            }
        }
    }
}
