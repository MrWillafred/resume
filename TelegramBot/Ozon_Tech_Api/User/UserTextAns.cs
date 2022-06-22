using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using static Ozon_Tech_Api.Contexts.Contexts;

namespace Ozon_Tech_Api.Comand.Comands
{
    internal class UserTextAns : Comand
    {
        public override string[] Names { get; set; } = new string[] { "Добавить ответ" };

        public override async void Execute(Message message, TelegramBotClient client)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var user = db.User.ToList();
                foreach (User u in user)
                {
                    if (u.Studet_Code == message.From.Id)
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, $"Добавте текст ответа", replyMarkup: new ForceReplyMarkup { Selective = true });
                    }
                }
            }
        }
    }
}

