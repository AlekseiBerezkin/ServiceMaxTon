﻿using ServiceMaxTon.Data;
using ServiceMaxTon.Model.DataBase;

using Telegram.Bot;
using Telegram.Bot.Types;

namespace ServiceMaxTon.Model.Commands
{
    public class Get : Command
    {
        public override string Name => "Данные";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            AppDbContext db = new AppDbContext();
            //CompletedWork cw = new CompletedWork();
            string[] str = message.Text.Split();
            string strOut ="";
            if(str.Length==2)
            {
               switch(str[1])
                {
                    case "выполнено":
                        foreach (CompletedWork cw in db.CompletedWork)
                        {

                            strOut += $"ID:{cw.id}\n" +
                                $"Дата:{cw.Date.ToString("d")}\n" +
                                $"Процент:{cw.Transparency}\n" +
                                $"Длинна:{cw.Lenght}\n" +
                                $"Стоимость:{cw.Cash}р\n" +
                                $"\n";

                        }
                        break;
                    case "расходы":
                        foreach (Expenses expenses in db.Expenses)
                        {

                            strOut += $"ID:{expenses.id}\n" +
                                $"Дата:{expenses.Date.ToString("d")}\n" +
                                $"Затраты:{expenses.CashExpenses}р\n" +
                                $"Комментарий:{expenses.Name}\n" +
                                $"\n";

                        }
                        break;
                    default:
                        strOut = $"Команда {str[1]} не определена";
                        break;
                }
            }
            else
            {
                strOut = "Не верный формат запроса";
            }



            await client.SendTextMessageAsync(message.Chat.Id, strOut);
        }
    }
}
