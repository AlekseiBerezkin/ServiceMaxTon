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
    public class SetExpensesCommand : Command
    {
        public override string Name => "Расходы";

        public override string Description => $"Команда {Name} добавляет в таблицу расходы информацию о расходах(аренда, интсрумент, свет т.д). Синтаксис:" +
            $"Расходы ТЕКСТ С\n" +
            $"ТЕКСТ - коментарий на что были расходованы средства\n" +
            $"C - сумма средств\n" +
            $"Пример:\n" +
            $"Расходы приобретение инструмента 2500";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            string[] SplitData = message.Text.Split(' ');
                AppDbContext db = new AppDbContext();
                Expenses expenses = new Expenses();

            int tempInt = 0;
           
                bool success = int.TryParse(SplitData[SplitData.Length-1], out tempInt);

                if(success)
                {
                expenses.CashExpenses = tempInt;
                expenses.Date = message.Date.AddHours(Settings.GMT);

                SplitData[0] = "";
                SplitData[SplitData.Length - 1] = "";
                expenses.Name = "";
                foreach (string s in SplitData)
                {
                    expenses.Name+=(s+" ");
                }
                
                    db.Add(expenses);
                    db.SaveChanges();
                    await client.SendTextMessageAsync(message.Chat.Id, "Данные успешно добавлены в БД.");
                }
                else
                {
                if (SplitData.Length == 2)
                {
                    if(SplitData[1]=="?")
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, Description);
                    }
                    else
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, "Не верный формат команды");
                    }
                }
                else
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "Не верный формат параметра средства");
                }
                    
                }
            
        }
    }
}
