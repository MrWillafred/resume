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
    internal class TuneTimeReply : Comand
    {
        public override string[] Names { get; set; } = new string[] { "На какое время меняем?" };

        string KmText1 = "Настроить текст сообщения";
        string KmText2 = "Изменить контент для пользователя";
        string KmText3 = "Настроить тайминги";
        string KmText4 = "Посмотреть статистику";

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
                        //сюда бы изменение бд)))))))) из Program.cs

                        var customer = db.Reminder
                                .Where(c => c.Id == DataBase.timeID)
                                .FirstOrDefault();

                        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                        // Внести изменения
                        customer.Time = TimeZoneInfo.ConvertTimeToUtc(Convert.ToDateTime(message.Text));
                        Console.WriteLine(customer.Time);

                        // Сохранить изменения
                        db.SaveChanges();

                        await client.SendTextMessageAsync(message.Chat.Id, $"дело сделано...", replyMarkup: ButtonsToStart());
                    }

                    else
                        await client.SendTextMessageAsync(message.Chat.Id, $"Команда не найдена)");
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

