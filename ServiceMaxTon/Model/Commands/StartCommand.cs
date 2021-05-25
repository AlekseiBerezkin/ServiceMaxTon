using ServiceMaxTon.Data;
using ServiceMaxTon.Model.DataBase;
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

            //DateTime a =message.Date;

            AppDbContext db = new AppDbContext();
            CompletedWork cw = new CompletedWork
            {
                Transparency = 5,
                Lenght = 1.5,
                Cash = 2500,
                Date = message.Date
                
            };

            db.Add(cw);

            db.SaveChanges();

           
            //db.Add
        }

    }
}
