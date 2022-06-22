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
    internal class Admin_Search : Comand
    {
        string KmText1 = "Настроить текст сообщения";
        string KmText2 = "Изменить контент для пользователя";
        string KmText3 = "Настроить тайминги";
        string KmText4 = "Посмотреть статистику";

        public override string[] Names { get; set; } = new string[] { "Админ" };

        public override async void Execute(Message message, TelegramBotClient client)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверка на администратора и вывод возможностей
                var users = db.User
                    .Include(u => u.Statuses)
                    .Where(u => u.Studet_Code == message.From.Id)
                    .ToList();

                foreach(var user in users)
                {
                    if (user.Statuses.Title == "Admin")
                        await client.SendTextMessageAsync(message.Chat.Id, $"Команды администратора:", replyMarkup: ButtonsToStart());

                    else
                        await client.SendTextMessageAsync(message.Chat.Id, $"Вы не админ)");
                }
            }
        }

        private IReplyMarkup ButtonsToStart()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = KmText1 } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = KmText2 } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = KmText3 } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = KmText4 } }
                }
            };
        }
    }
}
