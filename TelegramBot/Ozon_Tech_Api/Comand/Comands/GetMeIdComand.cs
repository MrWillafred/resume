using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Ozon_Tech_Api.Comand.Comands
{
    public class GetMeIdComand : Comand
    {
        public override string[] Names { get; set; } = new string[] { "Получить мой ID" };

        public override async void Execute(Message message, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(message.Chat.Id, $"Ваш телеграмм ID: {message.From.Id}");
        }
    }
}
