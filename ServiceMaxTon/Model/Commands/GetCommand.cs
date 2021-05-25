using ServiceMaxTon.Data;
using ServiceMaxTon.Model.DataBase;

using Telegram.Bot;
using Telegram.Bot.Types;

namespace ServiceMaxTon.Model.Commands
{
    public class GetCommand : Command
    {
        public override string Name => "Данные";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            AppDbContext db = new AppDbContext();
            //CompletedWork cw = new CompletedWork();
            string str = "";
            foreach(CompletedWork cw in db.CompletedWork)
            {

                str += $"ID:{cw.id}\n" +
                    $"Дата:{cw.Date.ToString("d")}\n" +
                    $"Процент:{cw.Transparency}\n" +
                    $"Длинна:{cw.Lenght}\n" +
                    $"Стоимость:{cw.Cash}\n" +
                    $"\n";
                
            }

            await client.SendTextMessageAsync(message.Chat.Id,str);
        }
    }
}
