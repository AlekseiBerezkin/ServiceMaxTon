using ServiceMaxTon.Data;
using ServiceMaxTon.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ServiceMaxTon.Model.Commands
{
    public class SetCommand : Command
    {
        public override string Name => "Записать";

        public override string Description => $"Команда {Name} предназначена для записи выполненых работ.Пример\n" +
            $"Синтаксис:{Name} % L C UV\n" +
            $"% - светопропускание пленки\n" +
            $"L - затраченная длинна\n" +
            $"C - Сумма средств, полученная в результате выполненой работы\n" +
            $"UV - производитель пленки";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            long chatId = message.Chat.Id;
            //Записать 5 1.5 2500 UV


            string[] SplitData = message.Text.Split(' ');
            //if(int.TryParse(SplitData[1])){}

            if (SplitData.Length == 5)
            {
            AppDbContext db = new AppDbContext();
            CompletedWork cw = new CompletedWork();
            int tempInt = 0;
            double tempDouble = 0;

            bool success = int.TryParse(SplitData[1], out tempInt);

            if (success)
            {
                cw.Transparency = tempInt;
                success = int.TryParse(SplitData[3], out tempInt);
                if (success)
                {
                    cw.Cash = tempInt;
                    success = double.TryParse(SplitData[2], out tempDouble);
                    if (success)
                    {
                        cw.Lenght = tempDouble;
                        cw.Date = message.Date.AddHours(Settings.GMT);
                        db.Add(cw);
                        db.SaveChanges();
                        await client.SendTextMessageAsync(chatId, "Данные записаны в БД");
                    }
                    else
                    {
                        success = double.TryParse(SplitData[2], NumberStyles.Any, CultureInfo.InvariantCulture, out tempDouble);
                        if (success)
                        {
                            cw.Lenght = tempDouble;
                            cw.Date = message.Date.AddHours(Settings.GMT);
                            cw.Manufacturer = SplitData[4];
                            db.Add(cw);
                            db.SaveChanges();
                            await client.SendTextMessageAsync(chatId, "Данные записаны в БД");
                        }
                        else
                        {

                            await client.SendTextMessageAsync(chatId, "Неверный формат параметра длиины пленки");
                        }

                    }
                }
                else
                {
                    await client.SendTextMessageAsync(chatId, "Неверный формат параметра денег");
                }

            }
            else
            {
                await client.SendTextMessageAsync(chatId, "Неверный формат параметра светопропускания");
            }
        }
            else
            {
                if(SplitData.Length==2)
                {
                    if(SplitData[1]=="?")
                    {
                        await client.SendTextMessageAsync(chatId, Description);
                    }
                    else
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, "Не верный формат команды");
                    }
                }
                else
                {
                    await client.SendTextMessageAsync(chatId, "Неверный формат команды");
                }
                
            }
        }
    }
}
