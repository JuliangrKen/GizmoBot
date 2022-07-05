using Discord.Commands;
using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GizmoBot.Commands
{
    public class Hello
    {
        public class PrefixCommands : ModuleBase<SocketCommandContext>
        {
            [Command("hello")]
            public async Task PrefixHelloCommand()
            {
                var user = Context.User;
                var client = Context.Client;
                await ReplyAsync($"**Ну привет-медвед, <@{user.Id}> !**");
            }

            [Command("hi")]
            public async Task PrefixHelloCommandAbb() => await PrefixHelloCommand();

            [Command("привет")]
            public async Task PrefixHelloCommandRu() => await PrefixHelloCommand();

            [Command("пр")]
            public async Task PrefixHelloCommandRuAbb() => await PrefixHelloCommand();
        }
        public class SlashCommands : InteractionModuleBase<SocketInteractionContext>
        {
            [SlashCommand("hello", "поздороваться с ботом")]
            public async Task Hello()
            {
                var user = Context.User;
                await RespondAsync($"**Ну привет-медвед, <@{user.Id}> !**");
            }
        }
    }
}
