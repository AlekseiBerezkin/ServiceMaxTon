using System;
using System.Threading;
using Telegram.Bot;

namespace ServiceMaxTon.Model.Feature
{
    public static class Alert
    {
        //private Timer timer = new Timer();
        private static TimerCallback timeCB;
        private static Timer time;
        public static void AlertStart(long chatId, TelegramBotClient client,int hours,int minets)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            dt = dt.AddSeconds(5);
            timeCB = new TimerCallback(OnTimedEvent);
            time = new Timer(timeCB, null,dt-DateTime.Now, TimeSpan.FromSeconds(10));
            //time.Change(Timeout.Infinite,Timeout.Infinite);

            thischatId = chatId;
            thisclient = client;

        }

        public static void  AlertStop()
        {
            time.Dispose();
        }

        private static TelegramBotClient thisclient { get; set; }
        private static long thischatId { get; set; }

        private static async void OnTimedEvent(object state)
        {
            await thisclient.SendTextMessageAsync(thischatId, DateTime.Now.ToString());
        }
    }
}
