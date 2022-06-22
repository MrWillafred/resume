using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using static Ozon_Tech_Api.Contexts.Contexts;


namespace Ozon_Tech_Api.Comand.Comands
{
    internal class Login : Comand
    {
        public override string[] Names { get; set; } = new string[] { "Войти"};

        public override async void Execute(Message message, TelegramBotClient client)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var user = db.User.ToList();
                Console.WriteLine("логинится челл");
                foreach (User u in user)
                {
                    if (u.Studet_Code == message.From.Id)
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, $"Вы успешно вошли в систему");
                    }
                }
            }
        }
    }
}
