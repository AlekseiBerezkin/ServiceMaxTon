﻿using ServiceMaxTon.Model.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ServiceMaxTon.Model
{
    static public class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commandsList;

        public static IReadOnlyList<Command> Commands { get => commandsList.AsReadOnly(); }

        static public async Task<TelegramBotClient> Get()
        {
            if(client!=null)
            {
                return client;
            }

            commandsList = new List<Command>();
            commandsList.Add(new StartCommand());
            client = new TelegramBotClient(Settings.Token);

            await client.SetWebhookAsync(Settings.Url);

            return client;        }

    }
}