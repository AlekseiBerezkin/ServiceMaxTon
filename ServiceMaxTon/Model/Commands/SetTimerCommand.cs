using ServiceMaxTon.Model.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ServiceMaxTon.Model.Commands
{
    public class SetTimerCommand : Command
    {
        public override string Name => "Напоминание";

        public override string Description => throw new NotImplementedException();

        public async override void Execute(Message message, TelegramBotClient client)
        {
            string[] SplitData = message.Text.Split();

            if (SplitData.Length == 2)
            {
                SplitData = SplitData[2].Split(":");

                if(SplitData.Length == 2)
                {
                    int minets;
                    int hours;

                    if (int.TryParse(SplitData[0], out hours))
                    {
                        if (int.TryParse(SplitData[0], out minets))
                        {
                            Alert.AlertStart(message.Chat.Id, client, hours, minets);
                        }
                        else
                        {
                            await client.SendTextMessageAsync(message.Chat.Id, "Не верный формат минут");
                        }

                    }
                    else
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, "Не верный формат часов");
                    }


                }
                else
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "Не верный формат времени");
                }
                
            }
            else
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Не верный формат команды");
            }
                
            
        }
    }
}
