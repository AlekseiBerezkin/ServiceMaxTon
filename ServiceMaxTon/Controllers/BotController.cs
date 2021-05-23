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
            bool flagCommand = false;
            
            foreach(var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    command.Execute(message, client);
                    flagCommand = true;
                    break;
                }
                if (command==commands[commands.Count-1] && flagCommand==false)
                {
                    await command.CommandNotFound(message.Text, message, client);
                }
                
            }


            return Ok();

        }

    }
}
