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
    public class SetServiceCommand : Command
    {
        public override string Name => "Услуга";

        public override string Description => $"Команда {Name} добавляет в таблицу выполненых услуг информацию о доходах от предоставления сторонних услуг " +
            $"(установка деталей, удаление винила, полировка)" +
            $"(аренда, интсрумент, свет т.д). Синтаксис:" +
            $"Услуга ТЕКСТ С Р\n" +
            $"ТЕКСТ - коментарий на что были расходованы средства\n" +
            $"C - сумма средств\n" +
            $"Р - расходы на предоставление услуги\n"+
            $"Пример:\n" +
            $"Услуга удаление винила 2500 200";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            string[] SplitData = message.Text.Split(' ');
                AppDbContext db = new AppDbContext();
            

            int tempIntIncome= 0;
            int tempIntCosts = 0;
            bool success = int.TryParse(SplitData[SplitData.Length-1], out tempIntCosts);

                if(success)
                {

                success= int.TryParse(SplitData[SplitData.Length - 2], out tempIntIncome);

                if (success)
                {
                    if(tempIntCosts< tempIntIncome)
                    {
                        Services services = new Services();
                        services.Costs = tempIntCosts;
                        services.Income = tempIntIncome;
                        services.Date = message.Date.AddHours(Settings.GMT);

                        SplitData[0] = "";
                        SplitData[SplitData.Length - 1] = "";
                        SplitData[SplitData.Length - 2] = "";
                        services.Name = "";
                        foreach (string s in SplitData)
                        {
                            services.Name += (s + " ");
                        }

                        db.Add(services);
                        db.SaveChanges();
                        await client.SendTextMessageAsync(message.Chat.Id, "Данные успешно добавлены в БД.");
                    }
                    else
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, "Расходы не могут быть больше доходов");
                    }

                }
                else
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "Не верный формат параметра прибыль");
                }

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
