using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ServiceMaxTon.Model.Commands
{
    public class SetResourceCommand : Command
    {
        public override string Name => "Пленка";
        //Пленка 5 30 13400 UV
        public override void Execute(Message message, TelegramBotClient client)
        {
            
        }
    }
}
