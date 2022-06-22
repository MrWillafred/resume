using Microsoft.EntityFrameworkCore;
using Ozon_Tech_Api.Admin;
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
    internal class ReplyTextID : Comand
    {
        public override string[] Names { get; set; } = new string[] { "Введите ID текста для изменения:" };

        public override async void Execute(Message message, TelegramBotClient client)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверка на администратора
                var users = db.User
                    .Include(u => u.Statuses)
                    .Where(u => u.Studet_Code == message.From.Id)
                    .ToList();

                foreach (var user in users)
                {
                    if (user.Statuses.Title == "Admin")
                    {
                        DataBase.textID = Convert.ToInt32(message.Text);

                        var text = db.Message_Text.ToArray();
                        await client.SendTextMessageAsync(message.Chat.Id, "На что меняем текст сообщения?", replyMarkup: new ForceReplyMarkup { Selective = true });
                    }

                    else
                        await client.SendTextMessageAsync(message.Chat.Id, $"Команда не найдена)");
                }
            }
        }
    }
}
