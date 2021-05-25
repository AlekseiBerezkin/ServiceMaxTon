﻿using ServiceMaxTon.Data;
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
                //List<string> ListNameExpenses = SplitData.ToList();
                //ListNameExpenses.;

                    expenses.Name = SplitData[1];
                    db.Add(expenses);
                    db.SaveChanges();
                    await client.SendTextMessageAsync(message.Chat.Id, "Данные успешно добавлены в БД.");
                }
                else
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "Не верный формат параметра средства");
                }
            
        }
    }
}
