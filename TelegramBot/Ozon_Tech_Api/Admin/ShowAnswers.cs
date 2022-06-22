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
    internal class ShowAnswers : Comand
    {
        public override string[] Names { get; set; } = new string[] { $"Посмотреть статистику" };

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
                        var text = db.User.OrderBy(p => p.Surname).ToArray();
                        await client.SendTextMessageAsync(message.Chat.Id, "Укажите ID ользователя за которым шпионим:", replyMarkup: new ForceReplyMarkup { Selective = true });

                        foreach (var tx in text)
                        {
                            await client.SendTextMessageAsync(message.Chat.Id, $"User ID: {tx.Id}\nSurname: {tx.Surname}\nName: {tx.Name}");
                        }
                    }

                    else
                        await client.SendTextMessageAsync(message.Chat.Id, $"Команда не найдена)");
                }
            }
        }
    }
}


