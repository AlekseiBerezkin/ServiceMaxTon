using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ServiceMaxTon.Model.Commands
{
    public class StartCommand : Command
    {
        public override string Name =>"/start";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            long chatId = message.Chat.Id;

            await client.SendTextMessageAsync(chatId, "Поехали");
        }
    }
}
