using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Telegram.Bot;

namespace ServiceMaxTon.Model.Feature
{
    public class Alert
    {
       private Timer timer = new Timer();

        public void timerStart(long chatId, TelegramBotClient client)
        {
            this.chatId = chatId;
            this.client = client;
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = 10000;
            timer.Enabled = true;


        }

        private TelegramBotClient client { get; set; }
        private long chatId { get; set; }


        //public 

        private async void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            await client.SendTextMessageAsync(chatId, "Данные успешно записаны в БД");
        }


    }
}
