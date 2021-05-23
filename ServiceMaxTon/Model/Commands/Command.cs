using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ServiceMaxTon.Model.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract void Execute(Message message, TelegramBotClient client);

        public bool Contains(string command)
        {

            return command.Contains(this.Name);
        }

        public async Task CommandNotFound(string command, Message message,TelegramBotClient client)
        {
            await client.SendTextMessageAsync(message.Chat.Id, $"Команда {command} не определена.");
        }
    }
}
