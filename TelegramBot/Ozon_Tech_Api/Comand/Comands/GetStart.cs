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
    internal class GetStart : Comand
    {
        public override string[] Names { get; set; } = new string[] { "/start", "help" };

        string KmText1 = "Пользователь";
        string KmText2 = "Админ";

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
                        await client.SendTextMessageAsync(message.Chat.Id, $"Вам доступно", replyMarkup: ButtonsToStart());
                    }
                }
            }
        }

        private IReplyMarkup ButtonsToStart()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{new KeyboardButton { Text = KmText1}, new KeyboardButton { Text = KmText2 } }
                }
            };
        }
    }
}
    