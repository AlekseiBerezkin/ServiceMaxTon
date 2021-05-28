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
    public class SetResourceCommand : Command
    {
        public override string Name => "Пленка";

        public override string Description => "Команда Пленка добавляет в таблицу информацию о новой пленке, которая преобретена. Синтаксис:\n" +
            "Пленка % L C UV \n" +
            "%-светопропускание\n" +
            "L-длинна пленки\n" +
            "C-стоимость\n" +
            "UV-производитель\n" +
            "Пример:\n" +
            "Пленка 5 30 13400 UltraVision";

        //Пленка 5 30 13400 UV
        public override async void Execute(Message message, TelegramBotClient client)
        {
            string[] SplitData = message.Text.Split();
            
            if(SplitData.Length==5)
            {
                AppDbContext db = new AppDbContext();
                Material material = new Material();

                for(int i=1;i<SplitData.Length-1;i++)
                {
                    int parametr = 0;
                    if(int.TryParse(SplitData[i],out parametr))
                        {
                    switch(i)
                    {
                        case 1:
                                material.Transparency = parametr;
                            break;
                            case 2:
                                material.lenght = parametr;
                            break;
                        case 3:
                                material.cost = parametr;
                                material.Date = message.Date.AddHours(Settings.GMT);
                                material.manufacturer = SplitData[4];

                                db.Add(material);
                                db.SaveChanges();
                                await client.SendTextMessageAsync(message.Chat.Id, "Данные успешно записаны в БД");
                                break;
                    }
                        }
                    else
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, "Не верный параметр");
                        break;
                    }
                }



            }
            else
            {
                if (SplitData.Length == 2)
                {
                    if (SplitData[1] == "?")
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
