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
    [Route("/")]
    public class BotController:ControllerBase
    {
        [HttpPost]
        public async Task <IActionResult> Post([FromBody] Update update)
        {
            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.Get();

            foreach(var command in commands)
            {
                if (true)
                {
                    command.Execute(message, client);
                    break;
                }
            }

            return Ok();

        }

    }
}
