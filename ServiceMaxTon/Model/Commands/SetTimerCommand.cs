using ServiceMaxTon.Model.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ServiceMaxTon.Model.Commands
{
    public class SetTimerCommand : Command
    {
        public override string Name => "Таймер";

        public override string Description => throw new NotImplementedException();

        public override void Execute(Message message, TelegramBotClient client)
        {
            Alert alert = new Alert();
            alert.timerStart(message.Chat.Id,client);
        }
    }
}
