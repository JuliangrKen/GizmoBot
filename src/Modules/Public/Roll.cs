using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GizmoBot.Commands
{
    public class Roll
    {
        public class PrefixCommands : ModuleBase<SocketCommandContext>
        {
            [Command("roll")]
            public async Task RollCommand()
            {
                int Максимум = 100, Минимум = 1;

                var message = Context.Message;
                if (Минимум > Максимум) await message.ReplyAsync("`Ошибка. Вы установили минимум больший, чем максимум.`");
                if (Максимум < 0 || Минимум < 0) await message.ReplyAsync("`Ошибка. Использование отрицательных чисел запрещено.`");

                var random = new Random();

                try
                {
                    var result = random.Next(Минимум, Максимум);

                    var embedBuilder = new EmbedBuilder()
                        .WithAuthor(Context.User)
                        .WithColor(Color.Gold)
                        .WithTitle($"**======================\n\t\t\t\tРезультат:   {result}\n======================**")
                        .WithDescription($"Случайное число от {Минимум} до {Максимум}");

                    await message.ReplyAsync(embed: embedBuilder.Build());
                }
                catch
                {
                    await message.ReplyAsync("```cs\n# Непредвиденная ошибка. Попробуйте снова или обратитесь к Julik#8946.\n```");
                }
            }

            [Command("ролл")]
            public async Task RollCommandRuAbb() => await RollCommand();
        }
        public class SlashCommand : InteractionModuleBase<SocketInteractionContext>
        {
            [Command, SlashCommand("roll", "генерирует случайное число")]
            public async Task RollCommand(int Максимум = 100, int Минимум = 1)
            {
                if (Минимум > Максимум) await RespondAsync("`Ошибка. Вы установили минимум больший, чем максимум.`");
                if (Максимум < 0 || Минимум < 0) await RespondAsync("`Ошибка. Использование отрицательных чисел запрещено.`");

                var random = new Random();
                
                try
                {
                    var result = random.Next(Минимум, Максимум);

                    var embedBuilder = new EmbedBuilder()
                        .WithAuthor(Context.User)
                        .WithColor(Color.Gold)
                        .WithTitle($"**======================\n\t\t\t\tРезультат:   {result}\n======================**")
                        .WithDescription($"Случайное число от {Минимум} до {Максимум}");

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