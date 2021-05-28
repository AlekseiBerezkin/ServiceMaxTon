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
    public class DeliteCommand : Command
    {
        public override string Name => "Удалить";

        public override string Description => $"Команда {Name} удалят из таблицы выполненных работ указанную позицию.Синтакси:\n" +
            $"Удалить ID\n" +
            $"Параметр ID это номер записи в таблице выполненных работ, который можно узнать набрав команду Данные Пример: \n" +
            $"Удалить 44";
        public override async void Execute(Message message, TelegramBotClient client)
        {
            string[] SplitData = message.Text.Split();

            if(SplitData.Length==2)
            {
                int id = 0;
                if (int.TryParse(SplitData[1],out id))
                {
                    AppDbContext db = new AppDbContext();

                    var delid = db.CompletedWork.SingleOrDefault(x => x.id == id);

                    if(delid!=null)
                    {
                        db.CompletedWork.Remove(delid);
                        db.SaveChanges();
                        await client.SendTextMessageAsync(message.Chat.Id, $"Запись с id={id} успешно удалена");
                    }
                    else
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, $"Запись с id {id} не найдена");
                    }
                }
                if (SplitData[1] == "?")
                {
                    await client.SendTextMessageAsync(message.Chat.Id, Description);
                }
                else
                {
                    await client.SendTextMessageAsync(message.Chat.Id, $"Не верный формат команды");
                }


            }
            else
            {

                await client.SendTextMessageAsync(message.Chat.Id, $"Не верный формат команды");
            }
        }
    }
}
