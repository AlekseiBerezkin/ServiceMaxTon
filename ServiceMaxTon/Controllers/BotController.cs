using Microsoft.AspNetCore.Mvc;
using ServiceMaxTon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ServiceMaxTon.Controllers
{
    [ApiController]
    [Route("api/bot")]
    public class BotController:ControllerBase
    {

        public async Task <IActionResult> Post([FromBody] Update update)
        {
            TelegramBotClient client = new TelegramBotClient(Settings.Token);

            if(update.Type== Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                await client.SendTextMessageAsync(update.Message.From.Id, "answer");
            }

            return Ok();

        }
    }
}
