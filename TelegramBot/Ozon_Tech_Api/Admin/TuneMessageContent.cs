using Microsoft.EntityFrameworkCore;
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
    internal class TuneMessageContent : Comand
    {
        public override string[] Names { get; set; } = new string[] { $"Изменить контент для пользователя" };

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
                        var text = db.File_To_Send.OrderBy(p => p.Id).ToArray();
                        await client.SendTextMessageAsync(message.Chat.Id, "Введите ID контента для изменения:", replyMarkup: new ForceReplyMarkup { Selective = true });

                        foreach (var tx in text)
                        {
                            await client.SendTextMessageAsync(message.Chat.Id, $"Content ID: {tx.Id}\nText: {tx.File}\nOrder ID: {tx.Send_OrderId}");
                        }
                    }

                    else
                        await client.SendTextMessageAsync(message.Chat.Id, $"Команда не найдена)");
                }
            }
        }
    }
}

