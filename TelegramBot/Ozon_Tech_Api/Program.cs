using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Linq;

using Ozon_Tech_Api.Comand.Comands;
using static Ozon_Tech_Api.Contexts.Contexts;
using Ozon_Tech_Api;
using System.Data.Common;
using Ozon_Tech_Api.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Telegram.Bot.Messages
{
    class Program
    {
        private static TelegramBotClient client;
        private static List<Ozon_Tech_Api.Comand.Comand> comands;

        static void Main(string[] args)
        {

            Config config = new Config();



            
            client = new TelegramBotClient(config.Token);
            comands = new List<Ozon_Tech_Api.Comand.Comand>();

            comands.Add(new GetMeIdComand());
            comands.Add(new GetStart());
            comands.Add(new Login());
            comands.Add(new Admin_Search());

            comands.Add(new ReplyTextID());
            comands.Add(new TuneTextReply());
            comands.Add(new TuneMessageText());

            comands.Add(new ReplyContent());
            comands.Add(new TuneMessageContent());
            comands.Add(new TuneContenReply());

            comands.Add(new TuneTiming());
            comands.Add(new ReplyTime());
            comands.Add(new TuneTimeReply());

            comands.Add(new ShowAnswers()); 
            comands.Add(new ReplyAnswers());

            comands.Add(new UserStart());
            comands.Add(new UserTextAns());
            comands.Add(new UserTextReply());
            comands.Add(new UserFileReply());

            var me = client.GetMeAsync().Result;

            Console.WriteLine($"BotId: {me.Id} \nBot_Name: {me.FirstName}");

            client.StartReceiving();

            client.OnMessage += Client_OnMessage;

            Console.ReadLine();
            client.StopReceiving();





        
        }
        private static async void Client_OnMessage(object? sender, Args.MessageEventArgs e)
        {
            var message = e.Message;

            if (message.Text != null)
            {
                Console.WriteLine($"Message Get from {message.From.LastName} c текстом: {message.Text}");

                foreach(var comm in comands)
                {
                    if (comm.Contains(message.Text))
                    {
                        comm.Execute(message, client); 
                    }
                }
            }

            if (message.ReplyToMessage != null)
            {
                Console.WriteLine($"Message Reply Get from {message.From.LastName} c текстом: {message.Text}");

                foreach (var comm in comands)
                {
                    if (comm.Contains(message.ReplyToMessage.Text))
                    {
                        comm.Execute(message, client);
                    }
                }
            }

        }
    }


}