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
    internal class ReplyAnswers : Comand
    {
        public override string[] Names { get; set; } = new string[] { "Укажите ID ользователя за которым шпионим:" };

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
                        var text = db.User_Responses
                            .OrderBy(p => p.Id)
                            .Where(u => u.UserId == Convert.ToInt32(message.Text))
                            .ToArray();

                        await client.SendTextMessageAsync(message.Chat.Id, "Вот его ответы: ");

                        foreach (var tx in text)
                        {
                            await client.SendTextMessageAsync(message.Chat.Id, $"Responses ID: {tx.Id}\nFile: {tx.File}\nText: {tx.Text_Response}");
                        }
                    }

                    else
                        await client.SendTextMessageAsync(message.Chat.Id, $"Команда не найдена)");
                }
            }
        }
    }
}


