using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ServiceMaxTon.Model.Commands
{
    public class SetCommand : Command
    {
        public override string Name => "Записать";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            long chatId = message.Chat.Id;
            //Записать 5 1.5 2500 UV
            await client.SendTextMessageAsync(chatId, Settings.workingDirectory);
        }
    }
}
