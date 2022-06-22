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
    internal class ReplyTime : Comand
    {
        public override string[] Names { get; set; } = new string[] { "Введите ID времени для изменения:" };

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
                        DataBase.timeID = Convert.ToInt32(message.Text);

                        var text = db.Message_Text.ToArray();
                        await client.SendTextMessageAsync(message.Chat.Id, "На какое время меняем?", replyMarkup: new ForceReplyMarkup { Selective = true });
                        await client.SendTextMessageAsync(message.Chat.Id, "Введите дату в формате: 2022-05-18 12:00");
                    }

                    else
                        await client.SendTextMessageAsync(message.Chat.Id, $"Команда не найдена)");
                }
            }
        }
    }
}

