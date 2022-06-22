using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using static Ozon_Tech_Api.Contexts.Contexts;
using Ozon_Tech_Api.Admin;
using Ozon_Tech_Api.Tables;

namespace Ozon_Tech_Api.Comand.Comands
{
    internal class UserFileReply : Comand
    {
        public override string[] Names { get; set; } = new string[] { "Добавте файл ответа" };

        public override async void Execute(Telegram.Bot.Types.Message message, TelegramBotClient client)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var user = db.User.ToList();
                foreach (User u in user)
                {
                    if (u.Studet_Code == message.From.Id)
                    {
                        int answerId = db.User_Responses.Count();
                        answerId++;

                        string textAns = DataBase.userTextReply;

                        string fileAns = message.Text;

                        User_Responses resp = new User_Responses
                        {
                            Id = answerId,
                            File = fileAns,
                            Text_Response = textAns,
                            UserId = db.User
                                .Where(c => c.Studet_Code == message.From.Id)
                                .Select(c => c.Id)
                                .Single()
                        };

                        db.User_Responses.Add(resp);

                        db.SaveChanges();

                        await client.SendTextMessageAsync(message.Chat.Id, $"Ответ добавлен!)");
                    }
                }
            }
        }
    }
}


