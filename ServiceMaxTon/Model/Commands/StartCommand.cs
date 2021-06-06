using ServiceMaxTon.Data;
using ServiceMaxTon.Model.DataBase;
using ServiceMaxTon.Model.Feature;
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
        public override string Name => "/start";

        public override string Description => $"Hello,это бот предоставляющий контроль средсв и материала для мастерской MaxTon." +
            $"Список доступных комманд:" +
            $"{GetCommand()}\n" +
            $"Для получения синтаксиса и примеров наберите команду и через пробел ?. Пример:\n" +
            $"Запись ?";

        private string GetCommand()
        {
            string s = "";
            var commands = Bot.Commands;
            foreach (var command in commands)
            {
                s += "\n"+command.Name;
            }

                return s;
        }

        public override async void Execute(Message message, TelegramBotClient client)
        {
            long chatId = message.Chat.Id;

            await client.SendTextMessageAsync(chatId,Description);
            Alert.AlertStop();

            //DateTime a =message.Date;


        }

    }
}
