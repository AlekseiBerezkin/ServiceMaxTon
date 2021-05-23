using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ServiceMaxTon.Model.Commands
{
    public class SetExpensesCommand : Command
    {
        public override string Name => "Расходы";

        public override void Execute(Message message, TelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}
